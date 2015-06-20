(function () {

    var app = angular.module("shepherdApp");

    app.controller("MembersDetailController", ["$scope", "$location", "$routeParams", "MemberService", function ($scope, $location, $routeParams, MemberService) {


        var id = $routeParams.id;
        
        $scope.member = MemberService.getMemberById(id);

    }]);

}());