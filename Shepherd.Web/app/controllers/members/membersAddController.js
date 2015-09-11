'use strict';
app.controller("MembersAddController", ["$scope", "$location", "MemberService", function ($scope, $location, MemberService) {

    $scope.member = {};

    $scope.submitForm = function () {
            
        $scope.$broadcast('show-errors-event');
        if ($scope.memberForm.$invalid) {
            return;
        }
        else {
            console.log("Insert Member: ");
            var promise = MemberService.insertMember($scope.member);

            promise.then(function (response) {
                console.log(response.data);
                $location.path("/Members");

            }, function (response) {
                console.log(response);
            });

                
        }

    }
}]);