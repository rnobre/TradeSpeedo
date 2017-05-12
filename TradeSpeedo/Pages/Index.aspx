<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="TradeSpeedo.Pages.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">


    <script src="../Scripts/modernizr-2.8.3.js"></script>
    <script src="../Scripts/jquery-3.1.1.min.js"></script>
    <script src="../Scripts/bootstrap.js"></script>
    <link href="../Style/index.css" rel="stylesheet" type="text/css" />
    <link href="../Style/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <meta charset="utf-8" />

    <title>Sistema Trade</title>
</head>
<body style="height: auto">
    <form id="form1" runat="server">
        <div id="dIndex" class="dIndex">
            <div id="dLogo" class="dLogo">
            </div>
            <img src="../Image/logo_speedo.JPG" />
            <div id="dLogin" class="dLogin">
                <span id="sWelcome" class="sWelcome">Bem vindo,
                    <asp:Label runat="server" ID="luser"></asp:Label>Raphael Nobre !</span>
            </div>
            <div id="dPesquisa" class="dPesquisa">
                <div id="dTexto" class="dTexto">
                    <h2 id="h2" class="h2">Pesquise o cliente:</h2>
                </div>
                <input type="text" id="busca" class="busca" autofocus="autofocus" placeholder="Pesquisar" />
            </div>
            <div class="row">
                <div class="col-md-2 col-md-offset-1"></div>
                <div class="col-md-2">
                    <asp:Image runat="server" />
                </div>
                <div class="col-md-2">
                    <asp:upload runat="server">
                    </asp:upload>
                </div>
                <div class="col-md-2">
                    <asp:dropdown runat="server"></asp:dropdown>
                </div>
                <div class="col-md-2">
                    <asp:dropdown runat="server"></asp:dropdown>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
