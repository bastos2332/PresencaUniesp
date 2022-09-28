using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CHAMADA.Pages
{
    public partial class Aluno : System.Web.UI.Page
    {
        public ChamadaRepository Repo { get; set; } = new ChamadaRepository();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var idMateria = Convert.ToInt32(Request.QueryString.Get("idm"));

                if (idMateria != 0)
                {
                    var materia = Repo.GetMateria(idMateria);

                    if (materia == null || !materia.IsChamadaAberta)
                        throw new Exception("Parametros incorretos.");
                    else
                    {
                        hf_idMateria.Value = materia.IdMateria.ToString();
                        txt_dataAtual.Text = DateTime.Now.ToLongDateString();
                    }
                }
                else
                    throw new Exception("Materia não encontrada.");

            }
        }

      

        protected void btn_responderChamada_Click(object sender, EventArgs e)
        {
            try
            {
                var chamada = new ChamadaAluno
                {
                    DataChamada = DateTime.Now,
                    IsMatriculaEncontrada = false,
                    NomeAluno = txt_nome.Text,
                    NumeroMatricula = txt_matricula.Text,
                    IpAluno = Request.UserHostAddress,
                    IdMateria = Convert.ToInt32(hf_idMateria.Value),
                    IsProcessado = false
                };

                var validacao = ValidarResposta(chamada);

                if (validacao == "")
                {
                    if (new ChamadaRepository().Salvar(chamada))
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "script", "alert('Chamada respondida.')", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "script", $"alert('{validacao}')", true);
                }
                LimparCampos();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LimparCampos()
        {
            txt_matricula.Text = "";
            txt_nome.Text = "";

            txt_matricula.Enabled = false;
            txt_nome.Enabled = false;
        }

        private string ValidarResposta(ChamadaAluno chamadaAluno)
        {
            var retorno = "";


            if (chamadaAluno.NomeAluno == "")
            {
                retorno = "Nome é obrigatório";
            }

            if (chamadaAluno.NumeroMatricula == "")
            {

                retorno = "Matrícula é obrigatório";
            }

            var chamada = Repo.GetRespostaChamada(chamadaAluno.IdMateria, chamadaAluno.NumeroMatricula, DateTime.Now);
            if (chamada != null)
            {
                retorno = "Chamada já respondida.";
            }

            return retorno;
        }
    }
}