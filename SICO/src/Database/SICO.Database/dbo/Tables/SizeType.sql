CREATE TABLE [dbo].[SizeType] (
    [Id]               INT           IDENTITY (1, 1) NOT NULL,
    [Name]             VARCHAR (50)  NOT NULL,
    [LegacyCode]       VARCHAR (3)   NOT NULL,
    [Status]           BIT           NOT NULL,
    [Description]      VARCHAR (100) DEFAULT ((0)) NULL,
    [CreationDate]     DATETIME      DEFAULT ('1900-01-01T00:00:00.000') NOT NULL,
    [CreatorIpAddress] VARCHAR (20)  DEFAULT ('') NOT NULL,
    [CreatorUser]      VARCHAR (20)  DEFAULT ('') NOT NULL,
    [UpdateDate]       DATETIME      NULL,
    [UpdaterIpAddress] VARCHAR (20)  NULL,
    [UpdaterUser]      VARCHAR (20)  NULL,
    [Code]             AS            ([dbo].[UFN_GetNextCodeSequence]('TP',[Id],(4))),
    CONSTRAINT [PK_dbo.SizeType] PRIMARY KEY CLUSTERED ([Id] ASC)
);












GO
CREATE NONCLUSTERED INDEX [IX_IdClasification]
    ON [dbo].[SizeType]([Description] ASC);



