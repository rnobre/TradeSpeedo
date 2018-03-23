<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Visitas_Relatorio.aspx.cs" Inherits="TradeSpeedo.Visitas.Pages.Visitas_Relatorio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Relatório</title>

    <link href="../../Image/bumerangue.ico" rel="shortcur icon" type="image/x-icon" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="dLogo" class="dLogo">
            <a>
                <img id="iLogo" class="iLogo" src="../../Image/logo.png" />
            </a>
        </div>
        <div id="dTitulo" class="dTitulo">
            <asp:TextBox ID="txTitulo" CssClass="txTitulo" runat="server"></asp:TextBox>
        </div>
        <div id="dCapa" class="dCapa">
            <label id="lRepre" class="lbl">Representante:</label>
            <asp:TextBox ID="txRepre" CssClass="txRepre" runat="server"></asp:TextBox>
            <label id="dPeriodo" class="lbl">Período:</label>
            <asp:TextBox ID="txPeriodo" CssClass="txPeriodo" runat="server"></asp:TextBox>
            <label id="lObj" class="lbl">Objetivos:</label>
            <textarea id="txObj" class="txObj" runat="server"></textarea>
        </div>
        <div id="dTituloCorpo" class="dTituloCorpo">
            <label id="lDia" class="lDia">Dia</label>
            <asp:TextBox ID="txDia" CssClass="txDia" runat="server"></asp:TextBox>
            <label id="lhifen" class="lbl">-</label>
            <asp:TextBox ID="txData" CssClass="txData" runat="server"></asp:TextBox>
        </div>
        <div id="dCorpo" class="dCorpo">
            <label id="lCliente" class="lbl">Cliente:</label>
            <asp:TextBox ID="txCliente" CssClass="txCliente" runat="server" />
            <label id="lLocal" class="lbl">Local</label>
            <asp:TextBox ID="txLocal" CssClass="txLocal" runat="server" />
            <label id="lComprador" class="lbl">Comprador:</label>
            <asp:TextBox ID="txComprador" CssClass="txComprador" runat="server" />
            <label id="lPerfil" class="lbl">Perfil:</label>
            <asp:TextBox ID="txPerfil" CssClass="txPerfil" runat="server" />
            <label id="lSort" class="lbl">Sortimento:</label>
            <asp:TextBox ID="txSort" CssClass="txSort" runat="server" />
            <label id="lExpo" class="lbl">Exposição</label>
            <asp:TextBox ID="txExpo" CssClass="txExpo" runat="server" />
            <label id="lConcorrente" class="lbl">Concorrentes:</label>
            <asp:TextBox ID="txConcorrente" CssClass="txConcorrente" runat="server" />
            <label id="lComent" class="lbl">Comentários:</label>
            <asp:TextBox ID="txComent" CssClass="txComent" runat="server" />
            <label id="lHistorio" class="lbl">Histórico</label>
            <asp:TextBox ID="txH1" CssClass="txH1" runat="server" />
            <asp:TextBox ID="txH2" CssClass="txH2" runat="server" />
            <asp:TextBox ID="txH3" CssClass="txH3" runat="server" />
            <asp:TextBox ID="txH4" CssClass="txH4" runat="server" />
            <asp:TextBox ID="txH5" CssClass="txH5" runat="server" />
            <asp:TextBox ID="txH6" CssClass="txH6" runat="server" />
            <asp:TextBox ID="txH7" CssClass="txH7" runat="server" />
            <asp:TextBox ID="txH8" CssClass="txH8" runat="server" />
            <div id="dImagem" class="dImagem">
                <div id="dImagemDia1" class="dImagemDia1"></div>
                <div id="dImagemDia2" class="dImagemDia2"></div>
                <div id="dImagemDia3" class="dImagemDia3"></div>
                <div id="dImagemDia4" class="dImagemDia4"></div>
                <div id="dImagemDia5" class="dImagemDia5"></div>
                <div id="dImagemDia6" class="dImagemDia6"></div>
                <div id="dImagemDia7" class="dImagemDia7"></div>
                <div id="dImagemDia8" class="dImagemDia8"></div>
                <div id="dImagemDia9" class="dImagemDia9"></div>
                <div id="dImagemDia10" class="dImagemDia10"></div>
            </div>
            <div id="dTituloFinal" class="dTituloFinal" runat="server">
                <div id="dLogoFinal" class="dLogo">
                    <a>
                        <img id="iLogoFinal" class="iLogo" src="../../Image/logo.png" />
                    </a>
                </div>
                <label id="lTituloFinal" class="lbl">Considerações Finais</label>
            </div>
            <div id="dConclusao" class="dConclusao" runat="server">
                <textarea id="txConclusao" class="txConclusao" runat="server"></textarea>
                <div id="dImagemConclusao1" class="dImagemConclusao1"></div>
                <asp:TextBox ID="txLegenda1" CssClass="txLegenda1" runat="server"></asp:TextBox>
                <div id="dImagemConclusao2" class="dImagemConclusao2"></div>
                <asp:TextBox ID="txLegenda2" CssClass="txLegenda2" runat="server"></asp:TextBox>
                <div id="dImagemConclusao3" class="dImagemConclusao3"></div>
                <asp:TextBox ID="txLegenda3" CssClass="txLegenda3" runat="server"></asp:TextBox>
                <div id="dImagemConclusao4" class="dImagemConclusao4"></div>
                <asp:TextBox ID="txLegenda4" CssClass="txLegenda4" runat="server"></asp:TextBox>
                <div id="dImagemConclusao5" class="dImagemConclusao5"></div>
                <asp:TextBox ID="txLegenda5" CssClass="txLegenda5" runat="server"></asp:TextBox>
                <div id="dImagemConclusao6" class="dImagemConclusao6"></div>
                <asp:TextBox ID="txLegenda6" CssClass="txLegenda6" runat="server"></asp:TextBox>
                <div id="dImagemConclusao7" class="dImagemConclusao7"></div>
                <asp:TextBox ID="txLegenda7" CssClass="txLegenda7" runat="server"></asp:TextBox>
            </div>
        </div>
    </form>
</body>
</html>
