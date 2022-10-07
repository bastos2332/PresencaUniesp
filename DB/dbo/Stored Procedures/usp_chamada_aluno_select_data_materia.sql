CREATE procedure [dbo].[usp_chamada_aluno_select_data_materia]
@idMateria int,
@numeroMatricula varchar(50),
@data date

as

select * from PresencaAluno
where idMateria = @idMateria and 
numeroMatricula = @numeroMatricula and 
CAST(dataChamada as date) = @data