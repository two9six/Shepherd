'use strict';
app.controller('reportMonthlyCelebrantsController', [
	  '$scope'
	, 'membersService'
	, 'formatHelpers'
	, 'dateTimeHelpers'
	, 'enumHelpers'
	, (function (
	  $scope
	, membersService
	, formatHelpers
	, dateTimeHelpers
	, enumHelpers) {

		$scope.formatHelpers = formatHelpers;
		$scope.members = [];		
		$scope.monthOptions = enumHelpers.convertEnumToKeyValueArray(monthEnum);
		$scope.selectedMonth = dateTimeHelpers.getCurrentMonth();
		$scope.monthEnum = monthEnum;

		////////////////////
		////// Events //////
		////////////////////

		$scope.selectMonth = function ($index) {
			if ($scope.selectedMonth !== $scope.monthOptions[$index].key) {
				$scope.selectedMonth = $scope.monthOptions[$index].key;
				loadMonthlyCelebrants();
			}
		}

		function loadMonthlyCelebrants() {
			membersService
				.getMonthlyCelebrants({
					month: $scope.selectedMonth + 1
				})
				.$promise.then(function (data) {
					$scope.members = data;
				});
		}

		loadMonthlyCelebrants();

	})])