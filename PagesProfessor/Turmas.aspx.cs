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
                DateTime temp;
                if (DateTime.TryParse(txt_dataFiltro.Text, out temp))
                    CarregarRespostasTurma();
                else
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "script", "alert('Data Inválida.')", true);

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

                string idMateriaTurma = DataBinder.Eval(e.Item.DataItem, "idMateria").ToString();

                Literal lit_linkTurma = (Literal)e.Item.FindControl("lit_linkTurma");
                lit_linkTurma.Text = HttpContext.Current.Request.Url.Host + $":{Request.Url.Port}" + $"/Pages/Aluno.aspx?idm={Utilitario.Base64Encode(idMateriaTurma)}";

                LinkButton linkBtn_processar = (LinkButton)e.Item.FindControl("linkBtn_processar");
                linkBtn_processar.Enabled = false;
                if (Convert.ToDateTime(txt_dataFiltro.Text).Date == DateTime.Now.Date)
                {
                    linkBtn_processar.CommandArgument = DataBinder.Eval(e.Item.DataItem, "idMateria").ToString();
                    linkBtn_processar.Enabled = true;
                }


                HiddenField hf_idMateriaTurma = (HiddenField)e.Item.FindControl("hf_idMateriaTurma");
                hf_idMateriaTurma.Value = DataBinder.Eval(e.Item.DataItem, "idMateria").ToString();

                Repeater rpt_PresencasMateria = (Repeater)e.Item.FindControl("rpt_PresencasMateria");
                rpt_PresencasMateria.DataSource = presencaRepo.ListByMateriaData((int)DataBinder.Eval(e.Item.DataItem, "idMateria"), txt_dataFiltro.Text);
                rpt_PresencasMateria.DataBind();

            }
        }

        protected void rpt_PresencasMateria_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {

                Literal lit_numeroMatricula = (Literal)e.Item.FindControl("lit_numeroMatricula");
                lit_numeroMatricula.Text = DataBinder.Eval(e.Item.DataItem, "numeroMatricula").ToString(); ;

                Literal lit_nomeAluno = (Literal)e.Item.FindControl("lit_nomeAluno");
                lit_nomeAluno.Text = DataBinder.Eval(e.Item.DataItem, "nomeAluno").ToString();

                Literal lit_ipAlubo = (Literal)e.Item.FindControl("lit_ipAlubo");
                lit_ipAlubo.Text = DataBinder.Eval(e.Item.DataItem, "ipAluno").ToString();

                Literal lit_MACAluno = (Literal)e.Item.FindControl("lit_MACAluno");
                lit_MACAluno.Text = DataBinder.Eval(e.Item.DataItem, "EnderecoMACAluno").ToString();

                Literal lit_dataHora = (Literal)e.Item.FindControl("lit_dataHora");
                lit_dataHora.Text = DataBinder.Eval(e.Item.DataItem, "dataChamada").ToString();

                int idMateria = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "idMateria"));

                Image img_statusPresenca = (Image)e.Item.FindControl("img_statusPresenca");
                SetarStatusPrensenca(idMateria, img_statusPresenca);

            }
        }


        protected void cb_presenhaAberta_CheckedChanged(object sender, EventArgs e)
        {
            try
            {

                CheckBox cb_presenhaAberta = (CheckBox)sender;

                HiddenField hf_idMateriaTurma = (HiddenField)cb_presenhaAberta.NamingContainer.FindControl("hf_idMateriaTurma");

                var turma = presencaRepo.GetMateria(Convert.ToInt32(hf_idMateriaTurma.Value));

                turma.IsChamadaAberta = cb_presenhaAberta.Checked;

                presencaRepo.AtualizarMateria(turma);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void linkBtn_processar_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton linkBtn_processar = (LinkButton)sender;

                int idMateria = Convert.ToInt32(linkBtn_processar.CommandArgument);

                var turma = presencaRepo.GetMateria(idMateria);
                if (!turma.IsChamadaAberta)
                {

                    var professor = professorRepo.GetDecript(Sessao.IdProfessor);
                    List<PresencaAluno> presencas = presencaRepo.ListByMateriaData(idMateria, DateTime.Now.ToShortDateString()).ToList();

                    if (presencas.Count > 0)
                    {
                        var selenium = new Selenium();
                        selenium.RealizarLogin(professor.UsuarioSistema, professor.SenhaSistema);
                        foreach (var presenca in presencas)
                        {
                            presenca.StatusPresenca = nameof(EStatusPresenca.CONFIRMADO);
                            presencaRepo.Atualizar(presenca);
                        }
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "script", "alert('Chamada Finalizada com sucesso!')", true);

                    }
                    else
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "script", "alert('Nenhuma presença encontrada!')", true);
                }
                else
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "script", "alert('A chamada precisa estar fechada!')", true);


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion


        #region METODOS

        private void SetarStatusPrensenca(int idMateria, Image img)
        {
            var chamada = presencaRepo.GetRespostaChamadaDiaMAC(idMateria, Utilitario.ObterEnderecoMAC(), DateTime.Now);

            switch (chamada.StatusPresenca)
            {
                case nameof(EStatusPresenca.AGUARDANDO):
                    img.ImageUrl = "~/img/status-waiting.gif";
                    img.ToolTip = "Aguardando finalização do professor!";
                    break;
                case nameof(EStatusPresenca.CONFIRMADO):
                    img.ImageUrl = "~/img/status-confirm.png";
                    img.ToolTip = "Presença confirmada!";
                    break;
                case nameof(EStatusPresenca.NAO_ENCONTRADO):
                    img.ImageUrl = "~/img/status-not-found.png";
                    img.ToolTip = "Matrícula digitada não encontrada, fale com o professor!";
                    break;
            }
        }
        private void CarregarRespostasTurma()
        {
            List<DTO.MateriaDto> materias = presencaRepo.ListMateriasProfessor(Sessao.IdProfessor);
            rpt_manuMaterias.DataSource = materias;
            rpt_manuMaterias.DataBind();

            rpt_materias.DataSource = materias;
            rpt_materias.DataBind();
        }




        #endregion


    }
}