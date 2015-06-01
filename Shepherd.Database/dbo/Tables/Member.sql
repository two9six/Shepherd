CREATE TABLE [dbo].[Member]
(
	[Id] INT NOT NULL IDENTITY, 
	[PersonId] INT NOT NULL,
    [ChurchId] VARCHAR(20) NOT NULL, 
	[DateBabtized] DATETIME NOT NULL,
	[BabtizedById] INT NOT NULL,
	[MaritalStatus] VARCHAR(10) NULL,
	[SpouseName] VARCHAR(200) NULL,
	[LandLine] VARCHAR(50) NULL,
	[MobileNumber] VARCHAR(500) NULL,
	[Email] VARCHAR(500) NULL,
	[StatusId] INT NOT NULL,
	[MemberTypeId] INT NOT NULL,
	[ChurchDesignationId] INT NOT NULL,
	[DateCreated] DATETIME NOT NULL,
	[CreatedById] INT NOT NULL,
	[DateUpdated] DATETIME NULL,
	[UpdatedById] INT NULL,
    [IsDeleted] BIT NOT NULL DEFAULT 0
	CONSTRAINT [PK_Member] PRIMARY KEY ([Id]),
	CONSTRAINT [FK_Member_Person] FOREIGN KEY ([PersonId]) REFERENCES [dbo].[Person]([Id])   
)
