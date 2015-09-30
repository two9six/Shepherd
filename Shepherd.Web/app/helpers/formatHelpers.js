'use strict';
//TODO: write tests
app.factory('formatHelpers', [
	  '$log'
	, '$locale'
	, function (
	  $log
	, $locale) {

	// TODO: Implement formatting
	var formatDate = function () {
		return '1';
	}

	return {
		formatDate: formatDate
	};
}])