<%@ Page Title="" Language="C#" MasterPageFile="~/Visitas/Pages/Top.Master" ValidateRequest = "false" ClientIDMode="static" AutoEventWireup="true" CodeBehind="Visitas_Index.aspx.cs" Inherits="TradeSpeedo.Visitas.Pages.Visitas_Index" %>



<asp:Content ID="head" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <meta charset="utf-8" />
    <title>Visitas</title>

    <script src="../../Scripts/jquery-3.1.1.min.js"></script>     
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.4/js/bootstrap.min.js"></script>   
    <script src="../Script/bootstrap-select.js"></script>

    <link href="../Style/bootstrap-select.min.css" rel="stylesheet" />
    <link href="../Style/bootstrap.min.css" rel="stylesheet" />
     <link href="../Style/bootstrap.min.css" rel="stylesheet" />
    <link href="../../Image/bumerangue.ico" rel="shortcur icon" type="image/x-icon" />  
    <link href="../Style/visitas_index.css" rel="stylesheet" type="text/css" />    
   

    <meta name="viewport" content="width=device-width, initial-scale=1">
</asp:Content>

<asp:Content ID="body" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div id="dMain" class="dMain">
        <div id="dTitulo" class="dTitulo">
            <h1 id="hTitulo" class="hTitulo">Visitas</h1>
        </div>
        <div id="dPesquisa" class="dPesquisa">          
            <asp:DropDownList ID="ddPesquisa" CssClass="ddPesquisa selectpicker show-tick form-control" data-live-search="true" OnSelectedIndexChanged="ddPesquisa_SelectedIndexChanged"  DataValueField="ID" 
                DataTextField="Descricao" runat="server"></asp:DropDownList>            

        </div>
        <div>
            <asp:Button ID="BtnIncluir" Text="Incluir" runat="server" CssClass="btnIncluir primary btn-lg" OnClick="BtnIncluir_Click" />
        </div>
        <div>
            <asp:Button ID="BtnSalvar" Text="Salvar" runat="server" CssClass="btnSalvar primary btn-lg" OnClick="BtnIncluir_Click" />
        </div>
    </div>
    <script>  
        $('.ddPesquisa').selectpicker();
    </script>
</asp:Content>
