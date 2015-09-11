'use strict';
app.controller('memberAddModal', [
	  '$scope'
	, '$modalInstance'
	, 'membersService'
	, function (
		  $scope
		, $modalInstance
		, membersService) {
		$scope.addMemberValidationMessage = '';

		$scope.isSaveButtonDisabled = function () {
			if (false) {
				$scope.addMemberValidationMessage = 'blah blah blah';
				return true;
			}

			$scope.addMemberValidationMessage = '';
			return false;
		};

		$scope.cancel = function () {
			$modalInstance.dismiss('cancel');
		};

	}]);