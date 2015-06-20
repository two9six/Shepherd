(function () {

    var app = angular.module("shepherdApp");

    app.factory("MemberService", ["$http", "$q", function ($http, $q) {


        var getMembers = function () {
            return [
                { "Id":"1","Name" : "Gideon Jura", "Age" : "2", "Status" : "Active" },
                { "Id": "2", "Name": "Jace Beleren", "Age": "3", "Status": "Active" },
                { "Id": "3", "Name": "Elspeth Tirel", "Age": "4", "Status": "Active" },
                { "Id": "4", "Name": "Liliana Vess", "Age": "5", "Status": "Active" },
                ]
        }

        var getMemberById = function (id) {

            return { Id: "1", FirstName: "Gideon", LastName: "Jura", MiddleName: "", BirthDate: "06/15/2015", DateBabtized: "06/15/2015" }
        }

        var insertMember = function (member) {



            return;
        }

        var updateMember = function (id, member) {
            return;
        }

        return {
            getMembers: getMembers,
            getMemberById: getMemberById,
            insertMember: insertMember,
            updateMember: updateMember
        }

    }]);

}());