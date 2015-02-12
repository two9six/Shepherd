SET IDENTITY_INSERT dbo.Dictionary ON
GO
PRINT 'Insert Dictionary'

;WITH Dictionary_CTE ([Id], [TypeId], [Value], [Description], [IsDeleted]) AS 
(
		SELECT 1, 1, 'Officer', NULL, 0
		UNION SELECT 2, 1, 'Member', NULL, 0
		UNION SELECT 3, 1, 'Suspended', NULL, 0
		UNION SELECT 4, 1, 'Removed', NULL, 0
)
MERGE INTO Dictionary
	  USING Dictionary_CTE as cte
	  ON Dictionary.Id = cte.Id
	  WHEN MATCHED THEN 
			UPDATE SET 
				 Dictionary.[TypeId] = cte.[TypeId]
				,Dictionary.[Value] = cte.[Value]
				,Dictionary.[Description] = cte.[Description]
				,Dictionary.[IsDeleted] = cte.[IsDeleted]
	  WHEN NOT MATCHED BY TARGET THEN 
			INSERT ([Id], [TypeId], [Value], [Description], [IsDeleted]) 
			VALUES (cte.[Id], cte.[TypeId], cte.[Value], cte.[Description], cte.[IsDeleted])
	  WHEN NOT MATCHED BY SOURCE THEN 
			DELETE;

SET IDENTITY_INSERT dbo.Dictionary OFF
GO