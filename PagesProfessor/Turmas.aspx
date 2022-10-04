<%@ Page Title="" Language="C#" MasterPageFile="~/PagesProfessor/Default.Master" AutoEventWireup="true" CodeBehind="Turmas.aspx.cs" Inherits="PRESENCA_FACIL.PagesProfessor.Turmas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="card">
        <div class="card-header">
            <asp:Literal runat="server" ID="txt_dataAtual"></asp:Literal>
        </div>
        <div class="card-body mt-3">

            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="row mt-3 justify-content-center">
                        <div class="col-6">

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

                                                <asp:CheckBox runat="server" ID="cb_presenhaAberta" Text="Aberta" CssClass="cb_isChamadaAberto" />
                                                <div class="row">
                                                    <div class="col">


                                                        <table class="table table-hover mt-3">
                                                            <thead>
                                                                <tr>
                                                                    <th scope="col">Matricula</th>
                                                                    <th scope="col">Nome</th>
                                                                    <th scope="col">IP</th>
                                                                    <th scope="col">Data Hora</th>
                                                                </tr>
                                                            </thead>
                                                            <tbody>
                                                                <asp:Repeater runat="server" ID="rpt_PresencasMateria" OnItemDataBound="rpt_PresencasMateria_ItemDataBound">
                                                                    <ItemTemplate>
                                                                        <tr>
                                                                            <th scope="row">
                                                                                <asp:Literal runat="server" ID="lit_numeroMatricula"></asp:Literal></th>
                                                                            <td>teste</td>
                                                                            <td>teste</td>
                                                                            <td>teste</td>
                                                                        </tr>
                                                                    </ItemTemplate>
                                                                </asp:Repeater>

                                                            </tbody>
                                                        </table>
                                                    </div>
                                                </div>
                                                <div class="row justify-content-center">
                                                    <div class="col-4">
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


        </div>
        <div class="card-footer">
        </div>
    </div>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="server">
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.12.9/dist/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>

</asp:Content>
