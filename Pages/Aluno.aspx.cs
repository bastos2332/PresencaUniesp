using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PRESENCA_FACIL.Repository;
using PRESENCA_FACIL.Utils;
namespace PRESENCA_FACIL.Pages
{
    public partial class Aluno : System.Web.UI.Page
    {
        public PresencaRepository Repo { get; set; } = new PresencaRepository();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var idMateriaBase64 = Request.QueryString.Get("idm").ToString();

                int idMateria = Convert.ToInt32(Utilitario.Base64Decode(idMateriaBase64));

                if (idMateria != 0)
                {
                    var materia = Repo.GetMateria(idMateria);

                    if (materia == null)
                        throw new Exception("Parametros incorretos.");
                    else
                    {

                        if (MacJaRespondeu(materia.IdMateria))
                        {
                            LimparCampos();
                            SetarStatusPrensenca(materia.IdMateria);
                        }
                        else
                        {

                            if (!materia.IsChamadaAberta)
                            {
                                LimparCampos();
                                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "script", "alert('Chamada ainda não foi aberta!')", true);
                            }
                            else
                            {
                                hf_idMateria.Value = materia.IdMateria.ToString();
                                txt_dataAtual.Text = DateTime.Now.ToLongDateString();

                            }

                        }



                    }
                }
                else
                    throw new Exception("Materia não encontrada.");

            }
        }

        private void SetarStatusPrensenca(int idMateria)
        {
            pnl_statusPresenca.Visible = true;
            var chamada = Repo.GetRespostaChamadaDiaMAC(idMateria, Utilitario.ObterEnderecoMAC(), DateTime.Now);

            switch (chamada.StatusPresenca)
            {
                case nameof(EStatusPresenca.AGUARDANDO):
                    img_statusPresenca.ImageUrl = "~/img/status-waiting.gif";
                    img_statusPresenca.ToolTip = "Aguardando finalização do professor!";
                    break;
                case nameof(EStatusPresenca.CONFIRMADO):
                    img_statusPresenca.ImageUrl = "~/img/status-confirm.png";
                    img_statusPresenca.ToolTip = "Presença confirmada!";
                    break;
                case nameof(EStatusPresenca.NAO_ENCONTRADO):
                    img_statusPresenca.ImageUrl = "~/img/status-not-found.png";
                    img_statusPresenca.ToolTip = "Matrícula digitada não encontrada, fale com o professor!";
                    break;
            }
        }

        private bool MacJaRespondeu(int idMateria)
        {
            var chamada = Repo.GetRespostaChamadaDiaMAC(idMateria, Utilitario.ObterEnderecoMAC(), DateTime.Now);


            return chamada != null;

        }

        protected void btn_responderChamada_Click(object sender, EventArgs e)
        {
            try
            {

                if (hf_idMateria.Value != "")
                {
                    string firstMacAddress = Utilitario.ObterEnderecoMAC();

                    var chamada = new PresencaAluno
                    {
                        DataChamada = DateTime.Now,
                        StatusPresenca = nameof(EStatusPresenca.AGUARDANDO),
                        NomeAluno = txt_nome.Text,
                        NumeroMatricula = txt_matricula.Text,
                        IpAluno = Request.UserHostAddress,
                        IdMateria = Convert.ToInt32(hf_idMateria.Value),
                        EnderecoMACAluno = firstMacAddress
                    };

                    var validacao = ValidarResposta(chamada);

                    if (validacao == "")
                    {
                        if (new PresencaRepository().Salvar(chamada))
                        {
                            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "script", "alert('Chamada respondida com sucesso.')", true);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "script", $"alert('{validacao}')", true);
                    }
                    LimparCampos();

                }

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

            btn_responderChamada.Enabled = false;
        }

        private string ValidarResposta(PresencaAluno chamadaAluno)
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
                retorno = "Chamada já respondida para este número de matrícula.";
            }
            else
            {
                chamada = Repo.GetRespostaChamadaDiaIP(chamadaAluno.IdMateria, chamadaAluno.IpAluno, DateTime.Now);
                if (chamada != null)
                {
                    retorno = "Este Computador já foi usado para responder a chamada hoje !";
                }
                else
                {

                    chamada = Repo.GetRespostaChamadaDiaMAC(chamadaAluno.IdMateria, chamadaAluno.EnderecoMACAluno, DateTime.Now);

                    if (chamada != null)
                        retorno = "Este Computador já foi usado para responder a chamada hoje !";
                }

            }




            return retorno;
        }
    }
}