memberStatusEnum = {
	active: 1,
	activeOtherLocale: 2,
	activeAbroad: 3,
	inActive: 4,
	suspended: 5,
	excommunicated: 6,
	deceased: 7,
	toString: function (value) {
		var result = "";
		switch (value) {
			case 1:
				result = "Active";
				break;
			case 2:
				result = "Active (Other Locale)";
				break;
			case 3:
				result = "Active (Abroad)";
				break;
			case 4:
			    result = "InActive";
				break;
			case 5:
				result = "Suspended";
				break;
			case 6:
				result = "Excommunicated";
				break;
			case 7:
				result = "Deceased";
				break;
			default:
				result = "Unknown Member Status: " + value;
		}
		return result;
	}
}