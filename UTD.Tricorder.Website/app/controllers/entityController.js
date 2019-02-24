//'use strict'; We have to not to use strict because it causes exception in beforeFn

var entityControllerFactory = {
    
    create: function (entityName, formName, extraFn) {
        //app.controller(entityName + 'Controller', ['$scope', '$location', '$timeout', 'entityName', function ($scope, $location, $timeout, entityName) {
        //if ($scope.service[entityName] !== undefined)
        //    return; // if we already had the controller, then do nothing.
        if (!formName)
            formName = "";
        var controllerName = entityName + formName;

        entityControllerFactory.InheritFns[controllerName] = extraFn;

        return app.controller(controllerName + "Controller", ['$scope', '$location', '$http', '$q', 'ngAuthSettings', 'authService', '$window', 'localStorageService', '$routeParams', '$upload', function ($scope, $location, $http, $q, ngAuthSettings, authService, $window, localStorageService, $routeParams, $upload) {
            //app.controller(entityName + 'Controller', ['$scope', function ($scope) {
            var serviceName = entityName;
            if (formName)
                serviceName = entityName + "-" + formName; // service with additional data key

            var entityService = EntityService.create(serviceName, $http, ngAuthSettings);

            var injectedParameters = {
                entityName: entityName,
                $location: $location,
                $http: $http,
                $q: $q,
                ngAuthSettings: ngAuthSettings,
                authService: authService,
                $window: $window,
                localStorageService: localStorageService,
                $routeParams: $routeParams,
                controllerName: controllerName,
                $upload: $upload
            }

            var viewParams = null;
            if ($routeParams) { // in route paramters 'p' is reserved word
                if ($routeParams.p) {
                    viewParams = JSON.parse(decodeURIComponent($routeParams.p)).d;
                }
            }

            // scope default variables
            $scope.model = {}; // model to keep forms data
            $scope.service = entityService; // service to call service functions
            $scope.itemsList = []; // items list to show grids
            $scope.CurrentUserID = $window.getLoginData().userName;
            $scope.MasterID = $routeParams.MasterID; // recordID of the master entity;
            $scope.MasterEN = $routeParams.MasterEN; // master entity
            $scope.RecordID = $routeParams.RecordID; // recordID of the editing entity
            $scope.ViewNeedsParams = null; // we don't want to propagate it to childs

            //   ---------------- default functions -----------------

            $scope.CallService = function (p) {
                    // {p parameters for service execution (look at service parameters)}
                var service = this.service;
                var fnName = p.sName;
                if (fnName == "Exec")
                    fnName = p.methodName; // if it was exec, then use exec parameter

                if (p.$event)
                    p.$event.preventDefault();

                // Show loading mask
                if (!p.successFn)
                    if (!p.failureFn)
                        $scope.FindRelatedDiv().mask("Please wait...");

                //if (p.beforeFn)
                //    if (p.beforeFn(service, p) === false)
                //        return;
                if (!p.successFn)
                    p.successFn = function (p) {

                        $scope.FindRelatedDiv().unmask();

                        if (service.message)
                            $window.ShowMessage(service.message, service.isErrorMsg);

                        if (p.sName == "Exec")  // we call success exec as a separate function
                            if ($scope['onSuccessExec'])
                                if ($scope['onSuccessExec'](p) === false)
                                    return false;

                        if ($scope['onSuccess' + fnName])
                            if ($scope['onSuccess' + fnName](p) === false)
                                return false;
                    }

                if (!p.failureFn)
                    p.failureFn = function (p) {

                        $scope.FindRelatedDiv().unmask();
                        if (service.message)
                            $window.ShowMessage(service.message, service.isErrorMsg);

                        if ($scope['onFailure' + p.sName])
                            if ($scope['onFailure' + p.sName](p) === false)
                                return false;
                    }

                if ($scope['onBefore' + fnName]) {
                    var r = $scope['onBefore' + fnName](p);
                    if (r === false)
                        return; // don't execute function
                }

                service.message = "";

                var retValue = service[p.sName](p);
                p.retvalue = retValue;

                return retValue;
            }

            $scope.Exec = function (p) {
                p.sName = "Exec";
                $scope.CallService(p);
            }

            // calls execution service with convenience
            $scope.ExecInline = function (mName, data, successFn, failureFn) {
                if (successFn === undefined)
                    $scope.CallService({
                        sName: "Exec",
                        methodName: mName,
                        data: data
                    });
                else
                    $scope.CallService({
                        sName: "Exec",
                        methodName: mName,
                        data: data,
                        successFn: successFn,
                        failureFn: failureFn
                    });
            }

            $scope.ClearForm = function () {// a function to clear the form on screen if possible
                $scope.model = {};
                $scope.SetModelDefaults();
            };

            $scope.SetModelDefaults = function () { };

            $scope.GotoPage = function (path) {
                $location.redirectTo(path);
            }

            $scope.GoBack = function (retParams) {
                setTimeout(function () {
                    $window.history.back();
                }, 500);
            }

            $scope.GotoView = function (viewName, objectParams) {
                var path = "/" + viewName;

                if (objectParams) {
                    //if (path.indexOf('?') > 0)
                    //    path = path + "&";
                    //else
                    //    path = path + "?";

                    ////var storageKey = $scope.NewGuid();
                    ////path = "key=" & storageKey;
                    ////localStorage.setItem(storageKey, objectParams);

                    //var pValue = { d: objectParams };
                    //path = path + "p=" &  decodeURIComponent(JSON.stringify(pValue));
                    //if (path.length > 1024)
                    //    throw "GotoView.objectParams is too large";

                    return $location.url(path).search("p", { d: objectParams });
                }
                else
                    return $location.url(path);
            }

            $scope.NewGuid = function() {
                var d = new Date().getTime();
                var uuid = 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function(c) {
                    var r = (d + Math.random()*16)%16 | 0;
                    d = Math.floor(d/16);
                    return (c=='x' ? r : (r&0x7|0x8)).toString(16);
                });
                return uuid;
            }

            $scope.DeleteItem = function (id, $event) {
                if (id) {
                    $scope.Confirm("Are you sure that you want to delete this item?", function () {
                        $scope.CallService({ sName: 'Delete', id: id, $event: $event });
                    });
                }
            }

            $scope.Confirm = function (msg, okFunction) {
                var r = $window.confirm(msg);
                if (r == true)
                    okFunction();
            }

            $scope.FormatDate = function (date) {
                if (date)
                    return moment.utc(date).startOf('day').format('LL'); //moment(date).format('MMMM DD YYYY');
                else
                    return "";
            }

            $scope.FormatDateTime = function (date) {
                if (date)
                    return moment(date).format('MMMM DD YYYY, h:mm a');
                else
                    return "";
            }

            $scope.FormatDateUnix = function (unixEpoch) {
                if (unixEpoch)
                    return moment.unix(unixEpoch).format('MMMM DD YYYY');
                else
                    return "";
            }

            $scope.FormatDateTimeUnix = function (unixEpoch) {
                if (unixEpoch)
                    return moment.unix(unixEpoch).format('MMMM DD YYYY, h:mm a');
                else
                    return "";
            }

            $scope.TextToHtml = function (text) {
                if (text)
                    return text.replace(/(\r\n|\n|\r)/gm, "<br />");
                else
                    return "";
            }

            $scope.IsFormValid = function () {
                //return sParams.
                return $window.isFormValid("#" + controllerName + "Frm");
            }

            $scope.CheckViewNeeds = function () {
                // DEVELOPER NOTE: Don't delete ViewNeedsParams from scope. it prevents default initialization
                var parameters = $scope.ViewNeedsParams;

                $scope.CallService({
                    sName: 'GetViewNeeds',
                    data: { ViewName: formName, Parameters: parameters },
                    successFn: function (p) {
                            var needs = p.response.data.Needs;
                            if (needs.length > 0) {
                                $window.ShowViewNeedPanel($scope.FindRelatedDiv(), needs);
                            }

                            if ($window.initView)
                                $window.initView();

                            if ($scope.init) {
                                // if it had an initializer parameter
                                //$scope.$apply(function () {
                                    $scope.init(viewParams);
                                //});
                            }
                        }
                    }
                );
            }

            $scope.FindRelatedDiv = function () {
                return $window.FindRelatedDiv(controllerName);
            }



            //   ---------------------------------
            // adding extra services

            //if (controllerFunctions[controllerName + "AddServices"] !== undefined)
            //{
            //    controllerFunctions[controllerName + "AddServices"]($scope, injectedParameters);
            //}
            if (extraFn)
                extraFn($scope, injectedParameters);

            if ($scope.ViewNeedsParams == null) // if it had view needs then we need to check needs first
            {
                if ($window.initView)
                    $window.initView();

                if ($scope.init) // if it had an initializer parameter
                    $scope.init(viewParams);
            }

        if ($scope.$parent)
            $scope.$parent[controllerName + "Controller"] = $scope;


        }]);
    },

    InheritFns: {}  // extra functions for all controllers create using create function (it is to help reducing code by inheritance)
    
} // end entityControllerFactory


// -------------------------------- Base Controllers -------------------------------

var BaseControllers = {};

/* base functions for form saving */
BaseControllers.AddFormServices = function ($scope, sParams) {

    $scope.View = function (entityId) {
        $scope.EntityIDValue = entityId;
        if ($scope.EntityIDValue) {
            $scope.service.GetByID({
                id: entityId,
                successFn: function (e) {
                    $scope.model = e.response.data;
                    if ($scope.model == null) {
                        $scope.IsInsertForm = true;
                        $scope.ViewNewForm();
                    }
                    else { $scope.IsInsertForm = false; }
                }
            });
        }
        else {
            $scope.IsInsertForm = true;
            $scope.ViewNewForm();
        }
    }

    $scope.ViewNewForm = function () {
        $scope.ClearForm(); // empty object instead of null
        $scope.IsInsertForm = true;
        if (ControllerDebug[sParams.entityName + "FormNew"])
            ControllerDebug[sParams.entityName + "FormNew"]($scope);
        $scope.ResetFormValidation();
    }

    $scope.ResetFormValidation = function () {
        sParams.$window.resetFormValidation("#" + sParams.controllerName + "Frm");
    }

    $scope.Insert = function ($event) {
        if ($event)
            $event.preventDefault();

        if ($scope.IsFormValid()) {
            $scope.CallService({ sName: 'Insert', data: $scope.model });
        }
    }

    $scope.Update = function ($event) {
        if ($event)
            $event.preventDefault();
        if ($scope.IsFormValid()) {
            $scope.CallService({ sName: 'Update', id: $scope.EntityIDValue, data: $scope.model });
        }
    }

    $scope.Save = function ($event) {
        if ($scope.IsInsertForm)
            $scope.Insert($event);
        else
            $scope.Update($event);
    }

}

BaseControllers.AddEditFormServices = function ($scope, sParams) {

    BaseControllers.AddFormServices($scope, sParams);

    var goBackFn = function () {
        if ($scope.CloseDialog)
            $scope.CloseDialog();
        else
            $scope.GoBack();
    }

    $scope.init = function () {
        if ($scope.RecordID) // edit form
            $scope.View($scope.RecordID);
        else
            $scope.ViewNewForm(); // insert form
    }

    $scope.onSuccessInsert = goBackFn;
    $scope.onSuccessUpdate = goBackFn;
}

BaseControllers.AddGridFunctions = function ($scope, sParams) {

    $scope.msgs.selectedItemsListIsEmpty = "No item is available in this list.";

    $scope.ListFilter = {};
    $scope.PageIndex = 0;
    $scope.PageSize = 100;
    $scope.ColumnNames = null;

    $scope.RefreshList = function () {
        var p = {};
        p.getParameters = {
            "Filter": $scope.ListFilter,
            "PageIndex": $scope.PageIndex,
            "PageSize": $scope.PageSize,
            "SourceType": 1,
            "ColumnNames": $scope.ColumnNames
        };
        p.successFn = function (e) {
            $scope.itemsList = e.response.data;
        }
        p.sName = "Get";
        $scope.CallService(p);
    }

    $scope.onSuccessUpdate = function (p) {
        if ($scope.RefreshList)
            $scope.RefreshList();
    }

    $scope.onSuccessInsert = function (p) {
        if ($scope.RefreshList)
            $scope.RefreshList();
    }

    $scope.onSuccessDelete = function (p) {
        if ($scope.RefreshList)
            $scope.RefreshList();
    }

    $scope.onSuccessExec = function (p) {
        if ($scope.RefreshList)
            $scope.RefreshList();
    }

    $scope.init = function () {
        $scope.RefreshList();
    }
}


/* General function for two column keys Master form */

BaseControllers.AddTwoKeyFormFunctions = function ($scope, sParams) {

    BaseControllers.AddGridFunctions($scope, sParams);

    $scope.Insert = function ($event) {
        if ($event)
            $event.preventDefault();

        if ($scope.IsFormValid()) {
            $scope.CallService({ sName: 'Insert', data: $scope.model });
        }
    }

    //entityService.onBeforeInsert = function (p) {
    //$scope.model.Person.PersonID = Framework.getQueryString("MasterEntityID");
    //}
    $scope.msgs.selectedItemsListIsEmpty = "Selected items list is empty. Please select an item and use 'Add to list' button.";


    $scope.onSuccessInsert = function (p) {
        $scope.ClearForm();
        $scope.RefreshList();
    }

    $scope.onSuccessDelete = function (p) {
        $scope.RefreshList();
    }

    $scope.init = function () {
        $scope.RefreshList();
    }
}

/* General dialog functions for all form dialogs */

BaseControllers.AddDialogFunction = function ($scope, sParams) {

    $scope.DialogID = sParams.controllerName + "Dlg";

    $scope.DialogParams = {};

    $scope.ShowDialog = function (dialogParams, closeFn, $event) {
        if ($event)
            $event.preventDefault();

        $scope.CloseDialogFunction = closeFn;

        sParams.$window.ShowDialog($scope.DialogID);
        if (dialogParams && $scope.OnLoadDialog)
        {
            $scope.DialogParams = dialogParams;
            $scope.OnLoadDialog(dialogParams);
        }
    }

    $scope.CloseDialog = function (result) {
        sParams.$window.CloseDialog($scope.DialogID);

        // default dialog functions
        if (result === true)
        {
            if ($scope.$parent)
                if ($scope.$parent.RefreshList)
                    $scope.$parent.RefreshList();
        }

        if ($scope.CloseDialogFunction)
            $scope.CloseDialogFunction(result);
    }

}

BaseControllers.AddViewPageFunctions = function ($scope, sParams) {

    $scope.View = function (entityId)
    {
        $scope.ViewID = entityId;
        if (entityId) {
            $scope.service.GetByID({
                id: entityId,
                successFn: function (e) {
                    $scope.model = e.response.data;
                }
            });
        }
        else
            $scope.model = {};
    }



}

var ControllerDebug = {}; // empty debug object when we are in release mode

// --------------------------------------------------------------------------
// --------------------------- Controllers Instances ------------------------


// creating controllers names
entityControllerFactory.create("User");
entityControllerFactory.create("Person");
entityControllerFactory.create("Dashboard");

