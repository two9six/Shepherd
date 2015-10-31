'use strict';
app.controller('committeeHeadSelectionModal', [
	  '$scope'
	, '$modalInstance'
	, 'membersService'
	, 'committee'
, function (
	  $scope
	, $modalInstance
	, membersService
	, committee) {

	$scope.committee = committee;
	$scope.selectedMember = {};

	////////////////////
	////// Events //////
	////////////////////

	$scope.ok = function () {
		$modalInstance.close({
			selectedMember: $scope.selectedMember
		});
	}

	$scope.cancel = function () {
		$modalInstance.dismiss('cancel');
	}

}]);