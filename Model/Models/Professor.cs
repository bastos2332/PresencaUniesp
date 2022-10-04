using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Professor
{

    [Key]
    public int IdProfessor { get; set; }
    public string NomeProfessor { get; set; }
    public string UsuarioSistema { get; set; }
    public string SenhaSistema { get; set; }

}
