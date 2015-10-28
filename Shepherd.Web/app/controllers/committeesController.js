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
            	width: '3em',
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

					$timeout(function () {
						if ($scope.committees.length > 0) {
							selectCommittee($scope.committees[0]);
						}
					}, 250);
				});
		}

		function setRowClickBehavior() {
			$('.committees-table > tbody').on('click', 'tr', function () {
				var tableRow = $(this).find('td')[0];
				if (tableRow) {
					var id = Number($.trim($(tableRow).find('.committee-id').val()));
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
			//$('.committees-table input.committee-id[value="' + committee.id + '"]').filter(function () {
			//	return ($.trim($(this).text()) == committee.id);
			//}).closest('tr').css("background-color", "#fdfd96");

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