designationTypeEnum = {
	member: 1,
	officer: 2,
	worker: 3,
	toString: function (value) {
		var result = "";
		switch (value) {
			case 1:
				result = "Member";
				break;
			case 2:
				result = "Officer";
				break;
			case 3:
				result = "Worker";
				break;
			default:
				result = "Unknown Designation Type: " + value;
		}
		return result;
	}
}