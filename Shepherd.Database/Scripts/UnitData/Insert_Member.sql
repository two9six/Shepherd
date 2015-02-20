SET IDENTITY_INSERT dbo.Member ON
GO
PRINT 'Insert Member'

;WITH Member_CTE (Id, PersonId, GeneratedId, DateBabtized, StatusId, IsDeleted) AS 
(
				  SELECT 1, 1, 'GUA00001', DATEADD(YEAR, -1, GETDATE()), 1, 0
			UNION SELECT 2, 2, 'GUA00002', DATEADD(YEAR, -10, GETDATE()), 2, 0
			UNION SELECT 3, 3, 'GUA00003', DATEADD(MONTH, -1, GETDATE()), 2, 0
			UNION SELECT 4, 4, 'GUA00004', DATEADD(MONTH, -10, GETDATE()), 2, 0
)
MERGE INTO Member
	  USING Member_CTE as cte
	  ON Member.Id = cte.Id
	  WHEN MATCHED THEN 
			UPDATE SET 
				 Member.PersonId = cte.PersonId
				,Member.GeneratedId = cte.GeneratedId
				,Member.DateBabtized = cte.DateBabtized
				,Member.StatusId = cte.StatusId
				,Member.IsDeleted = cte.IsDeleted
	  WHEN NOT MATCHED BY TARGET THEN 
			INSERT (Id, PersonId, GeneratedId, DateBabtized, StatusId, IsDeleted) 
			VALUES (cte.Id, cte.PersonId, cte.GeneratedId, cte.DateBabtized, cte.StatusId, cte.IsDeleted)
	  WHEN NOT MATCHED BY SOURCE THEN 
			DELETE;

SET IDENTITY_INSERT dbo.Member OFF
GO