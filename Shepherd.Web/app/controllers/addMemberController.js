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
		year: '',
		month: {
		    key: '',
            value: ''
		},
		day: ''
	}

	$scope.customDatebaptized = {
	    year: '',
	    month: {
	        key: '',
	        value: ''
	    },
	    day: ''
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
		createdBy: "",
		designation: "",
		memberStatus: "",
		memberStatusKeyValue: "",
		designationKeyValue: ""
	}
	$scope.dtStatus = {};
	$scope.dtStatus.birthdayOpened = false;

	$scope.dtStatus.dateBaptizedOpened = false;


	$scope.firstNameError = false;

	//$scope.openBirthday = function () {
	//	$timeout(function () {
	//		$scope.dtStatus.birthdayOpened = true;
	//	});
	//}
	//$scope.openDateBaptized = function () {
	//	$timeout(function () {
	//		$scope.dtStatus.dateBaptizedOpened = true;
	//	});
	//}


	$scope.isSaveButtonDisabled = function () {
		if (false) {
			$scope.addMemberValidationMessage = 'blah blah blah';
			return true;
		}

		$scope.addMemberValidationMessage = '';
		return false;
	};


	$scope.save = function () {

	    console.log("saving..");

		var firstNameLength = $scope.vm.firstName.length;

		if (firstNameLength < 1 || firstNameLength > 100) {
			$scope.firstNameError = true;
		}


		$scope.vm.birthDate = (new Date($scope.customBirthDate.year, $scope.customBirthDate.month.key, $scope.customBirthDate.day));
		$scope.vm.dateBaptized = (new Date($scope.customDateBaptized.year, $scope.customDateBaptized.month.key, $scope.customDateBaptized.day));

		console.log($scope.vm.birthDate);
		console.log($scope.vm.dateBaptized);

		var memberStatusValue = $scope.vm.memberStatusKeyValue.key;
		var genderValue = $scope.vm.genderKeyValue.key;
		var maritalStatusValue = $scope.vm.maritalStatusKeyValue.key;
		var designationValue = $scope.vm.designationKeyValue.key;


		$scope.vm.createdBy = "1";
		$scope.vm.designation = designationValue;
		$scope.vm.memberStatus = memberStatusValue;
		$scope.vm.gender = genderValue;
		$scope.vm.maritalStatus = maritalStatusValue;



		membersService.createMember($scope.vm).$promise
		    .then(function (response) {
		        console.log(response);

		    }, function (response) {
		        console.log(response);
		    });

	}


	$scope.success = function () {
		console.log("success!");

	};


	$scope.cancel = function () {
	};

}]);