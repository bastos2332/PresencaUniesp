CREATE procedure [dbo].[usp_chamada_list_data]
@data char(10),
@idProfessor int
as

SELECT * FROM MateriaTurma mat
	join Professor prof on prof.IdProfessor = mat.idProfessor
	join PresencaAluno chamada on chamada.idMateria = mat.idMateria
WHERE prof.idProfessor = @idProfessor 
and CAST(chamada.dataChamada AS DATE) = CAST(@data as date)