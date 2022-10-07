CREATE procedure usp_professor_select_decript
@idProfessor int,
@frase varchar(500)
as


SELECT 
IdProfessor,
nomeProfessor,
CAST(DECRYPTBYPASSPHRASE(@frase, usuarioSistema) as varchar(max)) as usuarioSistema
,CAST(DECRYPTBYPASSPHRASE(@frase, senhaSistema) as varchar(max)) as senhaSistema

FROM Professor
WHERE IdProfessor = @idProfessor