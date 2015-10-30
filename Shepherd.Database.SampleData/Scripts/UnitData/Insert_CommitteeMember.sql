SET IDENTITY_INSERT dbo.CommitteeMember ON
GO
PRINT 'Insert CommitteeMember'

;WITH CommitteeMember_CTE (Id, CommitteeId, MemberId, IsCommitteeHead, CreatedBy, DateCreated) AS 
(
		  SELECT  1, 1, 12, 1, 1, GETDATE()
	UNION SELECT  2, 1, 13, 1, 1, GETDATE()
	UNION SELECT  3, 1, 14, 0, 1, GETDATE()
	UNION SELECT  4, 1, 15, 0, 1, GETDATE()
	UNION SELECT  5, 1, 16, 0, 1, GETDATE()
)
MERGE INTO CommitteeMember
	  USING CommitteeMember_CTE as cte
	  ON CommitteeMember.Id = cte.Id
	  WHEN MATCHED THEN 
			UPDATE SET 
				 CommitteeMember.CommitteeId = cte.CommitteeId
				,CommitteeMember.MemberId = cte.MemberId
				,CommitteeMember.IsCommitteeHead = cte.IsCommitteeHead
				,CommitteeMember.CreatedBy = cte.CreatedBy
				,CommitteeMember.DateCreated = cte.DateCreated
	  WHEN NOT MATCHED BY TARGET THEN 
			INSERT (Id, CommitteeId, MemberId, IsCommitteeHead, CreatedBy, DateCreated) 
			VALUES (cte.Id, cte.CommitteeId, cte.MemberId, cte.IsCommitteeHead, cte.CreatedBy, cte.DateCreated)
	  WHEN NOT MATCHED BY SOURCE THEN 
			DELETE;

SET IDENTITY_INSERT dbo.CommitteeMember OFF
GO