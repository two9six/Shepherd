(function () {

    var app = angular.module("shepherdApp");

    app.controller("HomeController", ["$scope", function ($scope) {

        $scope.hello = "Hello Angular!";

    }]);

}());