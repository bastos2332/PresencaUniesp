create procedure [dbo].[usp_chamada_aluno_select_MAC_JaRespondeu]
@EnderecoMACAluno varchar(500),
@idMateria int,
@data date

as

select * from PresencaAluno
where EnderecoMACAluno = @EnderecoMACAluno and 
CAST(dataChamada as date) = @data and
idMateria = @idMateria