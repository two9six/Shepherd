(function () {

    var app = angular.module("shepherdApp");

    app.controller("MembersAddController", ["$scope", "$location", "MemberService", function ($scope, $location, MemberService) {

        $scope.member = {};

        $scope.submitForm = function () {
            
            $scope.$broadcast('show-errors-event');
            if ($scope.memberForm.$invalid) {
                return;
            }
            else {
                console.log("Insert Member: ");
                console.log($scope.member);
                MemberService.insertMember($scope.member);
                $location.path("/Members");
            }

        }
    }]);

}());