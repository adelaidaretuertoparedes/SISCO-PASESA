CREATE TABLE [dbo].[AvailableLegacyCode] (
    [Id]     INT          IDENTITY (1, 1) NOT NULL,
    [Code]   VARCHAR (10) NOT NULL,
    [TypeId] INT          NOT NULL,
    [Type]   VARCHAR (20) NOT NULL,
    CONSTRAINT [PK_dbo.AvailableLegacyCode] PRIMARY KEY CLUSTERED ([Id] ASC)
);



