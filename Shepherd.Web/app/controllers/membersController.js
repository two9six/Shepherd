'use strict';
app.controller('membersController', [
	  '$modal'
	, '$scope'
	, '$timeout'
	, 'membersService'
	, (function (
	  $modal
	, $scope
	, $timeout
	, membersService) {
		$scope.designationEnum = designationEnum;
		$scope.memberStatusEnum = memberStatusEnum;
		$scope.members = [];
		$scope.selectedMember = {};
		$scope.loadMembers = loadMembers();

		////////////////////
		////// Events //////
		////////////////////

		$scope.$on('adTableLite:pageChanged', function (t) {
			if (t.targetScope.attrs.tableName !== 'membersTable') {
				return;
			}

			$timeout(function () {
				setRowClickBehavior();
			}, 0);
		});

		$scope.addMember = function (size) {

			var modalInstance = $modal.open({
				templateUrl: '/app/templates/member-add-modal.html',
				controller: 'memberAddModal',
				size: size, // defaults if none provided http://angular-ui.github.io/bootstrap/
				animation: true,
				backdrop: 'static',
				resolve: {
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

		$scope.membersTableColumnDefinition = [
            {
            	columnHeaderTemplate: '',
            	template: '<i class="fa fa-info-circle info-circle" ' +
								'popover-template="app/templates/member-details-popover.html" ' +
								'popover-trigger="mouseenter" ' +
								'popover-append-to-body="true" popover-placement="top"></i>',
            	width: '1em',
            	visible: true
            },
            {
            	columnHeaderTemplate: '<span>Church Id</span>',
            	displayProperty: 'churchId',
            	sortKey: 'churchId',
            	width: '3em',
            	visible: true
            },
            {
            	columnHeaderTemplate: '<span>First Name</span>',
            	displayProperty: 'firstName',
            	sortKey: 'firstName',
            	columnSearchProperty: 'firstName',
            	width: '10em',
            	visible: true
            },
            {
            	columnHeaderTemplate: '<span>Last Name</span>',
            	displayProperty: 'lastName',
            	sortKey: 'lastName',
            	columnSearchProperty: 'lastName',
            	width: '10em',
            	visible: true
            },
            {
            	columnHeaderTemplate: '<span>Status</span>',
            	template: '<div>{{ memberStatusEnum.toString(item.memberStatus) }}</div>',
            	sortKey: 'status',
            	width: '5em',
            	visible: true
            },
            {
            	columnHeaderTemplate: '<span>Designation</span>',
            	template: '<span>{{ designationEnum.toString(item.designation) }}</span>',
            	sortKey: 'designation',
            	width: '5em',
            	visible: true
            }
		];

		/////////////////////////////
		////// Local Functions //////
		/////////////////////////////

		function loadMembers() {
			membersService
				.getMembers()
				.$promise.then(function (data) {
					$scope.members = data.members;

					$timeout(function () {
						if ($scope.members.length > 0) {
							selectMember($scope.members[0]);
						}
					}, 250);
				});
		}

		function setRowClickBehavior() {
			$('.members-table tr').unbind().click(function () {
				var tableRow = $(this).find('td')[1];
				if (tableRow) {
					var churchId = $.trim(tableRow.innerText);
					var item = _.find($scope.members, {
						'churchId': churchId
					});
					if (item) {
						selectMember(item);
					}
				}
			});
		}

		function selectMember (member) {
			$('.members-table tr').attr('style', '');
			$('.members-table td:contains("' + member.churchId + '")').filter(function () {
				return ($.trim($(this).text()) == member.churchId);
			}).closest('tr').css("background-color", "#fdfd96");
			$scope.selectedMember = member;
		};

		function clearSelectedMember() {
			$scope.selectedMember = {};
		}

	})
]);