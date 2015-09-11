var sw;
var app;

app = angular.module('Shepherd'
	, ['ngRoute'
	, 'ngResource'
	, 'ngSanitize'
	, 'adaptv.adaptStrap'
	, 'ui.bootstrap'
    , 'ui.router'
	]);

(function (sw) {
	app.config(function ($stateProvider, $urlRouterProvider, $locationProvider) {

		$stateProvider
            .state('dashboard', {
            	url: "/dashboard",
            	templateUrl: "/app/views/dashboard.html",
            	controller: "dashboardController"
            })
            .state('members', {
            	url: "/members",
            	templateUrl: "/app/views/members.html",
            	controller: "membersController"
            })
            .state('file-upload', {
            	url: "/file-upload",
            	templateUrl: "/app/views/file-upload.html",
            	controller: "fileUploadController"
            })
            .state('users', {
            	url: "/users",
            	templateUrl: "/app/views/users.html",
            	controller: "usersController"
            })
            .state('/', {
            	url: "/dashboard",
            	templateUrl: "/app/views/dashboard.html",
            	controller: "dashboardController"
            });

		// TODO: needs more research, removing hashtag on URL makes refreshing problematic

		//$urlRouterProvider.otherwise("/login");
		//$locationProvider.html5Mode({
		//	enabled: true,
		//	requireBase: false
		//});
	});
})(sw || (sw = {}));