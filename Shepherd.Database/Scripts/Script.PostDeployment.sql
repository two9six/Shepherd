/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

:r .\BaselineData\Load_DesignationType.SQL
:r .\BaselineData\Load_Designation.SQL
:r .\BaselineData\Load_GatheringType.SQL
:r .\BaselineData\Load_MemberStatus.SQL
