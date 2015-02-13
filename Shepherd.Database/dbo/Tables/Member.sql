CREATE TABLE [dbo].[Member]
(
	[Id] INT NOT NULL IDENTITY, 
	[PersonId] INT NOT NULL,
    [GeneratedId] VARCHAR(20) NOT NULL, 
	[StatusId] INT NOT NULL,
	[DateCreated] DATETIME NULL,
	[DateUpdated] DATETIME NULL,
    [IsDeleted] BIT NOT NULL DEFAULT 0
	CONSTRAINT [PK_Member] PRIMARY KEY ([Id]),
	CONSTRAINT [FK_Member_Person] FOREIGN KEY ([PersonId]) REFERENCES [dbo].[Person]([Id])   
)
