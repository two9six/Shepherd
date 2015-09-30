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
			scope: {
				monthlyCelebrantsData: '='
			},
			link: function (scope, element, attributes) {

				////////////////
				// Properties //
				////////////////



				////////////
				// Events //
				////////////

				scope.$on('renderMonthlyCelebrants', render);


				function render() {

				}

			}
		}
	}]);