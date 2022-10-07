<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Aluno.aspx.cs" Inherits="PRESENCA_FACIL.Pages.Aluno" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Aluno UNIESP</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous" />
    <link rel="icon" type="image/x-icon" href="/favicon.png" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.12.9/dist/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>
    <link href="/css/Main.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField runat="server" ID="hf_idMateria" />
        <div class="container mt-3">

            <div class="card ">
                <div class="card-header">
                    <b> <asp:Literal ID="lit_materiaTurma" runat="server" /></b> - 
                    <asp:Literal ID="txt_dataAtual" runat="server" />

                    <asp:Panel runat="server" ID="pnl_statusPresenca" Visible="false" CssClass="float-right">
                        <asp:Image runat="server" ID="img_statusPresenca" CssClass="img-fluid" Width="40px" />
                    </asp:Panel>

                </div>
                <div class="card-body">
                    <div class="row justify-content-center">
                        <div class="col-12 col-lg-8">
                            <div class="input-group mb-3">
                                <asp:TextBox runat="server" ID="txt_nome" CssClass="form-control" placeholder="Nome" aria-label="Recipient's username" aria-describedby="basic-addon2" />
                                <asp:TextBox runat="server" ID="txt_matricula" CssClass="form-control" placeholder="Matrícula" aria-label="Recipient's username" aria-describedby="basic-addon2" />
                                <div class="input-group-append">
                                    <asp:Button runat="server" ID="btn_responderChamada" OnClick="btn_responderChamada_Click" CssClass="btn btn-outline-secondary" Text="Enviar" />
                                </div>
                            </div>

                        </div>

                    </div>
                </div>
                <div class="card-footer text-muted">
                   

                    <footer class="main-footer">

                        <strong>Copyright &copy; 2022 - By <a href="https://www.instagram.com/o_bastos98/?hl=pt-br]" target="_blank">Gabriel Bastos</a>.</strong>

                        <div class="row">
                            <div class="col col-lg-4">
                             <ul class="lista-redes pl-0 mt-2">
                            <li>
                                <a href="https://www.facebook.com/profile.php?id=100035270381314" target="_blank">
                                    <img src="/img/facebook.png" />
                                </a>
                            </li>

                            <li>
                                <a href="https://www.instagram.com/o_bastos98/?hl=pt-br]" target="_blank">
                                    <img src="/img/instagram.png" />
                                </a>
                            </li>

                            <li>
                                <a href="https://www.linkedin.com/in/gabriel-bastos-26b53314a/" target="_blank">
                                    <img src="/img/linkedin.png" />
                                </a>
                            </li>

                            <li>
                                <a href="https://github.com/bastos2332" target="_blank">

                                    <img src="/img/github.png" />
                                </a>
                            </li>

                            <li>
                                <a href="https://gitlab.com/users/bastos2332/activity" target="_blank">

                                    <img src="/img/gitlab.png" />
                                </a>
                            </li>

                        </ul>

                            </div>
                        </div>

                    </footer>
                </div>
            </div>




        </div>

    </form>
</body>


</html>
