CREATE TABLE [dbo].[Person]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FirstName] VARCHAR(100) NOT NULL, 
    [LastName] VARCHAR(100) NOT NULL, 
    [MiddleName] VARCHAR(100) NULL, 
    [BirthDate] DATE NOT NULL, 
	[PlaceOfBirth] VARCHAR(200) NULL,
	[Gender] CHAR NOT NULL,
	[Citizenship] VARCHAR(50) NULL,
	[AddressLine1] VARCHAR(200) NULL,
	[AddressLine2] VARCHAR(200) NULL,
	[City] VARCHAR(100) NULL,
	[StateProvince] VARCHAR(100) NULL,
	[Country] VARCHAR(100) NULL,
	[DateCreated] DATETIME NOT NULL DEFAULT GETDATE(),
	[CreatedBy] INT NOT NULL,
	[DateModified] DATETIME NULL ,
	[ModifiedBy] INT NULL,
    [IsDeleted] BIT NOT NULL DEFAULT 0
)