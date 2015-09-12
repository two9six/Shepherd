'use strict';
app.controller('memberAddModal', [
	  '$scope'
	, '$modalInstance'
	, 'membersService'
	, function (
		  $scope
		, $modalInstance
		, membersService) {
		$scope.addMemberValidationMessage = '';

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

		        member.Designation = "28";

		        console.log(member);

		        var promise = membersService.insertMember($scope.member).$promise;

		        promise.then(function (response) {
		            console.log(response.data);
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