/// <reference path="typings/jquery/jquery.d.ts"/> 
var Shepherd;
(function (Shepherd) {
    Shepherd.Constants = Shepherd.Constants || {};
    var Utility = (function () {
        function Utility() {
        }
        Utility.getType = function (value) {
            return Object.prototype.toString.call(value);
        };
        Utility.isValidObject = function (value) {
            return value !== void 0 && value !== null;
        };
        Utility.isJQueryObject = function (value) {
            return Shepherd.Utility.isValidObject(value) && Shepherd.Utility.isValidObject(value.jquery);
        };
        Utility.isFunction = function (value) {
            return jQuery.isFunction(value);
        };
        Utility.isString = function (value) {
            return Shepherd.Utility.isValidObject(value) && Shepherd.Utility.getType(value) === '[object String]';
        };
        Utility.isInteger = function (value) {
            return Shepherd.Utility.isValidObject(value) && Shepherd.Utility.getType(value) === '[object Number]' && window.isNaN(+value) === false && (+value) % 1 === 0;
        };
        Utility.isFloat = function (value) {
            return Shepherd.Utility.isValidObject(value) && Shepherd.Utility.getType(value) === '[object Number]' && window.isNaN(+value) === false;
        };
        Utility.isBoolean = function (value) {
            return Shepherd.Utility.isValidObject(value) && Shepherd.Utility.getType(value) === '[object Boolean]';
        };
        Utility.isArray = function (value) {
            return Shepherd.Utility.isValidObject(value) && Shepherd.Utility.getType(value) === '[object Array]';
        };
        Utility.isValidString = function (value) {
            return Shepherd.Utility.isString(value) && value.length !== 0;
        };
        Utility.isValidInteger = function (value) {
            return Shepherd.Utility.isInteger(value) || (Shepherd.Utility.isValidString(value) && Shepherd.Utility.integerRegExp.test(value + ""));
        };
        Utility.parseInteger = function (value) {
            if (Shepherd.Utility.isValidInteger(value) === false) {
                return null;
            }
            if (Shepherd.Utility.isValidString(value) === false) {
                return Shepherd.Utility.isInteger(value) ? value : null;
            }
            return parseInt(value.replace(/[^0-9\.]/g, ''), 10);
        };
        Utility.isValidFloat = function (value) {
            return Shepherd.Utility.isFloat(value) || (Shepherd.Utility.isValidString(value) && Shepherd.Utility.floatRegExp.test(value));
        };
        Utility.parseFloat = function (value) {
            if (Shepherd.Utility.isValidFloat(value) === false) {
                return null;
            }
            if (Shepherd.Utility.isValidString(value) === false) {
                return Shepherd.Utility.isFloat(value) ? value : null;
            }
            return window.parseFloat((value + '').replace(/[^0-9\.]/g, ''));
        };
        Utility.isValidBoolean = function (value) {
            return Shepherd.Utility.isBoolean(value) || (Shepherd.Utility.isValidString(value) && Shepherd.Utility.booleanRegExp.test(value));
        };
        Utility.parseBoolean = function (value) {
            if (Shepherd.Utility.isValidBoolean(value) === false) {
                return null;
            }
            if (Shepherd.Utility.isValidString(value) === false) {
                return Shepherd.Utility.isBoolean(value) ? value : null;
            }
            return Shepherd.Utility.trueBooleanRegExp.test(value);
        };
        Utility.padString = function (value, padding, length, addToStart) {
            var i = 0, pad = '', s;
            if (Shepherd.Utility.isValidObject(value) === false || Shepherd.Utility.isValidInteger(length) === false || length <= 0) {
                return '';
            }
            if (Shepherd.Utility.isValidString(padding) === false) {
                return value;
            }
            for (; i < length; i++) {
                pad += padding;
            }
            if (addToStart || Shepherd.Utility.isBoolean(addToStart) === false) {
                s = pad + value;
                i = s.length - length;
                return s.substring(i);
            }
            s = value + pad;
            return s.substring(0, length);
        };
        Utility.isValidCurrency = function (value) {
            return Shepherd.Utility.isValidFloat(value) || (Shepherd.Utility.isValidString(value) && Shepherd.Utility.currencyRegExp.test(value));
        };
        Utility.formatFloatAsCurrency = function (value) {
            if (Shepherd.Utility.isValidFloat(value) === false) {
                return '';
            }
            if (value < 0) {
                return '$(' + Shepherd.Utility.formatFloatAsCurrency(-1 * value).replace('$', '') + ')';
            }
            return "$" + (+value).toFixed(2).replace(/^(\d{1,3})(\d{3})(\d{3})(\.\d{2})$/, "$1,$2,$3$4").replace(/^(\d{1,3})(\d{3})(\.\d{2})$/, "$1,$2$3");
        };
        Utility.formatCurrency = function (value) {
            return Shepherd.Utility.isFloat(value) ? Shepherd.Utility.formatFloatAsCurrency(+value) : Shepherd.Utility.isValidCurrency(value) ? Shepherd.Utility.formatFloatAsCurrency(Shepherd.Utility.parseCurrency(value)) : '';
        };
        Utility.parseCurrency = function (value) {
            if (Shepherd.Utility.isValidFloat(value)) {
                return Shepherd.Utility.parseFloat(value);
            }
            if (!Shepherd.Utility.isValidString(value)) {
                return null;
            }
            value = value + '';
            var isNegative = /[\(\-]/.test(value), value = value.replace(/[\(\)\-\$]/g, '');
            if (!Shepherd.Utility.isValidFloat(value)) {
                return null;
            }
            return (isNegative ? -1 : 1) * Shepherd.Utility.parseFloat(value);
        };
        Utility.isDate = function (value) {
            return Shepherd.Utility.isValidObject(value) && Shepherd.Utility.getType(value) === '[object Date]' && window.isNaN(value) === false && Object.prototype.toString.call(value) === '[object Date]';
        };
        Utility.isValidDate = function (value) {
            return Shepherd.Utility.isDate(value) || (Shepherd.Utility.isValidString(value) && Shepherd.Utility.dateRegExp.test(value));
        };
        Utility.formatDate = function (value) {
            if (Shepherd.Utility.isDate(value)) {
                return "{0}/{1}/{2}".replace('{0}', (value.getMonth() + 1).toString()).replace('{1}', value.getDate().toString()).replace('{2}', value.getFullYear().toString());
            }
            if (Shepherd.Utility.isValidDate(value)) {
                return Shepherd.Utility.formatDate(Shepherd.Utility.parseDate(value));
            }
            return '';
        };
        Utility.parseDate = function (value) {
            var matches, year, month, day, date = value;
            if (Shepherd.Utility.isValidString(value) && !Shepherd.Utility.isDate(value) && !Shepherd.Utility.isValidInteger(value) && !Shepherd.Utility.isValidFloat(value)) {
                date = new Date(Date.parse(value));
            }
            if (Shepherd.Utility.isDate(date)) {
                return date;
            }
            date = null;
            if (Shepherd.Utility.isValidDate(value) === false) {
                return date;
            }
            if (Shepherd.Utility.isValidString(value)) {
                matches = Shepherd.Utility.dateRegExp.exec(value);
                if (matches.length === 4) {
                    month = Shepherd.Utility.parseInteger(matches[1]);
                    day = Shepherd.Utility.parseInteger(matches[2]);
                    year = Shepherd.Utility.parseInteger(matches[3]);
                    if (year < 100) {
                        year = Shepherd.Utility.twoDigitYears[year];
                    }
                    return new Date(year, month - 1, day);
                }
            }
            // This bit of code is never reached. It is left in to make the TS compiler happy that we always return a value.
            return date;
        };
        Utility.today = function () {
            var t = new Date();
            t.setHours(0, 0, 0, 0);
            return t;
        };
        Utility.todayFormatted = function () {
            var t = Shepherd.Utility.today();
            return Shepherd.Utility.formatDate(t);
        };
        Utility.firstOfMonth = function (dateOrMonth, year) {
            if (Shepherd.Utility.isInteger(year) && Shepherd.Utility.isInteger(dateOrMonth)) {
                return new Date(year, dateOrMonth, 1);
            }
            if (Shepherd.Utility.isDate(dateOrMonth)) {
                dateOrMonth.setDate(1);
                dateOrMonth.setHours(0, 0, 0, 0);
                return dateOrMonth;
            }
            return undefined;
        };
        Utility.lastOfMonth = function (dateOrMonth, year) {
            var args = Array.prototype.slice.apply(arguments), dim = Shepherd.Utility.daysInMonth.apply(null, args), fom = Shepherd.Utility.firstOfMonth.apply(null, args);
            return Shepherd.Utility.isDate(fom) && Shepherd.Utility.isInteger(dim) ? new Date(fom.getFullYear(), fom.getMonth(), dim) : undefined;
        };
        Utility.daysInMonth = function (dateOrMonth, year) {
            var month, yearInternal;
            if (Shepherd.Utility.isInteger(year) && Shepherd.Utility.isInteger(dateOrMonth)) {
                month = dateOrMonth;
                yearInternal = year;
            }
            if (Shepherd.Utility.isDate(dateOrMonth)) {
                month = dateOrMonth.getMonth();
                yearInternal = dateOrMonth.getFullYear();
            }
            if (Shepherd.Utility.isInteger(month)) {
                if (month === 1) {
                    return (yearInternal % 4 === 0 && yearInternal % 100 !== 0) || yearInternal % 400 === 0 ? 29 : 28;
                }
                return Shepherd.Utility.daysInMonthList[month];
            }
            return undefined;
        };
        Utility.all = function (array, callback) {
            if (array.every) {
                return array.every(callback);
            }
            return $.grep(array, callback, false).length === array.length;
        };
        Utility.any = function (array, callback) {
            if (array.some) {
                return array.some(callback);
            }
            return $.grep(array, callback, false).length !== 0;
        };
        Utility.getCurrentUrl = function () {
            return window.location.href;
        };
        Utility.redirectToUrl = function (url) {
            if (Shepherd.Utility.isValidString(url)) {
                //amplify.publish('navigating-away');
                window.location.href = url;
            }
        };
        Utility.readCookie = function (name) {
            var nameEQ = name + "=";
            var ca = document.cookie.split(';');
            for (var i = 0; i < ca.length; i++) {
                var c = ca[i];
                while (c.charAt(0) == ' ')
                    c = c.substring(1, c.length);
                if (c.indexOf(nameEQ) == 0)
                    return c.substring(nameEQ.length, c.length);
            }
            return null;
        };
        Utility.createCookie = function (name, value) {
            document.cookie = name + "=" + value + "; path=/";
        };
        Utility.getCssClassName = function (value) {
            if (!Shepherd.Utility.isValidString(value)) {
                return '';
            }
            var first = value[0].toLowerCase(), rest = value.substring(1), result = rest, matches;
            while ((matches = /[A-Z]/g.exec(result)) !== null) {
                result = result.replace(matches[0], '-' + matches[0].toLowerCase());
            }
            return first + result;
        };
        Utility.compareDates = function (date1, date2, smallestDatePart) {
            var diff = 0;
            switch (smallestDatePart) {
                case 'y':
                    diff = date1.getFullYear() - date2.getFullYear();
                    break;
                case 'M':
                    diff = (date1.getFullYear() - date2.getFullYear()) * 100;
                    diff += date1.getMonth() - date2.getMonth();
                    break;
                case 'd':
                    diff = (date1.getFullYear() - date2.getFullYear()) * 1000;
                    diff += (date1.getMonth() - date2.getMonth()) * 100;
                    diff += date1.getDate() - date2.getDate();
                    break;
            }
            return diff === 0 ? 0 : diff < 0 ? -1 : 1;
        };
        Utility.integerRegExp = /^([0-9]{1,3}|[1-9][0-9]{1,2})(((,?[0-9]{3})*)?)$/;
        Utility.zipCodeRegExp = /^([0-9]{5})\-?([0-9]{4})?$/;
        Utility.phoneRegExp = /^([^0-9]*)([0-9]{3})?([^0-9]*)([0-9]{3})([^0-9]*)([0-9]{4})$/;
        Utility.floatRegExp = /^([0-9]|[1-9][0-9]{1,2})?(((,?[0-9]{3})*)?(\.[0-9]+)?)$/;
        Utility.currencyRegExp = /^(\(|\-)?\$?(\(|\-)?([0-9]|[1-9][0-9]{1,2})?(((,?([0-9]{3}))*)?(\.[0-9]{2})?)(\)?)$/;
        Utility.dateRegExp = /^([0-9]|0[0-9]|1[0-2])[\/\-]([0-9]|[0-2][0-9]|3[01])[\/\-]([0-9]{2}|[0-9]{4})$/;
        Utility.booleanRegExp = /^([Tt]rue|[Ff]alse|[Yy]es|[Nn]o|[Oo](n|ff))$/;
        Utility.trueBooleanRegExp = /^([Tt]rue|[Yy]es|[Oo]n)$/;
        Utility.daysInMonthList = [
            31,
            28,
            31,
            30,
            31,
            30,
            31,
            31,
            30,
            31,
            30,
            31
        ];
        Utility.twoDigitYears = [
            1930,
            1931,
            1932,
            1933,
            1934,
            1935,
            1936,
            1937,
            1938,
            1939,
            1940,
            1941,
            1942,
            1943,
            1944,
            1945,
            1946,
            1947,
            1948,
            1949,
            1950,
            1951,
            1952,
            1953,
            1954,
            1955,
            1956,
            1957,
            1958,
            1959,
            1960,
            1961,
            1962,
            1963,
            1964,
            1965,
            1966,
            1967,
            1968,
            1969,
            1970,
            1971,
            1972,
            1973,
            1974,
            1975,
            1976,
            1977,
            1978,
            1979,
            1980,
            1981,
            1982,
            1983,
            1984,
            1985,
            1986,
            1987,
            1988,
            1989,
            1990,
            1991,
            1992,
            1993,
            1994,
            1995,
            1996,
            1997,
            1998,
            1999,
            2000,
            2001,
            2002,
            2003,
            2004,
            2005,
            2006,
            2007,
            2008,
            2009,
            2010,
            2011,
            2012,
            2013,
            2014,
            2015,
            2016,
            2017,
            2018,
            2019,
            2020,
            2021,
            2022,
            2023,
            2024,
            2025,
            2026,
            2027,
            2028,
            2029
        ];
        return Utility;
    })();
    Shepherd.Utility = Utility;
})(Shepherd || (Shepherd = {}));
//# sourceMappingURL=Shepherd.js.map