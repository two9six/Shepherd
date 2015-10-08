'use strict';
app.controller('membersController', [
	  '$modal'
	, '$scope'
	, '$timeout'
	, 'membersService'
	, 'formatHelpers'
	, (function (
	  $modal
	, $scope
	, $timeout
	, membersService
	, formatHelpers) {
		$scope.formatHelpers = formatHelpers;
		$scope.designationEnum = designationEnum;
		$scope.memberStatusEnum = memberStatusEnum;
		$scope.maritalStatusEnum = maritalStatusEnum;
		$scope.members = [];
		$scope.selectedMember = {};
		$scope.loadMembers = loadMembers();
		$scope.vm = {
			memberDetailsPopoverTemplate: 'app/templates/member-details-popover.html'
		};

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
				windowClass: 'members-modal-window',
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
            	columnHeaderTemplate: '<span>Picture</span>',
            	template: '<div class="center"><img src="../content/images/profile_black.jpg" style="height: 80px; width: 80px;" /></div>',
            	width: '2em',
            	visible: true
            },
            {
            	columnHeaderTemplate: '<span>Church Id</span>',
            	displayProperty: 'churchId',
            	sortKey: 'churchId',
            	columnSearchProperty: 'churchId',
            	width: '2em',
            	visible: true
            },
            {
            	columnHeaderTemplate: '<span>Locale Id</span>',
            	displayProperty: 'localeChurchId',
            	sortKey: 'localeChurchId',
            	columnSearchProperty: 'localeChurchId',
            	width: '2em',
            	visible: true
            },
            {
            	columnHeaderTemplate: '<span>Name</span>',
            	template: '<div popover-template="vm.memberDetailsPopoverTemplate" popover-trigger="mouseenter" popover-append-to-body="true" popover-placement="left">{{item.name}}</div>',
            	sortKey: 'name',
            	columnSearchProperty: 'name',
            	width: '4em',
            	visible: true
            },
            {
            	columnHeaderTemplate: '<span>Sex</span>',
            	displayProperty: 'gender',
            	sortKey: 'gender',
            	columnSearchProperty: 'gender',
            	width: '1em',
            	visible: true
            },
            {
            	columnHeaderTemplate: '<span>Date Baptized</span>',
            	template: '<div>{{ formatHelpers.formatDate(item.dateBaptized) }}</div>',
            	sortKey: 'dateBaptized',
            	width: '2em',
            	visible: true
            },
            {
            	columnHeaderTemplate: '<span>Status</span>',
            	template: '<div>{{ memberStatusEnum.toString(item.memberStatus) }}</div>',
            	sortKey: 'status',
            	width: '2em',
            	visible: true
            },
            {
            	columnHeaderTemplate: '<span>Designation</span>',
            	template: '<span>{{ designationEnum.toString(item.designation) }}</span>',
            	sortKey: 'designation',
            	width: '2em',
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

					$scope.members.forEach(function (m) {
						// TODO: Soon, we will need to refactor this and put this concatenation logic on a separate helper
						m.name = m.lastName + ', ' + m.firstName + ' ' + (m.nameExtension == null ? '' : m.nameExtension);
					});

					$timeout(function () {
						if ($scope.members.length > 0) {
							selectMember($scope.members[0]);
						}
					}, 250);
				});
		}

		function setRowClickBehavior() {
			// Used jquery delegated event instead
			//$('.members-table tr').unbind().click(function () {
			$('.members-table > tbody').on('click', 'tr', function () {
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