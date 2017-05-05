using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TradeSpeedo
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Valida se usuário está logado
            var usuario = Session["usuario"];
            if (usuario == null) Response.Redirect("Login.aspx");
        }
    }
}