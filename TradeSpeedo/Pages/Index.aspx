<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="TradeSpeedo.Pages.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    
    <script src="../Scripts/modernizr-2.8.3.js"></script>    
    <script src="../Scripts/jquery-3.1.1.min.js"></script>
    <link href="../Style/index.css" rel="stylesheet" type="text/css" />
    <meta charset="utf-8" />

    <title>Sistema Trade</title>
</head>
<body style="height:auto">
    <form id="form1" runat="server">
    <div id="dIndex" class="dIndex">
        <div id="dLogo" class="dLogo">
            <img src="../Image/logo_speedo.JPG" />
        <div id="dLogin" class="dLogin">
            <span id="sWelcome" class="sWelcome">Bem vindo, <asp:Label runat="server" ID="luser"></asp:Label>Raphael Nobre !</span>
        </div>
            <div id="dPesquisa" class="dPesquisa">
                <div id="dTexto" class ="dTexto">
                    <h2 id="h2" class="h2">Pesquise o cliente:</h2>
                </div>
            <input type="text" id="busca" class="busca" autofocus="autofocus" placeholder="Pesquisar" />
            </div>
        </div>

    </div>
    </form>
    <script>
        var usuarios =
            [
                <%=RetornaClientes()%>
            ]

        var arrayParaTabela = function (clientes, busca) {
            var $tabela = $("<table></table>");
            var buscaEmMinusculo = busca.toLowerCase();

            for (var i = 0; i < clientes.legth; i++) {
                var cliente = clientes[i];

                if(cliente.clienteatacado.toLowerCase().indexOf(buscaEmMinusculo) !== -1 {
                    var linha = "<tr>";
                    linha += "<td><a CLIENTE_ATACADO='"  + cliente.clienteatacado + "' href='javascript:preencheFicha(usuarios, " + cliente.clienteatacado + ")'>" + cliente.clifor + "</a></td>";

                    $tabela.append(linha);       
                }
            }

            return $tabela;
        };

        
        var constroiTabelaHTML = function (usuarios, termo) {
           
            var tabela = arrayParaTabela(usuarios, termo);

           
            $("#listaClientes").empty();
            $("#listaClientes").append(tabela);
                
        };

        var retornaPrimeiroUsuario = function (usuario, busca) {
            var buscaEmMinusculo = busca.toLowerCase();
            for (var i = 0; i < usuarios.length; i++) {
                var usuario = usuarios[i];

                if (cliente.clienteatacado.toLowerCase().indexOf(buscaEmMinusculo) !== -1 || cliente.clifor.indexOf(busca) !== -1) {
                    return cliente;
                }
            }
        }

        $("#busca").keyup(function () {
            var termo = $("#busca").val();
            constroiTabelaHTML(clientes, termo);

            var primeiroUsuario = retornaPrimeiroUsuario(clientes, termo);
            preencheFicha(clientes, primeiroUsuario.clienteatacado);
        });


        // Preenche a ficha de usuário
        var preencheFicha = function (clientes, codigoUsuario) {

            var usuario;

            // Busca usuário no array
            for (i = 0; i < usuarios.length; i++) {
                if (usuarios[i].id == codigoUsuario) {
                    usuario = usuarios[i];
                }
            }

        }
            constroiTabelaHTML(usuarios, '');

    </script>
</body>
</html>
