CREATE TABLE [dbo].[GatheringSchedule]
(
	[Id] INT NOT NULL IDENTITY, 
    [GatheringTypeId] TINYINT NOT NULL, 
    [StartTime] BIGINT NOT NULL,
	[EndTime] BIGINT NOT NULL,
	[Notes] VARCHAR(MAX) NULL,
	[DateCreated] DATETIME NOT NULL ,
	[CreatedBy] INT NOT NULL,
	[DateModified] DATETIME NULL ,
	[ModifiedBy] INT NULL,
    [IsDeleted] BIT NOT NULL DEFAULT 0,
	CONSTRAINT [FK_GatheringSchedule_GatheringType] FOREIGN KEY ([GatheringTypeId]) REFERENCES [dbo].[GatheringType]([Id]),
	CONSTRAINT [PK_GatheringSchedule] PRIMARY KEY ([Id])

)
