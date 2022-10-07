create procedure usp_chamada_aluno_select_ip_JaRespondeu
@ipAluno varchar(100),
@idMateria int,
@data date

as

select * from PresencaAluno
where ipAluno = @ipAluno and 
CAST(dataChamada as date) = @data and
idMateria = @idMateria