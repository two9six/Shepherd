CREATE TABLE [dbo].[Person]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FirstName] VARCHAR(100) NOT NULL, 
    [LastName] VARCHAR(100) NOT NULL, 
    [MiddleName] VARCHAR(100) NULL, 
    [BirthDate] DATE NOT NULL, 
	[Gender] CHAR NOT NULL,
	[MaritalStatus] VARCHAR(10) NULL,
	[AddressLine1] VARCHAR(200) NULL,
	[AddressLine2] VARCHAR(200) NULL,
	[City] VARCHAR(100) NULL,
	[StateProvince] VARCHAR(100) NULL,
	[Country] VARCHAR(100) NULL,
	[LandLine] VARCHAR(50) NULL,
	[MobileNumber] VARCHAR(500) NULL,
	[Email] VARCHAR(500) NULL,
	[DateCreated] DATETIME NOT NULL,
	[CreatedBy] INT NOT NULL,
	[DateUpdated] DATETIME NULL,
	[UpdatedBy] INT NULL,
    [IsDeleted] BIT NOT NULL DEFAULT 0
)