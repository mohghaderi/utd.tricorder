/// <reference path="entityController.js" />
// ------------------------------- Medical History -------------------------------------


BaseControllers.MedicalHistoryBaseAddFormServices = function ($scope, sParams, SectionName) {
    $scope.SectionName = SectionName;

    $scope.init = function () {
        if ($scope.MasterID)
            $scope.PatientUserID = $scope.MasterID;
        else
            throw "MasterID is not provided for viewing the information";
        $scope.View();
    }

    $scope.View = function () {
        $scope.Exec({
            methodName: 'GetSectionValues',
            data: {
                SectionName: $scope.SectionName,
                PatientUserID: $scope.PatientUserID
            },
            successFn: function (e) {
                if (e.response.data != null)
                    $scope.model[SectionName] = e.response.data;
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
                    PatientUserID: $scope.PatientUserID
                }
            });
        }
    }
}


entityControllerFactory.create("MedicalHistory", "Allergy", function ($scope, sParams) {
    BaseControllers.MedicalHistoryBaseAddFormServices($scope, sParams, "Allergy");
});


entityControllerFactory.create("MedicalHistory", "Condition", function ($scope, sParams) {
    BaseControllers.MedicalHistoryBaseAddFormServices($scope, sParams, "Condition");
});

entityControllerFactory.create("MedicalHistory", "CurrentMed", function ($scope, sParams) {
    BaseControllers.MedicalHistoryBaseAddFormServices($scope, sParams, "CurrentMed");
});

entityControllerFactory.create("MedicalHistory", "FamilyHistory", function ($scope, sParams) {
    BaseControllers.MedicalHistoryBaseAddFormServices($scope, sParams, "FamilyHistory");
});

entityControllerFactory.create("MedicalHistory", "Immunization", function ($scope, sParams) {
    BaseControllers.MedicalHistoryBaseAddFormServices($scope, sParams, "Immunization");
});

entityControllerFactory.create("MedicalHistory", "PastMed", function ($scope, sParams) {
    BaseControllers.MedicalHistoryBaseAddFormServices($scope, sParams, "PastMed");
});

entityControllerFactory.create("MedicalHistory", "Social", function ($scope, sParams) {
    BaseControllers.MedicalHistoryBaseAddFormServices($scope, sParams, "Social");
});

entityControllerFactory.create("MedicalHistory", "Sign", function ($scope, sParams) {
    BaseControllers.MedicalHistoryBaseAddFormServices($scope, sParams, "Sign");
});


// --------------------- Tabs  ---------------------------
entityControllerFactory.create("MedicalHistory", "Tabs", function ($scope, sParams) {

});


// --------------------- Breast Cancer  ---------------------------

entityControllerFactory.create("BreastCancer", "Tabs", function ($scope, sParams) {

});
entityControllerFactory.create("MedicalHistory", "BCRisk", function ($scope, sParams) {
    BaseControllers.MedicalHistoryBaseAddFormServices($scope, sParams, "BCRisk");
});
entityControllerFactory.create("MedicalHistory", "BCRisk2", function ($scope, sParams) {
    BaseControllers.MedicalHistoryBaseAddFormServices($scope, sParams, "BCRisk2");
});
entityControllerFactory.create("MedicalHistory", "BCRisk3", function ($scope, sParams) {
    BaseControllers.MedicalHistoryBaseAddFormServices($scope, sParams, "BCRisk3");
});
entityControllerFactory.create("MedicalHistory", "PatientLabel", function ($scope, sParams) {
    BaseControllers.MedicalHistoryBaseAddFormServices($scope, sParams, "PatientLabel");
});