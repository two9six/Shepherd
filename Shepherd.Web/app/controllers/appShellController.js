'use strict';
app.controller('appShellController', [
      '$scope'
    , '$location'
    , 'environmentName'
    , function (
      $scope
    , $location
    , environmentName) {

    $scope.environmentName = environmentName;

    $scope.showGlobalErrorDialog = false;
    $scope.test = 'Hello World'

    $scope.isActive = function (viewPath) {
    	return $location.path().indexOf(viewPath) == 0;
    };

    $scope.bodyClass = function () {
    	return "show-scrollbar";
    }

}]);