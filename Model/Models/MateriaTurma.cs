using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class MateriaTurma
{
    [Key]
    public int IdMateria { get; set; }
    public string NomeMateria { get; set; }
    public int IdProfessor { get; set; }
    public bool IsChamadaAberta { get; set; }
    public string IdentificacaoMateria { get; set; }
}
