SET IDENTITY_INSERT dbo.Member ON
GO
PRINT 'Insert Member'

;WITH Member_CTE (Id, PersonId, ChurchId, DateBaptized, BaptizedById, MaritalStatus, SpouseName, LandLine, MobileNumber, Email, StatusId, TypeId, DesignationId, DateCreated, CreatedBy, IsDeleted) AS 
(
				  SELECT 1, 1, 'GUA00001', DATEADD(YEAR, -2, GETDATE()), 1, 'M', 'Test Spouse', '8811111', '09175201111', 'jgideon@gmail.com', 1, 25, 28, GETDATE(), 1, 0
			UNION SELECT 2, 2, 'GUA00002', DATEADD(YEAR, -3, GETDATE()), 1, 'M', 'Test Spouse', '8811112', '09175201112', 'jbeleren@gmail.com', 1, 25, 28, GETDATE(), 1, 0
			UNION SELECT 3, 3, 'GUA00003', DATEADD(YEAR, -4, GETDATE()), 1, 'F', null, '8811113', '09175201113', null, 1, 25, 28, GETDATE(), 1, 0
			UNION SELECT 4, 4, 'GUA00004', DATEADD(YEAR, -5, GETDATE()), 1, 'F', null, '8811114', '09175201114', null, 1, 25, 28, GETDATE(), 1, 0
)
MERGE INTO Member
	  USING Member_CTE as cte
	  ON Member.Id = cte.Id
	  WHEN MATCHED THEN 
			UPDATE SET 
				 Member.PersonId = cte.PersonId
				,Member.ChurchId = cte.ChurchId
				,Member.DateBaptized = cte.DateBaptized
				,Member.BaptizedById = cte.BaptizedById
				,Member.MaritalStatus = cte.MaritalStatus
				,Member.SpouseName = cte.SpouseName
				,Member.LandLine = cte.LandLine
				,Member.MobileNumber = cte.MobileNumber
				,Member.Email = cte.Email
				,Member.StatusId = cte.StatusId
				,Member.TypeId = cte.TypeId
				,Member.DesignationId = cte.DesignationId
				,Member.DateCreated = cte.DateCreated
				,Member.CreatedBy = cte.CreatedBy
				,Member.IsDeleted = cte.IsDeleted
	  WHEN NOT MATCHED BY TARGET THEN 
			INSERT (Id, PersonId, ChurchId, DateBaptized, BaptizedById, MaritalStatus, SpouseName, LandLine, MobileNumber, Email, StatusId, TypeId, DesignationId, DateCreated, CreatedBy, IsDeleted) 
			VALUES (cte.Id, cte.PersonId, cte.ChurchId, cte.DateBaptized, cte.BaptizedById, cte.MaritalStatus, cte.SpouseName, cte.LandLine, cte.MobileNumber, cte.Email, cte.StatusId, cte.TypeId, cte.DesignationId, cte.DateCreated, cte.CreatedBy, cte.IsDeleted)
	  WHEN NOT MATCHED BY SOURCE THEN 
			DELETE;

SET IDENTITY_INSERT dbo.Member OFF
GO