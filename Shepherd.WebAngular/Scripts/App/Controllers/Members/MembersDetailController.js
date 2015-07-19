﻿(function () {

    var app = angular.module("shepherdApp");

    app.controller("MembersDetailController", ["$scope", "$location", "$routeParams", "MemberService", function ($scope, $location, $routeParams, MemberService) {


        var id = $routeParams.id;
        
        var promise = MemberService.getMemberById(id);

        promise.then(function (response) {
            console.log(response.data);
            
            var memberDetail = response.data;

            $scope.member = {};

            $scope.member.FirstName = memberDetail.firstName;
            $scope.member.LastName = memberDetail.lastName;
            $scope.member.MiddleName = memberDetail.middleName;

            //$scope.members = response.data.members;

        }, function (response) {
            console.log(response);
        });

        //$scope.member = MemberService.getMemberById(id);

    }]);

}());