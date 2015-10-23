monthEnum = {
    january: 0,
    february: 1,
    march: 2,
    april: 3,
    may: 4,
    june: 5,
    july: 6,
    august: 7,
    september: 8,
    october: 9,
    november: 10,
    december: 11,
    toString: function (value) {
        var result = "";
        switch (value) {
            case 0:
                result = "January";
                break;
            case 1:
                result = "February";
                break;
        	case 2:
        		result = "March";
        		break;
        	case 3:
        		result = "April";
        		break;
        	case 4:
        		result = "May";
        		break;
        	case 5:
        		result = "June";
        		break;
        	case 6:
        		result = "July";
        		break;
        	case 7:
        		result = "August";
        		break;
        	case 8:
        		result = "September";
        		break;
        	case 9:
        		result = "October";
        		break;
        	case 10:
        		result = "November";
        		break;
        	case 11:
        		result = "December";
        		break;
            default:
                result = "Unknown month: " + value;
        }

        return result;
    }

}