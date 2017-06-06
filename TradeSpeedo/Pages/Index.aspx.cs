using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using TradeSpeedo.Model;

namespace TradeSpeedo.Pages
{
    public partial class Index : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                var conexao = Session["conexao"].ToString();

                var tipo = new Tipo(conexao);
                var tipos = tipo.Lista();

                DDTipo1.DataSource = tipos;
                DDTipo1.DataBind();
                DDTipo1.Items.Insert(0, new ListItem("Tipo de Exposição", ""));
                DDTipo2.DataSource = tipos;
                DDTipo2.DataBind();
                DDTipo2.Items.Insert(0, new ListItem("Tipo de Exposição", ""));
                DDTipo3.DataSource = tipos;
                DDTipo3.DataBind();
                DDTipo3.Items.Insert(0, new ListItem("Tipo de Exposição", ""));
                DDTipo4.DataSource = tipos;
                DDTipo4.DataBind();
                DDTipo4.Items.Insert(0, new ListItem("Tipo de Exposição", ""));
                DDTipo5.DataSource = tipos;
                DDTipo5.DataBind();
                DDTipo5.Items.Insert(0, new ListItem("Tipo de Exposição", ""));

                var classif = new Classificacao(conexao);
                var classifs = classif.Lista();

                DDClassif1.DataSource = classifs;
                DDClassif1.DataBind();
                DDClassif1.Items.Insert(0, new ListItem("Classif. da Exposição", ""));
                DDClassif2.DataSource = classifs;
                DDClassif2.DataBind();
                DDClassif2.Items.Insert(0, new ListItem("Classif. da Exposição", ""));
                DDClassif3.DataSource = classifs;
                DDClassif3.DataBind();
                DDClassif3.Items.Insert(0, new ListItem("Classif. da Exposição", ""));
                DDClassif4.DataSource = classifs;
                DDClassif4.DataBind();
                DDClassif4.Items.Insert(0, new ListItem("Classif. da Exposição", ""));
                DDClassif5.DataSource = classifs;
                DDClassif5.DataBind();
                DDClassif5.Items.Insert(0, new ListItem("Classif. da Exposição", ""));

                var cliente = new Cliente(conexao);
                var usuario = (Usuario)Session["usuario"];

                DDPesquisa.DataSource = cliente.Lista(usuario.Clifor);
                DDPesquisa.DataBind();
                DDPesquisa.Items.Insert(0, new ListItem("Selecione um cliente", ""));

                Luser.Text = usuario.Nome.ToString();

            }


        }

        protected void BtnSair_Click(object sender, EventArgs e)
        {
            Session["conexao"] = null;
            Response.Redirect("/Login.aspx");
        }

        protected void BtnSalvar_Click(object sender, EventArgs e)
        {
            var conexao = Session["conexao"].ToString();
            var clifor = DDPesquisa.SelectedValue;

            if (DDClassif1.SelectedValue != "" && DDTipo1.SelectedValue != "")
            {
                var imagem1 = new Imagem(conexao)
                {
                    Clifor = clifor,
                    Sequencia = 1,
                    ClassificacaoID = Convert.ToInt32(DDClassif1.SelectedValue),
                    TipoExposicaoID = Convert.ToInt32(DDTipo1.SelectedValue)
                };
                imagem1.Salvar();
            }


            if (DDClassif2.SelectedValue != "" && DDTipo2.SelectedValue != "")
            {
                var imagem2 = new Imagem(conexao)
                {
                    Clifor = clifor,
                    Sequencia = 2,
                    ClassificacaoID = Convert.ToInt32(DDClassif2.SelectedValue),
                    TipoExposicaoID = Convert.ToInt32(DDTipo2.SelectedValue)
                };
                imagem2.Salvar();
            }

            if (DDClassif3.SelectedValue != "" && DDTipo3.SelectedValue != "")
            {
                var imagem3 = new Imagem(conexao)
                {
                    Clifor = clifor,
                    Sequencia = 3,
                    ClassificacaoID = Convert.ToInt32(DDClassif3.SelectedValue),
                    TipoExposicaoID = Convert.ToInt32(DDTipo3.SelectedValue)
                };
                imagem3.Salvar();
            }

            if (DDClassif4.SelectedValue != "" && DDTipo4.SelectedValue != "")
            {
                var imagem4 = new Imagem(conexao)
                {
                    Clifor = clifor,
                    Sequencia = 4,
                    ClassificacaoID = Convert.ToInt32(DDClassif4.SelectedValue),
                    TipoExposicaoID = Convert.ToInt32(DDTipo4.SelectedValue)
                };
                imagem4.Salvar();
            }

            if (DDClassif5.SelectedValue != "" && DDTipo5.SelectedValue != "")
            {
                var imagem5 = new Imagem(conexao)
                {
                    Clifor = clifor,
                    Sequencia = 5,
                    ClassificacaoID = Convert.ToInt32(DDClassif5.SelectedValue),
                    TipoExposicaoID = Convert.ToInt32(DDTipo5.SelectedValue)
                };
                imagem5.Salvar();
            }

        }

        protected void DDPesquisa_SelectedIndexChanged(object sender, EventArgs e)
        {
            var conexao = Session["conexao"].ToString();

            var imagem1 = new Imagem(conexao);
            imagem1.Carregar(DDPesquisa.SelectedValue, 1);


            if (imagem1.ID != 0)
            {
                DDTipo1.SelectedValue = imagem1.TipoExposicaoID.ToString();
                DDClassif1.SelectedValue = imagem1.ClassificacaoID.ToString();

            }
            else // não encontrou imagem pro cliente
            {
                DDTipo1.SelectedIndex = 0;
                DDClassif1.SelectedIndex = 0;

            }

            var imagem2 = new Imagem(conexao);
            imagem2.Carregar(DDPesquisa.SelectedValue, 2);

            if (imagem2.ID != 0)
            {
                DDTipo2.SelectedValue = imagem2.TipoExposicaoID.ToString();
                DDClassif2.SelectedValue = imagem2.ClassificacaoID.ToString();
            }
            else
            {
                DDTipo2.SelectedIndex = 0;
                DDClassif2.SelectedIndex = 0;
            }

            var imagem3 = new Imagem(conexao);
            imagem3.Carregar(DDPesquisa.SelectedValue, 3);

            if (imagem3.ID != 0)
            {
                DDTipo3.SelectedValue = imagem3.TipoExposicaoID.ToString();
                DDClassif3.SelectedValue = imagem3.ClassificacaoID.ToString();
            }
            else
            {
                DDTipo3.SelectedIndex = 0;
                DDClassif3.SelectedIndex = 0;
            }

            var imagem4 = new Imagem(conexao);
            imagem4.Carregar(DDPesquisa.SelectedValue, 4);

            if (imagem4.ID != 0)
            {
                DDTipo4.SelectedValue = imagem4.TipoExposicaoID.ToString();
                DDClassif4.SelectedValue = imagem4.ClassificacaoID.ToString();
            }
            else
            {
                DDTipo4.SelectedIndex = 0;
                DDClassif4.SelectedIndex = 0;
            }

            var imagem5 = new Imagem(conexao);
            imagem5.Carregar(DDPesquisa.SelectedValue, 5);

            if (imagem5.ID != 0)
            {
                DDTipo5.SelectedValue = imagem5.TipoExposicaoID.ToString();
                DDClassif5.SelectedValue = imagem5.ClassificacaoID.ToString();
            }
            else
            {
                DDTipo5.SelectedIndex = 0;
                DDClassif5.SelectedIndex = 0;
            }


        }
    }


}
