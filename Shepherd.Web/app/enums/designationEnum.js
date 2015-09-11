designationEnum = {
	member: 1,
	deacon: 2,
	toString: function (value) {
		var result = "";
		switch (value) {
			case 1:
				result = "Member";
				break;
			case 2:
				result = "Deacon";
				break;
			default:
				result = "Unknown Designation: " + value;
		}
		return result;
	}
}