/// <reference path="entityController.js" />
// ----------------------------- Visit ---------------------------------

BaseControllers.VisitAddServices = function ($scope, sParams) {

    $scope.CancelVisit = function (visit) {
        $scope.Confirm("Are you sure that you want to cancel this appointment? If you cancel it, you need to book a new appointment, and you may not be able to schedule at the same time.", function ()
        {
            $scope.Exec(
                {
                methodName: "CancelVisit",
                data: visit.VisitID
            });
        });
    }

    $scope.onSuccessCancel = function (p) {
        $scope.RefreshList();
    }


}

// ----------------------------- GridForDoctor ---------------------------------

entityControllerFactory.create("Visit", "GridForDoctor", function ($scope, sParams) {
    BaseControllers.AddGridFunctions($scope, sParams);
    BaseControllers.VisitAddServices($scope, sParams);

    $scope.msgs.selectedItemsListIsEmpty = "There is no appointment in your list. You can book an appointment using 'Book new appointment button'";

    $scope.ListFilter = {
        "FiltersList":
        [
            { "ColumnName": "DoctorID", "Value": $scope.CurrentUserID }
        ]
    };

});

// ----------------------------- GridForPatient ---------------------------------

entityControllerFactory.create("Visit", "GridForPatient", function ($scope, sParams) {
    BaseControllers.AddGridFunctions($scope, sParams);
    BaseControllers.VisitAddServices($scope, sParams);

    $scope.msgs.selectedItemsListIsEmpty = "There is no appointment in your list. You can book an appointment using 'Book new appointment button'";

    $scope.ListFilter = {
        "FiltersList":
        [
            { "ColumnName": "PatientUserID", "Value": $scope.CurrentUserID }
        ]
    };

    $scope.ShowPaymentDialog = function (visitId) {
        $scope.GotoView("Payment-SentGrid");
    };

});

// ----------------------------- RescheduleDialog ---------------------------------

//entityControllerFactory.create("Visit", "RescheduleDialog", function ($scope, sParams) {
//    BaseControllers.AddDialogFunction($scope, sParams);

//    $scope.OnLoadDialog = function (params) {
//        $scope.NewDoctorSchedule = {};
//        $scope.RescheduleToText = "";
//        $scope.RescheduleFromText = $scope.FormatDateTimeUnix(params.SlotUnixEpoch);
//    }

//    $scope.ReSchedule = function () {
//        if ($scope.IsFormValid()) {
//            $scope.Exec({
//                methodName: "RescheduleVisit",
//                data: {
//                    VisitID: $scope.DialogParams.VisitID,
//                    NewDoctorScheduleID: $scope.NewDoctorSchedule.DoctorScheduleID
//                }
//            });
//        }
//    }

//    $scope.onSuccessRescheduleVisit = function (p) {
//        $scope.CloseDialog(true);
//    }

//    $scope.DoctorScheduleSelected = function (doctorSchedule) {
//        $scope.NewDoctorSchedule = doctorSchedule;
//        $scope.RescheduleToText = $scope.FormatDateTimeUnix($scope.NewDoctorSchedule.SlotUnixEpoch);
//    }

//});

// ----------------------------- RescheduleDialog ---------------------------------

entityControllerFactory.create("Visit", "RescheduleForm", function ($scope, sParams) {

    BaseControllers.AddFormServices($scope, sParams);

    $scope.init = function () {
        if (!$scope.MasterID)
            throw "MasterID is not provided";

        $scope.View($scope.MasterID);
        $scope.NewDoctorSchedule = {};
        $scope.RescheduleToText = "";
    }

    
    $scope.ReSchedule = function () {
        if ($scope.IsFormValid()) {
            $scope.Exec({
                methodName: "RescheduleVisit",
                data: {
                    VisitID: $scope.MasterID,
                    NewDoctorScheduleID: $scope.NewDoctorSchedule.DoctorScheduleID
                }
            });
        }
    }

    $scope.onSuccessRescheduleVisit = function (p) {
        $scope.GoBack();
    }

    $scope.DoctorScheduleSelected = function (doctorSchedule) {
        $scope.NewDoctorSchedule = doctorSchedule;
        $scope.RescheduleToText = $scope.FormatDateTimeUnix($scope.NewDoctorSchedule.SlotUnixEpoch);
    }

});

// ----------------------------- BookForPatientWizard ---------------------------------

entityControllerFactory.create("Visit", "BookForPatientWizard", function ($scope, sParams) {

    BaseControllers.AddFormServices($scope, sParams);
    $scope.ViewNeedsParams = { PatientID: "" + $scope.CurrentUserID };
    $scope.CheckViewNeeds();

    $scope.init = function () {
        sParams.$window.SetupWizard();
        $scope.ViewNewForm();
        $scope.model.PatientUserID = $scope.CurrentUserID;
        if (sParams.$routeParams.DoctorID)
            $scope.DoctorSelected(sParams.$routeParams.DoctorID, sParams.$routeParams.DoctorFullName)
    }

    $scope.DoctorSelected = function (doctorId, doctorFullName) {
        $scope.model.DoctorID = doctorId;
        $scope.SelectedDoctorFullName = doctorFullName;
        if ($scope.DoctorScheduleWeekSelectController) {
            $scope.DoctorScheduleWeekSelectController.DoctorID = $scope.model.DoctorID;
            $scope.DoctorScheduleWeekSelectController.RefreshList();
        }
        setTimeout(function () { sParams.$window.WizardGotoNextPage(); }, 100);
    }

    $scope.DoctorScheduleSelected = function (doctorSchedule) {
        $scope.model.DoctorScheduleID = doctorSchedule.DoctorScheduleID;
        $scope.SelectedScheduleTime = $scope.FormatDateTimeUnix(doctorSchedule.SlotUnixEpoch);
        setTimeout(function () { sParams.$window.WizardGotoNextPage(); }, 100);
    }

    $scope.onSuccessInsert = function () {
        $scope.GotoView("Visit-MyVisitsPatient");
    }


});

// ----------------------------- BookForDoctorWizard ---------------------------------

entityControllerFactory.create("Visit", "BookForDoctorWizard", function ($scope, sParams) {

    BaseControllers.AddFormServices($scope, sParams);
    $scope.ViewNeedsParams = { DoctorID: "" + $scope.CurrentUserID };
    $scope.CheckViewNeeds();

    $scope.init = function () {
        sParams.$window.SetupWizard();
        $scope.ViewNewForm();
        $scope.model.DoctorID = $scope.CurrentUserID;
    }

    $scope.PatientSelected = function (patientId, patientFullName) {
        $scope.model.PatientUserID = patientId;
        $scope.SelectedPatientFullName = patientFullName;
        $scope.DoctorScheduleWeekSelectController.DoctorID = $scope.model.DoctorID;
        $scope.DoctorScheduleWeekSelectController.RefreshList();
        setTimeout(function () { sParams.$window.WizardGotoNextPage(); }, 100);
    }

    $scope.DoctorScheduleSelected = function (doctorSchedule) {
        $scope.model.DoctorScheduleID = doctorSchedule.DoctorScheduleID;
        $scope.SelectedScheduleTime = $scope.FormatDateTimeUnix(doctorSchedule.SlotUnixEpoch);
        setTimeout(function () { sParams.$window.WizardGotoNextPage(); }, 100);
    }

    $scope.onSuccessInsert = function () {
        $scope.GotoView("Visit-MyVisitsDoctor");
    }


});

// --------------------------- Visit InfoDetail ---------------------------//

entityControllerFactory.create("Visit", "InfoDetail", function ($scope, sParams) {

    BaseControllers.VisitAddServices($scope, sParams);
    BaseControllers.AddViewPageFunctions($scope, sParams);

    $scope.init = function () {
        $scope.View($scope.MasterID);
    }

    $scope.onSuccessExec = function () {
        $scope.View($scope.MasterID);
    }

});

// --------------------------- Visit DetailsTab ---------------------------//

entityControllerFactory.create("Visit", "DetailsTab", function ($scope, sParams) {

});

// --------------------------- Visit DoctorReportForm ---------------------------//

entityControllerFactory.create("Visit", "DoctorReportForm", function ($scope, sParams) {
    BaseControllers.AddFormServices($scope, sParams);

    if ($scope.MasterID)
        $scope.VisitID = $scope.MasterID;
    else
        throw "MasterID is not provided for viewing the information";

    $scope.init = function () {
        $scope.View($scope.VisitID)
    }

});

// --------------------------- VisitSysReviewFrm ---------------------------//

entityControllerFactory.create("Visit", "SysReview", function ($scope, sParams) {

    $scope.SectionName = "SysReview";

    $scope.init = function () {
        if ($scope.MasterID)
            $scope.VisitID = $scope.MasterID;
        else
            throw "MasterID is not provided for viewing the information";
        $scope.View();
    }

    $scope.View = function () {
        $scope.Exec({
            methodName: 'GetSectionValues',
            data: {
                SectionName: $scope.SectionName,
                VisitID: $scope.VisitID
            },
            successFn: function (e) {
                if (e.response.data != null)
                    $scope.model[$scope.SectionName] = e.response.data;
            }
        });
    }

    $scope.Save = function ($event) {
        if ($scope.IsFormValid()) {
            $scope.Exec({
                methodName: 'SaveSection',
                data: {
                    SectionName: $scope.SectionName,
                    SectionValuesJson: JSON.stringify($scope.model[$scope.SectionName]),
                    VisitID: $scope.VisitID
                }
            });
        }
    }

});

// ---------------------------- Today's appointments -----------------------------

entityControllerFactory.create("Visit", "TodaysAppointments", function ($scope, sParams) {

    entityControllerFactory.InheritFns.VisitGridForDoctor($scope, sParams);
    BaseControllers.DoctorScheduleAddServices($scope, sParams);

    $scope.msgs.selectedItemsListIsEmpty = "There is no appointment for the selected date.";

    var baseRefreshList = $scope.RefreshList;
    $scope.RefreshList = function() {
        var startDateUnixEpoch = $scope.SelectedDayUnixEpoch;
        var endDateUnixEpoch = startDateUnixEpoch + 86400; // + one day seconds

        $scope.ListFilter = {
            "FiltersList":
            [
                { "ColumnName": "DoctorID", "Value": $scope.CurrentUserID },
                { "ColumnName": "SlotUnixEpoch", "Operator": "GreaterThanOrEqualTo", "Value": startDateUnixEpoch },
                { "ColumnName": "SlotUnixEpoch", "Operator": "LessThan", "Value": endDateUnixEpoch }
            ]
        };

        baseRefreshList();
    };


    $scope.init = function () {
        $scope.GotoToday();
    }

});

// ---------------------------- Attachments -----------------------------

entityControllerFactory.create("Visit", "Attachments", function ($scope, sParams) {
    $scope.AppFileTypeID = 1002; // Visit attachment
    $scope.FileUploadSuccess = function (file) {
        var doRefresh = false;
        if (!$scope.WaitForRefresh)
            doRefresh = true;

        if (doRefresh) {
            $scope.WaitForRefresh = setTimeout(function () {
                $scope.AppFileGridController.RefreshList();
                $scope.WaitForRefresh = null;
            }, 1000);
        }
    }
});