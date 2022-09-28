using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CHAMADA.Pages
{
    public partial class Professor : System.Web.UI.Page
    {
        public ChamadaRepository Repo { get; set; } = new ChamadaRepository();


        #region EVENTS
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (RequestValido())
                {
                    pnl_login.Visible = true;
                    pnl_acopanhamentoChamada.Visible = false;
                    txt_dataAtual.Text = DateTime.Now.ToLongDateString();
                }
                else
                {
                    throw new Exception("Request inválido");
                }

            }

        }

     

        protected void btn_login_Click(object sender, EventArgs e)
        {
            try
            {
                var usuarioRequestProf = txt_usuario.Text;
                var senhaRequestProf = txt_senha.Text;

                var professor = Repo.ProfessorLogin(usuarioRequestProf, senhaRequestProf);
                if (professor != null)
                {
                    hf_idProfessor.Value = professor.IdProfessor.ToString();
                    txt_nomeProfessor.Text = professor.NomeProfessor;

                    pnl_login.Visible = false;
                    pnl_acopanhamentoChamada.Visible = true;

                    txt_dataFiltro.Text = DateTime.Now.ToShortDateString();

                    CarregarRespostasTurma();

                }
                else
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "script", $"alert('Usuário ou senha são inválidos.')", true);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void btn_realizarFiltro_Click(object sender, EventArgs e)
        {
            try
            {
                CarregarRespostasTurma();
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        protected void rpt_manuMaterias_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Literal lit_menu = (Literal)e.Item.FindControl("lit_menu");
                lit_menu.Text = $" <li class='nav-item'><a class='nav-link' id='menu_materia_{DataBinder.Eval(e.Item.DataItem, "idMateria")}' data-toggle='tab' href='#materia_{DataBinder.Eval(e.Item.DataItem, "idMateria")}' role='tab' aria-controls='materia_{DataBinder.Eval(e.Item.DataItem, "idMateria")}' aria-selected='true'>{DataBinder.Eval(e.Item.DataItem, "NomeMateria")}</a></li>";

            }
        }

        #endregion


        #region METODOS
        private bool RequestValido()
        {
            var senhaRequest = Request.QueryString.Get("pass");
            if (senhaRequest != null && senhaRequest == "uniesp2022")
            {
                return true;
            }
            else
                return false;

        }
        private void CarregarRespostasTurma()
        {
            List<DTO.MateriaDto> materias = new ChamadaRepository().ListMateriasProfessor(Convert.ToInt32(hf_idProfessor.Value));
            rpt_manuMaterias.DataSource = materias;
            rpt_manuMaterias.DataBind();

            rpt_materias.DataSource = materias;
            rpt_materias.DataBind();

            ObterHTMLMaterias(materias);
        }
        private string ObterHTMLMaterias(List<DTO.MateriaDto> materias)
        {
            StringBuilder str = new StringBuilder();

            return str.ToString();
        }
        #endregion


    }
}