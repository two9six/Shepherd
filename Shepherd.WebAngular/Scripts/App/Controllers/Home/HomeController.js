(function () {

    var app = angular.module("shepherdApp");

    app.controller("HomeController", ["$scope", "adAlerts", function ($scope, adAlerts) {

        $scope.hello = "Hello Angular!";

        $scope.timeoutValue = '2000';

        $scope.showInfo = function () {
            adAlerts.info('Info!', 'This is important information.');
        };

        $scope.showWarning = function () {
            adAlerts.warning('Warning!', 'This is a warning.');
        };

        $scope.showSuccess = function () {
            adAlerts.success('Success!', 'Success message');
        };

        $scope.showError = function () {
            adAlerts.error('Error!', 'This is an error.');
        };

    }]);

}());