<%@ Page Title="" Language="C#" MasterPageFile="~/Visitas/Pages/Top.Master" AutoEventWireup="true" ClientIDMode="static" CodeBehind="Visitas_Capa.aspx.cs" Inherits="TradeSpeedo.Visitas.Pages.Visitas_Capa" %>
<asp:Content ID="head" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <meta charset="utf-8" />
    <title>Visitas_Capa</title>       
    <script src="https://cdn.ckeditor.com/4.8.0/standard/ckeditor.js"></script>
    <script src="../../Scripts/jquery-3.1.1.min.js"></script>
    <script src="../../Scripts/jquery.maskedinput.min.js"></script>
    <script src="../../Scripts/bootstrap.min.js"></script>    
    <link href="../../Style/bootstrap1.min.css" rel="stylesheet" />
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
    <div id="dFormulario" class="row">
        
        <!-- Coluna da esquerda -->
        <div class="col-md-6">
            <div id="dVisita" class="form-group">
                <label ID="lblVisita" class="lbl" for="txtVisita">Visita: </label>
                <asp:TextBox ID="txtVisita" CssClass="txtinput form-control" runat="server"></asp:TextBox>
            </div>
            <div id="dPeriodo" class="form-group">
                <label ID="lblPeriodo" class="lbl" for="txtPeriodo">Período: </label>
                <asp:TextBox ID="txtPeriodo" CssClass="txtinput form-control" runat="server"
                    ClientIDMode="Static" data-mask="00/00/0000"></asp:TextBox>
            </div>
            <div id="dRepre" class="form-group">
                <label ID="lblRepre" class="lbl" for="txtRepre">Representante: </label>
                <asp:TextBox ID="txtRepre" CssClass="txtinput form-control" runat="server"></asp:TextBox>
            </div>
            <div id="dRegiao" class="form-group" >
                <label ID="lblRegiao" class="lbl" for="txtRegiao">Região: </label>
                <asp:TextBox ID="txtRegiao" CssClass="txtinput form-control" runat="server"></asp:TextBox>
            </div>
        </div>

        <!-- Coluna da direita -->
        <div class="col-md-6">
            <div id="dObj" class="dObj">
                <Label ID="lblObj" Class="lblObj">Objetivo: </Label> 
            </div>
            
            <div id="dtObj" class="dtObj" runat="server">            
                <textarea id="txObj" class ="txtinput" runat="server"></textarea>            
            </div>
                </div>
        <div id="dDias" class="dDias col-md-4">
            <label id="lblDia" class="lbl">Dias:</label>
            <asp:Image ID="iDIa" CssClass="iDIa" ImageUrl="~/Visitas/Imagem/mais.jpg" runat="server" />
        </div>
        <div id="dConclusao" class="dConclusao col-md-4">
            <label id="lblConclusao" class="lbl">Conclusão:</label>
            <asp:Image ID="iConclusao" CssClass="iConclusao" ImageUrl="~/Visitas/Imagem/checkpreto.jpg" runat="server" />
        </div>
            <div class="col-md-4">
                <asp:Button ID="BtnSalvar" Text="Salvar" runat="server" CssClass="btnSalvar primary btn-lg" OnClick="BtnSalvar_Click"/>            
            </div>
        <div class="col-md-4">
                <asp:Button ID="BtnAltera" Text="Altera" runat="server" CssClass="btnSalvar primary btn-lg" OnClick="BtnAltera_Click"/>            
            </div>
        </div>
   
    <script>

        document.addEventListener('DOMContentLoaded', function () {
            CKEDITOR.replace('txObj');
        }, true);      
     
        $(document).ready(function () {
            $("#txtPeriodo").mask("99/99/9999 à 99/99/9999");
        });

    <%=strScript%>
    </script>
</asp:Content>
