SET IDENTITY_INSERT dbo.Lookup ON
GO
PRINT 'Insert Lookup'

;WITH Lookup_CTE (Id, LookupTypeId, Name, IsDefault, IsDeleted) AS 
(
				  SELECT 1, 1, 'Member', 1, 0
			UNION SELECT 2, 1, 'Officer', 0, 0
			UNION SELECT 3, 1, 'Suspended', 0, 0
			UNION SELECT 4, 1, 'Removed', 0, 0
)
MERGE INTO [Lookup]
	  USING Lookup_CTE as cte
	  ON [Lookup].Id = cte.Id
	  WHEN MATCHED THEN 
			UPDATE SET 
				 [Lookup].LookupTypeId = cte.LookupTypeId
				,[Lookup].Name = cte.Name
				,[Lookup].IsDefault = cte.IsDefault
				,[Lookup].IsDeleted = cte.IsDeleted
	  WHEN NOT MATCHED BY TARGET THEN 
			INSERT (Id, LookupTypeId, Name, IsDefault, IsDeleted) 
			VALUES (cte.Id, cte.LookupTypeId, cte.Name, cte.IsDefault, cte.IsDeleted)
	  WHEN NOT MATCHED BY SOURCE THEN 
			DELETE;

SET IDENTITY_INSERT dbo.[Lookup] OFF
GO