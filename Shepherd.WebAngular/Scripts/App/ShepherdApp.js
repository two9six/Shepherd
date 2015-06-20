(function () {


    var app = angular.module("shepherdApp", ["ngRoute", "ui.bootstrap"]);

    app.config(["$routeProvider", "$locationProvider", function ($routeProvider, $locationProvider) {

        $routeProvider.when("/Members", {
            templateUrl: "/Templates/MembersIndex.html",
            controller: "MembersIndexController"
        })
        .when("/Members/Add", {
            templateUrl: "/Templates/MembersAdd.html",
            controller: "MembersAddController"
        })
        .when("/Members/Details/:id", {
            templateUrl: "/Templates/MembersDetail.html",
            controller: "MembersDetailController"
        })
        .when("/", {
            templateUrl: "/Templates/Index.html",
            controller: "HomeController"
        })
        .otherwise({
            redirectTo : "/"
        });


        $locationProvider.html5Mode(true);

    }]);




}());