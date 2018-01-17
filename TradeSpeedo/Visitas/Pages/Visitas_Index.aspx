<%@ Page Title="" Language="C#" MasterPageFile="~/Visitas/Pages/Top.Master" AutoEventWireup="true" CodeBehind="Visitas_Index.aspx.cs" Inherits="TradeSpeedo.Visitas.Pages.Visitas_Index" %>



<asp:Content ID="head" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <meta charset="utf-8" />
    <title>Visitas</title>
    <script src="../../Scripts/jquery-3.1.1.min.js"></script>
    <script src="../../Scripts/bootstrap-select.min.js"></script>
    <script src="../../Scripts/bootstrap.js"></script>
    
    <link href="../../Image/bumerangue.ico" rel="shortcur icon" type="image/x-icon" />
    <link href="../../Style/bootstrap-select.min.css" rel="stylesheet" type="text/css" />
    <link href="../../Style/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../Style/visitas_index.css" rel="stylesheet" type="text/css" />    
    <meta name="viewport" content="width=device-width, initial-scale=1">
</asp:Content>

<asp:Content ID="body" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div id="dMain" class="dMain">
        <%--   <div id="dLogin" class="dLogin">
                    <span id="sWelcome" class="sWelcome">Bem vindo,
                    <asp:Label runat="server" ID="Luser"></asp:Label>!</span>
                    <asp:LinkButton ID="BtnSair" class="BtnSair" runat="server" OnClick="BtnSair_Click">Sair</asp:LinkButton>
                </div>--%>
        <div id="dTitulo" class="dTitulo">
            <h1 id="hTitulo" class="hTitulo">Visitas</h1>
        </div>
        <div id="dPesquisa" class="dPesquisa">
            <asp:DropDownList ID="ddPesquisa" CssClass="ddPesquisa form-control" runat="server" DataTextField="" DataValueField=""
                OnSelectedIndexChanged="ddPesquisa_SelectedIndexChanged" AutoPostBack="true" data-live-search="true" data-size="10"></asp:DropDownList>
            
        </div>
        <div class="col-md-2">
            <asp:Button ID="BtnIncluir" Text="Incluir" runat="server" CssClass="btn primary btn-lg" OnClick="BtnIncluir_Click" />            
        </div>
         <div class="col-md-2">
            <asp:Button ID="BtnSalvar" Text="Salvar" runat="server" CssClass="btnSalvar primary btn-lg" OnClick="BtnIncluir_Click" />            
        </div>
    </div>
        <script>
            $('#DDPesquisa').selectpicker();
        </script>          
</asp:Content>
