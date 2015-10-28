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
			}
		});
	}
]);