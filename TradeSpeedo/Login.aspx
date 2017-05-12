<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TradeSpeedo.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Sistema Trade</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Style/login_estilo.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/jquery-3.1.1.min.js"></script>

</head>
<body>
    <form class="form-horizontal" runat="server">

        <div class="container">
            <div class="form-login">
                <div class="panel panel-default">
                    <div class="panel-heading" style="background: #Fe370F">
                        <div class="panel-title">
                            <p id="pTitulo" class="pTitulo" style="text-align: center; color: white; font-size: 20px; margin-bottom: -5px;">Sistema Trade</p>
                        </div>
                    </div>

                    <div style="padding-top: 30px" class="panel-body">
                        <div style="display: none" id="result" class="alert alert-danger col-sm-12">
                        </div>

                        <div style="margin-bottom: 25px" class="input-group">
                            <span class="input-group-addon"><i class="glyphicon glyphicon-user" style="color: #FE370F"></i></span>
                            <asp:TextBox runat="server" ID="txtUsuario" class="form-control input-lg" placeholder="Usuário" type="text"></asp:TextBox>
                        </div>


                        <div style="margin-bottom: 25px" class="input-group">
                            <span class="input-group-addon"><i class="glyphicon glyphicon-lock" style="color: #FE370F"></i></span>
                            <asp:TextBox runat="server" ID="txtSenha" class="form-control input-lg" placeholder="Senha" type="password"></asp:TextBox>

                        </div>

                        <div id="dErro" class="dErro">
                        </div>
                        <div style="margin-top: 10px" class="form-group">

                            <div style="left: 120px;" class="col-sm-12 controls">
                                <asp:Button ID="Acessar" Text="Acessar" runat="server" CssClass="btn primary btn-lg" OnClick="Acessar_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
