CREATE TABLE [dbo].[Member]
(
	[Id] INT NOT NULL IDENTITY, 
	[PersonId] INT NOT NULL,
    [ChurchId] VARCHAR(20) NOT NULL, 
	[LocaleChurchId] VARCHAR(10) NOT NULL,
	[DateBaptized] DATETIME NOT NULL,
	[BaptizerId] INT NOT NULL,
	[MaritalStatus] VARCHAR(10) NULL,
	[SpouseName] VARCHAR(200) NULL,
	[LandLine] VARCHAR(50) NULL,
	[MobileNumber] VARCHAR(500) NULL,
	[Email] VARCHAR(500) NULL,
	[MemberStatusId] TINYINT NOT NULL,
	[DesignationId] TINYINT NOT NULL,
	[DateCreated] DATETIME NOT NULL ,
	[CreatedBy] INT NOT NULL,
	[DateModified] DATETIME NULL ,
	[ModifiedBy] INT NULL,
    [IsDeleted] BIT NOT NULL DEFAULT 0
	CONSTRAINT [PK_Member] PRIMARY KEY ([Id]),
	CONSTRAINT [FK_Member_Person] FOREIGN KEY ([PersonId]) REFERENCES [dbo].[Person]([Id]),
	CONSTRAINT [FK_Member_MemberStatus] FOREIGN KEY ([MemberStatusId]) REFERENCES [dbo].[MemberStatus]([Id]),
	CONSTRAINT [FK_Member_Designation] FOREIGN KEY ([DesignationId]) REFERENCES [dbo].[Designation]([Id]),
	CONSTRAINT [FK_Member_Baptizer] FOREIGN KEY ([BaptizerId]) REFERENCES [dbo].[Baptizer]([Id]),
	--CONSTRAINT Member_ChurchId UNIQUE ([ChurchId]),
	--CONSTRAINT Member_LocaleChuchId UNIQUE ([LocaleChurchId])
)
