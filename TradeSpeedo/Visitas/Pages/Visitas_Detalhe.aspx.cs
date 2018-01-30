using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TradeSpeedo.Model;

namespace TradeSpeedo.Visitas.Pages
{
    public partial class Visitas_Detalhe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BtnAltera.Visible = false;
            var conexao = Session["conexao"].ToString();
            var pesquisa = new Visita_Detalhe(conexao);
            if (!Page.IsPostBack)
            {


                ddCliente.DataSource = pesquisa.Lista();
                ddCliente.DataBind();
                ddCliente.Items.Insert(0, new ListItem("", ""));

                ddPerfil.DataSource = pesquisa.ListaPerfil();
                ddPerfil.DataBind();
                ddPerfil.Items.Insert(0, new ListItem("", ""));

                ddSortimento.DataSource = pesquisa.ListaSortimento();
                ddSortimento.DataBind();
                ddSortimento.Items.Insert(0, new ListItem("", ""));

                ddExpo.DataSource = pesquisa.ListaExpo();
                ddExpo.DataBind();
                ddExpo.Items.Insert(0, new ListItem("", ""));
            }

        }

        private void SalvaForm(int idVisita, string Dia, string Data, int Clifor, string Local, string comprador, int idPerfil, int idSort, int idExpo, string concorrente, string h1, string h2, string h3, string h4, string ht1, string ht2, string ht3, string ht4)
        {
            var conexao = Session["conexao"].ToString();

            var campo = new Visita_Detalhe(conexao)
            {
                ID_VISITA = idVisita,
                Dia = Dia,
                idClifor = Clifor,
                Local = Local,
                Comprador = comprador,
                Id_Perfil = idPerfil,
                Id_Sortimento = idSort,
                Id_Exposicao = idExpo,
                Concorrente = concorrente,
                H1 = h1,
                H2 = h2,
                H3 = h3,
                H4 = h4,
                Ht1 = ht1,
                Ht2 = ht2,
                Ht3 = ht3,
                Ht4 = ht4
            };

            campo.Salva();
        }

        public string strScript = "";

        protected void BtnSalvar_Click(object sender, EventArgs e)
        {
            var conexao = Session["conexao"].ToString();
            var valor = Request.QueryString["ID"];
            var idCliente = Convert.ToInt32(ddCliente.SelectedValue);

            SalvaForm(Convert.ToInt32(valor), txDia.Text, Convert.ToString(txData.Text), idCliente, txLocal.Text, txComprador.Text, Convert.ToInt32(ddPerfil.SelectedValue), Convert.ToInt32(ddSortimento.SelectedValue), Convert.ToInt32(ddExpo.SelectedValue), txConcorrentes.InnerText, txAno1.Text, txAno2.Text, txAno3.Text, txAno4.Text, txDin1.Text, txDin2.Text, txDin3.Text, txDin4.Text);
            strScript = "alert('Informações salvas com sucesso.');";

            var recupera = new Visita_Capa(conexao);
            recupera.IdRec();            
            Response.Redirect("Visitas_Imagem.aspx?id=" + recupera.ID);
        }
    }
}