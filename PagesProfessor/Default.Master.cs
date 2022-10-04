using PRESENCA_FACIL.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PRESENCA_FACIL.PagesProfessor
{
    public partial class Default : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Sessao.IsAtiva)
            {
                if (Sessao.NomeProfessor.Length <= 30)
                    lit_nomeProfessor.Text = Sessao.NomeProfessor;
                else
                    lit_nomeProfessor.Text = Sessao.NomeProfessor.Substring(0, 27) + "...";
            }

        }
    }
}