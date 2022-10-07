create procedure usp_professor_select
@idprofessor int
as
select * from Professor where IdProfessor = @idprofessor