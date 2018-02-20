using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TradeSpeedo.Model;
using System.Web.Services;
using System.Web.UI.HtmlControls;

namespace TradeSpeedo.Visitas.Pages
{
    public partial class Visitas_Capa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BtnAltera.Visible = false;
            var conexao = Session["conexao"].ToString();
            var dia = new Visita_Capa(conexao);
            var id = Request.QueryString["ID"];

            rDia.DataSource = dia.Lista(Convert.ToInt32(id));
            rDia.DataBind();

            if (!Page.IsPostBack)
            {
                var valor = Request.QueryString["ID"];
                var load = new Visita_Capa(conexao);
                load.Carrega(Convert.ToInt32(valor));

                if (load.ID != 0)
                {
                    CarregaPagina(load.Visita, load.Periodo, load.Representante, load.Regiao, load.Objetivo);
                }
            }
        }

        public void CarregaPagina(string lVisita, string lPeriodo, string lRepre, string lRegiao, string lObjetivo)
        {
            txtVisita.Text = lVisita;
            txtPeriodo.Text = lPeriodo;
            txtRepre.Text = lRepre;
            txtRegiao.Text = lRegiao;
            txObj.InnerText = lObjetivo;
        }


        private void SalvaCapa(string visita, string periodo, string repre, string regiao, string obj, string conexao)
        {
            var salva = new Visita_Capa(conexao)
            {
                Visita = visita,
                Periodo = periodo,
                Representante = repre,
                Regiao = regiao,
                Objetivo = obj
            };
            salva.Salvar();
        }

        public string strScript = "";


        protected void BtnSalvar_Click(object sender, EventArgs e)
        {
            //If validação
            var conexao = Session["conexao"].ToString();

            var valida = new Visita_Capa(conexao);
            valida.Valida(txtVisita.Text);

            if(valida.Visita == txtVisita.Text)
            {
                strScript = "alert('Nome da Visita já existe, por gentileza verificar!');";
            }
            else
            {
                SalvaCapa(txtVisita.Text, txtPeriodo.Text, txtRepre.Text, txtRegiao.Text, txObj.Value, conexao);
                strScript = "alert('Informações salvas com sucesso.');";
            }           

        }

        protected void BtnAltera_Click(object sender, EventArgs e)
        {
            var conexao = Session["conexao"].ToString();
            var recupera = new Visita_Capa(conexao);
            var valor = Request.QueryString["ID"];
            recupera.Carrega(Convert.ToInt32(valor));

            Response.Redirect("Visitas_Detalhe.aspx?id=" + recupera.ID + "?dia=");
        }


        protected void iDia_Click(object sender, ImageClickEventArgs e)
        {
            var conexao = Session["conexao"].ToString();
            var recupera = new Visita_Capa(conexao);
            recupera.IdRec();

            Response.Redirect("Visitas_Detalhe.aspx?id=" + recupera.ID);
        }

        protected void rDia_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            var conexao = Session["conexao"].ToString();
            var recupera = new Visita_Capa(conexao);
            recupera.idVisita(txtVisita.Text);
            var id = recupera.ID;

            switch (e.CommandName.ToString())
            {
                case "lbDireciona":
                    ;

                    var dia = (e.Item.FindControl("lbDireciona") as LinkButton).CommandArgument;
                    Response.Redirect("Visitas_Detalhe.aspx?id=" + id + "&dia=" + dia);
                    break;
            }

        }
    }
}
