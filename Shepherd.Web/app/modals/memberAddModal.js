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
		
		/*
		 *  instead of using member.property, it is a good practice to use vm (view model) 
		 *  since the page (member-add-modal.html) is referencing to member itself (x-add-modal.html, where x is the vm)
		 *  no need to be more explicit about it (it is more conventional way as well)
		 *  also, vm gives programmer an idea what data to manipulate in views
		 */ 
		$scope.vm = {
			firstName: "",
			middleName: "",
			lastName: "",
			citizenship: "",
			placeOfBirth: "",
			spouseName: "",
			// ... add the rest members
			memberStatus: ""
		}

		$scope.birthdayOpened = false;
		$scope.dateBaptizedOpened = false;
		
		$scope.openBirthday = function () {		
			$timeout(function() {
				$scope.birthdayOpened = true;
			});
		}
		$scope.openDateBaptized = function () {		
			$timeout(function() {
				$scope.dateBaptizedOpened = true;
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
		    

		    $scope.$broadcast('show-errors-event');
		    if ($scope.memberForm.$invalid) {
		        return;
		    }
		    else {
		    	// TODO: always use camel-case, use vm.firstName, instead of member.firstName
		        var member = $scope.member;
		        member.ChurchId = "GUAXXX";
		        member.Gender = "M";
		        member.Baptizer = {
		            Id: "1"
		        };
		        member.MaritalStatus = "Single";
		        member.StatusId = "1";
		        member.MemberTypeId = "1";
		        member.ChurchDesignationId = "1";
		        member.CreatedBy = "1";
		        member.Type = "25";
		        member.Status = "1";

		        member.Designation = "1";
		        member.MemberStatus = "1";

		        console.log(member);

		        var promise = membersService.createMember($scope.member).$promise;

		        promise.then(function (response) {
		            console.log(response);
		            $modalInstance.dismiss('saved');

		        }, function (response) {
		            console.log(response);
		        });


		    }

		}


		$scope.cancel = function () {
			$modalInstance.dismiss('cancel');
		};

	}]);