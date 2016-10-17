CREATE TABLE [dbo].[ParameterDetail] (
    [Id]                      SMALLINT       IDENTITY (1, 1) NOT NULL,
    [Name]                    NVARCHAR (200) NOT NULL,
    [ParentParameterDetailId] SMALLINT       NULL,
    [ParameterId]             NVARCHAR (30)  NOT NULL,
    [Valor1]                  NVARCHAR (100) NULL,
    [Valor2]                  NVARCHAR (100) NULL,
    [Valor3]                  NVARCHAR (100) NULL,
    [CreationDate]            DATETIME       NOT NULL,
    [CreatorIpAddress]        VARCHAR (20)   NOT NULL,
    [CreatorUser]             VARCHAR (20)   NOT NULL,
    [Status]                  BIT            NOT NULL,
    [UpdateDate]              DATETIME       NULL,
    [UpdaterIpAddress]        VARCHAR (20)   NULL,
    [UpdaterUser]             VARCHAR (20)   NULL,
    CONSTRAINT [PK_dbo.ParameterDetail] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.ParameterDetail_dbo.Parameter_ParameterId] FOREIGN KEY ([ParameterId]) REFERENCES [dbo].[Parameter] ([Id]),
    CONSTRAINT [FK_dbo.ParameterDetail_dbo.ParameterDetail_ParentParameterDetailId] FOREIGN KEY ([ParentParameterDetailId]) REFERENCES [dbo].[ParameterDetail] ([Id])
);




GO
CREATE NONCLUSTERED INDEX [IX_ParameterId]
    ON [dbo].[ParameterDetail]([ParameterId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_ParentParameterDetailId]
    ON [dbo].[ParameterDetail]([ParentParameterDetailId] ASC);

