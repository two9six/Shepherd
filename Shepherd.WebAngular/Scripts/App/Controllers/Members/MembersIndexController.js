(function () {

    var app = angular.module("shepherdApp");

    app.controller("MembersIndexController", ["$scope", "MemberService", function ($scope, MemberService) {

        $scope.hello = "Hello Angular!";

        $scope.members = MemberService.getMembers();

    }]);

}());