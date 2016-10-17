CREATE TABLE [dbo].[Parameter] (
    [Id]           NVARCHAR (30)  NOT NULL,
    [Name]         NVARCHAR (50)  NOT NULL,
    [Description]  NVARCHAR (200) NULL,
    [Status]       BIT            NOT NULL,
    [Maintainable] BIT            NOT NULL,
    CONSTRAINT [PK_dbo.Parameter] PRIMARY KEY CLUSTERED ([Id] ASC)
);

