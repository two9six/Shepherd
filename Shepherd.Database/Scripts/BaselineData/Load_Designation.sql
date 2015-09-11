SET IDENTITY_INSERT [dbo].[Designation] ON
GO
PRINT 'Load Designation'

;WITH Designation_Cte (Id, DesignationTypeId, Name, IsDefault, IsDeleted) AS 
(
	      SELECT 1, 1, 'Member', 1, 0
	UNION SELECT 2, 2, 'Deacon', 0, 0
)
MERGE INTO [Designation]
	  USING Designation_Cte AS src
	  ON [Designation].Id = src.Id
	  WHEN MATCHED THEN 
			UPDATE SET 
				 [Designation].DesignationTypeId = src.DesignationTypeId
				,[Designation].Name = src.Name
				,[Designation].IsDefault = src.IsDefault
				,[Designation].IsDeleted = src.IsDeleted
	  WHEN NOT MATCHED BY TARGET THEN 
			INSERT (Id, DesignationTypeId, Name, IsDefault, IsDeleted) 
			VALUES (src.Id, src.DesignationTypeId, src.Name, src.IsDefault, src.IsDeleted)
	  WHEN NOT MATCHED BY SOURCE THEN 
			DELETE;

SET IDENTITY_INSERT [dbo].[Designation] OFF
GO