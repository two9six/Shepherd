CREATE TABLE [dbo].[Lookup]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [LookupTypeId] INT NOT NULL, 
    [Name] VARCHAR(50) NOT NULL, 
    [IsDefault] BIT NOT NULL DEFAULT 0,
	[IsDeleted] BIT NOT NULL DEFAULT 0
	CONSTRAINT [FK_Lookup_LookupType] FOREIGN KEY ([LookupTypeId]) REFERENCES [dbo].[LookupType]([Id])   
)
