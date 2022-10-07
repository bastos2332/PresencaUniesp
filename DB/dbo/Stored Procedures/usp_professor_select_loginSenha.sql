CREATE procedure [dbo].[usp_professor_select_loginSenha]
@senha char(10),
@usuario int,
@frase varchar(200)
as

SELECT * FROM Professor 
WHERE CAST(DECRYPTBYPASSPHRASE(@frase, senhaSistema) as varchar(max)) = @senha 
and CAST(DECRYPTBYPASSPHRASE(@frase, usuarioSistema) as varchar(max)) = @usuario