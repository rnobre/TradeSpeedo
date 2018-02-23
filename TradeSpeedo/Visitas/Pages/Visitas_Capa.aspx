<%@ Page Title="" Language="C#" MasterPageFile="~/Visitas/Pages/Top.Master" AutoEventWireup="true" ClientIDMode="static" CodeBehind="Visitas_Capa.aspx.cs" Inherits="TradeSpeedo.Visitas.Pages.Visitas_Capa" %>

<asp:Content ID="head" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <meta charset="utf-8" />
    <title>Visitas_Capa</title>
    <script src="https://cdn.ckeditor.com/4.8.0/standard/ckeditor.js"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.3.1/jquery.min.js"></script>
    <script src="../../Scripts/jquery-3.1.1.min.js"></script>
    <script src="../../Scripts/jquery.maskedinput.min.js"></script>
    <script src="../../Scripts/bootstrap.min.js"></script>
    <link href="../../Style/bootstrap1.min.css" rel="stylesheet" />
    <link href="../../Image/bumerangue.ico" rel="shortcur icon" type="image/x-icon" />
    <link href="../Style/visitas_capa.css" rel="stylesheet" type="text/css" />
    <link href="../../Scripts/Check/contents.css" rel="stylesheet" type="text/css" />
    <meta name="viewport" content="width=device-width, initial-scale=1">
</asp:Content>

<asp:Content ID="body" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div id="dTitulo" class="dTitulo">
        <h1 id="hTitulo" class="hTitulo">Capa</h1>
    </div>
    <div id="dFormulario" runat="server" class="row">
        <div class="col-md-6">
            <div id="dVisita" class="form-group">
                <label id="lblVisita" class="lbl" for="txtVisita">Visita: </label>
                <asp:TextBox ID="txtVisita" CssClass="txtinput form-control" runat="server"></asp:TextBox>
            </div>
            <div id="dPeriodo" class="form-group">
                <label id="lblPeriodo" class="lbl" for="txtPeriodo">Período: </label>
                <asp:TextBox ID="txtPeriodo" CssClass="txtinput form-control" runat="server"
                    ClientIDMode="Static" data-mask="00/00/0000"></asp:TextBox>
            </div>
            <div id="dRepre" class="form-group">
                <label id="lblRepre" class="lbl" for="txtRepre">Representante: </label>
                <asp:TextBox ID="txtRepre" CssClass="txtinput form-control" runat="server"></asp:TextBox>
            </div>
            <div id="dRegiao" class="form-group">
                <label id="lblRegiao" class="lbl" for="txtRegiao">Região: </label>
                <asp:TextBox ID="txtRegiao" CssClass="txtinput form-control" runat="server"></asp:TextBox>
            </div>
            <div id="dObj" class="form-group">
                <label id="lblObj" class="lbl">Objetivo: </label>
                <textarea ID="txObj" class="txaObj form-control" runat="server"></textarea>
            </div>
        </div>
        <div class="col-md-6">
            <div id="dCliente" class="form-group">                
                <div>
                    <asp:Button ID="btnIncluir" Text="Nova Visita" runat="server" CssClass="btnIncluir primary btn-lg" OnClick="btnIncluir_Click" />
                </div> 
              <%--  <asp:table id="tbVisitas" class="tbVisitas table" runat="server">                    
                        <asp:TableHeaderRow runat="server">
                            <asp:TableHeaderCell Scope="Column" runat="server">Dia </asp:TableHeaderCell>
                            <asp:TableHeaderCell Scope="Column">Cliente</asp:TableHeaderCell>
                            <asp:TableHeaderCell Scope="Column">Data </asp:TableHeaderCell>                     
                        </asp:TableHeaderRow>
                </asp:table>--%>
                <asp:GridView ID="gvVisitas" CssClass="gvVisitas table" runat="server">
                </asp:GridView>
            </div>
        </div>     
<%--        <div id="dDias" class="dDias">
            <label id="lblDia" class="lbl">Dias:</label>
            <asp:ImageButton ID="iDia" CssClass="iDia" ImageUrl="~/Visitas/Imagem/maisp.jpg" OnClick="iDia_Click" runat="server" />
            <div id="ddDia" class="ddDia" runat="server">
                <asp:Repeater ID="rDia" runat="server" OnItemCommand="rDia_ItemCommand">
                    <HeaderTemplate>
                        <table>
                            <thead>
                                <tr>
                                </tr>
                            </thead>
                            <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <asp:LinkButton ID="lbDireciona" CssClass="aDireciona" runat="server" CommandArgument='<%# Eval("DIA") %>' CommandName="lbDireciona">
                            <%# Eval("DIA") %>
                            </asp:LinkButton>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </tbody>
                    </table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>--%>        
        <div id="dConclusao" class="dConclusao col-md-4">
            <label id="lblConclusao" class="lblConclusao">Conclusão:</label>
            <asp:Image ID="iConclusao" CssClass="iConclusao" ImageUrl="~/Visitas/Imagem/checkpreto.jpg" runat="server" />
        </div>
        <div>
            <asp:Button ID="BtnSalvar" Text="Salvar" runat="server" CssClass="btnSalvar primary btn-lg" OnClick="BtnSalvar_Click" />
        </div>
        <div>
            <asp:Button ID="BtnAltera" Text="Altera" runat="server" CssClass="btnSalvar primary btn-lg" OnClick="BtnAltera_Click" />
        </div>
    </div>

    <script>
        
        //document.addEventListener('DOMContentLoaded', function () {
        //    CKEDITOR.replace('txObj');
        //}, true);

        $(document).ready(function () {
            $("#txtPeriodo").mask("99/99/9999 à 99/99/9999");
        });    

        <%=strScript%>
</script>
</asp:Content>
