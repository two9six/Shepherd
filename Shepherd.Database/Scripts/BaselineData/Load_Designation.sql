SET IDENTITY_INSERT [dbo].[Designation] ON
GO
PRINT 'Load Designation'

;WITH Designation_Cte (Id, DesignationTypeId, Name, SortOrder, IsDefault, IsDeleted) AS 
(
	      SELECT 1, 1, 'Member', 1, 1, 0
	UNION SELECT 2, 2, 'Deacon', 1, 0, 0
	UNION SELECT 3, 2, 'Deaconess', 2, 0, 0
	UNION SELECT 4, 2, 'Secretary', 3, 0, 0
	UNION SELECT 5, 2, 'Treasurer', 4, 0, 0
	UNION SELECT 6, 2, 'Group Servant', 5, 0, 0
)
MERGE INTO [Designation]
	  USING Designation_Cte AS src
	  ON [Designation].Id = src.Id
	  WHEN MATCHED THEN 
			UPDATE SET 
				 [Designation].DesignationTypeId = src.DesignationTypeId
				,[Designation].Name = src.Name
				,[Designation].SortOrder = src.SortOrder
				,[Designation].IsDefault = src.IsDefault
				,[Designation].IsDeleted = src.IsDeleted
	  WHEN NOT MATCHED BY TARGET THEN 
			INSERT (Id, DesignationTypeId, Name, SortOrder, IsDefault, IsDeleted) 
			VALUES (src.Id, src.DesignationTypeId, src.Name, src.SortOrder, src.IsDefault, src.IsDeleted)
	  WHEN NOT MATCHED BY SOURCE THEN 
			DELETE;

SET IDENTITY_INSERT [dbo].[Designation] OFF
GO