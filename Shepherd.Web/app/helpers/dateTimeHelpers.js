//TODO: write unit tests
'use strict';
app.factory('dateTimeHelpers',
	function () {

		var getCurrentMonth = function () {
			var d = new Date();
			return d.getMonth() + 1;
		}

		return {
			getCurrentMonth: getCurrentMonth
		};
	})