<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="TradeSpeedo.Pages.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <script src="../Scripts/jquery-3.1.1.min.js"></script>
    <script src="../Scripts/bootstrap.js"></script>
    <script src="../Scripts/bootstrap-select.min.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.uploadPreview.min.js"></script>
    <link href="../Style/index.css" rel="stylesheet" type="text/css" />
    <link href="../Style/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../Style/bootstrap-select.min.css" rel="stylesheet" type="text/css" />
    <meta charset="utf-8" />

    <title>Sistema Trade</title>
</head>
<body class="body" id="body">
    <form id="form1" class="form1" runat="server">
        <div id="dIndex" class="dIndex">
            <div id="dLogo" class="dLogo">
                <img src="../Image/logo.png" />
            </div>
            <div id="dLogin" class="dLogin">
                <span id="sWelcome" class="sWelcome">Bem vindo,
                    <asp:Label runat="server" ID="Luser"></asp:Label>!</span>
                <asp:LinkButton ID="BtnSair" class="BtnSair" runat="server" OnClick="BtnSair_Click">Sair</asp:LinkButton>
            </div>
            <div id="dPesquisa" class="dPesquisa">
                <div id="dTexto" class="dTexto">
                    <h2 id="h2" class="h2">Pesquise o cliente:</h2>
                </div>
                <asp:DropDownList runat="server" CssClass="DDPesquisa form-control" DataTextField="NomeCompleto" DataValueField="Clifor" ID="DDPesquisa" OnSelectedIndexChanged="DDPesquisa_SelectedIndexChanged" AutoPostBack="true" data-live-search="true" data-size="10"></asp:DropDownList>
            </div>
            <div class="row">
                <div class="col-md-2 col-md-offset-1">
                    <div id="imagepreview1" class="image-preview">                        
                        <asp:HiddenField ID="lbl1" runat="server"></asp:HiddenField>
                        <label for="image-upload" runat="server" id="imagelabel1" class="image-label"></label>
                        <input type="file" runat="server" name="image" id="imageupload1" class="image-upload" />
                    </div>
                    <asp:DropDownList CssClass="DDTipo form-control" ID="DDTipo1" DataTextField="Descricao" DataValueField="ID" runat="server"></asp:DropDownList>
                    <asp:DropDownList CssClass="DDClassif form-control" ID="DDClassif1" DataTextField="Descricao" DataValueField="ID" runat="server"></asp:DropDownList>
                </div>
                <div class="col-md-2">
                    <div id="imagepreview2" class="image-preview">
                        <asp:HiddenField id="lbl2" runat="server" ></asp:HiddenField>
                        <label for="image-upload" runat="server" id="imagelabel2" class="image-label"></label>
                        <input type="file" runat="server" name="image" id="imageupload2" class="image-upload" />
                    </div>
                    <asp:DropDownList CssClass="DDTipo form-control" ID="DDTipo2" DataTextField="Descricao" DataValueField="ID" runat="server"></asp:DropDownList>
                    <asp:DropDownList CssClass="DDClassif form-control" ID="DDClassif2" DataTextField="Descricao" DataValueField="ID" runat="server"></asp:DropDownList>
                </div>
                <div class="col-md-2">
                    <div id="imagepreview3" class="image-preview">
                        <asp:HiddenField id="lbl3" runat="server" ></asp:HiddenField>
                        <label for="image-upload" runat="server" id="imagelabel3" class="image-label"></label>
                        <input type="file" runat="server" name="image" id="imageupload3" class="image-upload" />
                    </div>
                    <asp:DropDownList CssClass="DDTipo form-control" ID="DDTipo3" DataTextField="Descricao" DataValueField="ID" runat="server"></asp:DropDownList>
                    <asp:DropDownList CssClass="DDClassif form-control" ID="DDClassif3" DataTextField="Descricao" DataValueField="ID" runat="server"></asp:DropDownList>
                </div>
                <div class="col-md-2">
                    <div id="imagepreview4" class="image-preview">
                        <asp:HiddenField id="lbl4" runat="server" ></asp:HiddenField>
                        <label for="image-upload" runat="server" id="imagelabel4" class="image-label"></label>
                        <input type="file" runat="server" name="image" id="imageupload4" class="image-upload" />
                    </div>
                    <asp:DropDownList CssClass="DDTipo form-control" ID="DDTipo4" DataTextField="Descricao" DataValueField="ID" runat="server"></asp:DropDownList>
                    <asp:DropDownList CssClass="DDClassif form-control" ID="DDClassif4" DataTextField="Descricao" DataValueField="ID" runat="server"></asp:DropDownList>
                </div>
                <div class="col-md-2">
                    <div id="imagepreview5" class="image-preview">
                        <asp:HiddenField id="lbl5" runat="server"></asp:HiddenField>
                        <label for="image-upload" runat="server" id="imagelabel5" class="image-label"></label>
                        <input type="file" runat="server" name="image" id="imageupload5" class="image-upload" />
                    </div>
                    <asp:DropDownList CssClass="DDTipo form-control" ID="DDTipo5" DataTextField="Descricao" DataValueField="ID" runat="server"></asp:DropDownList>
                    <asp:DropDownList CssClass="DDClassif form-control" ID="DDClassif5" DataTextField="Descricao" DataValueField="ID" runat="server"></asp:DropDownList>
                </div>
                <div class="col-md-2">
                    <asp:Button ID="BtnSalvar" Text="Salvar" runat="server" CssClass="btn primary btn-lg" OnClick="BtnSalvar_Click" />
                </div>
            </div>
            <script>
                $('.DDPesquisa').selectpicker();


                $("input[type='image']").click(function () {
                    $("input[id='Img1']").click();
                });

                $(document).ready(function () {
                    $.uploadPreview({
                        input_field: "#imageupload1",
                        preview_box: "#imagepreview1",
                        label_field: "#imagelabel1",

                    });
                });
                $(document).ready(function () {
                    $.uploadPreview({
                        input_field: "#imageupload2",
                        preview_box: "#imagepreview2",
                        label_field: "#imagelabel2",

                    });
                });
                $(document).ready(function () {
                    $.uploadPreview({
                        input_field: "#imageupload3",
                        preview_box: "#imagepreview3",
                        label_field: "#imagelabel3",

                    });
                });
                $(document).ready(function () {
                    $.uploadPreview({
                        input_field: "#imageupload4",
                        preview_box: "#imagepreview4",
                        label_field: "#imagelabel4",

                    });
                });
                $(document).ready(function () {
                    $.uploadPreview({
                        input_field: "#imageupload5",
                        preview_box: "#imagepreview5",
                        label_field: "#imagelabel5",

                    });
                });
            </script>
        </div>
    </form>

</body>
</html>
