
describe("Testing the MemberService.js", function () {
    it("Try mocking the MemberService", function () {

        module(function ($provide) {
            $provide.service('MemberService', function () {
                this.getMemberById = jasmine.createSpy('getMemberById').and.callFake(function (id) {
                    //a fake implementation
                    return { Id: "1", FirstName: "Test", LastName: "Test", MiddleName: "Mock", BirthDate: "06/15/2016", DateBabtized: "06/15/2016" }
                });
            });
        });

        var mockMemberSvc;

        inject(function (MemberService) {
            mockMemberSvc = MemberService;
        });

        expect(mockMemberSvc.getMemberById(1).FirstName).toEqual("Test");
    });
});