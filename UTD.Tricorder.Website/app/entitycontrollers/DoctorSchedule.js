/// <reference path="entityController.js" />
// ----------------------------- Doctor Schedule ---------------------------------
BaseControllers.DoctorScheduleAddServices = function ($scope, sParams) {

    // inherit all functions from DoctorSchedule
    $scope.GotoOffset = function (days) {
        var newUnixEpoch = $scope.SelectedDayUnixEpoch + (days * 86400);
        $scope.SetSelectedEpoch(newUnixEpoch);
    };

    $scope.GotoToday = function () {
        $scope.SetSelectedEpoch($scope.GetUnixEpoch(moment().format('YYYY/MM/DD')));
    };

    $scope.SetSelectedEpoch = function (unixEpoch) {
        //if ($scope.SelectedDayUnixEpoch != unixEpoch) // if it was a new selection
        //{ // we would like to refresh it anytime because of inheritance in WeekView form
        $scope.SelectedDayUnixEpoch = unixEpoch;
        var newDateString = moment.unix($scope.SelectedDayUnixEpoch).format('YYYY/MM/DD');
        if ($scope.SelectedDateString !== newDateString) // we don't want to re-set DateString because it causes SetSelectedEpoch to be called again. 
        {
            $scope.SelectedDateString = newDateString;
        }
        else
            $scope.RefreshList();

        //}
    };

    $scope.GetUnixEpoch = function (stringDate) {
        return new Date(stringDate).getTime() / 1000;
    };

    $scope.$watch('SelectedDateString', function () {
        if ($scope.SelectedDateString !== undefined)
            $scope.SetSelectedEpoch($scope.GetUnixEpoch($scope.SelectedDateString));
    });

}


// ----------------------------- CalendarEdit  ---------------------------------

entityControllerFactory.create("DoctorSchedule", "CalendarEdit", function ($scope, sParams) {

    BaseControllers.DoctorScheduleAddServices($scope, sParams);

    $scope.msgs.selectedItemsListIsEmpty = "There is no time selected in this date";

    $scope.DoctorID = $scope.CurrentUserID;

    $scope.ViewNeedsParams = { DoctorID: "" + $scope.DoctorID };
    $scope.CheckViewNeeds();

    $scope.RefreshList = function () {
        var p = {};

        var doctorId = $scope.DoctorID;
        var startDateUnixEpoch = $scope.SelectedDayUnixEpoch;
        var endDateUnixEpoch = startDateUnixEpoch + 86400; // + one day seconds

        p.getParameters = {
            "Filter": {
                "FiltersList":
                    [{ "ColumnName": "DoctorID", "Value": doctorId },
                     { "ColumnName": "SlotUnixEpoch", "Operator": "GreaterThanOrEqualTo", "Value": startDateUnixEpoch },
                     { "ColumnName": "SlotUnixEpoch", "Operator": "LessThan", "Value": endDateUnixEpoch }
                    ]
            },
            "Sort": { "SortInfoList": [{ "ColumnName": "SlotUnixEpoch" }] },
            "PageIndex": 0,
            "PageSize": 100,
            "SourceType": 1
        };


        $scope.ResetAllButtons();

        p.successFn = function (e) {
            $scope.itemsList = e.response.data;
            var startDateUnixEpoch = $scope.SelectedDayUnixEpoch;
            // changing the appearance of buttons
            for (var i = 0; i < $scope.itemsList.length; i++) {
                var item = $scope.itemsList[i];
                var seconds = item.SlotUnixEpoch - startDateUnixEpoch;
                var btn = sParams.$window.$('#btnTime' + seconds).first();
                if (btn) {
                    btn.attr("title", item.NumberOfRegisteredPatients + "/"
                             + item.NumberOfAllowedPatients +
                        ", " + item.VisitPlaceTitle);

                    //btn.html(btn.attr("data-timestring") +
                    //    " (" + item.NumberOfRegisteredPatients + "/"
                    //         + item.NumberOfAllowedPatients +
                    //    ", " + item.VisitPlaceTitle +
                    //    ")");
                    if (!btn.hasClass('active')) {
                        btn.addClass('active');
                    }
                }
            }

        }
        $scope.service.Get(p);
    }


    $scope.ResetAButton = function (btn) {
        btn.text(btn.attr("data-timestring"));
        if (btn.hasClass('active')) {
            btn.removeClass('active');
        }
    }

    // resets all buttons to its original states
    $scope.ResetAllButtons = function () {
        $("[id^='btnTime'").each(function (index) {
            var btn = $(this);
            $scope.ResetAButton(btn);
        });
    }

    $scope.FindItemIndexBySeconds = function (seconds) {
        var startDateUnixEpoch = $scope.SelectedDayUnixEpoch;

        for (var i = 0; i < $scope.itemsList.length; i++) {
            var item = $scope.itemsList[i];
            if (item.SlotUnixEpoch - startDateUnixEpoch === Number(seconds))
                return i;
        }
        return null;
    }

    $scope.ShowSelectedDialog = function (seconds) {
        var itemIndex = $scope.FindItemIndexBySeconds(seconds);
        var item = $scope.itemsList[itemIndex];

        if (item != null) {
            $scope.DoctorScheduleFormDialogController.ShowDialog({ DoctorScheduleID: item.DoctorScheduleID });
        }
        else {
            var showForm = true;
            // trying to insert new item based on the previously saved item
            var model = $scope.DoctorScheduleFormDialogController.model;
            delete model.DoctorScheduleID; //make sure it doesn't update a slot mistakenly
            model.SlotUnixEpoch = $scope.SelectedDayUnixEpoch + Number(seconds);
            model.DoctorID = $scope.DoctorID;
            if (model.NumberOfAllowedPatients)
                if (model.DoctorScheduleVisitPlaceID) {
                    showForm = false;
                    $scope.CallService({
                        sName: 'Insert', data: model, successFn: function (e) {
                            $scope.RefreshList();
                        }
                    });
                }
            if (showForm)
            {
                $scope.DoctorScheduleFormDialogController.ShowDialog({ model: model });
            }
        }


    }

    $scope.onSuccessInsert = function () {
        $scope.RefreshList();
    }


    $scope.DeleteDay = function () {

        $scope.Confirm("Are you sure that you want to delete all available times of this day?", function () {
            var startUnixEpoch = $scope.SelectedDayUnixEpoch;
            var p = {
                sName: "Exec",
                methodName: "DeleteRange",
                data: {
                    DoctorID: $scope.DoctorID,
                    StartUnixEpoch: startUnixEpoch,
                    EndUnixEpoch: startUnixEpoch + 86400
                },
                successFn: function (e) {
                    $scope.RefreshList();
                }
            };
            $scope.CallService(p);
        });
    };


    // initializing parameters
    $scope.init = function () {
        $scope.GotoToday();
    }

    //$scope.SelectedNumberOfDays = "1";
});

// ----------------------------- FormDialog  ---------------------------------

entityControllerFactory.create("DoctorSchedule", "FormDialog", function ($scope, sParams) {
    BaseControllers.AddDialogFunction($scope, sParams);
    BaseControllers.AddFormServices($scope, sParams);

    $scope.OnLoadDialog = function (dialogParams) {
        $scope.View(dialogParams.DoctorScheduleID);
        if (dialogParams.model)
            $scope.model = dialogParams.model;
    }

    $scope.onSuccessDelete = function () {
        $scope.CloseDialog(true);
    }

    $scope.onSuccessInsert = function () {
        $scope.CloseDialog(true);
    }

    $scope.onSuccessUpdate = function () {
        $scope.CloseDialog(true);
    }

});

// ----------------------------- CopyDialog  ---------------------------------

entityControllerFactory.create("DoctorSchedule", "CopyRangeDialog", function ($scope, sParams) {

    BaseControllers.AddDialogFunction($scope, sParams, "copyRangeDialog");

    $scope.View = function (dialogParams) {
        $scope.SelectedDayUnixEpoch = dialogParams;

    }

    // copies data from some other days to the selected day (range)
    $scope.CopyRange = function () {

        if (!$scope.SelectedNumberOfDays) // default value for number of days is one
            $scope.SelectedNumberOfDays = "1";

        if ($scope.IsFormValid()) {

            var p = {
                methodName: "CopyRange",
                data: {
                    DoctorID: $scope.CurrentUserID,
                    SourceUnixEpoch: Date.parse($scope.SelectedDateForCopyString) / 1000,
                    DestinationUnixEpoch: $scope.SelectedDayUnixEpoch,
                    NumberOfDays: Number($scope.SelectedNumberOfDays)
                }
            };

            $scope.Exec(p);
        }
    };

    $scope.GenerateCopyDescription = function () {
        if ($scope.SelectedDateForCopyString) {
            var tmp = "Copy from " + moment.unix($scope.GetUnixEpoch($scope.SelectedDateForCopyString)).format('MMMM Do YYYY, dddd');
            tmp += "\rto " + moment.unix($scope.SelectedDayUnixEpoch).format('MMMM Do YYYY, dddd');
            tmp += "\rfor " + $scope.SelectedNumberOfDays + " days";
            $scope.CopyRangeDescription = tmp;
        }
    }

    $scope.$watch('SelectedDateForCopyString', function () {
        $scope.GenerateCopyDescription();
    });

    $scope.$watch('SelectedNumberOfDays', function () {
        $scope.GenerateCopyDescription();
    });


    $scope.onSuccessCopyRange = function () {
        $scope.CloseDialog(true);
    }

});





// ----------------------------- WeekSelect  ---------------------------------

entityControllerFactory.create("DoctorSchedule", "WeekSelect", function ($scope, sParams) {

    // inherit all functions from DoctorSchedule
    BaseControllers.DoctorScheduleAddServices($scope, sParams)

    $scope.NumebrOfDays = 7;
    if (sParams.$routeParams.DoctorID)
        $scope.DoctorID = sParams.$routeParams.DoctorID;
    else
        $scope.DoctorID = $scope.CurrentUserID;

    // overrides refresh list in the parent
    $scope.RefreshList = function () {
        var p = {
            methodName: "GetByRange",
            data: {
                DoctorID: $scope.DoctorID,
                StartUnixEpoch: $scope.SelectedDayUnixEpoch,
                EndUnixEpoch: $scope.SelectedDayUnixEpoch + $scope.NumebrOfDays * 86400
            }
            , successFn: function (e) {
                var numberOfDaysToShow = 7;
                $scope.itemsList = e.response.data;
                //clearing all item lists
                $scope.itemsListS = [];
                var i;
                for (i = 0; i < numberOfDaysToShow; i++) {
                    var label = moment.unix($scope.SelectedDayUnixEpoch + (i * 86400)).format('MMMM/DD/YYYY, dddd');
                    $scope.itemsListS[i] = { dayLabel: label, items: [] };
                }


                // separating items day by day
                var day = 0;
                for (i = 0; i < $scope.itemsList.length; i++) {
                    var item = $scope.itemsList[i];
                    if (item.SlotUnixEpoch > $scope.SelectedDayUnixEpoch + (day + 1) * 86400)
                        day++;
                    item.AvailableDateTimeLocal = $scope.GetFormattedFromUnixEpoch(item.SlotUnixEpoch);
                    $scope.itemsListS[day].items.push(item);
                }
            }
        };

        $scope.service.Exec(p);
    }

    $scope.GetFormattedFromUnixEpoch = function (unixEpoch) {
        return moment.unix(unixEpoch).format("h:mm a");
    }

    // initializing parameters
    $scope.init = function () {
        $scope.GotoToday();
    }


});