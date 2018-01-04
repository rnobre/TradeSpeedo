using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TradeSpeedo.Model;
using TradeSpeedo.Utils;

namespace TradeSpeedo.Visitas.Pages
{
    public partial class Visitas_Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var usuario = (Usuario)Session["usuario"];
            ddPesquisa.Items.Insert(0, new ListItem("Pesquisar", ""));

        }

        protected void ddPesquisa_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void BtnSair_Click(object sender, EventArgs e)
        {
            Session["conexao"] = null;
            Response.Redirect("Visitas_Login.aspx");

        }

    }
}