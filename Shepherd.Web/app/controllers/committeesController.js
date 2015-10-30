'use strict';
app.controller('committeesController', [
	  '$modal'
	, '$scope'
	, '$timeout'
	, 'committeesService'
	, 'formatHelpers'
	, (function (
	  $modal
	, $scope
	, $timeout
	, committeesService
	, formatHelpers) {
		$scope.formatHelpers = formatHelpers;
		$scope.committees = [];
		$scope.selectedCommittee = {};
		$scope.loadCommittees = loadCommittees();
		$scope.vm = {
			memberDetailsPopoverTemplate: 'app/templates/member-details-popover.html'
		};

		////////////////////
		////// Events //////
		////////////////////

		$scope.addCommittee = function (size) {

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
            	displayProperty: 'committeeHeads',
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

		/////////////////////////////
		////// Local Functions //////
		/////////////////////////////

		function loadCommittees() {
			committeesService
				.getCommittees()
				.$promise.then(function (data) {
					$scope.committees = data.committees;

					$scope.committees.forEach(function (c) {
						c.committeeHeads = getCommitteeHeads(c);
						c.totalMembers = (c.members == undefined ? 0 : c.members.length);
					});

					$timeout(function () {
						if ($scope.committees.length > 0) {
							selectCommittee($scope.committees[0]);
						}
					}, 250);
				});
		}

		function getCommitteeHeads(committee) {
			var committeeHeads = '';

			_.each(committee.members, function (m) {
				if (m.isCommitteeHead) {
					committeeHeads += (committeeHeads.length > 0 ? ', ' : '') 
						+ formatHelpers.formatNameWithPrefix(m.member.firstName + ' ' + m.member.lastName, m.member.gender);
				}
			});

			if (committeeHeads == '')
				committeeHeads = 'No committee head assigned.';

			return committeeHeads;
		}

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

		function selectCommittee (committee) {
			$('.committees-table tr').attr('style', '');
			$('.committees-table input.committee-id').filter(function () {
				return ($.trim($(this).val()) == committee.id);
			}).closest('tr').css("background-color", "#fdfd96");

			$scope.selectedCommittee = committee;
		};

		function clearSelectedCommittee() {
			$scope.selectedCommittee = {};
		}

	})
]);