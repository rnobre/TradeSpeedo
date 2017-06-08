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
                <asp:DropDownList runat="server" CssClass="DDPesquisa form-control" DataTextField="NomeCompleto" DataValueField="Clifor" ID="DDPesquisa" OnSelectedIndexChanged="DDPesquisa_SelectedIndexChanged" AutoPostBack="true" data-live-search="true" data-size="5"></asp:DropDownList>
            </div>
            <div class="row">
                <div class="col-md-2 col-md-offset-1">
                    <%--<input type="image" src="../Image/Camera_box.png" class="IUpload" />
                    <input type="file" id="Img1" style="display: none;" onchange="readURL(this);" />--%>
                    <div id="image-preview1" class="image-preview">
                        <label for="image-upload" id="image-label1" class="image-label"></label>                        
                        <input type="file" name="image" id="image-upload1" class="image-upload" />
                    </div>
                    <asp:DropDownList CssClass="DDTipo form-control" ID="DDTipo1" DataTextField="Descricao" DataValueField="ID" runat="server"></asp:DropDownList>
                    <asp:DropDownList CssClass="DDClassif form-control" ID="DDClassif1" DataTextField="Descricao" DataValueField="ID" runat="server"></asp:DropDownList>
                </div>
                <div class="col-md-2">                    
                   <%-- <input type="image" src="../Image/Camera_box.png" class="IUpload" />
                    <input type="file" id="Img2" style="display: none;" onchange="readURL(this);" />--%>
                    <div id="image-preview2" class="image-preview">
                        <label for="image-upload" id="image-label2" class="image-label" />                     
                        <input type="file" name="image" id="image-upload2" class="image-upload" />
                    </div>
                    <asp:DropDownList CssClass="DDTipo form-control" ID="DDTipo2" DataTextField="Descricao" DataValueField="ID" runat="server"></asp:DropDownList>
                    <asp:DropDownList CssClass="DDClassif form-control" ID="DDClassif2" DataTextField="Descricao" DataValueField="ID" runat="server"></asp:DropDownList>
                </div>
                <div class="col-md-2">
                    <%--<input type="image" src="../Image/Camera_box.png" class="IUpload" />
                    <input type="file" id="Img3" style="display: none;" onchange="readURL(this);" />  --%>     
                    <div id="image-preview3" class="image-preview">
                        <label for="image-upload" id="image-label3" class="image-label"></label>                        
                        <input type="file" name="image" id="image-upload3" class="image-upload" />
                    </div>             
                    <asp:DropDownList CssClass="DDTipo form-control" ID="DDTipo3" DataTextField="Descricao" DataValueField="ID" runat="server"></asp:DropDownList>
                    <asp:DropDownList CssClass="DDClassif form-control" ID="DDClassif3" DataTextField="Descricao" DataValueField="ID" runat="server"></asp:DropDownList>
                </div>
                <div class="col-md-2">
         <%--           <input type="image" src="../Image/Camera_box.png" class="IUpload" />
                    <input type="file" id="Img4" style="display: none;" onchange="readURL(this);" />--%>
                    <div id="image-preview4" class="image-preview">
                        <label for="image-upload" id="image-label4" class="image-label"></label>                        
                        <input type="file" name="image" id="image-upload4" class="image-upload" />
                    </div>      
                    <asp:DropDownList CssClass="DDTipo form-control" ID="DDTipo4" DataTextField="Descricao" DataValueField="ID" runat="server"></asp:DropDownList>
                    <asp:DropDownList CssClass="DDClassif form-control" ID="DDClassif4" DataTextField="Descricao" DataValueField="ID" runat="server"></asp:DropDownList>
                </div>
                <div class="col-md-2">
                  <%--  <input type="image" src="../Image/Camera_box.png" class="IUpload" />
                    <input type="file" id="Img5" style="display: none;" onchange="readURL(this);" />--%>
                    <div id="image-preview5" class="image-preview">
                        <label for="image-upload" id="image-label5" class="image-label"></label>                        
                        <input type="file" name="image" id="image-upload5" class="image-upload" />
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
                        input_field: "#image-upload1",
                        preview_box: "#image-preview1",
                        label_field: "#image-label1",
                        
                    });
                });
                $(document).ready(function () {
                    $.uploadPreview({
                        input_field: "#image-upload2",
                        preview_box: "#image-preview2",
                        label_field: "#image-label2",
                        
                    });
                });
                $(document).ready(function () {
                    $.uploadPreview({
                        input_field: "#image-upload3",
                        preview_box: "#image-preview3",
                        label_field: "#image-label3",
                        
                    });
                });
                $(document).ready(function () {
                    $.uploadPreview({
                        input_field: "#image-upload4",
                        preview_box: "#image-preview4",
                        label_field: "#image-label4",
                       
                    });
                });
                $(document).ready(function () {
                    $.uploadPreview({
                        input_field: "#image-upload5",
                        preview_box: "#image-preview5",
                        label_field: "#image-label5",
                       
                    });
                });
            </script>
        </div>
    </form>

</body>
</html>
