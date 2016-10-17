CREATE TABLE [dbo].[Trademark] (
    [Id]               INT           IDENTITY (1, 1) NOT NULL,
    [Name]             VARCHAR (50)  NOT NULL,
    [CreationDate]     DATETIME      NOT NULL,
    [CreatorIpAddress] VARCHAR (20)  NOT NULL,
    [CreatorUser]      VARCHAR (20)  NOT NULL,
    [Status]           BIT           NOT NULL,
    [UpdateDate]       DATETIME      NULL,
    [UpdaterIpAddress] VARCHAR (20)  NULL,
    [UpdaterUser]      VARCHAR (20)  NULL,
    [Code]             AS            ([dbo].[UFN_GetNextCodeSequence]('MC',[Id],(4))),
    [ShortName]        VARCHAR (50)  NULL,
    [Owner]            VARCHAR (100) NULL,
    [LegacyCode]       CHAR(2)   NOT NULL,
    CONSTRAINT [PK_dbo.Trademark] PRIMARY KEY CLUSTERED ([Id] ASC)
);









