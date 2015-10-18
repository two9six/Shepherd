'use strict';
app.controller('memberAddModal', [
	  '$scope'
    , '$modal'
	, '$modalInstance'
	, '$timeout'
	, 'membersService'
	, 'enumHelpers'
	, function (
		  $scope
        , $modal
		, $modalInstance
		, $timeout
		, membersService
		, enumHelpers) {
		$scope.addMemberValidationMessage = '';
		$scope.memberStatusOptions = enumHelpers.convertEnumToKeyValueArray(memberStatusEnum);
		$scope.genderOptions = enumHelpers.convertEnumToKeyValueArray(genderEnum);
		$scope.maritalStatusOptions = enumHelpers.convertEnumToKeyValueArray(maritalStatusEnum);

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
            baptizer: {
                Id: "1"
            },
            maritalStatus: "",
            maritalStatusKeyValue: "",
            statusId: "",
            memberTypeId: "",
            churchDesignationId: "",
            createdBy: "",
            type: "",
            status: "",
            designation: "",
			memberStatus: "",
            memberStatusKeyValue: ""
		}
		$scope.dtStatus = {};
		$scope.saving = false;
		$scope.dtStatus.birthdayOpened = false;
		
		$scope.dtStatus.dateBaptizedOpened = false;
		

		$scope.firstNameError = false;

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

		    var firstNameLength = $scope.vm.firstName.length;

		    if (firstNameLength < 1 || firstNameLength > 100) {
		        $scope.firstNameError = true;
		    }

		    var memberStatusValue = $scope.vm.memberStatusKeyValue.value;
		    var genderValue = $scope.vm.genderKeyValue.value;
		    var maritalStatusValue = $scope.vm.maritalStatusKeyValue.value;

		    console.log(memberStatusValue);
		    $scope.saving = true;
		    $scope.vm.baptizer = {
		        Id: "1"
		    };
		    $scope.vm.statusId = "1";
		    $scope.vm.memberTypeId = "1";
		    $scope.vm.churchDesignationId = "1";
		    $scope.vm.createdBy = "1";
		    $scope.vm.type = "25";
		    $scope.vm.status = "1";
		    $scope.vm.designation = "1";

		    $scope.vm.memberStatus = memberStatusValue;
		    $scope.vm.gender = genderValue;
		    $scope.vm.maritalStatus = maritalStatusValue;


		    console.log($scope.vm);

		    membersService.createMember($scope.vm).$promise
                .then(function (response) {
		        console.log(response);
		        $modalInstance.dismiss('saved');
		        $scope.success("lg");

		    }, function (response) {
		        console.log(response);
		    });

		}


		$scope.success = function (size) {

		    var modalInstance = $modal.open({
		        templateUrl: '/app/templates/member-add-success-modal.html',
		        controller: 'memberAddSuccessModal',
		        size: size, // defaults if none provided http://angular-ui.github.io/bootstrap/
		        animation: true,
		        backdrop: 'static',
		        windowClass: 'members-modal-window',
		        resolve: {
		            member: function () {
		                return $scope.vm;
		            }
		        }
		    });

		    modalInstance.result.then(
				function (result) {
				    //refresh the page
				},
				function () {

				}
			);
		};


		$scope.cancel = function () {
			$modalInstance.dismiss('cancel');
		};

	}]);