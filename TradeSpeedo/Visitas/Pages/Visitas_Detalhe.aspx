<%@ Page Title="" Language="C#" MasterPageFile="~/Visitas/Pages/Top.Master" ValidateRequest="false" AutoEventWireup="true" CodeBehind="Visitas_Detalhe.aspx.cs" Inherits="TradeSpeedo.Visitas.Pages.Visitas_Detalhe" %>


<asp:Content ID="head" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <meta charset="utf-8" />
    <title>Visitas_Detalhe</title>

    <script src="../../Scripts/jquery-3.1.1.js"></script>
    <script src="../../Scripts/bootstrap.js"></script>
    <script src="../../Scripts/jquery.maskedinput.min.js"></script>
    <script src="../Script/bootstrap-select.js"></script>

    <link href="../Style/bootstrap-select-detalhe.min.css" rel="stylesheet" />
    <link href="../../Image/bumerangue.ico" rel="shortcur icon" type="image/x-icon" />
    <link href="../Style/bootstrap.min.css" rel="stylesheet" />
    <link href="../Style/visitas_detalhe.css" rel="stylesheet" />

    <meta name="viewport" content="width=device-width, initial-scale=1">
</asp:Content>
<asp:Content ID="body" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div id="dMain" class="dMain">
        <div id="dTitulo" class="dTitulo">
            <h1 id="hTitulo" class="hTitulo">Detalhes</h1>
        </div>
        <div id="dFormulario" class="dFormulario">
            <div id="dDatas" class="dDatas row">
                <div id="dDia" class="dDia col-sm-3">
                    <label id="lDia" class="lDia">Dia: </label>
                    <asp:TextBox ID="txDia" CssClass="txDia form-control" runat="server"></asp:TextBox>
                </div>
                <div id="dData" class="dData col-sm-3">
                    <label id="lData" class="lData">Data: </label>
                    <asp:TextBox ID="txData" CssClass="txData form-control" runat="server"></asp:TextBox>
                </div>
            </div>
            <div id="dInformacao" class="dInformacao1 row">
                <div id="dCliente" class="dCliente col-sm-3">
                    <label id="lCliente" class="lCliente">Cliente: </label>
                    <asp:DropDownList ID="ddCliente" CssClass="ddCliente selectpicker show-tick form-control" data-live-search="true" TabIndex="-1" runat="server" DataValueField="idClifor" DataTextField="ClienteCompleto"></asp:DropDownList>
                </div>
                <div id="dPerfil" class="dPerfil col-sm-3">
                    <label id="lPerfil" class="lPerfil">Perfil: </label>
                    <asp:DropDownList ID="ddPerfil" CssClass="ddPerfil show-tick form-control" data-live-search="true" TabIndex="-1" DataTextField="Descricao" DataValueField="ID" runat="server"></asp:DropDownList>
                </div>
                <div id="dConcorrentes" class="dConcorrentes col-sm-4">
                    <label id="lConcorrentes" class="lConcorrentes">Concorrentes: </label>
                    <textarea id="txConcorrentes" class="txConcorrentes form-control" runat="server"></textarea>
                </div>
                <div class="dInformacao2 row">
                    <div id="dLocal" class="dLocal col-md-4">
                        <label id="lLocal" class="lLocal">Local: </label>
                        <asp:TextBox ID="txLocal" CssClass="txLocal form-control" runat="server"></asp:TextBox>
                    </div>
                    <div id="dSortimento" class="dSortimento col-md-4">
                        <label id="lSortimento" class="lSortimento">Sortimento: </label>
                        <asp:DropDownList ID="ddSortimento" CssClass="ddSortimento show-tick form-control" data-live-search="true" TabIndex="-1" DataTextField="Descricao" DataValueField="ID" runat="server"></asp:DropDownList>
                    </div>
                    <div class="col-md-8"></div>
                    <div class="col-md-8"></div>
                </div>
                <div class="dInformacao3 row">
                    <div id="dComprador" class="dComprador col-md-4">
                        <label id="lComprador" class="lComprador">Comprador: </label>
                        <asp:TextBox ID="txComprador" CssClass="txComprador form-control" runat="server"></asp:TextBox>
                    </div>
                    <div id="dExpo" class="dExpo col-md-4">
                        <label id="lExpo" class="lExpo">Exposição: </label>
                        <asp:DropDownList ID="ddExpo" CssClass="ddExpo show-tick form-control" data-live-search="true" TabIndex="-1" DataTextField="Descricao" DataValueField="ID" runat="server"></asp:DropDownList>
                    </div>
                    <div class="col-md-8"></div>
                    <div class="col-md-8"></div>

                </div>
                <div class="dInformacao4 row">
                    <div id="dComentario" class="dComentario .col-sm-6 .col-md-5 .col-lg-6">
                        <label id="lComentario" class="lComentario">Comentarios: </label>
                        <textarea id="txComentario" class="txComentario form-control" runat="server"></textarea>
                    </div>
                </div>
                <div class="dInformacao5 row">
                    <label id="lHistorico" class="lHistorico">Históricos: </label>
                    <div id="dHistorico1" class="dHistorico col-md-8">
                        <asp:TextBox ID="txAno1" CssClass="txAno1 form-control" MaxLength="4" runat="server"></asp:TextBox>
                        <asp:TextBox ID="txAno2" CssClass="txAno2 form-control" MaxLength="4" runat="server"></asp:TextBox>
                        <asp:TextBox ID="txAno3" CssClass="txAno3 form-control" MaxLength="4" runat="server"></asp:TextBox>
                        <asp:TextBox ID="txAno4" CssClass="txAno4 form-control" MaxLength="4" runat="server"></asp:TextBox>
                    </div>
                    <div id="dHistorico2" class="dHistorico col-md-8">
                        <asp:TextBox ID="txDin1" CssClass="txDin1 form-control" runat="server"></asp:TextBox>
                        <asp:TextBox ID="txDin2" CssClass="txDin2 form-control" runat="server"></asp:TextBox>
                        <asp:TextBox ID="txDin3" CssClass="txDin3 form-control" runat="server"></asp:TextBox>
                        <asp:TextBox ID="txDin4" CssClass="txDin4 form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="Botao col-md-4">
                <asp:Button ID="BtnSalvar" Text="Salvar" runat="server" CssClass="btnSalvar primary btn-lg" OnClick="BtnSalvar_Click" />
            </div>
            <div class="Botao col-md-4">
                <asp:Button ID="BtnAltera" Text="Altera" runat="server" CssClass="btnSalvar primary btn-lg" />
            </div>
        </div>
    </div>
    <script>
        $(document).ready(function () {
            $(".txData").mask("99/99/9999");
        });

        $('.ddCliente').selectpicker();

        <%=strScript%>
</script>
</asp:Content>
