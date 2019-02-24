'use strict';
app.controller('indexController', ['$scope', '$location', 'authService', '$window', '$timeout', function ($scope, $location, authService, $window, $timeout) {

    $scope.logOut = function () {
        authService.logOut();
        $location.redirectTo('~/Default/Signout');
    }

    $scope.authentication = authService.authentication;

    $scope.CurrentUserID = authService.authentication.userName;

    $scope.GotoMainMenu = function () {
        // redirecting to the menu
        if ($scope.CurrentRoleCode == 'Doctor') {
            $scope.MainMenuPath = "DoctorMenu";
        }
        else {
            $scope.MainMenuPath = "PatientMenu";
        }
        $scope.OpenPath($scope.MainMenuPath);
    }

    $scope.GoBack = function (retParams) {
        setTimeout(function () {
            $window.history.back();
        }, 500);
    }

    $scope.GoBackToCheckPoint = function () {
        $timeout(function () {
            if ($scope.$root.CheckPointUrl)
                $location.url($scope.$root.CheckPointUrl);
            else
                $scope.GotoMainMenu();
        }, 1);
    }

    $scope.OpenPath = function (path, searchKeyValue, markAsCheckPoint) {

        $timeout(function () {
            if (markAsCheckPoint)
                $scope.$root.CheckPointUrl = $location.url();
            var p = $location.path(path);
            if (searchKeyValue) {
                p.search(searchKeyValue); // query string in the form of {key:value}
            }
            else
            {
                p.search({});
            }
        }, 1);



        // use set time out to prevent AngularJS exception
        //setTimeout(function () {
        //    var url = "~/Dashboard";
        //    if (path.lastIndexOf('#') != 0)
        //        if (path.lastIndexOf('/') != 0)
        //            url += "#/" + path;
        //        else
        //            url += "#" + path;
        //    else
        //        url += path;
        //    //if (path.lastIndexOf('#') == 0) {
        //    //    $window.location.hash = path.substr(1);
        //    //    path = path.substr(1);
        //    //}
        //    //else
        //    //    $location.path(path);
        //    $location.redirectTo(url);
        //}, 1);

        // TODO: Remove dependency to window object like this.
        // closing the menu for mobile UI.
        if ($window.innerWidth < 768) {
            $("#wrapper").removeClass("toggled");
            $window.arrangeUI();
        }
    }



}]);