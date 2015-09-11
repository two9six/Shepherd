SET IDENTITY_INSERT dbo.Member ON
GO
PRINT 'Insert Member'

;WITH Member_CTE (Id, PersonId, ChurchId, DateBaptized, BaptizedById, MaritalStatus, SpouseName, LandLine, MobileNumber, Email, MemberStatusId, DesignationId, DateCreated, CreatedBy, IsDeleted) AS 
(
		  SELECT  1,  1, 'GUA00001', DATEADD(YEAR, -2, GETDATE()), 1, 'M', 'Test Spouse', '8811111', '09175201111', 'jgideon@gmail.com', 1, 1, GETDATE(), 1, 0
	UNION SELECT  2,  2, 'GUA00002', DATEADD(YEAR, -3, GETDATE()), 1, 'M', 'Test Spouse', '8811112', '09175201112', 'jbeleren@gmail.com', 1, 1, GETDATE(), 1, 0
	UNION SELECT  3,  3, 'GUA00003', DATEADD(YEAR, -4, GETDATE()), 1, 'S', null, '8811113', '09175201113', null, 1, 2, GETDATE(), 1, 0
	UNION SELECT  4,  4, 'GUA00004', DATEADD(YEAR, -5, GETDATE()), 1, 'S', null, '8811114', '09175201114', null, 1, 1, GETDATE(), 1, 0
	UNION SELECT  5,  5, 'GUA00005', DATEADD(YEAR, -5, GETDATE()), 1, 'S', null, '8811114', '09175201114', null, 1, 1, GETDATE(), 1, 0
	UNION SELECT  6,  6, 'GUA00006', DATEADD(YEAR, -5, GETDATE()), 1, 'S', null, '8811114', '09175201114', null, 1, 1, GETDATE(), 1, 0
	UNION SELECT  7,  7, 'GUA00007', DATEADD(YEAR, -5, GETDATE()), 1, 'S', null, '8811114', '09175201114', null, 1, 1, GETDATE(), 1, 0
	UNION SELECT  8,  8, 'GUA00008', DATEADD(YEAR, -5, GETDATE()), 1, 'S', null, '8811114', '09175201114', null, 1, 1, GETDATE(), 1, 0
	UNION SELECT  9,  9, 'GUA00009', DATEADD(YEAR, -5, GETDATE()), 1, 'S', null, '8811114', '09175201114', null, 1, 1, GETDATE(), 1, 0
	UNION SELECT 10, 10, 'GUA00010', DATEADD(YEAR, -5, GETDATE()), 1, 'S', null, '8811114', '09175201114', null, 1, 1, GETDATE(), 1, 0
	UNION SELECT 11, 11, 'GUA00011', DATEADD(YEAR, -5, GETDATE()), 1, 'S', null, '8811114', '09175201114', null, 1, 1, GETDATE(), 1, 0
	UNION SELECT 12, 12, 'GUA00012', DATEADD(YEAR, -5, GETDATE()), 1, 'S', null, '8811114', '09175201114', null, 1, 1, GETDATE(), 1, 0
	UNION SELECT 13, 13, 'GUA00013', DATEADD(YEAR, -5, GETDATE()), 1, 'S', null, '8811114', '09175201114', null, 1, 1, GETDATE(), 1, 0
	UNION SELECT 14, 14, 'GUA00014', DATEADD(YEAR, -5, GETDATE()), 1, 'S', null, '8811114', '09175201114', null, 1, 1, GETDATE(), 1, 0
	UNION SELECT 15, 15, 'GUA00015', DATEADD(YEAR, -5, GETDATE()), 1, 'S', null, '8811114', '09175201114', null, 1, 1, GETDATE(), 1, 0
	UNION SELECT 16, 16, 'GUA00016', DATEADD(YEAR, -5, GETDATE()), 1, 'S', null, '8811114', '09175201114', null, 1, 1, GETDATE(), 1, 0
	UNION SELECT 17, 17, 'GUA00017', DATEADD(YEAR, -5, GETDATE()), 1, 'S', null, '8811114', '09175201114', null, 1, 1, GETDATE(), 1, 0
	UNION SELECT 18, 18, 'GUA00018', DATEADD(YEAR, -5, GETDATE()), 1, 'S', null, '8811114', '09175201114', null, 1, 1, GETDATE(), 1, 0
	UNION SELECT 19, 19, 'GUA00019', DATEADD(YEAR, -5, GETDATE()), 1, 'S', null, '8811114', '09175201114', null, 1, 1, GETDATE(), 1, 0
	UNION SELECT 20, 20, 'GUA00020', DATEADD(YEAR, -5, GETDATE()), 1, 'S', null, '8811114', '09175201114', null, 1, 1, GETDATE(), 1, 0
	UNION SELECT 21, 21, 'GUA00021', DATEADD(YEAR, -5, GETDATE()), 1, 'S', null, '8811114', '09175201114', null, 1, 1, GETDATE(), 1, 0
	UNION SELECT 22, 22, 'GUA00022', DATEADD(YEAR, -5, GETDATE()), 1, 'S', null, '8811114', '09175201114', null, 1, 1, GETDATE(), 1, 0
	UNION SELECT 23, 23, 'GUA00023', DATEADD(YEAR, -5, GETDATE()), 1, 'S', null, '8811114', '09175201114', null, 1, 1, GETDATE(), 1, 0
	UNION SELECT 24, 24, 'GUA00024', DATEADD(YEAR, -5, GETDATE()), 1, 'S', null, '8811114', '09175201114', null, 1, 1, GETDATE(), 1, 0
	UNION SELECT 25, 25, 'GUA00025', DATEADD(YEAR, -5, GETDATE()), 1, 'S', null, '8811114', '09175201114', null, 1, 1, GETDATE(), 1, 0
	UNION SELECT 26, 26, 'GUA00026', DATEADD(YEAR, -5, GETDATE()), 1, 'S', null, '8811114', '09175201114', null, 1, 1, GETDATE(), 1, 0
	UNION SELECT 27, 27, 'GUA00027', DATEADD(YEAR, -5, GETDATE()), 1, 'S', null, '8811114', '09175201114', null, 1, 1, GETDATE(), 1, 0
	UNION SELECT 28, 28, 'GUA00028', DATEADD(YEAR, -5, GETDATE()), 1, 'S', null, '8811114', '09175201114', null, 1, 1, GETDATE(), 1, 0
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
				,Member.MemberStatusId = cte.MemberStatusId
				,Member.DesignationId = cte.DesignationId
				,Member.DateCreated = cte.DateCreated
				,Member.CreatedBy = cte.CreatedBy
				,Member.IsDeleted = cte.IsDeleted
	  WHEN NOT MATCHED BY TARGET THEN 
			INSERT (Id, PersonId, ChurchId, DateBaptized, BaptizedById, MaritalStatus, SpouseName, LandLine, MobileNumber, Email, MemberStatusId, DesignationId, DateCreated, CreatedBy, IsDeleted) 
			VALUES (cte.Id, cte.PersonId, cte.ChurchId, cte.DateBaptized, cte.BaptizedById, cte.MaritalStatus, cte.SpouseName, cte.LandLine, cte.MobileNumber, cte.Email, cte.MemberStatusId, cte.DesignationId, cte.DateCreated, cte.CreatedBy, cte.IsDeleted)
	  WHEN NOT MATCHED BY SOURCE THEN 
			DELETE;

SET IDENTITY_INSERT dbo.Member OFF
GO