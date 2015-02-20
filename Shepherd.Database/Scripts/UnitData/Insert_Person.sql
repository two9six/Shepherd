SET IDENTITY_INSERT dbo.Person ON
GO
PRINT 'Insert Person'

;WITH Person_CTE (Id, FirstName, LastName, MiddleName, BirthDate, IsDeleted) AS 
(
				  SELECT 1, 'Liliana', 'Vess', NULL, DATEADD(YEAR, -20, GETDATE()), 0
			UNION SELECT 2, 'Elspeth', 'Tirel', NULL, DATEADD(YEAR, -21, GETDATE()), 0
			UNION SELECT 3, 'Chandra', 'Nalaar', NULL, DATEADD(YEAR, -22, GETDATE()), 0
			UNION SELECT 4, 'Nissa', 'Revane', NULL, DATEADD(YEAR, -23, GETDATE()), 0
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
				,Person.IsDeleted = cte.IsDeleted
	  WHEN NOT MATCHED BY TARGET THEN 
			INSERT (Id, FirstName, LastName, MiddleName, BirthDate, IsDeleted) 
			VALUES (cte.Id, cte.FirstName, cte.LastName, cte.MiddleName, cte.BirthDate, cte.IsDeleted)
	  WHEN NOT MATCHED BY SOURCE THEN 
			DELETE;

SET IDENTITY_INSERT dbo.Person OFF
GO