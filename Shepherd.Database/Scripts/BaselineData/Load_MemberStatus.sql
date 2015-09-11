SET IDENTITY_INSERT [dbo].[MemberStatus] ON
GO
PRINT 'Load Member Status'

;WITH MemberStatus_Cte (Id, Name, IsDefault, IsDeleted) AS 
(
		  SELECT  1, 'Active', 1, 0
	UNION SELECT  2, 'In-Active', 0, 0
	UNION SELECT  3, 'Suspended', 0, 0
	UNION SELECT  4, 'Excommunicated', 0, 0
)
MERGE INTO [MemberStatus]
	  USING MemberStatus_Cte AS src
	  ON [MemberStatus].Id = src.Id
	  WHEN MATCHED THEN 
			UPDATE SET 
				 [MemberStatus].Name = src.Name
				,[MemberStatus].IsDefault = src.IsDefault
				,[MemberStatus].IsDeleted = src.IsDeleted
	  WHEN NOT MATCHED BY TARGET THEN 
			INSERT (Id, Name, IsDefault, IsDeleted) 
			VALUES (src.Id, src.Name, src.IsDefault, src.IsDeleted)
	  WHEN NOT MATCHED BY SOURCE THEN 
			DELETE;

SET IDENTITY_INSERT [dbo].[MemberStatus] OFF
GO