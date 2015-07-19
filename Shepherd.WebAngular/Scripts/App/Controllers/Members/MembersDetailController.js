(function () {

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
            $scope.member.BirthDate = memberDetail.birthDate;
            $scope.member.DateBaptized = memberDetail.dateBaptized;

            //$scope.members = response.data.members;

        }, function (response) {
            console.log(response);
        });

        $scope.submitForm = function () {

            $scope.$broadcast('show-errors-event');
            if ($scope.memberForm.$invalid) {
                return;
            }
            else {
                console.log("Update Member: " + id);
                $scope.member.Id = id;

                var promise = MemberService.updateMember($scope.member);

                promise.then(function (response) {
                    console.log(response.data);
                    $location.path("/Members");

                }, function (response) {
                    console.log(response);
                });


            }

        }



    }]);

}());