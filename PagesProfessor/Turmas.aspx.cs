using PRESENCA_FACIL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PRESENCA_FACIL.Utils;

namespace PRESENCA_FACIL.PagesProfessor
{
    public partial class Turmas : System.Web.UI.Page
    {
        public ProfessorRepository professorRepo { get; set; } = new ProfessorRepository();
        public PresencaRepository presencaRepo { get; set; } = new PresencaRepository();


        #region EVENTS




        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                if (Sessao.IsAtiva)
                {
                    txt_dataAtual.Text = DateTime.Now.ToLongDateString();
             
                }
                else
                    Response.Redirect("~/Pages/Login.aspx?SemAcesso");
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

        protected void rpt_materias_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                CheckBox cb_presenhaAberta = (CheckBox)e.Item.FindControl("cb_presenhaAberta");
                cb_presenhaAberta.Checked = (bool)DataBinder.Eval(e.Item.DataItem, "isChamadaAberta");

                LinkButton linkBtn_processar = (LinkButton)e.Item.FindControl("linkBtn_processar");
                linkBtn_processar.CommandArgument = DataBinder.Eval(e.Item.DataItem, "idMateria").ToString();


                Repeater rpt_PresencasMateria = (Repeater)e.Item.FindControl("rpt_PresencasMateria");
                rpt_PresencasMateria.DataSource = presencaRepo.ListByMateriaData((int)DataBinder.Eval(e.Item.DataItem, "idMateria"), DateTime.Now.ToShortDateString());
                rpt_PresencasMateria.DataBind();

            }
        }

        protected void rpt_PresencasMateria_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {

                Literal lit_numeroMatricula = (Literal)e.Item.FindControl("lit_numeroMatricula");
                lit_numeroMatricula.Text = DataBinder.Eval(e.Item.DataItem, "numeroMatricula").ToString(); ;

            }
        }




        #endregion


        #region METODOS


        private void CarregarRespostasTurma()
        {
            List<DTO.MateriaDto> materias = presencaRepo.ListMateriasProfessor(Sessao.IdProfessor);
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