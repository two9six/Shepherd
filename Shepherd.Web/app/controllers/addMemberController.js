'use strict';
app.controller('addMemberController', [
	  '$scope'
	, '$timeout'
	, 'membersService'
	, 'enumHelpers'
	, function (
		  $scope
		, $timeout
		, membersService
		, enumHelpers) {
	    $scope.addMemberValidationMessage = '';
	    $scope.memberStatusOptions = enumHelpers.convertEnumToKeyValueArray(memberStatusEnum);
	    $scope.genderOptions = enumHelpers.convertEnumToKeyValueArray(genderEnum);
	    $scope.maritalStatusOptions = enumHelpers.convertEnumToKeyValueArray(maritalStatusEnum);
	    $scope.designationOptions = enumHelpers.convertEnumToKeyValueArray(designationEnum);



	    $scope.formats = ['dd-MMMM-yyyy', 'yyyy/MM/dd', 'dd.MM.yyyy', 'shortDate'];
	    $scope.format = $scope.formats[0];

	    $scope.dateOptions = {
	        formatYear: 'yy',
	        startingDay: 1
	    };

	    $scope.customBirthDate = {
	        year: '2015',
	        month: '10',
            day: '24'
	    }

	    $scope.vm = {
	        firstName: "",
	        middleName: "",
	        lastName: "",
	        nameExtension: "",
	        citizenship: "",
	        placeOfBirth: "",
	        spouseName: "",
	        birthDate: "",
	        dateBaptized: "",
	        contactInformation: {
	            landLine: "",
	            email: "",
	            mobileNumber: ""
	        },
	        address: {
	            addressLine1: "",
	            addressLine2: "",
	            city: "",
	            stateProvince: "",
	            country: "",

	        },
	        churchId: "",
	        gender: "",
	        genderKeyValue: "",
	        baptizer: "",
	        maritalStatus: "",
	        maritalStatusKeyValue: "",
	        //statusId: "",
	        //memberTypeId: "",
	        //churchDesignationId: "",
	        createdBy: "",
	        //type: "",
	        //status: "",
	        designation: "",
	        memberStatus: "",
	        memberStatusKeyValue: "",
            designationKeyValue: ""
	    }
	    $scope.dtStatus = {};
	    $scope.dtStatus.birthdayOpened = false;

	    $scope.dtStatus.dateBaptizedOpened = false;


	    $scope.firstNameError = false;

	    $scope.openBirthday = function () {
	        $timeout(function () {
	            $scope.dtStatus.birthdayOpened = true;
	        });
	    }
	    $scope.openDateBaptized = function () {
	        //console.log($scope.dtStatus.dateBaptizedOpened);
	        $timeout(function () {
	            $scope.dtStatus.dateBaptizedOpened = true;
	        });
	    }


	    $scope.isSaveButtonDisabled = function () {
	        if (false) {
	            $scope.addMemberValidationMessage = 'blah blah blah';
	            return true;
	        }

	        $scope.addMemberValidationMessage = '';
	        return false;
	    };


	    $scope.save = function () {

	        var firstNameLength = $scope.vm.firstName.length;

	        if (firstNameLength < 1 || firstNameLength > 100) {
	            $scope.firstNameError = true;
	        }

            
	        $scope.vm.birthDate = (new Date($scope.customBirthDate.year, $scope.customBirthDate.month-1, $scope.customBirthDate.day)).toString();


	        var memberStatusValue = $scope.vm.memberStatusKeyValue.key;
	        var genderValue = $scope.vm.genderKeyValue.key;
	        var maritalStatusValue = $scope.vm.maritalStatusKeyValue.key;
	        var designationValue = $scope.vm.designationKeyValue.key;


	        console.log(memberStatusValue);

	        $scope.vm.createdBy = "1";
	        $scope.vm.designation = designationValue;
	        $scope.vm.memberStatus = memberStatusValue;
	        $scope.vm.gender = genderValue;
	        $scope.vm.maritalStatus = maritalStatusValue;

	        console.log($scope.vm);
	        console.log($scope.customBirthDate);


	        //membersService.createMember($scope.vm).$promise
            //    .then(function (response) {
            //        console.log(response);
            //        //$modalInstance.dismiss('saved');
            //        //$scope.success("lg");

            //    }, function (response) {
            //        console.log(response);
            //    });

	    }


	    $scope.success = function () {
	        console.log("success!");
	        //var modalInstance = $modal.open({
	        //    templateUrl: '/app/templates/member-add-success-modal.html',
	        //    controller: 'memberAddSuccessModal',
	        //    size: size, // defaults if none provided http://angular-ui.github.io/bootstrap/
	        //    animation: true,
	        //    backdrop: 'static',
	        //    windowClass: 'members-modal-window',
	        //    resolve: {
	        //        member: function () {
	        //            return $scope.vm;
	        //        }
	        //    }
	        //});

	        //modalInstance.result.then(
			//	function (result) {
			//	    //refresh the page
			//	},
			//	function () {

			//	}
			//);
	    };


	    $scope.cancel = function () {
	        //$modalInstance.dismiss('cancel');
	    };

	}]);