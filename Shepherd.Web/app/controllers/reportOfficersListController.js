'use strict';
app.controller('reportOfficersListController', [
	  '$scope'
	, 'reportsService'
	, 'formatHelpers'
	, 'dateTimeHelpers'
	, 'dataExportService'
	, (function (
	  $scope
	, reportsService
	, formatHelpers
	, dateTimeHelpers
	, dataExportService) {
		$scope.designationEnum = designationEnum;
		$scope.formatHelpers = formatHelpers;
		$scope.officers = [];

		////////////////////
		////// Events //////
		////////////////////

		$scope.exportData = function () {
			var filename = 'Officers_List_Report_' + dateTimeHelpers.getReportDateStamp() + '.xls';
			dataExportService.exportToExcel('report-contents', filename);
		}

		/////////////////////////////
		////// Local Functions //////
		/////////////////////////////

		function loadOfficersList() {
			reportsService
				.getOfficersList()
				.$promise.then(function (data) {
					$scope.officers = data;
				});
		}

		loadOfficersList();

	})]);