<%@ Page Title="" Language="C#" MasterPageFile="~/Visitas/Pages/Top.Master" AutoEventWireup="true" ClientIDMode="static" CodeBehind="Visitas_Capa.aspx.cs" Inherits="TradeSpeedo.Visitas.Pages.Visitas_Capa" %>
<asp:Content ID="head" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <meta charset="utf-8" />
    <title>Visitas</title>       
    <script src="https://cdn.ckeditor.com/4.8.0/standard/ckeditor.js"></script>
    <!--<script src="http://code.jquery.com/jquery-3.0.0.min.js"></script>-->
    <script src="../../Scripts/jquery-3.1.1.min.js"></script>
    <%--<script src="../Script/jquery.mask.js"></script>--%>
    <script src="../../Scripts/jquery.maskedinput.min.js"></script>
    <link href="../../Image/bumerangue.ico" rel="shortcur icon" type="image/x-icon" />        
    <link href="../Style/visitas_capa.css" rel="stylesheet" type="text/css" />
    <link href="../../Scripts/Check/contents.css" rel="stylesheet" type="text/css" />
    <meta name="viewport" content="width=device-width, initial-scale=1">
    

</asp:content>

<asp:Content ID="body" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     <div id="dTitulo" class="dTitulo">
            <h1 id="hTitulo" class="hTitulo">
                Capa</h1>
        </div>
    <div id="dFormulario" class="dFormulario">
        <div id="dVisita" class="dVisita">
            <asp:Label ID="lblVisita" CssClass="lblVisita" runat="server">Visita: </asp:Label>
            <asp:TextBox ID="txtVisita" CssClass="txtVisita" runat="server"></asp:TextBox>
        </div>
        <div id="dPeriodo" class="dPeriodo">
            <asp:Label ID="lblPeriodo" CssClass="lblPeriodo" runat="server">Período: </asp:Label>
            <asp:TextBox ID="txtPeriodo" CssClass="txtPeriodo" runat="server"  ClientIDMode="Static" data-mask="00/00/0000"></asp:TextBox>
        </div>
        <div id="dRepre" class="dRepre">
            <asp:Label ID="lblRepre" CssClass="lblRepre" runat="server">Representante: </asp:Label>
            <asp:TextBox ID="txtRepre" CssClass="txtRepre" runat="server"></asp:TextBox>
        </div>
        <div id="dRegiao" class="dRegiao" >
            <asp:Label ID="lblRegiao" CssClass="lblRegiao" runat="server">Região: </asp:Label>
            <asp:TextBox ID="txtRegiao" CssClass="txtRegiao" runat="server"></asp:TextBox>
        </div>
        <div id="dObj" class="dObj">
            <asp:Label ID="Label1" CssClass="lblObj" runat="server">Objetivo: </asp:Label> 
        </div>
        <div id="ddObj" class="ddObj">
        <div id="dtObj" class="dtObj">            
            <textarea id="txObj" class ="txObj" runat="server"></textarea>            
        </div>
            </div>
        <div class="col-md-2">
            <asp:Button ID="BtnSalvar" Text="Salvar" runat="server" CssClass="btnSalvar primary btn-lg" OnClick="BtnSalvar_Click"/>            
        </div>
    </div>
    <script>

        document.addEventListener('DOMContentLoaded', function () {
            CKEDITOR.replace('dtObj');
        }, true);      
     
        $(document).ready(function () {
            $("#txtPeriodo").mask("99/9999");
        });
    
    </script>
</asp:Content>
