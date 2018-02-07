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
            BtnAlterar.Visible = false;
            BtnRelatorio.Visible = false;

            if (!Page.IsPostBack)
            {
                var pesquisa = new Visita(conexao);
                ddPesquisa.DataSource = pesquisa.Lista();
                ddPesquisa.DataBind();
                ddPesquisa.Items.Insert(0, new ListItem("", ""));

            }
        }

        protected void BtnSair_Click(object sender, EventArgs e)
        {
            Response.Redirect("Visitas_Login.aspx");

        }

        protected void ddPesquisa_SelectedIndexChanged(object sender, EventArgs e)
        {
            BtnAlterar.Visible = true;
            BtnRelatorio.Visible = true;
        }

        protected void BtnIncluir_Click(object sender, EventArgs e)
        {                            
            Response.Redirect("Visitas_Capa.aspx");
        }

        protected void BtnAlterar_Click(object sender, EventArgs e)
        {
            var conexao = Session["conexao"].ToString();
            var rep = new Visita(conexao);
            rep.Recupera(Convert.ToInt32(ddPesquisa.SelectedValue));
            
            Response.Redirect("Visitas_Capa.aspx?id=" + rep.ID);
        }

    }
}