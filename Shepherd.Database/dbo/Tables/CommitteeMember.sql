CREATE TABLE [dbo].[CommitteeMember]
(
	[Id] INT NOT NULL IDENTITY, 
	[CommitteeId] INT NOT NULL,
	[MemberId] INT NOT NULL, 
	[IsCommitteeHead] BIT NOT NULL DEFAULT 0,
	[CreatedBy] INT NULL,
	[DateCreated] DATETIME NULL,
	CONSTRAINT [PK_CommitteeMember] PRIMARY KEY ([Id]),
	CONSTRAINT [FK_CommitteeMember_Committee] FOREIGN KEY ([CommitteeId]) REFERENCES [dbo].[Committee]([Id]),
	CONSTRAINT [FK_CommitteeMember_Member] FOREIGN KEY ([MemberId]) REFERENCES [dbo].[Member]([Id]),
)
