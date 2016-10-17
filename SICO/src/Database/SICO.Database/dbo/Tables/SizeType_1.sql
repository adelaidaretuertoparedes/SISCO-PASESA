CREATE TABLE [dbo].[SizeType] (
    [Id]               INT           IDENTITY (1, 1) NOT NULL,
    [Name]             VARCHAR (50)  NOT NULL,
    [LegacyCode]       VARCHAR (3)   NOT NULL,
    [Active]           BIT           NOT NULL,
    [Status]           BIT           NOT NULL,
    [Description]  VARCHAR(100)           DEFAULT ((0)) NOT NULL,
    [CreationDate]     DATETIME      DEFAULT ('1900-01-01T00:00:00.000') NOT NULL,
    [CreatorIpAddress] NVARCHAR (20) DEFAULT ('') NOT NULL,
    [CreatorUser]      NVARCHAR (20) DEFAULT ('') NOT NULL,
    [UpdateDate]       DATETIME      NULL,
    [UpdaterIpAddress] NVARCHAR (20) NULL,
    [UpdaterUser]      NVARCHAR (20) NULL,
    [Code]             AS            ([dbo].[UFN_GetNextCodeSequence]('TP',[Id],(3))),
    CONSTRAINT [PK_dbo.SizeType] PRIMARY KEY CLUSTERED ([Id] ASC)
);




GO
CREATE NONCLUSTERED INDEX [IX_IdClasification]
    ON [dbo].[SizeType]([Description] ASC);

