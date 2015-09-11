memberStatusEnum = {
	active: 1,
	inActive: 2,
	suspended: 3,
	excommunicated: 4,
	toString: function (value) {
		var result = "";
		switch (value) {
			case 1:
				result = "Active";
				break;
			case 2:
				result = "In-Active";
				break;
			case 3:
				result = "Suspended";
				break;
			case 4:
				result = "Excommunicated";
				break;
			default:
				result = "Unknown Member Status: " + value;
		}
		return result;
	}
}