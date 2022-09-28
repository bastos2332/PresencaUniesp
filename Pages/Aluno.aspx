<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Aluno.aspx.cs" Inherits="CHAMADA.Pages.Aluno" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Aluno UNIESP</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous" />


    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.12.9/dist/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField runat="server" ID="hf_idMateria" />
        <div class="container mt-3">

            <div class="card ">
                <div class="card-header">
                    Chamada do dia
                    <asp:Literal ID="txt_dataAtual" runat="server" />
                </div>
                <div class="card-body">
                    <div class="row justify-content-center">
                        <div class="col-8">
                            <div class="input-group mb-3">
                                <asp:TextBox runat="server" ID="txt_nome" CssClass="form-control" placeholder="Nome" aria-label="Recipient's username" aria-describedby="basic-addon2" />
                                <asp:TextBox runat="server" ID="txt_matricula" CssClass="form-control" placeholder="Matrícula" aria-label="Recipient's username" aria-describedby="basic-addon2" />
                                <div class="input-group-append">
                                    <asp:Button runat="server" ID="btn_responderChamada" OnClick="btn_responderChamada_Click" CssClass="btn btn-lg btn-outline-secondary" Text="Enviar" />
                                </div>
                            </div>

                        </div>

                    </div>
                </div>
                <div class="card-footer text-muted">
                    <asp:Literal ID="lit_dataAtual" runat="server" />
                </div>
            </div>


            
        </div>

    </form>
</body>
</html>
