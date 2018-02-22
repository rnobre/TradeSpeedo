using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using TradeSpeedo.Model;

namespace TradeSpeedo.Visitas.Pages
{
    public partial class Visitas_Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {            
            var conexao = Session["conexao"].ToString();
            var usuario = (Usuario)Session["usuario"];
            
            if (!Page.IsPostBack)
            {
                ddPesquisa.DataSource = Visita.Lista(conexao);
                ddPesquisa.DataBind();
                ddPesquisa.Items.Insert(0, new ListItem("", ""));
            }
        }

        protected void BtnSair_Click(object sender, EventArgs e) =>
            Response.Redirect("Visitas_Login.aspx");

        protected void ddPesquisa_SelectedIndexChanged(object sender, EventArgs e)
        {
            BtnAlterar.Visible = true;
            BtnRelatorio.Visible = true;
        }

        protected void BtnIncluir_Click(object sender, EventArgs e) =>
            Response.Redirect("Visitas_Capa.aspx");

        protected void BtnAlterar_Click(object sender, EventArgs e)
        {
            var conexao = Session["conexao"].ToString();           
            Response.Redirect("Visitas_Capa.aspx?id=" + Convert.ToInt32(ddPesquisa.SelectedValue).ToString());
        }

    }
}