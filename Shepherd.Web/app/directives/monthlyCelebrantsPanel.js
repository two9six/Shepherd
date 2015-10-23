'use strict';
app.directive('monthlyCelebrantsPanel', [
	  '$window'
	, 'formatHelpers'
	, 'dateTimeHelpers'
	, function (
	  $window
	, formatHelpers
	, dateTimeHelpers) {
		return {
			restrict: 'A',
			replace: false,
			templateUrl: 'app/templates/monthly-celebrants-panel.html',
			scope: {
				monthlyCelebrantsData: '='
			},
			link: function ($scope, element, attributes) {

				////////////////
				// Properties //
				////////////////
				var rowSize = 5;

				$scope.members = [];
				$scope.formatHelpers = formatHelpers;
				$scope.dateTimeHelpers = dateTimeHelpers;
				

				////////////
				// Events //
				////////////

				$scope.$on('renderMonthlyCelebrants', render);

				function render() {
					$scope.members = _.chunk($scope.monthlyCelebrantsData, rowSize);
				}

			}
		}
	}]);