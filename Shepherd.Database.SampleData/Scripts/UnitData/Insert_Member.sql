SET IDENTITY_INSERT dbo.Member ON
GO
PRINT 'Insert Member'

;WITH Member_CTE (Id, PersonId, ChurchId, LocaleChurchId, DateBaptized, BaptizerId, MaritalStatus, SpouseName, LandLine, MobileNumber, Email, MemberStatusId, DesignationId, DateCreated, CreatedBy, IsDeleted) AS 
(
		  SELECT 1,		1,  'GUA00001', '1',  DATEADD(MONTH,  0,  DATEADD(YEAR, -1,  GETDATE())), 1, 'M', 'Test Spouse',	'8811111', '09175201111', 'jgideon@gmail.com',	1, 1, GETDATE(), 1, 0
	UNION SELECT 2,		2,  'GUA00002', '2',  DATEADD(MONTH,  0,  DATEADD(YEAR, -1,  GETDATE())), 1, 'M', 'Test Spouse',	'8811112', '09175201112', 'jbeleren@gmail.com', 1, 1, GETDATE(), 1, 0
	UNION SELECT 3,		3,  'GUA00003', '3',  DATEADD(MONTH,  0,  DATEADD(YEAR, -2,  GETDATE())), 1, 'S', null,				'8811113', '09175201113', null,					1, 2, GETDATE(), 1, 0
	UNION SELECT 4,		4,  'GUA00004', '4',  DATEADD(MONTH, -1,  DATEADD(YEAR, -2,  GETDATE())), 1, 'S', null,				'8811114', '09175201114', null,					1, 1, GETDATE(), 1, 0
	UNION SELECT 5,		5,  'GUA00005', '5',  DATEADD(MONTH, -1,  DATEADD(YEAR, -3,  GETDATE())), 1, 'S', null,				'8811114', '09175201114', null,					1, 1, GETDATE(), 1, 0
	UNION SELECT 6,		6,  'GUA00006', '6',  DATEADD(MONTH, -1,  DATEADD(YEAR, -3,  GETDATE())), 1, 'S', null,				'8811114', '09175201114', null,					1, 1, GETDATE(), 1, 0
	UNION SELECT 7,		7,  'GUA00007', '7',  DATEADD(MONTH, -2,  DATEADD(YEAR, -4,  GETDATE())), 1, 'S', null,				'8811114', '09175201114', null,					1, 1, GETDATE(), 1, 0
	UNION SELECT 8,		8,  'GUA00008', '8',  DATEADD(MONTH, -2,  DATEADD(YEAR, -4,  GETDATE())), 1, 'S', null,				'8811114', '09175201114', null,					1, 1, GETDATE(), 1, 0
	UNION SELECT 9,		9,  'GUA00009', '9',  DATEADD(MONTH, -2,  DATEADD(YEAR, -5,  GETDATE())), 1, 'S', null,				'8811114', '09175201114', null,					1, 1, GETDATE(), 1, 0
	UNION SELECT 10,	10, 'GUA00010', '10', DATEADD(MONTH, -3,  DATEADD(YEAR, -5,  GETDATE())), 1, 'S', null,				'8811114', '09175201114', null,					1, 1, GETDATE(), 1, 0
	UNION SELECT 11,	11, 'GUA00011', '11', DATEADD(MONTH, -3,  DATEADD(YEAR, -6,  GETDATE())), 1, 'S', null,				'8811114', '09175201114', null,					1, 1, GETDATE(), 1, 0
	UNION SELECT 12,	12, 'GUA00012', '12', DATEADD(MONTH, -3,  DATEADD(YEAR, -6,  GETDATE())), 1, 'S', null,				'8811114', '09175201114', null,					1, 1, GETDATE(), 1, 0
	UNION SELECT 13,	13, 'GUA00013', '13', DATEADD(MONTH, -4,  DATEADD(YEAR, -7,  GETDATE())), 1, 'S', null,				'8811114', '09175201114', null,					1, 1, GETDATE(), 1, 0
	UNION SELECT 14,	14, 'GUA00014', '14', DATEADD(MONTH, -4,  DATEADD(YEAR, -7,  GETDATE())), 1, 'S', null,				'8811114', '09175201114', null,					1, 1, GETDATE(), 1, 0
	UNION SELECT 15,	15, 'GUA00015', '15', DATEADD(MONTH, -5,  DATEADD(YEAR, -8,  GETDATE())), 1, 'S', null,				'8811114', '09175201114', null,					1, 1, GETDATE(), 1, 0
	UNION SELECT 16,	16, 'GUA00016', '16', DATEADD(MONTH, -5,  DATEADD(YEAR, -8,  GETDATE())), 1, 'S', null,				'8811114', '09175201114', null,					1, 1, GETDATE(), 1, 0
	UNION SELECT 17,	17, 'GUA00017', '17', DATEADD(MONTH, -6,  DATEADD(YEAR, -9,  GETDATE())), 1, 'S', null,				'8811114', '09175201114', null,					1, 1, GETDATE(), 1, 0
	UNION SELECT 18,	18, 'GUA00018', '18', DATEADD(MONTH, -6,  DATEADD(YEAR, -9,  GETDATE())), 1, 'S', null,				'8811114', '09175201114', null,					1, 1, GETDATE(), 1, 0
	UNION SELECT 19,	19, 'GUA00019', '19', DATEADD(MONTH, -7,  DATEADD(YEAR, -10, GETDATE())), 1, 'S', null,				'8811114', '09175201114', null,					1, 1, GETDATE(), 1, 0
	UNION SELECT 20,	20, 'GUA00020', '20', DATEADD(MONTH, -7,  DATEADD(YEAR, -10, GETDATE())), 1, 'S', null,				'8811114', '09175201114', null,					1, 1, GETDATE(), 1, 0
	UNION SELECT 21,	21, 'GUA00021', '21', DATEADD(MONTH, -8,  DATEADD(YEAR, -11, GETDATE())), 1, 'S', null,				'8811114', '09175201114', null,					1, 1, GETDATE(), 1, 0
	UNION SELECT 22,	22, 'GUA00022', '22', DATEADD(MONTH, -8,  DATEADD(YEAR, -11, GETDATE())), 1, 'S', null,				'8811114', '09175201114', null,					1, 1, GETDATE(), 1, 0
	UNION SELECT 23,	23, 'GUA00023', '23', DATEADD(MONTH, -9,  DATEADD(YEAR, -12, GETDATE())), 1, 'S', null,				'8811114', '09175201114', null,					1, 1, GETDATE(), 1, 0
	UNION SELECT 24,	24, 'GUA00024', '24', DATEADD(MONTH, -9,  DATEADD(YEAR, -12, GETDATE())), 1, 'S', null,				'8811114', '09175201114', null,					1, 1, GETDATE(), 1, 0
	UNION SELECT 25,	25, 'GUA00025', '25', DATEADD(MONTH, -10, DATEADD(YEAR, -13, GETDATE())), 1, 'S', null,				'8811114', '09175201114', null,					1, 1, GETDATE(), 1, 0
	UNION SELECT 26,	26, 'GUA00026', '26', DATEADD(MONTH, -10, DATEADD(YEAR, -13, GETDATE())), 1, 'S', null,				'8811114', '09175201114', null,					1, 1, GETDATE(), 1, 0
	UNION SELECT 27,	27, 'GUA00027', '27', DATEADD(MONTH, -11, DATEADD(YEAR, -14, GETDATE())), 1, 'S', null,				'8811114', '09175201114', null,					1, 1, GETDATE(), 1, 0
	UNION SELECT 28,	28, 'GUA00028', '28', DATEADD(MONTH, -11, DATEADD(YEAR, -14, GETDATE())), 1, 'S', null,				'8811114', '09175201114', null,					1, 1, GETDATE(), 1, 0
)
MERGE INTO Member
	  USING Member_CTE as cte
	  ON Member.Id = cte.Id
	  WHEN MATCHED THEN 
			UPDATE SET 
				 Member.PersonId = cte.PersonId
				,Member.ChurchId = cte.ChurchId
				,Member.LocaleChurchId = cte.LocaleChurchId
				,Member.DateBaptized = cte.DateBaptized
				,Member.BaptizerId = cte.BaptizerId
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
			INSERT (Id, PersonId, ChurchId, LocaleChurchId, DateBaptized, BaptizerId, MaritalStatus, SpouseName, LandLine, MobileNumber, Email, MemberStatusId, DesignationId, DateCreated, CreatedBy, IsDeleted) 
			VALUES (cte.Id, cte.PersonId, cte.ChurchId, cte.LocaleChurchId, cte.DateBaptized, cte.BaptizerId, cte.MaritalStatus, cte.SpouseName, cte.LandLine, cte.MobileNumber, cte.Email, cte.MemberStatusId, cte.DesignationId, cte.DateCreated, cte.CreatedBy, cte.IsDeleted)
	  WHEN NOT MATCHED BY SOURCE THEN 
			DELETE;

SET IDENTITY_INSERT dbo.Member OFF
GO