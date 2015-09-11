SET IDENTITY_INSERT dbo.Person ON
GO
PRINT 'Insert Person'

;WITH Person_CTE (Id, FirstName, LastName, MiddleName, BirthDate, PlaceOfBirth, Gender, Citizenship, AddressLine1, AddressLine2, City, StateProvince, Country, DateCreated, CreatedBy, IsDeleted) AS 
(
		  SELECT  1, 'Gideon', 'Jura', NULL, DATEADD(YEAR, -20, GETDATE()), 'Makati', 'M', 'Filipino', 'Test Address Line 1', 'Test Address Line 2', 'Makati', 'NCR', 'Philippines', GETDATE(), 1, 0
	UNION SELECT  2, 'Jace', 'Beleren', NULL, DATEADD(YEAR, -21, GETDATE()), 'Makati', 'M', 'Filipino', 'Test Address Line 1', 'Test Address Line 2', 'Makati', 'NCR', 'Philippines', GETDATE(), 1, 0
	UNION SELECT  3, 'Elspeth', 'Tirel', NULL, DATEADD(YEAR, -22, GETDATE()), 'Taguig', 'F', 'Filipino', 'Test Address Line 1', 'Test Address Line 2', 'Makati', 'NCR', 'Philippines', GETDATE(), 1, 0
	UNION SELECT  4, 'Liliana', 'Vess', NULL, DATEADD(YEAR, -23, GETDATE()), 'Taguig', 'F', 'Filipino', 'Test Address Line 1', 'Test Address Line 2', 'Makati', 'NCR', 'Philippines', GETDATE(), 1, 0
	UNION SELECT  5, 'Nissa', 'Revane', NULL, DATEADD(YEAR, -24, GETDATE()), 'Taguig', 'F', 'Filipino', 'Test Address Line 1', 'Test Address Line 2', 'Makati', 'NCR', 'Philippines', GETDATE(), 1, 0
	UNION SELECT  6, 'Chandra', 'Nalaar', NULL, DATEADD(YEAR, -22, GETDATE()), 'Taguig', 'F', 'Filipino', 'Test Address Line 1', 'Test Address Line 2', 'Makati', 'NCR', 'Philippines', GETDATE(), 1, 0
	UNION SELECT  7, 'Sorin', 'Markov', NULL, DATEADD(YEAR, -35, GETDATE()), 'Taguig', 'M', 'Filipino', 'Test Address Line 1', 'Test Address Line 2', 'Makati', 'NCR', 'Philippines', GETDATE(), 1, 0
	UNION SELECT  8, 'Ajani', 'Goldmane', NULL, DATEADD(YEAR, -45, GETDATE()), 'Taguig', 'M', 'Filipino', 'Test Address Line 1', 'Test Address Line 2', 'Makati', 'NCR', 'Philippines', GETDATE(), 1, 0
	UNION SELECT  9, 'Nicol', 'Bolas', NULL, DATEADD(YEAR, -61, GETDATE()), 'Taguig', 'M', 'Filipino', 'Test Address Line 1', 'Test Address Line 2', 'Makati', 'NCR', 'Philippines', GETDATE(), 1, 0
	UNION SELECT 10, 'Dack', 'Fayden', NULL, DATEADD(YEAR, -39, GETDATE()), 'Taguig', 'M', 'Filipino', 'Test Address Line 1', 'Test Address Line 2', 'Makati', 'NCR', 'Philippines', GETDATE(), 1, 0
	UNION SELECT 11, 'Domri', 'Rade', NULL, DATEADD(YEAR, -35, GETDATE()), 'Taguig', 'M', 'Filipino', 'Test Address Line 1', 'Test Address Line 2', 'Makati', 'NCR', 'Philippines', GETDATE(), 1, 0
	UNION SELECT 12, 'Garruk', 'Wildspeaker', NULL, DATEADD(YEAR, -35, GETDATE()), 'Taguig', 'M', 'Filipino', 'Test Address Line 1', 'Test Address Line 2', 'Makati', 'NCR', 'Philippines', GETDATE(), 1, 0
	UNION SELECT 13, 'Kiora', 'Wave', NULL, DATEADD(YEAR, -28, GETDATE()), 'Taguig', 'F', 'Filipino', 'Test Address Line 1', 'Test Address Line 2', 'Makati', 'NCR', 'Philippines', GETDATE(), 1, 0
	UNION SELECT 14, 'Ashiok', 'Weaver', NULL, DATEADD(YEAR, -51, GETDATE()), 'Taguig', 'M', 'Filipino', 'Test Address Line 1', 'Test Address Line 2', 'Makati', 'NCR', 'Philippines', GETDATE(), 1, 0
	UNION SELECT 15, 'Karn', 'Liberated', NULL, DATEADD(YEAR, -56, GETDATE()), 'Taguig', 'M', 'Filipino', 'Test Address Line 1', 'Test Address Line 2', 'Makati', 'NCR', 'Philippines', GETDATE(), 1, 0
	UNION SELECT 16, 'Koth', 'Hammer', NULL, DATEADD(YEAR, -38, GETDATE()), 'Taguig', 'M', 'Filipino', 'Test Address Line 1', 'Test Address Line 2', 'Makati', 'NCR', 'Philippines', GETDATE(), 1, 0
	UNION SELECT 17, 'Nahiri', 'Litho', NULL, DATEADD(YEAR, -33, GETDATE()), 'Taguig', 'F', 'Filipino', 'Test Address Line 1', 'Test Address Line 2', 'Makati', 'NCR', 'Philippines', GETDATE(), 1, 0
	UNION SELECT 18, 'Narset', 'Transcendent', NULL, DATEADD(YEAR, -35, GETDATE()), 'Taguig', 'F', 'Filipino', 'Test Address Line 1', 'Test Address Line 2', 'Makati', 'NCR', 'Philippines', GETDATE(), 1, 0
	UNION SELECT 19, 'Ral', 'Zarek', NULL, DATEADD(YEAR, -30, GETDATE()), 'Taguig', 'M', 'Filipino', 'Test Address Line 1', 'Test Address Line 2', 'Makati', 'NCR', 'Philippines', GETDATE(), 1, 0
	UNION SELECT 20, 'Sarkhan', 'Vol', NULL, DATEADD(YEAR, -41, GETDATE()), 'Taguig', 'M', 'Filipino', 'Test Address Line 1', 'Test Address Line 2', 'Makati', 'NCR', 'Philippines', GETDATE(), 1, 0
	UNION SELECT 21, 'Teferi', 'Jamuraan', NULL, DATEADD(YEAR, -53, GETDATE()), 'Taguig', 'M', 'Filipino', 'Test Address Line 1', 'Test Address Line 2', 'Makati', 'NCR', 'Philippines', GETDATE(), 1, 0
	UNION SELECT 22, 'Tezzeret', 'Seeker', NULL, DATEADD(YEAR, -39, GETDATE()), 'Taguig', 'M', 'Filipino', 'Test Address Line 1', 'Test Address Line 2', 'Makati', 'NCR', 'Philippines', GETDATE(), 1, 0
	UNION SELECT 23, 'Tibalt', 'Nephalia', NULL, DATEADD(YEAR, -29, GETDATE()), 'Taguig', 'M', 'Filipino', 'Test Address Line 1', 'Test Address Line 2', 'Makati', 'NCR', 'Philippines', GETDATE(), 1, 0
	UNION SELECT 24, 'Tamiyo', 'Oboro', NULL, DATEADD(YEAR, -36, GETDATE()), 'Taguig', 'F', 'Filipino', 'Test Address Line 1', 'Test Address Line 2', 'Makati', 'NCR', 'Philippines', GETDATE(), 1, 0
	UNION SELECT 25, 'Venser', 'Savant', NULL, DATEADD(YEAR, -25, GETDATE()), 'Taguig', 'M', 'Filipino', 'Test Address Line 1', 'Test Address Line 2', 'Makati', 'NCR', 'Philippines', GETDATE(), 1, 0
	UNION SELECT 26, 'Vraska', 'Unseen', NULL, DATEADD(YEAR, -41, GETDATE()), 'Taguig', 'F', 'Filipino', 'Test Address Line 1', 'Test Address Line 2', 'Makati', 'NCR', 'Philippines', GETDATE(), 1, 0
	UNION SELECT 27, 'Xenagos', 'Reveler', NULL, DATEADD(YEAR, -44, GETDATE()), 'Taguig', 'M', 'Filipino', 'Test Address Line 1', 'Test Address Line 2', 'Makati', 'NCR', 'Philippines', GETDATE(), 1, 0
	UNION SELECT 28, 'Ugin', 'Tarkir', NULL, DATEADD(YEAR, -64, GETDATE()), 'Taguig', 'M', 'Filipino', 'Test Address Line 1', 'Test Address Line 2', 'Makati', 'NCR', 'Philippines', GETDATE(), 1, 0
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
				,Person.DateCreated = cte.DateCreated
				,Person.CreatedBy = cte.CreatedBy
				,Person.IsDeleted = cte.IsDeleted
	  WHEN NOT MATCHED BY TARGET THEN 
			INSERT (Id, FirstName, LastName, MiddleName, BirthDate, PlaceOfBirth, Gender, Citizenship, AddressLine1, AddressLine2, City, StateProvince, Country, DateCreated, CreatedBy, IsDeleted) 
			VALUES (cte.Id, cte.FirstName, cte.LastName, cte.MiddleName, cte.BirthDate, cte.PlaceOfBirth, cte.Gender, cte.Citizenship, cte.AddressLine1, cte.AddressLine2, cte.City, cte.StateProvince, cte.Country, cte.DateCreated, cte.CreatedBy, cte.IsDeleted)
	  WHEN NOT MATCHED BY SOURCE THEN 
			DELETE;

SET IDENTITY_INSERT dbo.Person OFF
GO