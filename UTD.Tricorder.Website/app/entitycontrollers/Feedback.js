/// <reference path="entityController.js" />
// ----------------------------- Feedback ---------------------------------

entityControllerFactory.create("Feedback", "InsertForm", function ($scope, sParams) {

    BaseControllers.AddFormServices($scope, sParams);
    //$scope.ViewNeedsParams = { UserID: "" + $scope.CurrentUserID };
    //$scope.CheckViewNeeds();

    $scope.SubmitFeedback = function ($event) {
        if ($scope.IsFormValid()) {
            $scope.model.ViewAddress = window.location.href;
            $scope.ExecInline("NewFeedback", $scope.model);
        }
    }

    //$scope.$watch("IsRelatedToCurrentUrl", function () {
    //    if ($scope.IsRelatedToCurrentUrl)
            
    //})


    $scope.onSuccessNewFeedback = function () {
        $scope.model = {};
        if ($scope.CloseDialog)
            $scope.CloseDialog();
        else
            $scope.GoBack();
    }

});

entityControllerFactory.create("Feedback", "InsertFormDialog", function ($scope, sParams) {
    BaseControllers.AddDialogFunction($scope, sParams);
});