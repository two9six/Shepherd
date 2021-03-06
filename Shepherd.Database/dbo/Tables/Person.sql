﻿CREATE TABLE [dbo].[Person]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FirstName] NVARCHAR(100) NOT NULL, 
    [LastName] NVARCHAR(100) NOT NULL, 
    [MiddleName] NVARCHAR(100) NULL, 
	[NameExtension] NVARCHAR(10) NULL,
    [BirthDate] DATE NOT NULL, 
	[PlaceOfBirth] VARCHAR(200) NULL,
	[Gender] CHAR NOT NULL,
	[Citizenship] VARCHAR(50) NULL,
	[AddressLine1] VARCHAR(200) NULL,
	[AddressLine2] VARCHAR(200) NULL,
	[City] VARCHAR(100) NULL,
	[StateProvince] VARCHAR(100) NULL,
	[Country] VARCHAR(100) NULL,
	[DateCreated] DATETIME NOT NULL ,
	[CreatedBy] INT NOT NULL,
	[DateModified] DATETIME NULL ,
	[ModifiedBy] INT NULL,
    [IsDeleted] BIT NOT NULL DEFAULT 0
)