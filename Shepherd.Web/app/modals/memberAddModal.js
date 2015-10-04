'use strict';
app.controller('memberAddModal', [
	  '$scope'
	, '$modalInstance'
	, '$timeout'
	, 'membersService'
	, 'enumHelpers'
	, function (
		  $scope
		, $modalInstance
		, $timeout
		, membersService
		, enumHelpers) {
		$scope.addMemberValidationMessage = '';
		$scope.memberStatusOptions = enumHelpers.convertEnumToKeyValueArray(memberStatusEnum);		
		$scope.formats = ['dd-MMMM-yyyy', 'yyyy/MM/dd', 'dd.MM.yyyy', 'shortDate'];
		$scope.format = $scope.formats[0];
		
		$scope.dateOptions = {
			formatYear: 'yy',
			startingDay: 1
		};

		$scope.vm = {
			firstName: "",
			middleName: "",
			lastName: "",
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
            baptizer: {
                Id: "1"
            },
            maritalStatus: "",
            statusId: "",
            memberTypeId: "",
            churchDesignationId: "",
            createdBy: "",
            type: "",
            status: "",
            designation: "",
			memberStatus: ""
		}
		$scope.dtStatus = {};
		$scope.saving = false;
		$scope.dtStatus.birthdayOpened = false;
		
		$scope.dtStatus.dateBaptizedOpened = false;
		
		$scope.openBirthday = function () {		
			$timeout(function() {
			    $scope.dtStatus.birthdayOpened = true;
			});
		}
		$scope.openDateBaptized = function () {
		    console.log($scope.dtStatus.dateBaptizedOpened);;
			$timeout(function() {
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
		    
		    $scope.saving = true;

		    //$scope.vm.churchId = "12345";
		    //$scope.vm.gender = "M";
		    $scope.vm.baptizer = {
		        Id: "1"
		    };
		    //$scope.vm.maritalStatus = "Single";
		    $scope.vm.statusId = "1";
		    $scope.vm.memberTypeId = "1";
		    $scope.vm.churchDesignationId = "1";
		    $scope.vm.createdBy = "1";
		    $scope.vm.type = "25";
		    $scope.vm.status = "1";

		    $scope.vm.designation = "1";
		    $scope.vm.memberStatus = "1";
		    //$scope.vm.localeChurchId = "6789";

		    console.log($scope.vm);
		    membersService.createMember($scope.vm).$promise
                .then(function (response) {
		        console.log(response);
		        $modalInstance.dismiss('saved');

		    }, function (response) {
		        console.log(response);
		    });

		}


		$scope.cancel = function () {
			$modalInstance.dismiss('cancel');
		};

	}]);