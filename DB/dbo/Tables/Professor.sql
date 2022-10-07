CREATE TABLE [dbo].[Professor] (
    [IdProfessor]    INT             IDENTITY (1, 1) NOT NULL,
    [nomeProfessor]  VARCHAR (100)   NULL,
    [usuarioSistema] VARBINARY (MAX) NULL,
    [senhaSistema]   VARBINARY (MAX) NULL,
    CONSTRAINT [PK__Professo__9D84BE1BE7459F15] PRIMARY KEY CLUSTERED ([IdProfessor] ASC)
);

