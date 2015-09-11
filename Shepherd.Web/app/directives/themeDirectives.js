/**
 * INSPINIA - Responsive Admin Theme
 * Copyright 2014 Webapplayers.com
 */


/**
 * pageTitle - Directive for set Page title - mata title
 */
//TODO: this code is not minification safe - needs dependencies injected e.g. ['$rootScope','$timeout', function($rootScope, $timeout){ ..etc...
function pageTitle($rootScope, $timeout) {
	return {
		link: function (scope, element) {
			var listener = function (event, toState, toParams, fromState, fromParams) {
				var title = 'BCG B2B Pricing';
				// Create your own title pattern
				if (toState.data && toState.data.pageTitle) title = 'BCG B2B Pricing | ' + toState.data.pageTitle;
				$timeout(function () {
					element.text(title);
				});
			};
			$rootScope.$on('$stateChangeStart', listener);
		}
	}
};

/**
 * sideNavigation - Directive for run metsiMenu on sidebar navigation
 */
function sideNavigation() {
	return {
		restrict: 'A',
		link: function (scope, element) {
			// Call the metsiMenu plugin and plug it to sidebar navigation
			element.metisMenu();
		}
	};
};

/**
 * minimalizaSidebar - Directive for minimalize sidebar
*/
function minimalizaSidebar($timeout, $rootScope) {
	return {
		restrict: 'A',
		template: '<a class="navbar-minimalize minimalize-styl-2 btn btn-primary " href="" ng-click="minimalize()"><i class="fa fa-bars"></i></a>',
		controller: function ($scope, $element) {

			$scope.minimalize = function () {
				$("body").toggleClass("mini-navbar");
				if (!$('body').hasClass('mini-navbar') || $('body').hasClass('body-small')) {
					// Hide menu in order to smoothly turn on when maximize menu
					$('#side-menu').hide();
					// For smoothly turn on menu
					$timeout(function () {
						$('#side-menu').fadeIn(500);
					}, 100);
				} else {
					// Remove all inline style from jquery fadeIn function to reset menu state
					$('#side-menu').removeAttr('style');
				}
			}

			$rootScope.$on('$stateChangeSuccess', function () {
				if (document.documentElement.clientWidth > 1370) {
					//showFullMenu();
				} else {
					if (!$('body').hasClass('mini-navbar') || $('body').hasClass('body-small')) {
						$("body").toggleClass("mini-navbar");
						// Hide menu in order to smoothly turn on when maximize menu
						$('#side-menu').hide();
						// For smoothly turn on menu
						$timeout(function () {
							$('#side-menu').fadeIn(500);
						}, 100);
					}
				}
			});

			function showFullMenu() {
				if ($('body').hasClass('mini-navbar')) {
					$scope.minimalize();
				}
			}

			showFullMenu();
		}
	};
};

/**
 *
 * Pass all functions into module
 */
angular
    .module('Shepherd')
    .directive('pageTitle', pageTitle)
    .directive('sideNavigation', sideNavigation)
    .directive('minimalizaSidebar', minimalizaSidebar);
