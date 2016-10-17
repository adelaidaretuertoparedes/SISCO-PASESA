CREATE TABLE [dbo].[Classification] (
    [Id]               INT          IDENTITY (1, 1) NOT NULL,
    [ArticleGroupCode] INT          NOT NULL,
    [Name]             VARCHAR (50) NOT NULL,
    [CreationDate]     DATETIME     NOT NULL,
    [CreatorIpAddress] VARCHAR (20) NOT NULL,
    [CreatorUser]      VARCHAR (20) NOT NULL,
    [Status]           BIT          NOT NULL,
    [UpdateDate]       DATETIME     NULL,
    [UpdaterIpAddress] VARCHAR (20) NULL,
    [UpdaterUser]      VARCHAR (20) NULL,
    [Code]             AS           ([dbo].[UFN_GetNextCodeSequence]('CL',[Id],(4))),
    CONSTRAINT [PK_dbo.Classification] PRIMARY KEY CLUSTERED ([Id] ASC)
);







