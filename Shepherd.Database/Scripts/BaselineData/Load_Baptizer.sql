SET IDENTITY_INSERT [dbo].[Baptizer] ON
GO
PRINT 'Load Baptizer'

;WITH Baptizer_Cte (Id, Name, IsDeleted) AS 
(
	      SELECT 1, 'Brimaz Leonin', 0
	UNION SELECT 2, 'Surrak Dragonclaw', 0
)
MERGE INTO [Baptizer]
	  USING Baptizer_Cte AS src
	  ON [Baptizer].Id = src.Id
	  WHEN MATCHED THEN 
			UPDATE SET 
				 [Baptizer].Name = src.Name
				,[Baptizer].IsDeleted = src.IsDeleted
	  WHEN NOT MATCHED BY TARGET THEN 
			INSERT (Id, Name, IsDeleted) 
			VALUES (src.Id, src.Name, src.IsDeleted)
	  WHEN NOT MATCHED BY SOURCE THEN 
			DELETE;

SET IDENTITY_INSERT [dbo].[Baptizer] OFF
GO