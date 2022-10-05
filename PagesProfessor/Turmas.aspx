<%@ Page Title="" Language="C#" MasterPageFile="~/PagesProfessor/Default.Master" AutoEventWireup="true" CodeBehind="Turmas.aspx.cs" Inherits="PRESENCA_FACIL.PagesProfessor.Turmas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">

    <asp:UpdatePanel runat="server" ID="upPnl_btnRefresh">
        <ContentTemplate>
            <asp:Button runat="server" ID="btn_refresh" Style="opacity: 0;" CssClass="btn-refresh" OnClick="btn_refresh_Click" />
        </ContentTemplate>
    </asp:UpdatePanel>



    <div class="card">
        <div class="card-header">
            <asp:Literal runat="server" ID="txt_dataAtual"></asp:Literal>
        </div>
        <div class="card-body mt-3">

            <asp:UpdatePanel runat="server" ID="UpPnl_geral" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="row mt-3 justify-content-center">
                        <div class="col-4">

                            <div class="input-group ">
                                <label>Data Chamada:</label>
                                <div class="input-group mb-3">
                                    <asp:TextBox runat="server" ToolTip="Preencha com a data que deseja realizar a Chamada Fácil" ID="txt_dataFiltro" CssClass="form-control" TextMode="Date" placeholder="Data" aria-label="Recipient's username" aria-describedby="basic-addon2" />
                                    <div class="input-group-append">
                                        <asp:Button Text="Filtrar" CssClass="btn btn-outline-secondary" ID="btn_realizarFiltro" OnClick="btn_realizarFiltro_Click" runat="server" />
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


                                <asp:Repeater runat="server" ID="rpt_materias" OnItemDataBound="rpt_materias_ItemDataBound">

                                    <ItemTemplate>
                                        <div class="tab-pane fade" id='<%# Eval("idConteudo") %>' role="tabpanel" aria-labelledby="home-tab">
                                            <div class="container">
                                                <div class="row mb-3 mt-2">
                                                    <div class="col">

                                                        <asp:UpdatePanel runat="server" ID="upPnl_materias" UpdateMode="Conditional">
                                                            <ContentTemplate>

                                                                <asp:HiddenField runat="server" ID="hf_idMateriaTurma" />
                                                                <asp:CheckBox runat="server" ID="cb_presenhaAberta" AutoPostBack="true" Text="Chamada Aberta" CssClass="cb_isChamadaAberto" OnCheckedChanged="cb_presenhaAberta_CheckedChanged" />
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </div>
                                                    <div class="col">
                                                        <div class="copia-cola-btn mt-2 float-right">
                                                            <span class="btn btn-outline-success btn-copia" onclick="CopiarLinkTurma(this);"><i class="fa fa-copy"></i>&nbsp;Copiar Link da Chamada</span>
                                                        </div>
                                                        <div class="copia-texto float-right" style="opacity: 0;">
                                                            <textarea class="textArea-link-turma">
                                                                <asp:Literal runat="server" ID="lit_linkTurma"></asp:Literal>
                                                            </textarea>
                                                        </div>
                                                    </div>

                                                </div>
                                                <div class="row">
                                                    <div class="col">
                                                        <asp:UpdatePanel runat="server">
                                                            <ContentTemplate>
                                                                <table class="table table-hover mt-3">
                                                                    <thead>
                                                                        <tr>
                                                                            <th scope="col">Matricula</th>
                                                                            <th scope="col">Nome</th>
                                                                            <th scope="col">IP</th>
                                                                            <th scope="col">Data Hora</th>
                                                                            <th scope="col">Status</th>
                                                                        </tr>
                                                                    </thead>
                                                                    <tbody>
                                                                        <asp:Repeater runat="server" ID="rpt_PresencasMateria" OnItemDataBound="rpt_PresencasMateria_ItemDataBound">
                                                                            <ItemTemplate>
                                                                                <tr>
                                                                                    <th scope="row">
                                                                                        <asp:Literal runat="server" ID="lit_numeroMatricula"></asp:Literal></th>
                                                                                    <td>
                                                                                        <asp:Literal runat="server" ID="lit_nomeAluno"></asp:Literal></td>
                                                                                    <td>
                                                                                        <asp:Literal runat="server" ID="lit_ipAlubo"></asp:Literal></td>

                                                                                    <td>
                                                                                        <asp:Literal runat="server" ID="lit_dataHora"></asp:Literal></td>

                                                                                    <td>
                                                                                        <asp:Image runat="server" ID="img_statusPresenca" CssClass="img-fluid" Width="40px" /></td>
                                                                                </tr>
                                                                            </ItemTemplate>
                                                                        </asp:Repeater>

                                                                    </tbody>
                                                                </table>
                                                            </ContentTemplate>
                                                            <Triggers>
                                                                <asp:AsyncPostBackTrigger ControlID="linkBtn_processar" />
                                                                <asp:AsyncPostBackTrigger ControlID="btn_refresh" />
                                                            </Triggers>
                                                        </asp:UpdatePanel>
                                                    </div>
                                                </div>
                                                <div class="row justify-content-center mt-5">
                                                    <div class="col-4">
                                                        <asp:UpdatePanel runat="server" ID="upPnl_btnProcessar" UpdateMode="Conditional">
                                                            <ContentTemplate>
                                                                <asp:LinkButton runat="server" ID="linkBtn_processar" OnClick="linkBtn_processar_Click" CssClass="btn btn-success d-block"><i class="far fa-calendar-check"></i>&nbsp; Realizar Chamada</asp:LinkButton>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
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


        </div>
        <div class="card-footer">
        </div>
    </div>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="server">

    <script>
        setInterval(function () {
            $(".btn-refresh").click();
            console.log("chamou");
        }, 15000);
    </script>

    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.12.9/dist/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>

</asp:Content>
