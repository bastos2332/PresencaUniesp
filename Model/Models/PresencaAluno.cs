using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper.Contrib.Extensions;
public class PresencaAluno
{
    [Key]
    public int IdPresenca { get; set; }
    public string NumeroMatricula { get; set; }
    public DateTime DataChamada { get; set; }
    public string IpAluno { get; set; }
    public string NomeAluno { get; set; }
    public bool IsMatriculaEncontrada { get; set; }
    public int IdMateria { get; set; }
    public bool IsProcessado { get; set; }
}
