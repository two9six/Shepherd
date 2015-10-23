CREATE TABLE [dbo].[Designation]
(
	[Id] TINYINT NOT NULL PRIMARY KEY IDENTITY, 
    [DesignationTypeId] TINYINT NOT NULL,
	[Name] VARCHAR(128) NOT NULL, 
	[SortOrder] BIT NOT NULL,
    [IsDefault] BIT NOT NULL DEFAULT 0,
	[IsDeleted] BIT NOT NULL DEFAULT 0
	CONSTRAINT [FK_Designation_DesignationType] FOREIGN KEY ([DesignationTypeId]) REFERENCES [dbo].[DesignationType]([Id]),
)
