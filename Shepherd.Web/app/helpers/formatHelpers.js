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

		var formatNameWithPrefix = function (name, gender) {
			if (gender != 'M' && gender != 'F') {
				return name;
			}

			return (gender == 'M' ? 'Bro. ' : 'Sis. ') + name
		}

		var formatNameDefault = function (lastName, firstName, nameExtension) {
			return lastName + ', ' + firstName + ' ' + (nameExtension == null || nameExtension == undefined ? '' : nameExtension);
		}

		return {
			formatShortDate: formatShortDate,
			formatDate: formatDate,
			formatNameWithPrefix: formatNameWithPrefix,
			formatNameDefault: formatNameDefault
		};
	}])