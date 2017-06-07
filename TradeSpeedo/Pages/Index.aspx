<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="TradeSpeedo.Pages.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">


    
    <script src="../Scripts/jquery-3.1.1.min.js"></script>
    <script src="../Scripts/bootstrap.js"></script>
    <script src="../Scripts/bootstrap-select.min.js"></script>
    <link href="../Style/index.css" rel="stylesheet" type="text/css" />
    <link href="../Style/bootstrap.min.css" rel="stylesheet" type="text/css" />    
    <link href="../Style/bootstrap-select.min.css" rel="stylesheet" type="text/css" />
    <meta charset="utf-8" />

    <title>Sistema Trade</title>
    <style type="text/css">
        #dTexto {
            top: -135px;
            left: -143px;
        }
    </style>
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
                <asp:DropDownList runat="server" CssClass="DDPesquisa form-control" DataTextField="NomeCompleto" DataValueField="Clifor" autofocus="autofocus" ID="DDPesquisa" OnSelectedIndexChanged="DDPesquisa_SelectedIndexChanged" AutoPostBack="true" data-live-search="true" data-size="5"></asp:DropDownList>

            </div>
            <div class="row">
                <div class="col-md-2 col-md-offset-1">
                    <%--<asp:Image CssClass="IUpload" ID="IUpload1" runat="server" AlternateText="Selecione a foto para envio" ImageUrl="~/Image/Camera_box.png" />--%>
                    <input type="image" src="../Image/Camera_box.png" class="IUpload" />
                    <input type="file" id="my_file" style="display:none;" onchange="readURL(this);" />                                            
                    <asp:DropDownList CssClass="DDTipo form-control" ID="DDTipo1" DataTextField="Descricao" DataValueField="ID" runat="server"></asp:DropDownList>
                    <asp:DropDownList CssClass="DDClassif form-control" ID="DDClassif1" DataTextField="Descricao" DataValueField="ID" runat="server"></asp:DropDownList>
                </div>
                <div class="col-md-2">
                    <asp:Image CssClass="IUpload" ID="IUpload2" runat="server" AlternateText="Selecione a foto para envio" ImageUrl="~/Image/Camera_box.png" />
                    <asp:FileUpload CssClass="FUpload" runat="server" />
                    <asp:DropDownList CssClass="DDTipo form-control" ID="DDTipo2" DataTextField="Descricao" DataValueField="ID" runat="server"></asp:DropDownList>
                    <asp:DropDownList CssClass="DDClassif form-control" ID="DDClassif2" DataTextField="Descricao" DataValueField="ID" runat="server"></asp:DropDownList>
                </div>
                <div class="col-md-2">
                    <asp:Image CssClass="IUpload" ID="IUpload3" runat="server" AlternateText="Selecione a foto para envio" ImageUrl="~/Image/Camera_box.png" />
                    <asp:FileUpload CssClass="FUpload" runat="server" />
                    <asp:DropDownList CssClass="DDTipo form-control" ID="DDTipo3" DataTextField="Descricao" DataValueField="ID" runat="server"></asp:DropDownList>
                    <asp:DropDownList CssClass="DDClassif form-control" ID="DDClassif3" DataTextField="Descricao" DataValueField="ID" runat="server"></asp:DropDownList>
                </div>
                <div class="col-md-2">
                    <asp:Image CssClass="IUpload" ID="IUpload4" runat="server" AlternateText="Selecione a foto para envio" ImageUrl="~/Image/Camera_box.png" />
                    <asp:FileUpload CssClass="FUpload" runat="server" />
                    <asp:DropDownList CssClass="DDTipo form-control" ID="DDTipo4" DataTextField="Descricao" DataValueField="ID" runat="server"></asp:DropDownList>
                    <asp:DropDownList CssClass="DDClassif form-control" ID="DDClassif4" DataTextField="Descricao" DataValueField="ID" runat="server"></asp:DropDownList>
                </div>
                <div class="col-md-2">
                    <asp:Image CssClass="IUpload" ID="IUpload5" runat="server" AlternateText="Selecione a foto para envio" ImageUrl="~/Image/Camera_box.png" />
                    <asp:FileUpload CssClass="FUpload" runat="server" />
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
                    $("input[id='my_file']").click();
                });

                function readURL(input) {
                    if (input.files && input.files[0]) {
                        var reader = new FileReader();

                        reader.onload = function (e) {
                            $('#blah')
                                .attr('src', e.target.result)
                                .width(150)
                                .height(200);
                        };

                        reader.readAsDataURL(input.files[0]);
                    }
                }
            </script>
        </div>
    </form>

</body>
</html>
