maritalStatusEnum = {

    single: 1,
    married: 2,
    widowed: 3,
    toString: function (value) {

        var result = "";
        switch (value) {
            case 1:
                result = "Single";
                break;
            case 2:
                result = "Married";
                break;
            case 3:
                result = "Widowed";
                break;
            default:
                result = "Unknown gender: " + value;
        }

        return result;

    }

}