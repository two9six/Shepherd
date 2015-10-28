SET IDENTITY_INSERT [dbo].[Committee] ON
GO
PRINT 'Load Committee'

;WITH Committee_Cte (Id, Name, [Description], IsActive, IsDeleted) AS 
(
	      SELECT 1, 'KKTK',			'',	1, 0
	UNION SELECT 2, 'Senior',		'',	1, 0
	UNION SELECT 3, 'VIDP',			'',	1, 0
	UNION SELECT 4, 'Choir',		'',	1, 0
	UNION SELECT 5, 'Mothers Club', '', 1, 0
	UNION SELECT 6, 'QUAT',			'', 1, 0
)
MERGE INTO [Committee]
	  USING Committee_Cte AS src
	  ON [Committee].Id = src.Id
	  WHEN MATCHED THEN 
			UPDATE SET 
				 [Committee].Name = src.Name
				,[Committee].[Description] = src.[Description]
				,[Committee].IsActive = src.IsActive
				,[Committee].IsDeleted = src.IsDeleted
	  WHEN NOT MATCHED BY TARGET THEN 
			INSERT (Id, Name, [Description], IsActive, IsDeleted) 
			VALUES (src.Id, src.Name, src.[Description], src.IsActive, src.IsDeleted)
	  WHEN NOT MATCHED BY SOURCE THEN 
			DELETE;

SET IDENTITY_INSERT [dbo].[Committee] OFF
GO