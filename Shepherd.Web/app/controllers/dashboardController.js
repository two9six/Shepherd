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

		$scope.monthlyCelebrantsData = [];
		$scope.newlyBaptizedData = [];

		loadPanels();

		/////////////////////////////
		////// Local Functions //////
		/////////////////////////////

		function loadPanels() {
			loadMonthlyCelebrants();
			//loadNewlyBaptized();
		}

		function loadMonthlyCelebrants() {
			membersService
				.getMonthlyCelebrants({
					month: dateTimeHelpers.getCurrentMonth() + 1
				})
				.$promise.then(function (data) {
					$scope.monthlyCelebrantsData = data;

					$timeout(function () {
						$scope.$broadcast('renderMonthlyCelebrants');
					}, 1000);

					loadNewlyBaptized();
				});
		}

		function loadNewlyBaptized() {
			var monthlyThreshold = 3; // TODO: Should be in web.config or settings table

			membersService
				.getNewlyBaptized({
					monthThreshold: monthlyThreshold
				})
				.$promise.then(function (data) {
					$scope.newlyBaptizedData = data;

					$timeout(function () {
						$scope.$broadcast('renderNewlyBaptized');
					}, 1000);
				});
		}

	})
]);