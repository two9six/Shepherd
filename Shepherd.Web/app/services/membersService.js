'use strict';
app.factory('membersService', [
	  '$resource'
	, 'baseServiceUrl'
	, function (
	  $resource
	, baseServiceUrl) {
		return $resource(baseServiceUrl + '/api/members/:action', { action: '@action' }, {
			getMembers: {
				method: 'GET',
				params: {
					action: ''
				},
				isArray: false
			},

			createMember: {
				method: 'POST',
				isArray: false
			},

			getMonthlyCelebrants: {
				method: 'GET',
				params: {
					action: 'GetMonthlyCelebrants'
				},
				isArray: true
			}

		});
	}
]);