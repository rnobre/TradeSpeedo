using System;
using System.Configuration;
using System.Web.UI;
using TradeSpeedo.Model;

namespace TradeSpeedo.Visitas.Pages
{
    public partial class Visitas_Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Session["conexao"] = ConfigurationManager.ConnectionStrings["conexao"].ConnectionString;
                dErro.Visible = false;
            }
        }

        protected void Acessar_Click(object sender, EventArgs e)
        {
            var conexao = Session["conexao"].ToString();
            var usuario = Usuario.RetornaUsuarioV(txUsuario.Text, txtSenha.Text, conexao);

            if (usuario != null)
            {
                Session["usuario "] = usuario;
                Response.Redirect("Visitas_Index.aspx");

            }
            else
            {
                dErro.Visible = true;
            }

        }
    }
}