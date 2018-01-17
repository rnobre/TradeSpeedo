﻿using System;
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
            var conexao = Session["conexao"].ToString();
            var usuario = (Usuario)Session["usuario"];
            //txtVisita.Visible = false;
            BtnSalvar.Visible = false;
            

            var visita = new Visita(conexao);

            ddPesquisa.DataSource = visita.Lista();
            ddPesquisa.DataBind();
            ddPesquisa.Items.Insert(0, new ListItem("Pesquisar", ""));            

        }

        protected void ddPesquisa_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void BtnSair_Click(object sender, EventArgs e)
        {            
            Response.Redirect("Visitas_Login.aspx");
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