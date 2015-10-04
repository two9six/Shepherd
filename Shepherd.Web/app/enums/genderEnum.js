genderEnum = {

    male: 1,
    female: 2,
    toString: function (value) {

        var result = "";
        switch (value) {
            case 1:
                result = "M";
                break;
            case 2:
                result = "F";
                break;
            default:
                result = "Unknown gender: " + value;
        }

        return result;

    }

}