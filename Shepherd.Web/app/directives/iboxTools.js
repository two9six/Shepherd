/**
 * iboxTools - Directive for iBox tools elements in right corner of ibox
 */
'use strict';
app.directive('iboxTools', ['$timeout', '$location',
function ($timeout) {
	return {
		restrict: 'A',
		scope:
            {
            	allowForceResize: '@',
            	maximizeable: '@',
            	onClose: '=',
            	onMinimize: '=',
            	onExpand: '=',
            	isMinimized: '='
            },
		templateUrl: 'app/templates/ibox_tools.html',
		link: function (scope, element, attributes, ctrl) {
			if (angular.isDefined(attributes.collapsed)) {
				scope.showhide();
			}
		},
		controller: function ($scope, $element) {

			initializeDropdown();

			var allowVisibilityToggle = true;
			var isVisible = true;

			function initializeDropdown() {
				var menuItems = $('[ibox-tools-parent="' + $element[0].id + '"]');
				if (menuItems.length > 0) {
					$element.find("#menu-items").append(menuItems.children());
					menuItems.remove();
				}
				else {
					$element.find('[data-toggle="dropdown"]').remove();
				}
			}

			$scope.$on('forceResize', function () {
				if ($scope.allowForceResize === "true") {
					$scope.showhide();
					$scope.showhide();
				}
			});

			$scope.$on('toggleVisibility', function () {
				if (allowVisibilityToggle) {
					var ibox = $element.closest('div.ibox');
					if (isVisible) ibox.css('display', 'none');
					else ibox.css('display', '');

					isVisible = !isVisible;
				}
			});

			if ($scope.isMinimized != undefined) {
				$scope.$watch('isMinimized', function () {
					var icon = $element.find('i:first');
					if ($scope.isMinimized === true) {
						if (icon.hasClass('fa-chevron-up')) {
							$scope.showhide();
						}
					}

					if ($scope.isMinimized === false) {
						if (icon.hasClass('fa-chevron-down')) {
							$scope.showhide();
						}
					}
				});
			}

			$scope.maximize = function () {
				allowVisibilityToggle = false;
				$scope.$emit('tellControllerToToggleVisibility');
				allowVisibilityToggle = true;

				var ibox = $element.closest('div.ibox');
				ibox.resize();
			}

			// Function for collapse ibox
			$scope.showhide = function () {
				var ibox = $element.closest('div.ibox');
				var icon = $element.find('i:first');
				var content = ibox.find('div.ibox-content');
				content.slideToggle(200);
				// Toggle icon from up to down
				icon.toggleClass('fa-chevron-up').toggleClass('fa-chevron-down');
				ibox.toggleClass('').toggleClass('border-bottom');
				if (icon.hasClass('fa-chevron-down')) {
					if ($scope.isMinimized != undefined) {
						$scope.isMinimized = true;
					}
					if ($scope.onMinimize != undefined) {
						$scope.onMinimize();
					}
				} else {
					if ($scope.isMinimized != undefined) {
						$scope.isMinimized = false;
					}
					if ($scope.onExpand != undefined) {
						$scope.onExpand();
					}
				}
				$timeout(function () {
					ibox.resize();
					ibox.find('[id^=map-]').resize();
				}, 50);
			},
            $scope.showClose = function () {
            	return $scope.onClose != undefined;
            },
			// Function for close ibox
            $scope.closebox = function () {
            	var ibox = $element.closest('div.ibox');
            	ibox.remove();
            	// call callback if provided
            	if ($scope.onClose != undefined) {
            		$scope.onClose();
            	}
            }
		}
	};
}]);