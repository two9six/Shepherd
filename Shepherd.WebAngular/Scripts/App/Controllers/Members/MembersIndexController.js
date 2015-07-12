(function () {

    var app = angular.module("shepherdApp");

    app.controller("MembersIndexController", ["$scope", "MemberService", function ($scope, MemberService) {

        $scope.hello = "Hello Angular!";


        var promise = MemberService.getMembers();

        promise.then(function (response) {
            console.log(response.data);
            $scope.members = response.data.members;
            //$location.path("/Members");

        }, function (response) {
            console.log(response);
        });

        //$scope.members = MemberService.getMembers();

    }]);

}());