SET IDENTITY_INSERT [dbo].[GatheringType] ON
GO
PRINT 'Load Gathering Type'

;WITH GatheringType_Cte (Id, Name, IsDefault, IsDeleted) AS 
(
		  SELECT 1, 'Prayer Meeting', 1, 0
	UNION SELECT 2, 'Worship Service', 0, 0
	UNION SELECT 3, 'Thanksgiving', 0, 0
	UNION SELECT 4, 'Thanksgiving Viewing', 0, 0
	UNION SELECT 5, 'Christian New Year', 0, 0
	UNION SELECT 6, 'International Thanksgiving', 0, 0
	UNION SELECT 7, 'Lords Supper', 0, 0
)
MERGE INTO [GatheringType]
	  USING GatheringType_Cte AS src
	  ON [GatheringType].Id = src.Id
	  WHEN MATCHED THEN 
			UPDATE SET 
				 [GatheringType].Name = src.Name
				,[GatheringType].IsDefault = src.IsDefault
				,[GatheringType].IsDeleted = src.IsDeleted
	  WHEN NOT MATCHED BY TARGET THEN 
			INSERT (Id, Name, IsDefault, IsDeleted) 
			VALUES (src.Id, src.Name, src.IsDefault, src.IsDeleted)
	  WHEN NOT MATCHED BY SOURCE THEN 
			DELETE;

SET IDENTITY_INSERT [dbo].[GatheringType] OFF
GO