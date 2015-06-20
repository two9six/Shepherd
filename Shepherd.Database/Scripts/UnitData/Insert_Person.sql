SET IDENTITY_INSERT dbo.Person ON
GO
PRINT 'Insert Person'

;WITH Person_CTE (Id, FirstName, LastName, MiddleName, BirthDate, PlaceOfBirth, Gender, Citizenship, AddressLine1, AddressLine2, City, StateProvince, Country, CreatedBy, IsDeleted) AS 
(
				  SELECT 1, 'Gideon', 'Jura', NULL, DATEADD(YEAR, -20, GETDATE()), 'Makati', 'M', 'Filipino', 'Test Address Line 1', 'Test Address Line 2', 'Makati', 'NCR', 'Philippines', 1, 0
			UNION SELECT 2, 'Jace', 'Beleren', NULL, DATEADD(YEAR, -21, GETDATE()), 'Makati', 'M', 'Filipino', 'Test Address Line 1', 'Test Address Line 2', 'Makati', 'NCR', 'Philippines', 1, 0
			UNION SELECT 3, 'Elspeth', 'Tirel', NULL, DATEADD(YEAR, -22, GETDATE()), 'Taguig', 'F', 'Filipino', 'Test Address Line 1', 'Test Address Line 2', 'Makati', 'NCR', 'Philippines', 1, 0
			UNION SELECT 4, 'Liliana', 'Vess', NULL, DATEADD(YEAR, -23, GETDATE()), 'Taguig', 'F', 'Filipino', 'Test Address Line 1', 'Test Address Line 2', 'Makati', 'NCR', 'Philippines', 1, 0
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
				,Person.PlaceOfBirth = cte.PlaceOfBirth
				,Person.Gender = cte.Gender
				,Person.Citizenship = cte.Citizenship
				,Person.AddressLine1 = cte.AddressLine1
				,Person.AddressLine2 = cte.AddressLine2
				,Person.City = cte.City
				,Person.StateProvince = cte.StateProvince
				,Person.Country = cte.Country
				,Person.CreatedBy = cte.CreatedBy
				,Person.IsDeleted = cte.IsDeleted
	  WHEN NOT MATCHED BY TARGET THEN 
			INSERT (Id, FirstName, LastName, MiddleName, BirthDate, PlaceOfBirth, Gender, Citizenship, AddressLine1, AddressLine2, City, StateProvince, Country, CreatedBy, IsDeleted) 
			VALUES (cte.Id, cte.FirstName, cte.LastName, cte.MiddleName, cte.BirthDate, cte.PlaceOfBirth, cte.Gender, cte.Citizenship, cte.AddressLine1, cte.AddressLine2, cte.City, cte.StateProvince, cte.Country, cte.CreatedBy, cte.IsDeleted)
	  WHEN NOT MATCHED BY SOURCE THEN 
			DELETE;

SET IDENTITY_INSERT dbo.Person OFF
GO