SET IDENTITY_INSERT dbo.DictionaryType ON
GO
PRINT 'Insert Dictionary Type'

;WITH DictionaryType_CTE ([Id], [Value], [Description], [IsDeleted]) AS 
(
		SELECT 1,'Member Status', NULL, 0
		UNION SELECT 2,'Type 2', NULL, 0
		UNION SELECT 3,'Type 3', NULL, 0
		UNION SELECT 4,'Type 4', NULL, 0
)
MERGE INTO DictionaryType
	  USING DictionaryType_CTE as cte
	  ON DictionaryType.Id = cte.Id
	  WHEN MATCHED THEN 
			UPDATE SET 
				 DictionaryType.[Value] = cte.[Value]
				,DictionaryType.[Description] = cte.[Description]
				,DictionaryType.[IsDeleted] = cte.[IsDeleted]
	  WHEN NOT MATCHED BY TARGET THEN 
			INSERT ([Id], [Value], [Description], [IsDeleted]) 
			VALUES (cte.Id, cte.[Value], cte.[Description], cte.[IsDeleted])
	  WHEN NOT MATCHED BY SOURCE THEN 
			DELETE;

SET IDENTITY_INSERT dbo.DictionaryType OFF
GO