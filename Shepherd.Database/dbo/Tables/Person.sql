CREATE TABLE [dbo].[Person]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FirstName] VARCHAR(100) NOT NULL, 
    [LastName] VARCHAR(100) NOT NULL, 
    [MiddleName] VARCHAR(100) NULL, 
    [BirthDate] DATE NOT NULL, 
	[DateCreated] DATETIME NULL,
	[DateUpdated] DATETIME NULL,
    [IsDeleted] BIT NOT NULL DEFAULT 0
)