SET IDENTITY_INSERT dbo.LookupType ON
GO
PRINT 'Insert Lookup Type'

;WITH LookupType_CTE (Id, Name, IsDeleted) AS 
(
	SELECT 1, 'Member Status', 0
	UNION SELECT 2, 'Gathering Type', 0
	UNION SELECT 3, 'Member Type', 0 
	UNION SELECT 4, 'Church Designation', 0
)
MERGE INTO LookupType
	  USING LookupType_CTE as cte
	  ON LookupType.Id = cte.Id
	  WHEN MATCHED THEN 
			UPDATE SET 
				 LookupType.Name = cte.Name
				,LookupType.IsDeleted = cte.IsDeleted
	  WHEN NOT MATCHED BY TARGET THEN 
			INSERT (Id, Name, IsDeleted) 
			VALUES (cte.Id, cte.Name, cte.IsDeleted)
	  WHEN NOT MATCHED BY SOURCE THEN 
			DELETE;

SET IDENTITY_INSERT dbo.LookupType OFF
GO