var EntityService = {

    services: [],

    getByEntityName: function (entityName) {
        if (EntityService.services[entityName] !== undefined) {
            return EntityService.services[entityName];
        }
        throw "Service for " + entityName + " not found";
    },

    create: function (entityName, $http, ngAuthSettings) {
        var serviceBase = ngAuthSettings.apiServiceBaseUri + 'sapi/';
        var entityService = {
            entityName: entityName,
            message: '',
            isErrorMsg: false,
            serviceBase: serviceBase,
        };

        entityService.handleError = function (p, err, status) {
            // framework doesn't return error codes now.
            // it should be error codes related to other http errors that we may handle here
            // or define an inceptor for AngularJS to handle them.
            entityService.isErrorMsg = true;
            if (status === 0 || err === "") // when the user disconnects from the net, this part doesn't return correct error
                entityService.message = "Internet connection lost. The data of this form may not be valid anymore. Please verify that you are connected to the Internet, go back and try again.";
            else
                entityService.message = err.Message + "<br />" + err.MessageDetail;

            //if (entityService['onFailure' + p.sName])
            //    if (entityService['onFailure' + p.sName](p) === false)
            //        return false;

            if (p.failureFn)
                if (p.failureFn(p) === false)
                    return false;

            //$.growl(entityService.message, {
            //    type: 'danger',
            //    z_index: 9999
            //});

        };

        entityService.handleResponse = function (p) {
            var response = p.response;
            if (response) {
                // handing data
                if (response.data)
                {
                    if ($.type(response.data) === "string")
                        response.data = JSON.parse(response.data);
                }



                // showing business exceptions
                if (response.errorMessage) {
                    entityService.message = response.errorMessage;
                    entityService.isErrorMsg = true;
                    //$.growl(entityService.message, {
                    //    type: 'danger'
                    //    , z_index: 9999
                    //});
                }
                else 
                {
                    entityService.isErrorMsg = false;
                    if (response.message) {
                        entityService.message = response.message;
                        //$.growl(entityService.message, {
                        //    type: 'success'
                        //    , z_index: 9999
                        //});
                    }
                }

                if (entityService.isErrorMsg !== true) {
                    //    if (entityService['onSuccess' + p.sName])
                    //        if (entityService['onSuccess' + p.sName](p) === false)
                    //            return false;

                    if (p.successFn)
                        if (p.successFn(p) === false)
                            return false;
                }
                else {
                    //if (entityService['onFailure' + p.sName])
                    //    if (entityService['onFailure' + p.sName](p) === false)
                    //        return false;

                    if (p.failureFn)
                        if (p.failureFn(p) === false)
                            return false;
                }
            }

            return true;
        }

        entityService.Get = function (p) {
            // {getParameters, $event, beforeFn, successFn}
            var self = this;
            p.sName = "Get";

            return $http.get(serviceBase + entityName + '/Get?p=' + decodeURIComponent(JSON.stringify(p.getParameters))).success(function (response) {
                p.response = response;
                if (self.handleResponse(p) == true)
                    return response.data;
            }).error(function (err, status) {
                self.handleError(p, err, status);
            });;
        }

        entityService.GetByID = function (p) {
            // {id, $event, beforeFn, successFn}
            var self = this;
            p.sName = "GetByID";

            return $http.get(serviceBase + entityName + '/GetByID/' + p.id).success(function (response) {
                p.response = response;
                if (self.handleResponse(p) == true)
                    return response.data;
                return response.data;
            }).error(function (err, status) {
                self.handleError(p, err, status);
            });
        }

        entityService.Insert = function (p) {
            // {data, $event, beforeFn, successFn}
            var self = this;
            p.sName = "Insert";

            return $http.post(serviceBase + entityName + '/Insert', { data: JSON.stringify(p.data) }).success(function (response) {
                p.response = response;
                if (self.handleResponse(p) == true)
                    return response.data;
            }).error(function (err, status) {
                self.handleError(p, err, status);
            });
        }

        entityService.Update = function (p) {
            // {id, data, $event, beforeFn, successFn}
            p.sName = "Update";
            var self = this;
            return $http.put(serviceBase + entityName + '/Update/' + p.id, { data: JSON.stringify(p.data) }).success(function (response) {
                p.response = response;
                if (self.handleResponse(p) == true)
                    return response.data;
            }).error(function (err, status) {
                self.handleError(p, err, status);
            });
        }

        entityService.Delete = function (p) {
            // {id, $event, beforeFn, successFn}
            var self = this;
            p.sName = "Delete";

            return $http.delete(serviceBase + entityName + '/Delete/' + p.id).success(function (response) {
                p.response = response;
                if (self.handleResponse(p) == true)
                    return response.data;
            }).error(function (err, status) {
                self.handleError(p, err, status);
            });
        }

        entityService.Exec = function (p) {
            // {methodName, data, $event, beforeFn, successFn}
            var self = this;
            var pExec = {};
            pExec.methodName = p.methodName;
            pExec.data = p.data;
            var requestData;
            if (typeof p.data == 'string')
                requestData = { data: p.data };
            else
                requestData = { data: JSON.stringify(p.data) };

            return $http.post(serviceBase + entityName + '/Exec/' + pExec.methodName, requestData).success(function (response) {
                p.response = response;
                if (self.handleResponse(p) == true)
                    return response.data;
            }).error(function (err, status) {
                self.handleError(p, err, status);
            });
        }

        entityService.ExecInline = function (methodName, data, successFn, failureFn) {
            this.Exec({methodName: methodName, data: data, successFn: successFn, failureFn: failureFn});
        }

        entityService.GetViewNeeds = function (p) {
            // {getParameters, $event, beforeFn, successFn}
            var self = this;
            p.sName = "GetViewNeeds";

            return $http.get(serviceBase + entityName + '/GetViewNeeds?p=' + decodeURIComponent(JSON.stringify(p.data))).success(function (response) {
                p.response = response;
                if (self.handleResponse(p) == true)
                    return response.data;
            }).error(function (err, status) {
                self.handleError(p, err, status);
            });;
        }

        if (EntityService[entityName + "AddServices"] !== undefined) {
            EntityService[entityName + "AddServices"](entityName, $http, ngAuthSettings);
        }

        EntityService.services[entityName] = entityService;

        return entityService;
    }

    //UserAddServices: function (entityName, $http, ngAuthSettings) {
    //    entityService.Signup = function (p) {

    //        return $http.post(entityService.serviceBase + entityService.entityName + '/Signup', $scope.model.UserRegisterSP).success(function (response) {

    //            p.response = response;
    //            p.successFn = function (e) {
    //                var loginData = {
    //                    userName: $scope.model.UserRegisterSP.userName,
    //                    password: $scope.model.UserRegisterSP.password,
    //                    useRefreshTokens: false
    //                };
    //                sParams.authService.login(loginData).then(function (response) {
    //                    sParams.$location.redirectTo('~/Register/Person');
    //                });
    //            }
    //            entityService.handleResponse(p);

    //        }).error(function (err, status) {
    //            entityService.handleError(p, err, status);
    //        });

    //    }
    //},


}

