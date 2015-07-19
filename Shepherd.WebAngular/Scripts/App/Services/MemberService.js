(function () {

    var app = angular.module("shepherdApp");

    app.factory("MemberService", ["$http", "$q", function ($http, $q) {

        var baseUrl = "http://localhost:7071/";

        var getMembers = function () {


            var apiUrl = baseUrl + "api/Members";

            var deferred = $q.defer();

            $http.get(apiUrl).then(function (response) {
                deferred.resolve(response);
            }, function (response) {
                deferred.reject(response);
            });

            return deferred.promise;
            //return [
            //    { "Id":"1","Name" : "Gideon Jura", "Age" : "2", "Status" : "Active" },
            //    { "Id": "2", "Name": "Jace Beleren", "Age": "3", "Status": "Active" },
            //    { "Id": "3", "Name": "Elspeth Tirel", "Age": "4", "Status": "Active" },
            //    { "Id": "4", "Name": "Liliana Vess", "Age": "5", "Status": "Active" },
            //    ]
        }

        var getMemberById = function (id) {

            var apiUrl = baseUrl + "api/Members/" + id;

            var deferred = $q.defer();

            $http.get(apiUrl).then(function (response) {
                deferred.resolve(response);
            }, function (response) {
                deferred.reject(response);
            });
            
            return deferred.promise;

            //return { Id: "1", FirstName: "Gideon", LastName: "Jura", MiddleName: "", BirthDate: "06/15/2015", DateBabtized: "06/15/2015" }
        }

        var insertMember = function (member) {

            member.ChurchId = "GUAXXX";
            member.Gender = "M";
            //member.Citizenship = "Filipino";
            //member.Address = {
            //    AddressLine1: "",
            //    AddressLine2: "",
            //    City: "",
            //    StateProvince: "",
            //    Country: ""
            //};
            member.Baptizer = {
                Id: "1"
            };
            member.MaritalStatus = "Single";
            //member.SpouseName = "";
            //member.ContactInformation = {
            //    LandLine: "",
            //    MobileNumber: "",
            //    Email: ""
            //};
            member.StatusId = "1";
            member.MemberTypeId = "1";
            member.ChurchDesignationId = "1";
            member.CreatedBy = "1";
            member.Type = "25";
            member.Status = "1";

            member.Designation = "28";
            console.log(member);


            var apiUrl = baseUrl + "api/Members/";
            var deferred = $q.defer();


            //var addMemberRequest = {
            //    Member: member
            //};

            $http.post(apiUrl, member).then(function (response) {
                deferred.resolve(response);
            }, function (response) {
                deferred.reject(response);
            });




            return deferred.promise;
        }

        var updateMember = function (member) {

            var apiUrl = baseUrl + "api/Members/";
            var deferred = $q.defer();

            $http.put(apiUrl, member).then(function (response) {
                deferred.resolve(response);
            }, function (response) {
                deferred.reject(response);
            });

            return deferred.promise;
        }

        return {
            getMembers: getMembers,
            getMemberById: getMemberById,
            insertMember: insertMember,
            updateMember: updateMember
        }

    }]);

}());