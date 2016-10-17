CREATE TABLE [dbo].[Size] (
    [Id]               INT          IDENTITY (1, 1) NOT NULL,
    [Name]             VARCHAR (50) NOT NULL,
    [LegacyCode]       VARCHAR (3)  NOT NULL,
    [Status]           BIT          NOT NULL,
    [CreationDate]     DATETIME     CONSTRAINT [DF__tmp_ms_xx__Creat__5CD6CB2B] DEFAULT ('1900-01-01T00:00:00.000') NOT NULL,
    [CreatorIpAddress] VARCHAR (20) NULL,
    [CreatorUser]      VARCHAR (20) NULL,
    [UpdateDate]       DATETIME     NULL,
    [UpdaterIpAddress] VARCHAR (20) NULL,
    [UpdaterUser]      VARCHAR (20) NULL,
    [Code]             AS           ([dbo].[UFN_GetNextCodeSequence]('TL',[Id],(5))),
    CONSTRAINT [PK_dbo.Size] PRIMARY KEY CLUSTERED ([Id] ASC)
);








