//TODO: write unit tests
'use strict';
app.factory('dateTimeHelpers', [
	'$filter'
	, function ($filter) {

		var getCurrentMonthName = function () {
			var d = new Date();
			return monthEnum.toString(d.getMonth());
		}

		var getCurrentMonth = function () {
			var d = new Date();
			return d.getMonth();
		}

		var getReportDateStamp = function () {
			var d = new Date();
			return $filter('date')(d, 'yyyy_MM_dd');
		}

		return {
			getCurrentMonth: getCurrentMonth,
			getCurrentMonthName: getCurrentMonthName,
			getReportDateStamp: getReportDateStamp
		};
	}]);