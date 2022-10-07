CREATE procedure [dbo].[usp_materia_list_professor]
@idProfessor int
as

select 
*,
CONCAT('materia_', idMateria) idConteudo

from MateriaTurma where idProfessor = @idProfessor