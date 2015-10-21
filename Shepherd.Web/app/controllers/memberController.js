'use strict';
app.controller('memberController', [
	  '$modal'
	, '$scope'
	, '$timeout'
	, '$stateParams'
	, 'membersService'
	, 'formatHelpers'
	, (function (
	  $modal
	, $scope
	, $timeout
	, $stateParams
	, membersService
	, formatHelpers) {
		var memberId = $stateParams.id;
	})
]);