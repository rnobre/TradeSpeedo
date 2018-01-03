using System;
using TradeSpeedo.Model;

namespace TradeSpeedo.Visitas.Pages
{
    public partial class Top : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var usuario = Session["usuario"];
            var login = (Usuario)Session["usuario"];
        }
        protected void BtnSair_Click(object sender, EventArgs e)
        {
            Session["conexao"] = null;
            Response.Redirect("Visitas_Login.aspx");
        }
    }
}