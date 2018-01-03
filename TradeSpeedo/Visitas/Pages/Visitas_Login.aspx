<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Visitas_Login.aspx.cs" Inherits="TradeSpeedo.Visitas.Pages.Visitas_Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>.:Visitas:.</title>
    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../../Style/login_estilo.css" rel="stylesheet" type="text/css" />
    <link href="../../Image/bumerangue.ico" rel="shortcur icon" type="image/x-icon" />
    <script src="../../Scripts/jquery-3.1.1.min.js"></script>
</head>
<body>
    <form class="form-horizontal" runat="server">
        <div class="container">
            <div class="form-login">
                <div class="panel panel-default">
                    <div class="panel-heading" style="background: #Fe370F">
                        <div class="Dtitulo panel-title">
                            <p id="pTitulo" class="pTitulo">Visitas</p>
                        </div>
                    </div>                    
                    <div style="padding-top: 30px" class="panel-body">
                        <div style="display: none" id="result" class="alert alert-danger col-sm-12">
                        </div>
                        <div style="margin-bottom: 25px" class="input-group">
                            <span class="input-group-addon">
                                <i class="glyphicon glyphicon-user" style="color: #FE370F"></i>
                            </span>
                            <asp:TextBox runat="server" ID="txUsuario" CssClass="form-control input-lg" placeholder="Usuário" type="text"></asp:TextBox>
                        </div>
                        <div style="margin-bottom: 25px" class="input-group">
                            <span class="input-group-addon">
                                <i class="glyphicon glyphicon-lock" style="color: #FE370D"></i>
                            </span>
                            <asp:TextBox runat="server" ID="txtSenha" CssClass="form-control input-lg" placeholder="Senha" type="password"></asp:TextBox>
                        </div>
                        <div style="margin-top: 10px" class="form-group">
                            <div style="left: 120px;" class="col-sm-12 controls">
                                <asp:Button ID="Acessar" Text="Acessar" runat="server" CssClass="btn primary btn-lg" OnClick="Acessar_Click" />
                            </div>
                            <div id="dErro" class="dErro" runat="server">
                                <p id="pErro">Usuário ou senha incorreto.</p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>