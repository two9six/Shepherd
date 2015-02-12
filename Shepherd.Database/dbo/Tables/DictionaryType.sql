CREATE TABLE [dbo].[DictionaryType]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Value] VARCHAR(50) NOT NULL, 
	[Description] VARCHAR(200) NULL,
    [IsDeleted] BIT NOT NULL DEFAULT 0    
)
