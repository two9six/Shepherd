'use strict';
app.controller('committeeHeadSelectionModal', [
	  '$scope'
	, '$modalInstance'
	, 'committeesService'
	, 'referencesService'
	, 'committee'
, function (
	  $scope
	, $modalInstance
	, committeesService
	, referencesService
	, committee) {

	$scope.committee = committee;
	$scope.selectedMember = undefined;
	$scope.showOfficersOnly = true;
	$scope.nonMembers = [];
	$scope.nonMembersOptions = [];
	$scope.designations = [];

	referencesService
		.getDesignations()
		.$promise.then(function (data) {
			$scope.designations = data.designations;
		});

	////////////////////
	////// Events //////
	////////////////////

	$scope.showOfficersOnlyChanged = function () {
		filterMembersList();
	}

	$scope.ok = function () {
		$modalInstance.close({
			selectedMember: $scope.selectedMember
		});
	}

	$scope.cancel = function () {
		$modalInstance.dismiss('cancel');
	}

	/////////////////////////////
	////// Members Loading //////
	/////////////////////////////

	function loadMembers() {
		committeesService
			.getNonMembers({ 
				id: committee.id
			})
			.$promise.then(function (data) {
				$scope.nonMembers = data;
				filterMembersList();
			});
	}

	function filterMembersList() {
		$scope.nonMembersOptions.length = 0;

		var filteredOptions = [];
		_.merge(filteredOptions, $scope.nonMembers);

		if ($scope.showOfficersOnly) {
			filteredOptions.forEach(function (d) {
				d.designationTypeId = _.first(_.pluck(_.where($scope.designations, { id: d.designation }), 'designationTypeId'));
			});

			filteredOptions = _.where(filteredOptions, { designationTypeId: designationTypeEnum.officer });
		}

		$scope.nonMembersOptions = _.map(filteredOptions,
			function (d) {
				return { key: d.id, value: d.firstName + ' ' + d.lastName };
			});
		$scope.nonMembersOptions = _.sortBy($scope.nonMembersOptions, 'value');
	}

	loadMembers();
}]);