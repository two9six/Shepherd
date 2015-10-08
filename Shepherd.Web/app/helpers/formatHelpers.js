//TODO: write unit tests
'use strict';
app.factory('formatHelpers', [
	  '$log'
	, '$filter'
	, '$locale'
	, function (
	  $log
	, $filter
	, $locale) {


		var formatShortDate = function (date) {
			return $filter('date')(date, 'M/d/yyyy');
		}

		var formatDate = function (date) {
			return $filter('date')(date, 'MMM dd, yyyy');
		}

		return {
			formatShortDate: formatShortDate,
			formatDate: formatDate
		};
	}])