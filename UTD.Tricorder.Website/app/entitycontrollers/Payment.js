/// <reference path="entityController.js" />
// ----------------------------- Payment ---------------------------------

entityControllerFactory.create("Payment", "ReceivedGrid", function ($scope, sParams) {

    BaseControllers.AddGridFunctions($scope, sParams);

    $scope.UserID = $scope.CurrentUserID;

    $scope.msgs.selectedItemsListIsEmpty = "There is no payment in your current list";
    $scope.msgs.cancelConfirm = 'Are you sure that you want to cancel this payment?';
    $scope.msgs.refundConfirm = 'Are you sure that you want to refund the whole amount of this payment to the sender?';

    $scope.ListFilter = {
        "FiltersList":
            [
                { "ColumnName": "ReceiverUserID", "Value": $scope.UserID }
                , { "ColumnName": "PaymentStatusID", "Value": 4, "Operator": "NotEqualTo" } // not cancelled
            ]
    };

    $scope.IsCancelable = function(item) {
        var status = item.PaymentStatusID;
        return status == 0 || status == 1 || status == 2;
    }

    $scope.IsRefundable = function(item) {
        return item.PaymentStatusID == 3;
    }

    $scope.Cancel = function (paymentId, $event) {
        $scope.Confirm($scope.msgs.cancelConfirm, function () { $scope.ExecInline('Cancel', paymentId); });
    }

    $scope.Refund = function (paymentId) {
        $scope.Confirm($scope.msgs.refundConfirm, function () { $scope.ExecInline('RefundPayment', paymentId); });
    }

});



entityControllerFactory.create("Payment", "SentGrid", function ($scope, sParams) {
    BaseControllers.AddGridFunctions($scope, sParams);

    $scope.UserID = $scope.CurrentUserID;

    $scope.msgs.selectedItemsListIsEmpty = "There is no payment in your current list";

    $scope.ListFilter = {
        "FiltersList":
            [
                { "ColumnName": "SenderUserID", "Value": $scope.UserID }
                , { "ColumnName": "PaymentStatusID", "Value": 4, "Operator": "NotEqualTo" } // not cancelled
            ]
    };

    $scope.Pay = function (payment) {
        $scope.ExecInline('GetPaymentUrl',
                {
                    PaymentID: payment.PaymentID,
                    IsMobileClient: false  //PayPal doesn't have credit card option for mobile client yet.
                },
                function (p) {
                    var paymentUrl = p.response.data;
                    if (paymentUrl) {
                        var win = sParams.$window.open(paymentUrl, '_blank');
                        if (win)  //i.e. doesn't return anything here
                            win.focus();
                    }
                    else
                        $scope.RefreshList();
                });
    }

    $scope.IsPayable = function (payment) {
        var status = payment.PaymentStatusID;
        return status == 0 || status == 1 || status == 2;
    }

});


entityControllerFactory.create("Payment", "VisitDetailGrid", function ($scope, sParams) {

    entityControllerFactory.InheritFns.PaymentReceivedGrid($scope, sParams);

    $scope.msgs.selectedItemsListIsEmpty = "There is no payment record for this visit";

    $scope.ListFilter = {
        "FiltersList":
            [
                { "ColumnName": "AppEntityID", "Value": 1 }
                , { "ColumnName": "AppEntityRecordIDValue", "Value": $scope.MasterID }
                , { "ColumnName": "PaymentStatusID", "Value": 4, "Operator": "NotEqualTo" }  // not cancelled
            ]
    };


});

entityControllerFactory.create("Payment", "InsertForm", function ($scope, sParams) {

    BaseControllers.AddFormServices($scope, sParams);
    $scope.ViewNeedsParams = { UserID: "" + $scope.CurrentUserID };
    $scope.CheckViewNeeds();

    if (!$scope.MasterID)
        throw new "MasterID is not provided";

    $scope.CreatePaymentForVisit = function ($event) {
        if ($scope.IsFormValid()) {
            $scope.model.VisitID = $scope.MasterID;
            $scope.ExecInline("CreatePaymentForVisit", $scope.model);
        }
    }

    $scope.$watch("model.Amount", function () {
        // TODO: get amount value from the web configuration
        if ($scope.model.Amount)
            $scope.model.ServiceChargeAmount = 0.01 * $scope.model.Amount;
    })


    $scope.onSuccessCreatePaymentForVisit = function () {
        if ($scope.CloseDialog)
            $scope.CloseDialog();
        else
            $scope.GoBack();
    } 

});