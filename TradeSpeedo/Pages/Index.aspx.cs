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
using System.Runtime.InteropServices.ComTypes;
using System.IO;

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
                DDClassif1.Items.Insert(0, new ListItem("Classificação da Exposição"));
                DDClassif2.DataSource = classifs;
                DDClassif2.DataBind();
                DDClassif2.Items.Insert(0, new ListItem("Classificação da Exposição", ""));
                DDClassif3.DataSource = classifs;
                DDClassif3.DataBind();
                DDClassif3.Items.Insert(0, new ListItem("Classificação da Exposição", ""));
                DDClassif4.DataSource = classifs;
                DDClassif4.DataBind();
                DDClassif4.Items.Insert(0, new ListItem("Classificação da Exposição", ""));
                DDClassif5.DataSource = classifs;
                DDClassif5.DataBind();
                DDClassif5.Items.Insert(0, new ListItem("Classificação da Exposição", ""));

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

        private void SalvarImagem(DropDownList classificacao, DropDownList tipo, int sequencia, string conexao, string clifor)
        {
            if (classificacao.SelectedValue != "" || tipo.SelectedValue != "")
            {
                var imagem= new Imagem(conexao)
                {
                    Clifor = clifor,
                    Sequencia = sequencia,
                    ClassificacaoID = Convert.ToInt32(classificacao.SelectedValue),
                    TipoExposicaoID = Convert.ToInt32(tipo.SelectedValue)
                };
                imagem.Salvar();
            }
        }

        protected void BtnSalvar_Click(object sender, EventArgs e)
        {

            var conexao = Session["conexao"].ToString();
            var clifor = DDPesquisa.SelectedValue;
            var sequencia = new Imagem(conexao).Sequencia;
            var ID = new Imagem(conexao).ID;


            HttpPostedFile imagem1 = Request.Files["imageupload1"];

            if (imagem1 != null && imagem1.ContentLength > 0)
            {
                
                string extimagem = Path.GetExtension(imagem1.FileName).ToLower();
                string nomeimagem = clifor + '_' + sequencia + extimagem;
                
                imagem1.SaveAs(Server.MapPath(Path.Combine("~/Uploads", nomeimagem)));
            }

            HttpPostedFile imagem2 = Request.Files["imageupload2"];

            if (imagem2 != null && imagem2.ContentLength > 0)
            {
                string extimagem = Path.GetExtension(imagem2.FileName).ToLower();
                string nomeimagem = clifor + '_' + sequencia + extimagem;
                imagem2.SaveAs(Server.MapPath(Path.Combine("~/Uploads", (nomeimagem))));
            }

            HttpPostedFile imagem3 = Request.Files["imageupload3"];

            if (imagem3 != null && imagem3.ContentLength > 0)
            {

                string extimagem = Path.GetExtension(imagem3.FileName).ToLower();
                string nomeimagem = clifor + '_' + sequencia + extimagem;

                imagem3.SaveAs(Server.MapPath(Path.Combine("~/Uploads", nomeimagem)));
            }

            HttpPostedFile imagem4 = Request.Files["imageupload4"];

            if (imagem4 != null && imagem4.ContentLength > 0)
            {
                string extimagem = Path.GetExtension(imagem4.FileName).ToLower();
                string nomeimagem = clifor + '_' + sequencia + extimagem;
                imagem4.SaveAs(Server.MapPath(Path.Combine("~/Uploads", (nomeimagem))));
            }


            HttpPostedFile imagem5 = Request.Files["imageupload5"];

            if (imagem5 != null && imagem5.ContentLength > 0)
            {
                string extimagem = Path.GetExtension(imagem5.FileName).ToLower();
                string nomeimagem = clifor + '_' + sequencia + extimagem;
                imagem5.SaveAs(Server.MapPath(Path.Combine("~/Uploads", (nomeimagem))));
            }

            


            SalvarImagem(DDClassif1, DDTipo1, 1, conexao, clifor);
            SalvarImagem(DDClassif2, DDTipo2, 2, conexao, clifor);
            SalvarImagem(DDClassif3, DDTipo3, 3, conexao, clifor);
            SalvarImagem(DDClassif4, DDTipo4, 4, conexao, clifor);
            SalvarImagem(DDClassif5, DDTipo5, 5, conexao, clifor);       

     
            
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
                LblID1.InnerText = imagem1.ID.ToString();
            }
            else 
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
                LblID2.InnerText = imagem2.ID.ToString();
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
                LblID3.InnerText = imagem3.ID.ToString();
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
                LblID4.InnerText = imagem4.ID.ToString();
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
                LblID5.InnerText = imagem5.ID.ToString();
            }
            else
            {
                DDTipo5.SelectedIndex = 0;
                DDClassif5.SelectedIndex = 0;
            }
        }

       

    }

}



