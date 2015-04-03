/// <reference path="typings/jquery/jquery.d.ts"/> 
module Shepherd {
	export var Constants: any = Shepherd.Constants || {};
	export class Utility {
		static integerRegExp: RegExp = /^([0-9]{1,3}|[1-9][0-9]{1,2})(((,?[0-9]{3})*)?)$/;
		static zipCodeRegExp: RegExp = /^([0-9]{5})\-?([0-9]{4})?$/;
		static phoneRegExp: RegExp = /^([^0-9]*)([0-9]{3})?([^0-9]*)([0-9]{3})([^0-9]*)([0-9]{4})$/;
		static floatRegExp: RegExp = /^([0-9]|[1-9][0-9]{1,2})?(((,?[0-9]{3})*)?(\.[0-9]+)?)$/;
		static currencyRegExp: RegExp = /^(\(|\-)?\$?(\(|\-)?([0-9]|[1-9][0-9]{1,2})?(((,?([0-9]{3}))*)?(\.[0-9]{2})?)(\)?)$/;
		static dateRegExp: RegExp = /^([0-9]|0[0-9]|1[0-2])[\/\-]([0-9]|[0-2][0-9]|3[01])[\/\-]([0-9]{2}|[0-9]{4})$/;
		static booleanRegExp: RegExp = /^([Tt]rue|[Ff]alse|[Yy]es|[Nn]o|[Oo](n|ff))$/;
		static trueBooleanRegExp: RegExp = /^([Tt]rue|[Yy]es|[Oo]n)$/;
		static daysInMonthList: number[] = [
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
		static twoDigitYears: number[] = [
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
		static getType(value: any): string {
			return Object.prototype.toString.call(value);
		}

		static isValidObject(value: any): boolean {
			return value !== void 0 && value !== null;
		}

		static isJQueryObject(value: any): boolean {
			return Shepherd.Utility.isValidObject(value) && Shepherd.Utility.isValidObject(value.jquery);
		}

		static isFunction(value: any): boolean {
			return jQuery.isFunction(value);
		}

		static isString(value: any): boolean {
			return Shepherd.Utility.isValidObject(value) && Shepherd.Utility.getType(value) === '[object String]';
		}

		static isInteger(value: any): boolean {
			return Shepherd.Utility.isValidObject(value) && Shepherd.Utility.getType(value) === '[object Number]' && (<any>window).isNaN(+value) === false && (+value) % 1 === 0;
		}

		static isFloat(value: any): boolean {
			return Shepherd.Utility.isValidObject(value) && Shepherd.Utility.getType(value) === '[object Number]' && (<any>window).isNaN(+value) === false;
		}
		static isBoolean(value: any): boolean {
			return Shepherd.Utility.isValidObject(value) && Shepherd.Utility.getType(value) === '[object Boolean]';
		}

		static isArray(value: any): boolean {
			return Shepherd.Utility.isValidObject(value) && Shepherd.Utility.getType(value) === '[object Array]';
		}

		static isValidString(value: any): boolean {
			return Shepherd.Utility.isString(value) && value.length !== 0;
		}

		static isValidInteger(value: any): boolean {
			return Shepherd.Utility.isInteger(value) || (Shepherd.Utility.isValidString(value) && Shepherd.Utility.integerRegExp.test(value + ""));
		}

		static parseInteger(value: any): number {
			if (Shepherd.Utility.isValidInteger(value) === false) {
				return null;
			}
			if (Shepherd.Utility.isValidString(value) === false) {
				return Shepherd.Utility.isInteger(value) ? value : null;
			}

			return parseInt(value.replace(/[^0-9\.]/g, ''), 10);
		}

		static isValidFloat(value: any): boolean {
			return Shepherd.Utility.isFloat(value) || (Shepherd.Utility.isValidString(value) && Shepherd.Utility.floatRegExp.test(value));
		}

		static parseFloat(value: any): number {
			if (Shepherd.Utility.isValidFloat(value) === false) {
				return null;
			}
			if (Shepherd.Utility.isValidString(value) === false) {
				return Shepherd.Utility.isFloat(value) ? value : null;
			}

			return (<any>window).parseFloat((value + '').replace(/[^0-9\.]/g, ''));
		}

		static isValidBoolean(value: any): boolean {
			return Shepherd.Utility.isBoolean(value) || (Shepherd.Utility.isValidString(value) && Shepherd.Utility.booleanRegExp.test(value));
		}

		static parseBoolean(value: any): boolean {
			if (Shepherd.Utility.isValidBoolean(value) === false) {
				return null;
			}

			if (Shepherd.Utility.isValidString(value) === false) {
				return Shepherd.Utility.isBoolean(value) ? value : null;
			}

			return Shepherd.Utility.trueBooleanRegExp.test(value);
		}

		static padString(value: any, padding: string, length: number, addToStart?: boolean): string {
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
		}

		static isValidCurrency(value: any): boolean {
			return Shepherd.Utility.isValidFloat(value) || (Shepherd.Utility.isValidString(value) && Shepherd.Utility.currencyRegExp.test(value));
		}

		static formatFloatAsCurrency(value: number): string {
			if (Shepherd.Utility.isValidFloat(value) === false) {
				return '';
			}

			if (value < 0) {
				return '$(' + Shepherd.Utility.formatFloatAsCurrency(-1 * value).replace('$', '') + ')';
			}

			return "$" + (+value).toFixed(2).replace(/^(\d{1,3})(\d{3})(\d{3})(\.\d{2})$/, "$1,$2,$3$4").replace(/^(\d{1,3})(\d{3})(\.\d{2})$/, "$1,$2$3");
		}

		static formatCurrency(value: any): string {
			return Shepherd.Utility.isFloat(value)
				? Shepherd.Utility.formatFloatAsCurrency(+value)
				: Shepherd.Utility.isValidCurrency(value)
				? Shepherd.Utility.formatFloatAsCurrency(Shepherd.Utility.parseCurrency(value))
				: '';
		}

		static parseCurrency(value: any): number {
			if (Shepherd.Utility.isValidFloat(value)) {
				return Shepherd.Utility.parseFloat(value);
			}

			if (!Shepherd.Utility.isValidString(value)) {
				return null;
			}

			value = value + '';
			var isNegative = /[\(\-]/.test(value),
				value = value.replace(/[\(\)\-\$]/g, '');
			if (!Shepherd.Utility.isValidFloat(value)) {
				return null;
			}

			return (isNegative ? -1 : 1) * Shepherd.Utility.parseFloat(value);
		}

		static isDate(value: any): boolean {
			return Shepherd.Utility.isValidObject(value) &&
				Shepherd.Utility.getType(value) === '[object Date]' &&
				(<any>window).isNaN(value) === false &&
				Object.prototype.toString.call(value) === '[object Date]';
		}

		static isValidDate(value: any): boolean {
			return Shepherd.Utility.isDate(value) ||
				(Shepherd.Utility.isValidString(value) && Shepherd.Utility.dateRegExp.test(value));
		}

		static formatDate(value: any): string {
			if (Shepherd.Utility.isDate(value)) {
				return "{0}/{1}/{2}".replace('{0}', (value.getMonth() + 1).toString()).replace('{1}', value.getDate().toString()).replace('{2}', value.getFullYear().toString());
			}
			if (Shepherd.Utility.isValidDate(value)) {
				return Shepherd.Utility.formatDate(Shepherd.Utility.parseDate(value));
			}

			return '';
		}

		static parseDate(value: any): Date {
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
		}

		static today(): Date {
			var t = new Date();
			t.setHours(0, 0, 0, 0);
			return t;
		}

		static todayFormatted(): string {
			var t = Shepherd.Utility.today();
			return Shepherd.Utility.formatDate(t);
		}

		static firstOfMonth(date: Date): Date;
		static firstOfMonth(month: number, year: number): Date;
		static firstOfMonth(dateOrMonth: any, year?: number) {
			if (Shepherd.Utility.isInteger(year) &&
				Shepherd.Utility.isInteger(dateOrMonth)) {
				return new Date(year, dateOrMonth, 1);
			}
			if (Shepherd.Utility.isDate(dateOrMonth)) {
				dateOrMonth.setDate(1);
				dateOrMonth.setHours(0, 0, 0, 0);
				return dateOrMonth;
			}

			return undefined;
		}

		static lastOfMonth(date: Date): Date;
		static lastOfMonth(month: number, year: number): Date;
		static lastOfMonth(dateOrMonth: any, year?: number): Date {
			var args = Array.prototype.slice.apply(arguments),
				dim = Shepherd.Utility.daysInMonth.apply(null, args),
				fom = Shepherd.Utility.firstOfMonth.apply(null, args);
			return Shepherd.Utility.isDate(fom) &&
				Shepherd.Utility.isInteger(dim)
				? new Date(fom.getFullYear(), fom.getMonth(), dim)
				: undefined;
		}

		static daysInMonth(date: Date): number;
		static daysInMonth(month: number, year: number): number;
		static daysInMonth(dateOrMonth: any, year?: number): number {
			var month: any, yearInternal: any;
			if (Shepherd.Utility.isInteger(year) &&
				Shepherd.Utility.isInteger(dateOrMonth)) {
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
		}

		static all<T>(array: T[], callback: (element: T, index?: number, array?: T[]) => boolean): boolean {
			if (array.every) {
				return array.every(callback);
			}

			return $.grep(array, callback, false).length === array.length;
		}
		static any<T>(array: T[], callback: (element: T, index?: number, array?: T[]) => boolean): boolean {
			if (array.some) {
				return array.some(callback);
			}

			return $.grep(array, callback, false).length !== 0;
		}

		static getCurrentUrl(): string {
			return window.location.href;
		}
		static redirectToUrl(url: string): void {
			if (Shepherd.Utility.isValidString(url)) {
				//amplify.publish('navigating-away');
				window.location.href = url;
			}
		}

		static readCookie(name): string {
			var nameEQ = name + "=";
			var ca = document.cookie.split(';');
			for (var i = 0; i < ca.length; i++) {
				var c = ca[i];
				while (c.charAt(0) == ' ') c = c.substring(1, c.length);
				if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length, c.length);
			}
			return null;
		}
		static createCookie(name, value): void {
			document.cookie = name + "=" + value + "; path=/";
		}

		static getCssClassName(value: string): string {
			if (!Shepherd.Utility.isValidString(value)) {
				return '';
			}
			var first = value[0].toLowerCase(),
				rest = value.substring(1),
				result = rest,
				matches;
			while ((matches = /[A-Z]/g.exec(result)) !== null) {
				result = result.replace(matches[0], '-' + matches[0].toLowerCase());
			}
			return first + result;
		}
		static compareDates(date1, date2, smallestDatePart) {
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
		}
	}
}