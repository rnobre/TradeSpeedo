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
using System.Security.AccessControl;


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

                // Preenche combos de tipos
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
                DDClassif1.Items.Insert(0, new ListItem("Classificação da Exposição", ""));
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

        protected void DDPesquisa_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregarCliente();
        }

        private void CarregarCliente()
        {
            var conexao = Session["conexao"].ToString();

            var imagem1 = new Imagem(conexao);
            imagem1.Carregar(DDPesquisa.SelectedValue, 1);


            if (imagem1.ID != 0)
            {
                DDTipo1.SelectedValue = imagem1.TipoExposicaoID.ToString();
                DDClassif1.SelectedValue = imagem1.ClassificacaoID.ToString();
                lbl1.Value = imagem1.ID.ToString();
                imagepreview1.Style["background-image"] = Page.ResolveUrl(".." + "/Uploads/" + imagem1.Url);
                imagepreview1.Style["background-size"] = "contain";
            }
            else
            {
                DDTipo1.SelectedIndex = 0;
                DDClassif1.SelectedIndex = 0;
                lbl1.Value = "0";
                imagepreview1.Style["background-image"] = Page.ResolveUrl(".." + "/Image/Camera_box.png");
                imagepreview1.Style["background-size"] = "238px 220px";



            }

            var imagem2 = new Imagem(conexao);
            imagem2.Carregar(DDPesquisa.SelectedValue, 2);

            if (imagem2.ID != 0)
            {
                DDTipo2.SelectedValue = imagem2.TipoExposicaoID.ToString();
                DDClassif2.SelectedValue = imagem2.ClassificacaoID.ToString();
                lbl2.Value = imagem2.ID.ToString();
                imagepreview2.Style["background-image"] = Page.ResolveUrl(".." + "/Uploads/" + imagem2.Url);
                imagepreview2.Style["background-size"] = "contain";
            }
            else
            {
                DDTipo2.SelectedIndex = 0;
                DDClassif2.SelectedIndex = 0;
                lbl2.Value = "0";
                imagepreview2.Style["background-image"] = Page.ResolveUrl(".." + "/Image/Camera_box.png");
                imagepreview2.Style["background-size"] = "238px 220px";
            }

            var imagem3 = new Imagem(conexao);
            imagem3.Carregar(DDPesquisa.SelectedValue, 3);

            if (imagem3.ID != 0)
            {
                DDTipo3.SelectedValue = imagem3.TipoExposicaoID.ToString();
                DDClassif3.SelectedValue = imagem3.ClassificacaoID.ToString();
                lbl3.Value = imagem3.ID.ToString();
                imagepreview3.Style["background-image"] = Page.ResolveUrl(".." + "/Uploads/" + imagem3.Url);
                imagepreview3.Style["background-size"] = "contain";
            }
            else
            {
                DDTipo3.SelectedIndex = 0;
                DDClassif3.SelectedIndex = 0;
                lbl3.Value = "0";
                imagepreview3.Style["background-image"] = Page.ResolveUrl(".." + "/Image/Camera_box.png");
                imagepreview3.Style["background-size"] = "238px 220px";
            }

            var imagem4 = new Imagem(conexao);
            imagem4.Carregar(DDPesquisa.SelectedValue, 4);

            if (imagem4.ID != 0)
            {
                DDTipo4.SelectedValue = imagem4.TipoExposicaoID.ToString();
                DDClassif4.SelectedValue = imagem4.ClassificacaoID.ToString();
                lbl4.Value = imagem4.ID.ToString();
                imagepreview4.Style["background-image"] = Page.ResolveUrl(".." + "/Uploads/" + imagem4.Url);
                imagepreview4.Style["background-size"] = "contain";
            }
            else
            {
                DDTipo4.SelectedIndex = 0;
                DDClassif4.SelectedIndex = 0;
                lbl4.Value = "0";
                imagepreview4.Style["background-image"] = Page.ResolveUrl(".." + "/Image/Camera_box.png");
                imagepreview4.Style["background-size"] = "238px 220px";
            }

            var imagem5 = new Imagem(conexao);
            imagem5.Carregar(DDPesquisa.SelectedValue, 5);

            if (imagem5.ID != 0)
            {
                DDTipo5.SelectedValue = imagem5.TipoExposicaoID.ToString();
                DDClassif5.SelectedValue = imagem5.ClassificacaoID.ToString();
                lbl5.Value = imagem5.ID.ToString();
                imagepreview5.Style["background-image"] = Page.ResolveUrl(".." + "/Uploads/" + imagem5.Url);
                imagepreview5.Style["background-size"] = "contain";
            }
            else
            {
                DDTipo5.SelectedIndex = 0;
                DDClassif5.SelectedIndex = 0;
                lbl5.Value = "0";
                imagepreview5.Style["background-image"] = Page.ResolveUrl(".." + "/Image/Camera_box.png");
                imagepreview5.Style["background-size"] = "238px 220px";
            }
        }

        private void SalvarImagem(int Id_img, DropDownList classificacao, DropDownList tipo, int sequencia, string clifor, string cnpj, string url, string conexao)
        {
            if (classificacao.SelectedValue != "" || tipo.SelectedValue != "")
            {
                var imagem = new Imagem(conexao)
                {
                    ID = Id_img,
                    Clifor = clifor,
                    Cnpj = cnpj,
                    Sequencia = sequencia,
                    Url = url,
                    ClassificacaoID = Convert.ToInt32(classificacao.SelectedValue),
                    TipoExposicaoID = Convert.ToInt32(tipo.SelectedValue)
                };
                imagem.Salvar();
            }
        }



        private string SubirImagem(string imagemupload, string sequencia, string clifor)
        {
            HttpPostedFile imagem = Request.Files[imagemupload];
            string nomeimagem = "";

            if (imagem != null && imagem.ContentLength > 0)
            {
                string extimagem = Path.GetExtension(imagem.FileName).ToLower();
                nomeimagem = clifor + '_' + sequencia /*+ extimagem*/;
                imagem.SaveAs(Server.MapPath(Path.Combine("~/Uploads", (nomeimagem))));
                //caminho = Server.MapPath(Path.Combine("~/Uploads", (nomeimagem)));
            }
            return nomeimagem;
        }

        private void ExcluirImagens(string conexao, string clifor)
        {
            var imagensDoCliente = new Imagem(conexao).Lista(clifor);
            
            foreach(var imagemDoCliente in imagensDoCliente)
            {
                File.Delete(Server.MapPath(Path.Combine("~/Uploads", (imagemDoCliente.Url))));
            }
        }

        protected void BtnSalvar_Click(object sender, EventArgs e)
        {
            var conexao = Session["conexao"].ToString();
            var clifor = DDPesquisa.SelectedValue;
            var cliente = new Cliente(conexao);
            cliente.Carregar(clifor);
            var cnpj = cliente.Cnpj;

            var imagem1 = new Imagem(conexao);
            imagem1.Carregar(Convert.ToInt32(lbl1.Value));
            var urlVelha1 = imagem1.Url;
            var imagem2 = new Imagem(conexao);
            imagem2.Carregar(Convert.ToInt32(lbl2.Value));
            var urlVelha2 = imagem2.Url;
            var imagem3 = new Imagem(conexao);
            imagem3.Carregar(Convert.ToInt32(lbl3.Value));
            var urlVelha3 = imagem3.Url;
            var imagem4 = new Imagem(conexao);
            imagem4.Carregar(Convert.ToInt32(lbl4.Value));
            var urlVelha4 = imagem4.Url;
            var imagem5= new Imagem(conexao);
            imagem5.Carregar(Convert.ToInt32(lbl5.Value));
            var urlVelha5 = imagem5.Url;


                        
            var urlNova1 = SubirImagem("imageupload1", "1", clifor);
            var urlNova2 = SubirImagem("imageupload2", "2", clifor);
            var urlNova3 = SubirImagem("imageupload3", "3", clifor);
            var urlNova4 = SubirImagem("imageupload4", "4", clifor);
            var urlNova5 = SubirImagem("imageupload5", "5", clifor);

            if(urlVelha1 != urlNova1 && urlVelha1 != null && urlNova1 == null)
            {
                File.Delete(Server.MapPath(Path.Combine("~/Uploads", (urlVelha1))));
                SalvarImagem(Convert.ToInt32(lbl1.Value), DDClassif1, DDTipo1, 1, clifor, Convert.ToString(cnpj), urlNova1, conexao);
            }
            else
            {
                SalvarImagem(Convert.ToInt32(lbl1.Value), DDClassif1, DDTipo1, 1, clifor, Convert.ToString(cnpj), urlNova1, conexao);
            }

            if (urlVelha2 != urlNova2 && urlVelha2 != null && urlNova2 == null)
            {
                File.Delete(Server.MapPath(Path.Combine("~/Uploads", (urlVelha2))));
                SalvarImagem(Convert.ToInt32(lbl2.Value), DDClassif2, DDTipo2, 2, clifor, Convert.ToString(cnpj), urlNova2, conexao);
            }
            else
            {
                SalvarImagem(Convert.ToInt32(lbl2.Value), DDClassif2, DDTipo2, 2, clifor, Convert.ToString(cnpj), urlNova2, conexao);
            }

            if (urlVelha3 != urlNova3 && urlVelha3 != null && urlNova3 == null)
            {
                File.Delete(Server.MapPath(Path.Combine("~/Uploads", (urlVelha3))));
                SalvarImagem(Convert.ToInt32(lbl3.Value), DDClassif3, DDTipo3, 3, clifor, Convert.ToString(cnpj), urlNova3, conexao);
            }
            else
            {
                SalvarImagem(Convert.ToInt32(lbl3.Value), DDClassif3, DDTipo3, 3, clifor, Convert.ToString(cnpj), urlNova3, conexao);
            }

            if (urlVelha4 != urlNova4 && urlVelha4 != null && urlNova4 == null)
            {
                File.Delete(Server.MapPath(Path.Combine("~/Uploads", (urlVelha4))));
                SalvarImagem(Convert.ToInt32(lbl4.Value), DDClassif4, DDTipo4, 4, clifor, Convert.ToString(cnpj), urlNova4, conexao);
            }
            else
            {
                SalvarImagem(Convert.ToInt32(lbl4.Value), DDClassif4, DDTipo4, 4, clifor, Convert.ToString(cnpj), urlNova4, conexao);
            }

            if (urlVelha5 != urlNova5 && urlVelha5 != null && urlNova5 == null)
            {
                File.Delete(Server.MapPath(Path.Combine("~/Uploads", (urlVelha5))));
                SalvarImagem(Convert.ToInt32(lbl5.Value), DDClassif5, DDTipo5, 5, clifor, Convert.ToString(cnpj), urlNova5, conexao);
            }
            else
            {
                SalvarImagem(Convert.ToInt32(lbl5.Value), DDClassif5, DDTipo5, 5, clifor, Convert.ToString(cnpj), urlNova5, conexao);
            }            

            CarregarCliente();
        }

    }

}



