'use strict';
app.factory('enumHelpers', ['$log', function ($log) {

	return {
		convertEnumToKeyValueArray: convertEnumToKeyValueArray,
		convertEnumToIdLabelArray: convertEnumToIdLabelArray
	};

	function convertEnumToKeyValueArray(enm, excludeKeys) {
		var keyValues = [];
		var toString = enm["toString"];

		if (!_.isFunction(toString)) {
			$log.error("'Enum' does not adhere to expected interface!");
			return null;
		}

		for (var prop in enm) {
			if (enm.hasOwnProperty(prop)) {
				var id = enm[prop];
				if (excludeKeys && _.indexOf(excludeKeys, id) >= 0) {
					continue;
				}
				if (_.isNumber(id)) {
					keyValues.push({
						key: id,
						value: toString(id)
					});
				}
			}
		}

		return keyValues;
	};

	function convertEnumToIdLabelArray(enm, excludeKeys) {
		var idValues = [];
		var toString = enm["toString"];

		if (!_.isFunction(toString)) {
			$log.error("'Enum' does not adhere to expected interface!");
			return null;
		}

		for (var prop in enm) {
			if (enm.hasOwnProperty(prop)) {
				var id = enm[prop];
				if (excludeKeys && _.indexOf(excludeKeys, id) >= 0) {
					continue;
				}
				if (_.isNumber(id)) {
					idValues.push({
						id: id,
						label: toString(id)
					});
				}
			}
		}

		return idValues;
	};
}])