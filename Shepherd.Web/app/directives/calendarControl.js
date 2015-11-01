'use strict';

app.directive('calendarControl', function () {

    return {
        restrict: 'A',
        replace: false,
        templateUrl: 'app/templates/calendar-control.html',
        scope: {

            calendarControlStart: '='
        },
        link: function ($scope, element, attributes) {


            console.log($scope.calendarControlStart);


        }
    }

});