designationEnum = {
	member: 1,
	deacon: 2,
	deaconess: 3,
	secretary: 4,
	treasurer: 5,
	groupServant: 6,
	auditor: 7,
	trustee: 8,
	committeeHead: 9,
	kktkOfficer: 10,
	toString: function (value) {
		var result = "";
		switch (value) {
			case 1:
				result = "Member";
				break;
			case 2:
				result = "Deacon";
				break;
			case 3:
				result = "Deaconess";
				break;
			case 4:
				result = "Secretary";
				break;
			case 5:
				result = "Treasurer";
				break;
			case 6:
				result = "Group Servant";
				break;
			case 7:
				result = "Auditor";
				break;
			case 8:
				result = "Trustee";
				break;
			case 9:
				result = "Committee Head";
				break;
			case 10:
				result = "KKTK Officer";
				break;
			default:
				result = "Unknown Designation: " + value;
		}
		return result;
	}
}