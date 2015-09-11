'use strict';
app.controller("MembersIndexController", ["$scope", "MemberService", function ($scope, MemberService) {
    $scope.hello = "Hello Angular!";


    var promise = MemberService.getMembers();

    promise.then(function (response) {
        console.log(response.data);
        //$scope.members = response.data.members;
        //$location.path("/Members");


        $scope.models = {
            changeInfo: [],
            searchText: '',
            selectedMembers: [],
            members: response.data.members
        };

        $scope.membersTableColumnDefinition = [
            {
                columnHeaderDisplayName: 'Firstname',
                displayProperty: 'firstName',
                sortKey: 'firstName',
                columnSearchProperty: 'firstName',
                visible: true
            },
            {
                columnHeaderDisplayName: 'Lastname',
                displayProperty: 'lastName',
                sortKey: 'lastName',
                columnSearchProperty: 'lastName',
                visible: true
            },
            {
                columnHeaderDisplayName: 'Status',
                displayProperty: 'status',
                sortKey: 'status',
                columnSearchProperty: 'status',
                visible: true
            }
        ];



    }, function (response) {
        console.log(response);
    });

    //$scope.members = MemberService.getMembers();

}]);