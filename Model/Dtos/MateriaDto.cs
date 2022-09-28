using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DTO
{
    public class MateriaDto
    {
        [Key]
        public int IdMateria { get; set; }
        public string NomeMateria { get; set; }
        public int IdProfessor { get; set; }
        public bool IsChamadaAberta { get; set; }
        public string IdConteudo { get; set; }
    }


}
