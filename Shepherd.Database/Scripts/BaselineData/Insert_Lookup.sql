SET IDENTITY_INSERT dbo.Lookup ON
GO
PRINT 'Insert Lookup'

;WITH Lookup_CTE (Id, LookupTypeId, Name, IsDefault, IsDeleted) AS 
(
				  SELECT  1, 1, 'Active', 1, 0
			UNION SELECT  2, 1, 'In-Active', 0, 0
			UNION SELECT  3, 1, 'Suspended', 0, 0
			UNION SELECT  4, 1, 'Excommunicated', 0, 0
			UNION SELECT  5, 1, 'Reserved', 0, 1
			UNION SELECT  6, 1, 'Reserved', 0, 1
			UNION SELECT  7, 1, 'Reserved', 0, 1
			UNION SELECT  8, 1, 'Reserved', 0, 1
			UNION SELECT  9, 2, 'Prayer Meeting', 1, 0
			UNION SELECT 10, 2, 'Worship Service', 0, 0
			UNION SELECT 11, 2, 'Thanksgiving', 0, 0
			UNION SELECT 12, 2, 'Thanksgiving Viewing', 0, 0
			UNION SELECT 13, 2, 'Christian New Year', 0, 0
			UNION SELECT 14, 2, 'International Thanksgiving', 0, 0
			UNION SELECT 15, 2, 'Lords Supper', 0, 0
			UNION SELECT 16, 2, 'Reserved', 0, 1
			UNION SELECT 17, 2, 'Reserved', 0, 1
			UNION SELECT 18, 2, 'Reserved', 0, 1
			UNION SELECT 19, 2, 'Reserved', 0, 1
			UNION SELECT 20, 2, 'Reserved', 0, 1
			UNION SELECT 21, 2, 'Reserved', 0, 1
			UNION SELECT 22, 2, 'Reserved', 0, 1
			UNION SELECT 23, 2, 'Reserved', 0, 1
			UNION SELECT 24, 2, 'Reserved', 0, 1
			UNION SELECT 25, 3, 'Member', 1, 0
			UNION SELECT 26, 3, 'Officer', 0, 0
			UNION SELECT 27, 3, 'Worker', 0, 0
			UNION SELECT 28, 4, 'Member', 1, 0
			UNION SELECT 29, 4, 'Deacon', 0, 0

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