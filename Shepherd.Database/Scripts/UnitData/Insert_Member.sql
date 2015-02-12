SET IDENTITY_INSERT dbo.Member ON
GO
PRINT 'Insert Member'

;WITH Member_CTE (Id, PersonId, MemberId, StatusId, IsDeleted) AS 
(
				  SELECT 1, 1, 'GUA00001', 1, 0
			UNION SELECT 2, 2, 'GUA00002', 2, 0
			UNION SELECT 3, 3, 'GUA00003', 2, 0
			UNION SELECT 4, 4, 'GUA00004', 2, 0
)
MERGE INTO Member
	  USING Member_CTE as cte
	  ON Member.Id = cte.Id
	  WHEN MATCHED THEN 
			UPDATE SET 
				 Member.PersonId = cte.PersonId
				,Member.MemberId = cte.MemberId
				,Member.StatusId = cte.StatusId
				,Member.IsDeleted = cte.IsDeleted
	  WHEN NOT MATCHED BY TARGET THEN 
			INSERT (Id, PersonId, MemberId, StatusId, IsDeleted) 
			VALUES (cte.Id, cte.PersonId, cte.MemberId, cte.StatusId, cte.IsDeleted)
	  WHEN NOT MATCHED BY SOURCE THEN 
			DELETE;

SET IDENTITY_INSERT dbo.Member OFF
GO