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

            SalvaCapa(txtVisita.Text, txtPeriodo.Text , txtRepre.Text, txtRegiao.Text, txObj.Value, conexao);
            strScript = "alert('Informações salvas com sucesso.');";

        }

        protected void BtnAltera_Click(object sender, EventArgs e)
        {
            

        }
    }
}