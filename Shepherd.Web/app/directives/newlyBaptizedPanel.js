'use strict';
app.directive('newlyBaptizedPanel', [
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
			templateUrl: 'app/templates/newly-baptized-panel.html',
			scope: {
				newlyBaptizedData: '='
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

				$scope.$on('renderNewlyBaptized', render);

				function render() {
					$scope.members = _.chunk($scope.newlyBaptizedData, rowSize);
				}

			}
		}
	}]);