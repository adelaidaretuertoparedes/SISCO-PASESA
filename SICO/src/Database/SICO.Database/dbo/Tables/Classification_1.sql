CREATE TABLE [dbo].[Classification] (
    [Id]               INT            IDENTITY (1, 1) NOT NULL,
    [Code]             NVARCHAR (MAX) NULL,
    [CodeArticleGroup] NVARCHAR (MAX) NULL,
    [Name]             NVARCHAR (MAX) NULL,
    [Description]      NVARCHAR (MAX) NULL,
    [Active]           BIT            NOT NULL,
    [Status]           BIT            NOT NULL,
    [CreationDate]     DATETIME       DEFAULT ('1900-01-01T00:00:00.000') NOT NULL,
    [CreatorIpAddress] NVARCHAR (MAX) NULL,
    [CreatorUser]      NVARCHAR (MAX) NULL,
    [UpdateDate]       DATETIME       NULL,
    [UpdaterIpAddress] NVARCHAR (MAX) NULL,
    [UpdaterUser]      NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.Classification] PRIMARY KEY CLUSTERED ([Id] ASC)
);

