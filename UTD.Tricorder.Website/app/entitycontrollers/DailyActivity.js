

entityControllerFactory.create("DailyActivity", "FitActivityForm", function ($scope, sParams) {

    BaseControllers.AddEditFormServices($scope, sParams);
    var fitActivityService = EntityService.create("FitActivity", sParams.$http, sParams.ngAuthSettings);
    var personService = EntityService.create("Person", sParams.$http, sParams.ngAuthSettings);

    // model for calorie calculator
    $scope.uimodel = {
        gender: "male", // from person entity
        age: 0, // from person entity
        hours: 0,
        minutes: 0,
        seconds: 0,
        height: 0, // cm
        weight: 0,
        weightunits: "pounds",
        mets: 0
    };

    $scope.init = function () {
        $scope.ViewNewForm(); // insert form
        fitActivityService.ExecInline("GetAllData", null,
            function (e) {
                $scope.fitActivityData = e.response.data;
                sParams.$window.LoadComboBox("ExternalEntityID", $scope.fitActivityData, "");
            });

        personService.GetByID({
                id: $scope.CurrentUserID,
                successFn: function (e) {
                    var person = e.response.data;
                    if (person.GenderTypeID === 0)
                        $scope.uimodel.gender = "male";
                    else
                        $scope.uimodel.gender = "female";

                    $scope.uimodel.age = new Date().getFullYear() - new Date(person.Birthday).getFullYear();
                }
        });
        $scope.model.RecordDateTime = new Date();
    }

    $scope.$watch("model.ExternalEntityID", function () {
        if ($scope.model.ExternalEntityID) {
            var list = $scope.fitActivityData;
            for (var i = 0; i < list.length; i++) {
                if (Number($scope.model.ExternalEntityID) === Number(list[i]["FitActivityID"])) {
                    $scope.uimodel.mets = list[i].FitActivityMET;
                    $scope.model.DailyActivityTitle = list[i].FitActivityTitle;
                }
            }
        }
        else
            $scope.uimodel.mets = 0;
    });

    $scope.$watch(
        function() {
            return angular.toJson($scope.uimodel);
        }
        , function (newValues, oldValues, scope) {
            $scope.CalculateGrossCalorie();
        }, true);


    $scope.onBeforeInsert = function () {
        $scope.model.UserID = $scope.CurrentUserID;
        //$scope.model.RecordDateTime = new Date();
        $scope.model.DailyActivityTypeID = 8; // Physical Activity
        $scope.model.IsManualEntry = true;
        $scope.model.Calorie = -1 * $scope.calculatedCalorie;
        $scope.model.DurationSeconds = ($scope.uimodel.hours * 3600) + ($scope.uimodel.minutes * 60) + $scope.uimodel.seconds;
    }

    $scope.onSuccessInsert = function () {
        $scope.GotoView("DailyActivityChart-CalorieChart");
    }

    // gender = male or female
    // age = 8 - 99
    // weight (number) (in lbs or kg, just specify in )
    // weightunits = kilograms or pounds
    // height in inches (not centimeters)
    // minutes
    // seconds
    // mets

    $scope.CalculateGrossCalorie = function () {

        var gender = $scope.uimodel.gender;
        var age = $scope.uimodel.age;
        var weight = $scope.uimodel.weight;
        var weightunits = $scope.uimodel.weightunits;
        var height = $scope.uimodel.height;
        var hours = $scope.uimodel.hours;
        var minutes = $scope.uimodel.minutes;
        var seconds = $scope.uimodel.seconds;
        var mets = $scope.uimodel.mets;

        var kilogramweight = 0;
        var bmr = 0;
        var time = 0;
        var caloricexpenditure = 0;

        age = Number(age);
        weight = Number(weight);
        hours = Number(hours);
        minutes = Number(minutes);
        seconds = Number(seconds);
        bmr = Number(bmr);
        mets = Number(mets);

        if (age == null || age === "" || weight == null || weight === "" || isNaN(age) === true || age < 1 || isNaN(weight) === true || weight < 1 || minutes == null || seconds == null || seconds > 59 || isNaN(minutes) === true || minutes < 0 || isNaN(seconds) === true || seconds < 0) {
            return 0;
        }

        if (weightunits === "kilograms") {
            kilogramweight = weight;
        }
        else if (weightunits === "pounds") {
            kilogramweight = 0.4536 * weight;
        }

        if (gender === "male") {
            bmr = (13.75 * kilogramweight) + (5 * height) - (6.76 * age) + 66;
        }
        else if (gender === "female") {
            bmr = (9.56 * kilogramweight) + (1.85 * height) - (4.68 * age) + 655;
        }

        time = hours + ((minutes + (seconds / 60)) / (60));

        caloricexpenditure = Math.round((bmr / 24) * time * mets);

        $scope.calculatedCalorie = caloricexpenditure;
        return caloricexpenditure;
    }


});




entityControllerFactory.create("DailyActivity", "SleepForm", function ($scope, sParams) {

    BaseControllers.AddEditFormServices($scope, sParams);

    // model for calorie calculator
    $scope.uimodel = {
        hours: 0,
        minutes: 0,
        seconds: 0
    };

    $scope.onBeforeInsert = function () {
        $scope.model.UserID = $scope.CurrentUserID;
        //$scope.model.RecordDateTime = new Date();
        $scope.model.DailyActivityTypeID = 7; // Sleep
        $scope.model.IsManualEntry = true;
        $scope.model.Calorie = 0;
        $scope.model.DurationSeconds = ($scope.uimodel.hours * 3600) + ($scope.uimodel.minutes * 60) + $scope.uimodel.seconds;
    }

    $scope.onSuccessInsert = function () {
        $scope.GotoView("DailyActivityChart-CalorieChart");
    }


});