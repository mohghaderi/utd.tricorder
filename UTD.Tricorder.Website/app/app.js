
var app = angular.module('XecareApp', ['ngRoute',
                                            'LocalStorageModule',
                                            'angular-loading-bar',
                                            'ngAnimate',
                                            'angularFileUpload',
                                            'angulartics',
                                            'angulartics.google.analytics',
                                            'angulartics.google.tagmanager',
                                            'internationalPhoneNumber'
                                            ]);

app.config(function ($analyticsProvider) {
    $analyticsProvider.firstPageview(true); /* Records pages that don't use $state or $route */
    $analyticsProvider.withAutoBase(true);  /* Records full path */
});


app.config(function ($routeProvider) {

    //$routeProvider.when('/Register/:name', {
    //    templateUrl: function (urlattr) {
    //        return '/Register/' + urlattr.name;
    //    }
    //});

    //$routeProvider.when('/Default/:name', {
    //    templateUrl: function (urlattr) {
    //        return '/Default/' + urlattr.name;
    //    }
    //});

    if (window.location.href.indexOf("/Dashboard") > 0)
    {
        $routeProvider.when("/:name", {
            templateUrl: function (urlattr) {
                return window.AppSettings.websiteviewserverbaseurl + 'Dashboard/AjaxView/' + urlattr.name;
            }
        });
    }

    //$routeProvider.otherwise({ redirectTo: "/MainMenu" });

});

app.constant('ngAuthSettings', {
    apiServiceBaseUri: window.AppSettings.apiserverbaseurl,
    singlesignonserverurl: window.AppSettings.singlesignonserverurl,
    //apiServiceBaseUri: 'http://localhost:10237/',
    clientId: 'xecareAngularJS',
    clientSecret: "LTUmjdbt6v847P7nAnX3kBQsvmbPHq" + "aG9Wk2t5efESbUuxTypTub28wzT7dQtm4NJQAjd78a"
});

app.config(function ($httpProvider) {
    $httpProvider.interceptors.push('authInterceptorService');
    $httpProvider.interceptors.push('errorHandlerInterceptorService');
    $httpProvider.defaults.headers.common["X-Requested-With"] = 'XMLHttpRequest';  // ajax request tag for MVC
});

app.run(['authService', '$location', '$rootScope', function (authService, $location, $rootScope) {
    authService.fillAuthData();

    // set anlytics per user activity
    if (authService.authentication.userName)
        ga('set', 'userId', authService.authentication.userName.toString()); //Google analytics user id

    var loc = $location;

    loc.resolveClientUrl = function (url) {
        if (url.startsWith("~/") == false)
            return url;
        var baseUrl = window.AppSettings.websiteviewserverbaseurl;
        return Framework.concatUrl(baseUrl, url.substr(2, url.length - 2));
    }

    loc.redirectTo = function (newUrl, win) {

        setTimeout(function () { // wait a few seconds to prevent after login redirect bug in IE
            try {
                newUrl = loc.resolveClientUrl(newUrl);
                if (win === undefined)
                    win = window;
                win.location.href = newUrl;
            } catch (e) {
                ShowError(e); // this is window.ShowMessage
            }
        }, 100);
        //$location.href = Framework.resolveClientUrl(newUrl);
    };
    loc.getQueryString = Framework.getQueryString;

    $rootScope.$on('$routeChangeSuccess', function () {
        // handing view changes
        angularRouteChangeSuccess();
    });

    $rootScope.msgs = window.Msgs;

}]);

//http://stackoverflow.com/questions/18926306/angularjs-ng-bind-html-unsafe-replacement?lq=1
// usage <any ng-bind-html="content | unsafe"></any>
// to support unsafe html in angularjs 1.2 and newer
app.filter('unsafe', ['$sce', function ($sce) {
    return function (val) {
        return $sce.trustAsHtml(val);
    };
}]);


// icheck directive : http://stackoverflow.com/questions/19346523/integration-of-angular-and-jquery-icheck-by-using-a-directive-is-not-working
app.directive('ngIcheck', function ($timeout, $parse) {
    return {
        require: 'ngModel',
        link: function ($scope, element, $attrs, ngModel) {
            return $timeout(function () {
                var value;
                value = $attrs['value'];

                $scope.$watch($attrs['ngModel'], function (newValue) {
                    $(element).iCheck('update');
                })

                return $(element).iCheck(
                    {
                        handle:'radio', //TODO: Fix checkbox click problems in Android browser for check boxes. and remove this line
                        checkboxClass: 'icheckbox_square-blue',
                        radioClass: 'iradio_square-blue',
                        aria: true,
                        cursor: false
                    }
                    ).on('ifChanged', function (event) {

                    var field = $(element);
                    var elementType = $(element).attr('type');

                    //if (elementType !== 'checkbox') // we don't validate check boxes because no individual validation is available for a checkbox
                    if (field.attr('data-bv-field') !== undefined) // if the field had no validation
                        $(element).closest("form").bootstrapValidator('revalidateField', field);

                    if (elementType === 'checkbox' && $attrs['ngModel']) {
                        $scope.$apply(function () {
                            return ngModel.$setViewValue(event.target.checked);
                        });
                    }
                    if (elementType === 'radio' && $attrs['ngModel']) {
                        return $scope.$apply(function () {
                            return ngModel.$setViewValue(value);
                        });
                    }
                });
            });
        }
    };
})

app.directive('select2', function ($timeout) {
    return {
        // Restrict it to be an attribute in this case
        restrict: 'AE',
        // optionally hook-in to ngModel's API 
        require: '?ngModel',
        // responsible for registering DOM listeners as well as updating the DOM
        link: function ($scope, element, $attrs, ngModel) {
            var $element;
            //$timeout(function () {

                var options = $scope.$eval($attrs.select2);
                if (options)
                    options.theme = "bootstrap";
                var $element = $(element).find("select");
                element[0].selectoptions = options;
                var s2 = $element.select2(options);

                //Select2.prototype.setValueAngular = function (newValue) {
                //    this.angularSetValue = true; // a lock object to prevent calling change trigger of input to fix the re-cursive call of changing values
                //    $element.select2("val", newValue);
                //    this.angularSetValue = false;
                //}

                if (!ngModel) { return; }//below this we interact with ngModel's controller

                $scope.$watch($attrs['ngModel'], function (newValue) {
                    //s2.setValueAngular(newValue);
                    $element.angularSetValue = true;
                    var oldValue = $element.val();
                    if (!(newValue === undefined && (oldValue == null || oldValue == "")))
                        if (oldValue != newValue)
                            $element.val(newValue).trigger('change');
                    $element.angularSetValue = false;
                });

                //update ngModel when changes
                $element.on('change', function () {
                    if ($element.angularSetValue == true)
                        return;
                    var value = $element.val()
                    if (!(ngModel.$viewValue === undefined && (value == null || value == "")))
                        if (value != ngModel.$viewValue)
                            $scope.$apply(function () {
                                ngModel.$setViewValue(value);
                            });
                });
            //});
        }
    };
});

//http://stackoverflow.com/questions/21888828/selectize-angularjs-not-playing-along-with-select-box-multiple-options
app.directive('selectize', function ($timeout) {
    return {
        // Restrict it to be an attribute in this case
        restrict: 'AE',
        // optionally hook-in to ngModel's API 
        require: '?ngModel',
        // responsible for registering DOM listeners as well as updating the DOM
        link: function ($scope, element, $attrs, ngModel) {
            var $element;
            //$timeout(function () {
                Selectize.prototype.onChange = function () { //fix the re-cursive call of changing values
                    if (!this.angularSetValue)
                        this.$input.trigger('change');
                };
                Selectize.prototype.setValueAngular = function (newValue) {
                    this.angularSetValue = true; // a lock object to prevent calling change trigger of input to fix the re-cursive call of changing values
                    this.setValue(newValue);
                    this.angularSetValue = false;
                }

                var selectizeOptions = $scope.$eval($attrs.selectize);

                if ($attrs.selectize.selectizeOptions)
                    selectizeOptions = angular.extend(selectizeOptions, $scope.selectizeOptions || {});

                if (selectizeOptions.create === false
                    && selectizeOptions.load === undefined
                    && selectizeOptions.EntityName !== undefined
                    && selectizeOptions.DropDownUseCustomLoad === false) {
                    selectizeOptions.load = function (query, callback) {
                        var service = EntityService.getByEntityName(selectizeOptions.EntityName);
                        service.Get({
                            getParameters: {
                                "Filter": {
                                    "FiltersList":
                                        [{ "ColumnName": selectizeOptions.labelField, "Value": query, "Operator":"Contains" }
                                        ]
                                }
                            }, successFn: function (e) {
                                callback(e.response.data);
                            }
                        });
                    }
                } 

                $element = $(element).find("select").selectize(selectizeOptions);
                if (!ngModel) { return; }//below this we interact with ngModel's controller

                $scope.$watch($attrs['ngModel'], function (newValue) {
                    var control = $element[0].selectize;
                    control.setValueAngular(newValue);
                });

                //update ngModel when selectize changes
                $element.on('change', function () {
                    //var newValue =$element[0].selectize().val();
                    var newValue = $element[0].selectize.getValue();
                    if (newValue !== ngModel.$viewValue)
                        $scope.$apply(function () {
                            //console.log('change:', newValue);
                            ngModel.$setViewValue(newValue);
                        });
                });
            //});
        }
    };
});

/*

app.directive('selectize', [function () {
    return {
        restrict: "A",
        scope: {
            selectize: '=',
            ngModel: '=',
            mouseOver: '&',
            mouseOut: '&'
        },
        link: function ($scope, $element, $attrs) {
            var element = $($element).find("select");
            function safeApply(fn) {
                var phase = $scope.$root.$$phase;
                if (phase == '$apply' || phase == '$digest') {
                    if (fn && (typeof (fn) === 'function')) {
                        fn();
                    }
                } else {
                    $scope.$apply(fn);
                }
            };

            var ngModel = $scope.ngModel;
            var defaultOptions = {};
            var options = angular.extend(defaultOptions, $scope.selectize || {});
            element.selectize(options);

            // Set view to score if model changes
            $scope.$watch('ngModel', function (newValue, oldValue) {
                safeApply(function () {
                    element[0].selectize.setValue($scope.ngModel);
                });
            });

            element.on('change', function () {
                safeApply(function () {
                    //var newValue =$element[0].selectize().val();
                        var newValue = element[0].selectize.getValue();
                        if (newValue !== $scope.ngModel.$viewValue)
                            $scope.$apply(function () {
                                //console.log('change:', newValue);
                                $scope.ngModel.$setViewValue(newValue);
                            });
                    });
            });

        }
    }
}]);
*/





//The MIT License (MIT)

//Copyright (c) 2013 Perry Hoffman

//Permission is hereby granted, free of charge, to any person obtaining a copy of
//this software and associated documentation files (the "Software"), to deal in
//the Software without restriction, including without limitation the rights to
//use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
//the Software, and to permit persons to whom the Software is furnished to do so,
//subject to the following conditions:

//The above copyright notice and this permission notice shall be included in all
//copies or substantial portions of the Software.

//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
//FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
//COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
//IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
//CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

app.directive('ngraty', [function () {
    return {
        restrict: "A",
        scope: {
            ngraty: '=',
            ngModel: '=',
            mouseOver: '&',
            mouseOut: '&'
        },
        link: function ($scope, $element, $attrs) {
            var element = $($element);
            function safeApply(fn) {
                var phase = $scope.$root.$$phase;
                if (phase == '$apply' || phase == '$digest') {
                    if (fn && (typeof (fn) === 'function')) {
                        fn();
                    }
                } else {
                    $scope.$apply(fn);
                }
            };

            var rating = $scope.ngModel;
            var raty = {
                score: parseFloat(rating, 10),
                click: function (stars, evt) {
                    evt.stopPropagation();
                    if (!stars) stars = 0;
                    safeApply(function () {
                        $scope.ngModel = parseFloat(stars);
                    });
                },
                mouseover: function (stars, evt) {
                    if (!$scope.mouseOver) return;
                    safeApply(function () {
                        $scope.mouseOver({ stars: stars, e: evt });
                    });
                },
                mouseout: function (stars, evt) {
                    if (!$scope.mouseOut) return;
                    safeApply(function () {
                        $scope.mouseOut({ stars: stars, e: evt });
                    });
                }
            };
            var options = angular.extend(raty, $scope.ngraty || {});
            element.raty(options);

            // Set view to score if model changes
            $scope.$watch('ngModel', function (newValue, oldValue) {
                element.raty('score', $scope.ngModel);
            });

            function destroy() {
                element.raty('destroy');
            }
            element.bind('$destroy', destroy);
        }
    }
}]);


app.directive('datetimepicker', function ($timeout) {
    return {
        // Restrict it to be an attribute in this case
        restrict: 'AE',
        // optionally hook-in to ngModel's API 
        require: '?ngModel',
        // responsible for registering DOM listeners as well as updating the DOM
        link: function ($scope, element, $attrs, ngModel) {
            var $element;
            //$timeout(function () {

                $element = $(element).find("input").datetimepicker($scope.$eval($attrs.datetimepicker));

                var DateTimePicker = $element.data("DateTimePicker");
                DateTimePicker.setValueAngular = function (newValue) {
                    this.angularSetValue = true; // a lock object to prevent calling change trigger of input to fix the re-cursive call of changing values
                    this.setDate(newValue);
                    this.angularSetValue = false;
                }

                if (!ngModel) { return; }//below this we interact with ngModel's controller

                $scope.$watch($attrs['ngModel'], function (newValue) {
                    //var newDate = (newValue instanceof Date) ? newValue : moment(newValue);
                    //if (control.getDate() - newDate !== 0)
                    //{
                    //    $(element).data('datevalue', newDate);
                    //    control.setDate(newDate);
                    //}
                    //if ($(element)[0].value != newValue)
                    //control.setDate(newValue);
                    if (newValue)
                        if (newValue != "Invalid date")
                        {
                            DateTimePicker.setValueAngular(newValue);
                        }
                });

                ngModel.$formatters.push(function (value) {
                    var format = DateTimePicker.format;
                    var date = moment(value);
                    if (date.isValid()) {
                        return date.format(format);
                    }
                    return '';
                });

                ngModel.$parsers.push(function toModel(input) {
                    // do something to format user input 
                    var modifiedInput = moment(input).format();
                    return modifiedInput;
                });

                //update ngModel when UI changes
                $element.on('dp.change', function (e) {
                    if (DateTimePicker.angularSetValue === true)
                        return;

                    var newValue = $element[0].value;
                    if (newValue !== ngModel.$viewValue)
                        $scope.$apply(function () {
                            //var newValue = $(element).data("DateTimePicker").getDate();
                            ngModel.$setViewValue(newValue);
                        });

                    if ($element.attr('data-bv-field') !== undefined) // if the field had validation
                        $element.closest("form").bootstrapValidator('revalidateField', $element);

                });
            //});
        }
    };
});



//function privateGetBaseClientPath() {
//    var currentjsPath = "app/app.js"; // if function moved to another file, this needs to be updated
//    // since framework common.js is one of the scripts in the document
//    // we search all scripts and by removing the path, we get the root
//    if (window.privateBaseClientPath)
//        return window.privateBaseClientPath;
//    else
//    {
//        var scripts = document.getElementsByTagName("script");
//        for (var i = 0; i < scripts.length; i++)
//        {
//            src = scripts[i].src.toLowerCase();
//            if (src.indexOf(currentjsPath) > -1)
//            {
//                window.privateBaseClientPath = src.replace(currentjsPath, "");
//                return window.privateBaseClientPath;
//            }
//        }
//    }
//}

//app.config([
//        '$httpProvider', 'fileUploadProvider',
//        function ($httpProvider, fileUploadProvider) {
//            delete $httpProvider.defaults.headers.common['X-Requested-With'];

//            // This is for iFrame Upload that doesn't work well.
//            // When itranspose iframe option added, it needs an extra parameter for "redirect"
//            // I added redirect and it's page in cors folder, but it didn't help
//            // I think that it was because the version of Amazon was different, and it no longer returns the required answer

//            //fileUploadProvider.defaults.redirect =
//            //    Framework.resolveClientUrl("~/Scripts/jquery-fileupload/cors/result.html?a=1");
//            //fileUploadProvider.defaults.redirect = window.location.href.replace(
//            //    /\/[^\/]*$/,
//            //    '/cors/result.html?%s'
//            //);

//        //angular.extend(fileUploadProvider.defaults, {
//        //    // Enable image resizing, except for Android and Opera,
//        //    // which actually support image resizing, but fail to
//        //    // send Blob objects via XHR requests:
//        //    disableImageResize: /Android(?!.*Chrome)|Opera/
//        //        .test(window.navigator.userAgent),
//        //    maxFileSize: 5000000,
//        //    acceptFileTypes: /(\.|\/)(gif|jpe?g|png)$/i
//        //});
//    }
//])

// exception handling
app.config(function ($provide) {
    $provide.decorator('$exceptionHandler', ['$log', '$delegate',
      function ($log, $delegate) {
          return function (exception, cause) {
              if (typeof exception === "string")
                  ShowMessage(exception, true);
              else
                  ShowMessage("Unknown error in the client-side javascript code.", true);
              //$log.debug('Default exception handler.');
              $delegate(exception, cause);
          };
      }
    ]);
});