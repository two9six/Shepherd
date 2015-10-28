'use strict';
app.factory('reportsService', [
	  '$resource'
	, 'baseServiceUrl'
	, function (
	  $resource
	, baseServiceUrl) {
		return $resource(baseServiceUrl + '/api/reports/:action', { action: '@action' }, {
			getOfficersList: {
				method: 'GET',
				params: {
					action: 'GetOfficersList'
				},
				isArray: true
			}
		});
	}
]);