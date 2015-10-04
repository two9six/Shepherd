'use strict';

app.controller('memberAddSuccessModal', [
      '$scope'
    , '$modalInstance'
    , 'member'
    , function (
          $scope
        , $modalInstance
        , member) {


        console.log(member);

        $scope.vm = member;

        $scope.okay = function () {

            $modalInstance.dismiss('okay');

        }



    }]);