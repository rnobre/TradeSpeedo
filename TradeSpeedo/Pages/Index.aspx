<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="TradeSpeedo.Pages.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #dLogo {
            width: 178px;
            height: 64px;
        }
        #dLogin {
            width: 210px;
        }
        #dPesquisa {
            height: 90px;
            width: 890px;
        }
        #busca {
            width: 875px;
        }
    </style>
</head>
<body style="height:auto">
    <form id="form1" runat="server">
    <div id="dIndex" class="dIndex" style="height:1366px; width:auto;">
        <div id="dLogo" class="dLogo">
            <img src="../Image/logo_speedo.JPG" />
        <div id="dLogin" class="dLogin" style="position:relative; top: -42px; left: 1190px; margin-top: 0px;">
            <span id="sWelcome" class="sWelcome">Bem vindo, <asp:Label runat="server" ID="luser"></asp:Label>Raphael Nobre !</span>
        </div>
            <div id="dPesquisa" class="dPesquisa" style="position:relative; top: 0px; left: 237px;">
                <div id="dTexto" class ="dTexto">
                    <h2 style="position:relative; top: 4px; left: 0px; width: 194px;">Pesquise o cliente:</h2>
                </div>
            <input type="text" id="busca" class="busca" autofocus="autofocus" placeholder="Pesquisar" />
            </div>
    
        </div>
    
    </div>
    </form>
</body>
</html>
