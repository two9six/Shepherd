'use strict';
app.directive('monthlyCelebrants', [
	  '$window'
	, 'formatHelpers'
	, function (
	  $window
	, formatHelpers) {
		return {
			restrict: 'A',
			replace: false,
			templateUrl: 'app/templates/monthly-celebrants.html',
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