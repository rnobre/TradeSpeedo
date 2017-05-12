using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TradeSpeedo.Model;

namespace TradeSpeedo
{
    public partial class Login : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {


            if (!Page.IsPostBack)
            {
                // Grava string de conexão em sessão
                Session["conexao"] = ConfigurationManager.ConnectionStrings["conexao"].ConnectionString;
            }

        }




        protected void Acessar_Click(object sender, EventArgs e)
        {
            var conexao = Session["conexao"].ToString();
            var usuario = Usuario.RetornaUsuario(txtUsuario.Text, txtSenha.Text, conexao);

            if(usuario != null)
            {
                // Loga
                Session["usuario"] = usuario;
                Response.Redirect("Default.aspx");
            }
        }
    }
}