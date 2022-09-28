<%@ Page Language="C#" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="Professor.aspx.cs" Inherits="CHAMADA.Pages.Professor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Professor UNIESP</title>

    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">

    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.12.9/dist/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <asp:HiddenField ID="hf_idProfessor" runat="server" />

        <div class="container">

            <div class="card">
                <div class="card-header">
                    Bem Vindo professor
                            <asp:Literal ID="txt_nomeProfessor" runat="server" />
                    !
                </div>
                <div class="card-body mt-3">


                    <asp:Panel runat="server" ID="pnl_login" Visible="false">
                        <div class="row justify-content-center mt-3">
                            <div class="col-8">
                                <div class="alert alert-primary">
                                    Realizar Login
                                </div>
                                <div class="input-group mb-3">
                                    <asp:TextBox runat="server" ID="txt_usuario" CssClass="form-control" placeholder="Usuário" aria-label="Recipient's username" aria-describedby="basic-addon2" />
                                    <asp:TextBox runat="server" ID="txt_senha" CssClass="form-control" TextMode="Password" placeholder="Senha" aria-label="Recipient's username" aria-describedby="basic-addon2" />
                                    <div class="input-group-append">
                                        <asp:Button runat="server" OnClick="btn_login_Click" ID="btn_login" CssClass="btn btn-lg btn-outline-secondary" Text="Logar" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </asp:Panel>



                    <asp:Panel runat="server" ID="pnl_acopanhamentoChamada" Visible="false">
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <div class="row mt-3 justify-content-center">
                                    <div class="col-8">

                                        <div class="input-group ">
                                            <div class="input-group mb-3">
                                                <asp:TextBox runat="server" ID="txt_dataFiltro" CssClass="form-control" TextMode="Date" placeholder="Data" aria-label="Recipient's username" aria-describedby="basic-addon2" />
                                                <div class="input-group-append">
                                                    <asp:Button Text="Filtrar" CssClass="btn btn-lg btn-outline-secondary" ID="btn_realizarFiltro" OnClick="btn_realizarFiltro_Click" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="row justify-content-center mt-3">
                                    <div class="col-12">


                                        <ul class="nav nav-tabs" id="myTab" role="tablist">

                                            <asp:Repeater runat="server" ID="rpt_manuMaterias" OnItemDataBound="rpt_manuMaterias_ItemDataBound">
                                                <ItemTemplate>

                                                    <asp:Literal runat="server" ID="lit_menu" />


                                                </ItemTemplate>
                                            </asp:Repeater>



                                        </ul>
                                        <div class="tab-content" id="myTabContent">

                                            <asp:Repeater runat="server" ID="rpt_materias">

                                                <ItemTemplate>

                                                    <div class="tab-pane fade" id='<%# Eval("idConteudo") %>' role="tabpanel" aria-labelledby="home-tab">
                                                        <div class="container">

                                                            <div class="row">
                                                                <div class="col">
                                                                    <table class="table table-hover">
                                                                        <thead>
                                                                            <tr>
                                                                                <th scope="col">Matricula</th>
                                                                                <th scope="col">Nome</th>
                                                                                <th scope="col">IP</th>
                                                                                <th scope="col">Data Hora</th>
                                                                            </tr>
                                                                        </thead>
                                                                        <tbody>
                                                                            <asp:Repeater runat="server" ID="rpt_chamadasMaterias">
                                                                                <ItemTemplate>
                                                                                    <tr>
                                                                                        <th scope="row"><asp:Literal runat="server" ID="lit_numeroMatricula"></asp:Literal></th>
                                                                                    </tr>
                                                                                </ItemTemplate>
                                                                            </asp:Repeater>

                                                                        </tbody>
                                                                    </table>
                                                                </div>
                                                            </div>
                                                            <div class="row justify-content-center">
                                                                <div class="col-6">
                                                                    <asp:LinkButton runat="server" ID="linkBtn_processar" Text="Processar Dia" CssClass="btn btn-success d-block"></asp:LinkButton>
                                                                </div>
                                                            </div>


                                                        </div>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:Repeater>

                                        </div>
                                    </div>

                                </div>

                            </ContentTemplate>

                        </asp:UpdatePanel>

                    </asp:Panel>


                </div>
                <div class="card-footer">
                    <asp:Literal runat="server" ID="txt_dataAtual"></asp:Literal>
                </div>
            </div>


        </div>
    </form>
</body>
</html>
