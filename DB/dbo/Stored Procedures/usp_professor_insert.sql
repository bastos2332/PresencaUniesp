create procedure [dbo].[usp_professor_insert]
@senha varchar(20),
@usuario varchar(20),
@NomeProfessor varchar(100),
@frase varchar(200)
as

insert into Professor(
nomeProfessor,
usuarioSistema,
senhaSistema
)
values(
@NomeProfessor,
ENCRYPTBYPASSPHRASE(@frase, @usuario),  
ENCRYPTBYPASSPHRASE(@frase, @senha)
)