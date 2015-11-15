'use strict';

app.directive('calendarControl', ['enumHelpers', function (enumHelpers) {

    return {
        restrict: 'A',
        replace: false,
        templateUrl: 'app/templates/calendar-control.html',
        scope: {

            calendarControlStart: '=',
            yearEnd: '=',
            yearValues: '=',
            monthValues: '='
        },
        link: function ($scope, element, attributes) {

            
            console.log($scope.calendarControlStart);

        },
        controller: function ($scope, $element) {

            initializeYearDropdown();
            initializeMonthDropdown();

            function initializeMonthDropdown() {
                $scope.monthValues = enumHelpers.convertEnumToKeyValueArray(monthEnum);
            }

            function initializeYearDropdown() {

                var range = 100;
                $scope.yearEnd = 2015;
                var yearStart = $scope.yearEnd - range;

                $scope.yearValues = [];

                for (var i = yearStart; i <= $scope.yearEnd; i++) {

                    $scope.yearValues.push(i);

                }

            }

            



        }
    }

}]);