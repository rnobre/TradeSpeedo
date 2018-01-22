<%@ Page Title="" Language="C#" MasterPageFile="~/Visitas/Pages/Top.Master" AutoEventWireup="true" CodeBehind="Visitas_Index.aspx.cs" Inherits="TradeSpeedo.Visitas.Pages.Visitas_Index" %>



<asp:Content ID="head" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <meta charset="utf-8" />
    <title>Visitas</title>

    <script src="../../Scripts/jquery-3.1.1.min.js"></script>    
    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-select/1.12.4/js/bootstrap-select.min.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-select/1.12.4/css/bootstrap-select.min.css">
    <script src="../Script/chosen.jquery.js"></script>
    <script src="../../Scripts/bootstrap.min.js"></script>
    <link href="../../Style/bootstrap1.min.css" rel="stylesheet" />
    <link href="../Style/chosen.css" rel="stylesheet" />
    <link href="../../Image/bumerangue.ico" rel="shortcur icon" type="image/x-icon" />  
    <link href="../Style/visitas_index.css" rel="stylesheet" type="text/css" />    
    <%--<link href="../Style/bootstrap-select.min.css" rel="stylesheet" />--%>

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
            <%--<asp:DropDownList ID="ddPesquisa" CssClass="ddPesquisa" runat="server" DataTextField="visita" DataValueField="visita"
                OnSelectedIndexChanged="ddPesquisa_SelectedIndexChanged" AutoPostBack="true" data-live-search="true" data-size="10"></asp:DropDownList>--%>
            
            <select id="SPesquisa" class="sPesquisa form-control chosen-select" data-live-search="true" data-placeholder="Pesquisar" tabindex="-1"  DataTextField="visita" DataValueField="visita" runat="server">
                <option value=""></option>              
            </select>
            

        </div>
        <div>
            <asp:Button ID="BtnIncluir" Text="Incluir" runat="server" CssClass="btnIncluir primary btn-lg" OnClick="BtnIncluir_Click" />
        </div>
        <div>
            <asp:Button ID="BtnSalvar" Text="Salvar" runat="server" CssClass="btnSalvar primary btn-lg" OnClick="BtnIncluir_Click" />
        </div>
    </div>
    <script>                              
        
        $(".chosen-select").chosen();
    </script>
</asp:Content>
