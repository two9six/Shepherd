'use strict';
app.factory('referencesService', [
	  '$resource'
	, 'baseServiceUrl'
	, function (
	  $resource
	, baseServiceUrl) {
		return $resource(baseServiceUrl + '/api/references/:action', { action: '@action' }, {
			getDesignations: {
				method: 'GET',
				params: {
					action: 'GetDesignations'
				},
				isArray: false
			}
		});
	}
]);