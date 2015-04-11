SET IDENTITY_INSERT dbo.Person ON
GO
PRINT 'Insert Person'

;WITH Person_CTE (Id, FirstName, LastName, MiddleName, BirthDate, Gender, DateCreated, CreatedBy, IsDeleted) AS 
(
				  SELECT 1, 'Gideon', 'Jura', NULL, DATEADD(YEAR, -20, GETDATE()), 'M', GETDATE(), 1, 0
			UNION SELECT 2, 'Jace', 'Beleren', NULL, DATEADD(YEAR, -21, GETDATE()), 'M', GETDATE(), 1, 0
			UNION SELECT 3, 'Elspeth', 'Tirel', NULL, DATEADD(YEAR, -22, GETDATE()), 'F', GETDATE(), 1, 0
			UNION SELECT 4, 'Liliana', 'Vess', NULL, DATEADD(YEAR, -23, GETDATE()), 'F', GETDATE(), 1, 0
)
MERGE INTO Person
	  USING Person_CTE as cte
	  ON Person.Id = cte.Id
	  WHEN MATCHED THEN 
			UPDATE SET 
				 Person.FirstName = cte.FirstName
				,Person.LastName = cte.LastName
				,Person.MiddleName = cte.MiddleName
				,Person.BirthDate = cte.BirthDate
				,Person.Gender = cte.Gender
				,Person.DateCreated = cte.DateCreated
				,Person.CreatedBy = cte.CreatedBy
				,Person.IsDeleted = cte.IsDeleted
	  WHEN NOT MATCHED BY TARGET THEN 
			INSERT (Id, FirstName, LastName, MiddleName, BirthDate, Gender, DateCreated, CreatedBy, IsDeleted) 
			VALUES (cte.Id, cte.FirstName, cte.LastName, cte.MiddleName, cte.BirthDate, cte.Gender, cte.DateCreated, cte.CreatedBy, cte.IsDeleted)
	  WHEN NOT MATCHED BY SOURCE THEN 
			DELETE;

SET IDENTITY_INSERT dbo.Person OFF
GO