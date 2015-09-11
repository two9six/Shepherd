SET IDENTITY_INSERT [dbo].[DesignationType] ON
GO
PRINT 'Load Designation Type'

;WITH DesignationType_Cte (Id, Name, IsDeleted) AS 
(
		  SELECT 1, 'Member', 0
	UNION SELECT 2, 'Officer', 0
	UNION SELECT 3, 'Worker', 0
)
MERGE INTO DesignationType
	  USING DesignationType_Cte AS src
	  ON DesignationType.Id = src.Id
	  WHEN MATCHED THEN 
			UPDATE SET 
				 DesignationType.Name = src.Name
				,DesignationType.IsDeleted = src.IsDeleted
	  WHEN NOT MATCHED BY TARGET THEN 
			INSERT (Id, Name, IsDeleted) 
			VALUES (src.Id, src.Name, src.IsDeleted)
	  WHEN NOT MATCHED BY SOURCE THEN 
			DELETE;

SET IDENTITY_INSERT [dbo].[DesignationType] OFF
GO