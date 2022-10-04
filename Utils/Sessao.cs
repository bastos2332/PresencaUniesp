
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using PRESENCA_FACIL.DTO;
namespace PRESENCA_FACIL.Utils
{
    public static class Sessao
    {

        public static bool IsAtiva
        {
            get
            {
                return HttpContext.Current.Session["IdProfessor"] != null;
            }
        }

        public static int IdProfessor
        {
            get
            {
                return (int)HttpContext.Current.Session["IdProfessor"];
            }

        }

        public static string NomeProfessor
        {
            get
            {
                return (string)HttpContext.Current.Session["NomeProfessor"];
            }

        }


        public static void MontarSessao(ProfessorDTO prof)
        {
            HttpContext.Current.Session["IdProfessor"] = prof.IdProfessor;
            HttpContext.Current.Session["NomeProfessor"] = prof.NomeProfessor;
        }


    }
}