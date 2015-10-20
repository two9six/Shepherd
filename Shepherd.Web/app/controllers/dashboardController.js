'use strict';
app.controller('dashboardController', [
	  '$scope'
	, '$timeout'
	, 'membersService'
	, 'dateTimeHelpers'
	, (function (
	  $scope
	, $timeout
	, membersService
	, dateTimeHelpers) {

		$scope.monthlyCelebrants = [];

		loadMonthlyCelebrants();

		/////////////////////////////
		////// Local Functions //////
		/////////////////////////////

		function loadMonthlyCelebrants() {
			membersService
				.getMonthlyCelebrants({
					month: dateTimeHelpers.getCurrentMonth()
				})
				.$promise.then(function (data) {
					$scope.monthlyCelebrants = data;

					renderMonthlyCelebrants();
				});
		}

		function renderMonthlyCelebrants() {
			$timeout(function () {
				$scope.$broadcast('renderMonthlyCelebrants');
			}, 0);
		}

	})
]);