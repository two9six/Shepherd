
'use strict'
app.controller('addMemberSuccessController', ['$scope', '$stateParams', function ($scope, $stateParams) {

    var name = $stateParams.name;

    $scope.vm = {
        name : ''
    };

    $scope.vm.name = name;

}]);