'use strict';
app.factory('committeesService', [
	  '$resource'
	, 'baseServiceUrl'
	, function (
	  $resource
	, baseServiceUrl) {
		return $resource(baseServiceUrl + '/api/committees/:action', { action: '@action' }, {
			getCommittees: {
				method: 'GET',
				params: {
					action: ''
				},
				isArray: false
			},
			getNonMembers: {
				method: 'GET',
				params: {
					action: 'GetNonMembers'
				},
				isArray: true
			},
			addCommitteeMember: {
				method: 'POST',
				params: {
					action: 'AddCommitteeMember'
				},
				isArray: false
			},
			deleteCommitteeMember: {
				method: 'POST',
				params: {
					action: 'DeleteCommitteeMember'
				},
				isArray: false
			},
		});
	}
]);