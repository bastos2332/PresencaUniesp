create procedure [dbo].[usp_presenca_materia_list_data]
@idMateria int,
@data date

as

select * from PresencaAluno
where idMateria = @idMateria and 
CAST(dataChamada as date) = @data