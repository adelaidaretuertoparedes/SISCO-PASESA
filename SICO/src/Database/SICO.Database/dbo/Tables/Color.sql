CREATE TABLE [dbo].[Color] (
    [Id]               INT           IDENTITY (1, 1) NOT NULL,
    [LegacyCode]       CHAR(3)   NOT NULL,
    [Name]             VARCHAR (50)  NOT NULL,
    [Status]           BIT           NOT NULL,
    [CreationDate]     DATETIME      CONSTRAINT [DF__Color__CreationD__145C0A3F] DEFAULT ('1900-01-01T00:00:00.000') NOT NULL,
    [CreatorIpAddress] VARCHAR(20) CONSTRAINT [DF__Color__CreatorIp__15502E78] DEFAULT ('') NOT NULL,
    [CreatorUser]      VARCHAR(20) CONSTRAINT [DF__Color__CreatorUs__164452B1] DEFAULT ('') NOT NULL,
    [UpdateDate]       DATETIME      NULL,
    [UpdaterIpAddress] VARCHAR(20) NULL,
    [UpdaterUser]      VARCHAR(20) NULL,
    [Code]             AS            ([dbo].[UFN_GetNextCodeSequence]('CR',[Id],(5))),
    CONSTRAINT [PK_dbo.Color] PRIMARY KEY CLUSTERED ([Id] ASC)
);







