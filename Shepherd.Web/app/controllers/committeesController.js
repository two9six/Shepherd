'use strict';
app.controller('committeesController', [
	  '$modal'
	, '$scope'
	, '$timeout'
	, 'committeesService'
	, 'formatHelpers'
, function (
	  $modal
	, $scope
	, $timeout
	, committeesService
	, formatHelpers) {

	$scope.formatHelpers = formatHelpers;
	$scope.committees = [];
	$scope.selectedCommittee = undefined;
	$scope.vm = {
		memberDetailsPopoverTemplate: 'app/templates/member-details-popover.html'
	};

	//////////////////////////////////
	////// Edit Committee Heads //////
	//////////////////////////////////

	$scope.addCommittee = function (size) {

	}

	$scope.toggleAddCommitteeHeadModal = function (size) {
		var modalInstance = $modal.open({
			templateUrl: 'app/templates/committee-head-selection.html',
			controller: 'committeeHeadSelectionModal',
			size: size, // defaults if none provided http://angular-ui.github.io/bootstrap/
			resolve: {
				committee: function () {
					return $scope.selectedCommittee;
				}
			}
		});

		modalInstance.result.then(
			function (result) {
				var selectedMember = result.selectedMember;

				committeesService
					.addCommitteeMember({
						committeeId: $scope.selectedCommittee.id,
						memberId: selectedMember.key,
						isCommitteeHead: true
					})
					.$promise.then(function (response) {
						$timeout(function () {
							$scope.loadCommittees();
						}, 500);	
					});
			},
			function () {
				//$log.info('Modal dismissed at: ' + new Date());
			});
	}

	$scope.removeCommitteeHead = function (committeeHead) {
		if (committeeHead != undefined) {
			committeesService
				.deleteCommitteeMember({
					id: committeeHead.id
				})
				.$promise.then(function (response) {
					$timeout(function () {
						$scope.loadCommittees();
					}, 500);
				});
		}
	}

	////////////////////////////
	////// Committee List //////
	////////////////////////////

	$scope.loadCommittees = function () {
		$scope.committees.length = 0;
		committeesService
			.getCommittees()
			.$promise.then(function (data) {
				$scope.committees = data.committees;		 
				$scope.committees.forEach(function (c) {
					c.committeeHeads = _.filter(c.members, { 'isCommitteeHead': true });
					c.totalMembers = (c.members == undefined ? 0 : c.members.length);
				});

				if ($scope.selectedCommittee == undefined) {
					$scope.selectedCommittee = $scope.committees[0];
				}

				$timeout(function () {
					if ($scope.committees.length > 0) {
						selectCommittee($scope.selectedCommittee);
					}
				}, 250);
			});
	}

	$scope.$on('adTableLite:pageChanged', function (t) {
		if (t.targetScope.attrs.tableName !== 'committeesTable') {
			return;
		}

		$timeout(function () {
			setRowClickBehavior();
		}, 0);
	});

	$scope.committeesTableColumnDefinition = [
		{
			columnHeaderTemplate: '<span>Committee</span>',
			template: '<input type="hidden" id="committee-{{item.id}}" class="committee-id" value="{{item.id}}" /><div>{{item.name}}</div>',
			sortKey: 'name',
			columnSearchProperty: 'name',
			width: '3em',
			visible: true
		},
		{
			columnHeaderTemplate: '<span>Committee Head(s)</span>',
			template: '<div ng-repeat="ch in item.committeeHeads">{{ formatHelpers.formatNameWithPrefix(ch.member.firstName + " " + ch.member.lastName, ch.member.gender) }} <a class="fa-times fa fa-1x" ng-click="removeCommitteeHead(ch)" tooltip-html-unsafe="Remove as committee head" tooltip-append-to-body="true"></a></div>',
			columnSearchProperty: 'committeeHeads',
			width: '4em',
			visible: true
		},
		{
			columnHeaderTemplate: '<span>Total Members</span>',
			displayProperty: 'totalMembers',
			columnSearchProperty: 'totalMembers',
			width: '2em',
			visible: true
		}
	];

	function setRowClickBehavior() {
		$('.committees-table > tbody').on('click', 'tr', function () {
			var tableRow = $(this).find('input.committee-id')[0];
			if (tableRow) {
				var id = parseInt($.trim(tableRow.value));
				var item = _.find($scope.committees, {
					'id': id
				});
				if (item) {
					selectCommittee(item);
				}
			}
		});
	}

	function selectCommittee(committee) {
		$('.committees-table tr').attr('style', '');
		$('.committees-table input.committee-id').filter(function () {
			return ($.trim($(this).val()) == committee.id);
		}).closest('tr').css("background-color", "#fdfd96");

		$scope.selectedCommittee = committee;
	};

	function clearSelectedCommittee() {
		$scope.selectedCommittee = {};
	}

	$scope.loadCommittees();
}]);