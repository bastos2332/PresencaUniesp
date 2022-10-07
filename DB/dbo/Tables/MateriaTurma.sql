CREATE TABLE [dbo].[MateriaTurma] (
    [idMateria]            INT           IDENTITY (1, 1) NOT NULL,
    [nomeMateria]          VARCHAR (100) NULL,
    [idProfessor]          INT           NULL,
    [isChamadaAberta]      BIT           NULL,
    [identificacaoMateria] VARCHAR (50)  NULL,
    PRIMARY KEY CLUSTERED ([idMateria] ASC),
    CONSTRAINT [FK__Materia__idProfe__36B12243] FOREIGN KEY ([idProfessor]) REFERENCES [dbo].[Professor] ([IdProfessor])
);

