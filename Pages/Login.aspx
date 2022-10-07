<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PRESENCA_FACIL.Pages.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Presença Fácil</title>
      <link rel="icon" type="image/x-icon" href="/favicon.png"/>

    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700&display=fallback" />
    <link href="../css/adminlte.min.css" rel="stylesheet" />
    <link href="../css/all.min.css" rel="stylesheet" />

</head>
<body class="hold-transition login-page" style="background-color:#dd4b39 !important">
    <form id="form1" runat="server">
        <div class="login-box">
            <div class="login-logo">
                <img src="../img/iesp-logo.png" class="img-fluid" />
                <a href="#" class="text-white" ><b>Presença</b>Fácil</a>
            </div>

            <div class="card">
                <div class="card-body login-card-body">
                    <p class="login-box-msg">Bem vindo professor !</p>

                    <div class="form-group">
                        <div class="input-group mb-3">
                            <asp:TextBox runat="server" ID="txt_usuario" class="form-control" placeholder="Usuário"/>
                            <div class="input-group-append">
                                <div class="input-group-text">
                                    <span class="fas fa-user"></span>
                                </div>
                            </div>
                        </div>
                        <div class="input-group mb-3">
                            <asp:TextBox runat="server" ID="txt_senha" type="password" class="form-control" placeholder="Senha"/>
                            <div class="input-group-append">
                                <div class="input-group-text">
                                    <span class="fas fa-lock"></span>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-8">
                                <div class="icheck-primary">
                                    <input type="checkbox" id="remember" />
                                    <label for="remember">
                                        Lembrar-Me
             
                                    </label>
                                </div>
                            </div>
                            <div class="col-4">
                                <asp:Button runat="server" ID="btn_login" OnClick="btn_login_Click" type="submit" CssClass="btn btn-success btn-block" Text="Entrar"/>
                            </div>
                        </div>
                    </div>
                    <p class="mb-0">
                        <a href="register.html" class="text-center">Quero me registrar !</a>
                    </p>
                </div>
            </div>
        </div>
    </form>
</body>
<script src="../js/jquery.min.js"></script>
<script src="../js/bootstrap.bundle.min.js"></script>
<script src="../js/adminlte.min.js"></script>
</html>
