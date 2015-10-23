//TODO: write unit tests
'use strict';
app.factory('dateTimeHelpers',
	function () {

		var getCurrentMonthName = function () {
			var d = new Date();
			return monthEnum.toString(d.getMonth());
		}

		var getCurrentMonth = function () {
			var d = new Date();
			return d.getMonth();
		}

		return {
			getCurrentMonth: getCurrentMonth,
			getCurrentMonthName: getCurrentMonthName
		};
	})