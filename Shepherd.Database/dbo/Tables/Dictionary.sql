CREATE TABLE [dbo].[Dictionary]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [TypeId] INT NOT NULL, 
    [Value] VARCHAR(50) NOT NULL, 
	[Description] VARCHAR(200) NULL,
    [IsDeleted] BIT NOT NULL DEFAULT 0
	CONSTRAINT [FK_Dictionary_DictionaryType] FOREIGN KEY ([TypeId]) REFERENCES [dbo].[DictionaryType]([Id])   
)
