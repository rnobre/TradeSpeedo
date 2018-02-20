<%@ Page Title="" Language="C#" MasterPageFile="~/Visitas/Pages/Top.Master" AutoEventWireup="true" ClientIDMode="static" CodeBehind="Visitas_Imagem.aspx.cs" Inherits="TradeSpeedo.Visitas.Pages.Visitas_Imagem" %>

<asp:Content ID="head" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <meta charset="utf-8" />
    <title>Visitas_Detalhe</title>    
    <script type="text/javascript" src="http://code.jquery.com/jquery-2.0.3.min.js"></script>
    <script src="../Script/jquery.uploadPreview.min.js"></script>
    <script src="../../Scripts/bootstrap.min.js"></script>


    <link href="../Style/bootstrap.min.css" rel="stylesheet" />
    <link href="../../Image/bumerangue.ico" rel="shortcur icon" type="image/x-icon" />
    <link href="../Style/visitas_imagen.css" rel="stylesheet" />

    <meta name="viewport" content="width=device-width, initial-scale=1">
</asp:Content>

<asp:Content ID="body" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div id="dTitulo" class="dTitulo">
        <h1 id="hTitulo" class="hTitulo">Imagens</h1>
    </div>
    <div id="dMain" class="dMain row" runat="server">
        <div class="dImg1 col-md-2 col-md-offset-1">
            <div id="imagepreview1" class="image-preview" runat="server">
                <asp:HiddenField ID="lbl1" runat="server"></asp:HiddenField>
                <asp:HiddenField ID="NovaImagem1" runat="server" Value="false" />
                <label for="image-upload" runat="server" id="imagelabel1" class="image-label"></label>
                <input type="file" runat="server" name="image" id="imageupload1" class="image-upload" />
            </div>
        </div>
        <div class="dImg2 col-md-2">
            <div id="imagepreview2" class="image-preview" runat="server">
                <asp:HiddenField ID="lbl2" runat="server"></asp:HiddenField>
                <asp:HiddenField ID="NovaImagem2" runat="server" Value="false" />
                <label for="image-upload" runat="server" id="imagelabel2" class="image-label"></label>
                <input type="file" runat="server" name="image" id="imageupload2" class="image-upload" />
            </div>
        </div>
        <div class="dImg3 col-md-2">
            <div id="imagepreview3" class="image-preview" runat="server">
                <asp:HiddenField ID="lbl3" runat="server"></asp:HiddenField>
                <asp:HiddenField ID="NovaImagem3" runat="server" Value="false" />
                <label for="image-upload" runat="server" id="imagelabel3" class="image-label"></label>
                <input type="file" runat="server" name="image" id="imageupload3" class="image-upload" />
            </div>
        </div>
        <div class="dImg4 col-md-2">
            <div id="imagepreview4" class="image-preview" runat="server">
                <asp:HiddenField ID="lbl4" runat="server"></asp:HiddenField>
                <asp:HiddenField ID="NovaImagem4" runat="server" Value="false" />
                <label for="image-upload" runat="server" id="imagelabel4" class="image-label"></label>
                <input type="file" runat="server" name="image" id="imageupload4" class="image-upload" />
            </div>
        </div>
        <div class="dImg5 col-md-2">
            <div id="imagepreview5" class="image-preview" runat="server">
                <asp:HiddenField ID="lbl5" runat="server"></asp:HiddenField>
                <asp:HiddenField ID="NovaImagem5" runat="server" Value="false" />
                <label for="image-upload" runat="server" id="imagelabel5" class="image-label"></label>
                <input type="file" runat="server" name="image" id="imageupload5" class="image-upload" />
            </div>
        </div>
        <div class="dImg6 col-md-2 col-md-offset-1">
            <div id="imagepreview6" class="image-preview" runat="server">
                <asp:HiddenField ID="lbl6" runat="server"></asp:HiddenField>
                <asp:HiddenField ID="NovaImagem6" runat="server" Value="false" />
                <label for="image-upload" runat="server" id="imagelabel6" class="image-label"></label>
                <input type="file" runat="server" name="image" id="imageupload6" class="image-upload" />
            </div>
        </div>
        <div class="dImg7 col-md-2">
            <div id="imagepreview7" class="image-preview" runat="server">
                <asp:HiddenField ID="lbl7" runat="server"></asp:HiddenField>
                <asp:HiddenField ID="NovaImagem7" runat="server" Value="false" />
                <label for="image-upload" runat="server" id="imagelabel7" class="image-label"></label>
                <input type="file" runat="server" name="image" id="imageupload7" class="image-upload" />
            </div>
        </div>
        <div class="dImg8 col-md-2">
            <div id="imagepreview8" class="image-preview" runat="server">
                <asp:HiddenField ID="lbl8" runat="server"></asp:HiddenField>
                <asp:HiddenField ID="NovaImagem8" runat="server" Value="false" />
                <label for="image-upload" runat="server" id="imagelabel8" class="image-label"></label>
                <input type="file" runat="server" name="image" id="imageupload8" class="image-upload" />
            </div>
        </div>
        <div class="dImg9 col-md-2">
            <div id="imagepreview9" class="image-preview" runat="server">
                <asp:HiddenField ID="lbl9" runat="server"></asp:HiddenField>
                <asp:HiddenField ID="NovaImagem9" runat="server" Value="false" />
                <label for="image-upload" runat="server" id="imagelabel9" class="image-label"></label>
                <input type="file" runat="server" name="image" id="imageupload9" class="image-upload" />
            </div>
        </div>
        <div class="dImg10 col-md-2">
            <div id="imagepreview10" class="image-preview" runat="server">
                <asp:HiddenField ID="lbl10" runat="server"></asp:HiddenField>
                <asp:HiddenField ID="NovaImagem10" runat="server" Value="false" />
                <label for="image-upload" runat="server" id="imagelabel10" class="image-label"></label>
                <input type="file" runat="server" name="image" id="imageupload10" class="image-upload" />
            </div>
        </div>
        <div class="Botao col-md-4">
            <asp:Button ID="BtnSalvar" Text="Salvar" runat="server" CssClass="btnSalvar primary btn-lg" OnClick="BtnSalvar_Click" />
        </div>

    </div>
    <script>  
        $("input[type='image']").click(function () {
            $("input[id='Img1']").click();
        });

        $(document).ready(function () {
            $.uploadPreview({
                input_field: "#imageupload1",
                preview_box: "#imagepreview1",
                label_field: "#imagelabel1",

            });


            $.uploadPreview({
                input_field: "#imageupload2",
                preview_box: "#imagepreview2",
                label_field: "#imagelabel2",

            });

            $.uploadPreview({
                input_field: "#imageupload3",
                preview_box: "#imagepreview3",
                label_field: "#imagelabel3",

            });

            $.uploadPreview({
                input_field: "#imageupload4",
                preview_box: "#imagepreview4",
                label_field: "#imagelabel4",

            });

            $.uploadPreview({
                input_field: "#imageupload5",
                preview_box: "#imagepreview5",
                label_field: "#imagelabel5",

            });

            $.uploadPreview({
                input_field: "#imageupload6",
                preview_box: "#imagepreview6",
                label_field: "#imagelabel6",

            });

            $.uploadPreview({
                input_field: "#imageupload7",
                preview_box: "#imagepreview7",
                label_field: "#imagelabel7",

            });

            $.uploadPreview({
                input_field: "#imageupload8",
                preview_box: "#imagepreview8",
                label_field: "#imagelabel8",

            });

            $.uploadPreview({
                input_field: "#imageupload9",
                preview_box: "#imagepreview9",
                label_field: "#imagelabel9",

            });

            $.uploadPreview({
                input_field: "#imageupload10",
                preview_box: "#imagepreview10",
                label_field: "#imagelabel10",

            });
        });

         <%=strScript%>
</script>
</asp:Content>
