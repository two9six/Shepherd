'use strict';
app.controller('dashboardController', [
	  '$scope'
	, '$timeout'
	, 'membersService'
	, (function (
	  $scope
	, $timeout
	, membersService) {

		$scope.monthlyCelebrants = [];

		loadMonthlyCelebrants();

		/////////////////////////////
		////// Local Functions //////
		/////////////////////////////

		function loadMonthlyCelebrants() {
			membersService
				.getMonthlyCelebrants({
					month: 9
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