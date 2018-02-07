using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TradeSpeedo.Model;

namespace TradeSpeedo.Visitas.Pages
{
    public partial class Visitas_Capa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BtnAltera.Visible = false;
            var conexao = Session["conexao"].ToString();

            if (!Page.IsPostBack)
            {
                var valor = Request.QueryString["ID"];
                var load = new Visita_Capa(conexao);
                load.Carrega(Convert.ToInt32(valor)); 

                if(load.ID != 0)
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
            var conexao = Session["conexao"].ToString();

            SalvaCapa(txtVisita.Text, txtPeriodo.Text, txtRepre.Text, txtRegiao.Text, txObj.Value, conexao);
            strScript = "alert('Informações salvas com sucesso.');";

            var recupera = new Visita_Capa(conexao);
            recupera.IdRec();
            var valida = new Visita_Capa(conexao);
            valida.Carrega(recupera.ID);

            if(valida.ID == 0)
            {
                Response.Redirect("Visitas_Detalhe.aspx?id=" + recupera.ID);
            }
            else
            {
                Response.Redirect("Visitas_Detalhe.aspx?id=" + valida.ID);
            }
            
        }

        protected void BtnAltera_Click(object sender, EventArgs e)
        {


        }
    }
}