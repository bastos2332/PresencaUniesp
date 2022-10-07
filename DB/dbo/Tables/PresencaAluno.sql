CREATE TABLE [dbo].[PresencaAluno] (
    [idPresenca]      INT           IDENTITY (1, 1) NOT NULL,
    [numeroMatricula] VARCHAR (30)  NULL,
    [dataChamada]     DATETIME      NULL,
    [ipAluno]         VARCHAR (100) NULL,
    [nomeAluno]       VARCHAR (100) NULL,
    [idMateria]       INT           NULL,
    [StatusPresenca]  VARCHAR (20)  NULL,
    CONSTRAINT [PK_Chamada] PRIMARY KEY CLUSTERED ([idPresenca] ASC),
    CONSTRAINT [FK_ChamadaAluno_Materia] FOREIGN KEY ([idMateria]) REFERENCES [dbo].[MateriaTurma] ([idMateria])
);

