var cis;
var app;

app = angular.module('Shepherd'
	, ['ngRoute'
	, 'ngResource'
	, 'ngSanitize'
	, 'adaptv.adaptStrap'
	, 'ui.bootstrap'
    , 'ui.router'
	]);

(function (cis) {
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
            .state('member', {
            	url: "/member:id",
            	templateUrl: "/app/views/member.html",
            	controller: "memberController"
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
            .state('reports', {
            	url: "/reports",
            	templateUrl: "/app/views/reports.html",
            	controller: "reportsController"
            })
            .state('reports-monthly-celebrants', {
            	url: "/reports-monthly-celebrants",
            	templateUrl: "/app/views/report-monthly-celebrants.html",
            	controller: "reportMonthlyCelebrantsController"
            })
            .state('reports-officers-list', {
            	url: "/reports-officers-list",
            	templateUrl: "/app/views/report-officers-list.html",
            	controller: "reportOfficersListController"
            })
            .state('committees', {
            	url: "/committees",
            	templateUrl: "/app/views/committees.html",
            	controller: "committeesController"
            })
            .state('addMember', {
                url: "/addMember",
                templateUrl: "/app/views/add-member.html",
                controller: "addMemberController"
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
})(cis || (cis = {}));