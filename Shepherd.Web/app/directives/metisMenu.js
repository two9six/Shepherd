'use strict';
app.directive('metisMenu', function () {
	return {
		restrict: 'A',
		link: function (scope, element, attrs) {
			angular.element(element).metisMenu();
		}
	};
});