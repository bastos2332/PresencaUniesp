using PRESENCA_FACIL.Utils;
using PRESENCA_FACIL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PRESENCA_FACIL.Pages
{
    public partial class Login : System.Web.UI.Page
    {

        public ProfessorRepository professorRepo { get; set; } = new ProfessorRepository();


        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Session.Clear();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btn_login_Click(object sender, EventArgs e)
        {
            try
            {
                var usuarioRequestProf = txt_usuario.Text;
                var senhaRequestProf = txt_senha.Text;

                var professor = professorRepo.Login(usuarioRequestProf, senhaRequestProf);
                if (professor != null)
                {
                    Sessao.MontarSessao(professor);
                    Response.Redirect("~/PagesProfessor/Turmas.aspx");
                }
                else
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "script", $"alert('Usuário ou senha são inválidos.')", true);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}