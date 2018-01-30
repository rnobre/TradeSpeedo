using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TradeSpeedo.Model;

namespace TradeSpeedo.Visitas.Pages
{
    public partial class Visitas_Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BtnSalvar.Visible = false;
            var conexao = Session["conexao"].ToString();
            var usuario = (Usuario)Session["usuario"];

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

        }

        protected void BtnIncluir_Click(object sender, EventArgs e)
        {
            //txtVisita.Visible = true;
            //ddPesquisa.Visible = false;
            //BtnIncluir.Visible = false;
            //BtnSalvar.Visible = true;                                

            Response.Redirect("Visitas_Capa.aspx");
        }

    }
}