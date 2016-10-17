CREATE TABLE [dbo].[DetailSizeType] (
    [Id]               INT          IDENTITY (1, 1) NOT NULL,
    [SizeId]           INT          NOT NULL,
    [SizeTypeId]       INT          NOT NULL,
    [Order]            INT          NOT NULL,
    [CreationDate]     DATETIME     NOT NULL,
    [CreatorIpAddress] VARCHAR (20) NOT NULL,
    [CreatorUser]      VARCHAR (20) NOT NULL,
    [Status]           BIT          NOT NULL,
    [UpdateDate]       DATETIME     NULL,
    [UpdaterIpAddress] VARCHAR (20) NULL,
    [UpdaterUser]      VARCHAR (20) NULL,
    CONSTRAINT [PK_dbo.DetailSizeType] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.DetailSizeType_dbo.Size_SizeId] FOREIGN KEY ([SizeId]) REFERENCES [dbo].[Size] ([Id]),
    CONSTRAINT [FK_dbo.DetailSizeType_dbo.SizeType_SizeTypeId] FOREIGN KEY ([SizeTypeId]) REFERENCES [dbo].[SizeType] ([Id])
);




GO
CREATE NONCLUSTERED INDEX [IX_SizeTypeId]
    ON [dbo].[DetailSizeType]([SizeTypeId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_SizeId]
    ON [dbo].[DetailSizeType]([SizeId] ASC);

