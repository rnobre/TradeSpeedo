using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using TradeSpeedo.Model;

namespace TradeSpeedo.Visitas.Pages
{
    public partial class Visitas_Conclusao : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var conexao = Session["conexao"].ToString();

            if (!Page.IsPostBack)
            {
                var idVisita = Request.QueryString["IdVisita"];
                var load = new Visita_Conclusao(conexao);
                var valida = new Visita_Conclusao(conexao);
                valida.Valida(Convert.ToInt32(idVisita));

                if (valida.ID != 0)
                {
                    for (int i = 0; i <= 6; i++)

                    {
                        string imagepreview = "imagepreview" + (i + 1).ToString();
                        var legenda = "txLegenda" + (i + 1).ToString();
                        TextBox leg = dMain.FindControl(legenda) as TextBox;

                        var ValidaImagem = load.ExisteImagem(Convert.ToInt32(idVisita), imagepreview);


                        if (ValidaImagem != null)
                        {
                            load.CarregaLoad(Convert.ToInt32(idVisita), imagepreview);
                            var div = (HtmlControl)dMain.FindControl(imagepreview);
                            div.Style["background-image"] = Page.ResolveUrl(".." + "/Upload_Conclusao/" + ValidaImagem);
                            txConclusao.InnerText = load.Conclusao;
                            leg.Text = load.Legenda;
                        }

                    }
                }
            }
        }

        private string SubirImagem(int imagemupload, int id_visita)
        {
            HttpPostedFile imagem = Request.Files[imagemupload];
            var nomeimagem = "";

            if (imagem != null && imagem.ContentLength > 0)
            {
                nomeimagem = imagem.FileName;
                imagem.SaveAs(Server.MapPath(Path.Combine("../Upload_Conclusao", (nomeimagem)))); //OffLine         
            }
            return nomeimagem;
        }

        private void SalvaImagem(int id_visita, int idconclusao, string imagem, string legenda, string sequencia, string conexao)
        {
            var a = new Visita_Conclusao(conexao)
            {
                IdVisita = id_visita,
                IdVisitaConclusao = idconclusao,
                Imagem = imagem,
                Legenda = legenda,
                sequencia = sequencia
            };

            a.SalvaImagem();

        }
        private void SalvaConclusao(int id_visita, string conclusao, string conexao)
        {
            var a = new Visita_Conclusao(conexao)
            {
                IdVisita = id_visita,
                Conclusao = conclusao,
            };

            a.SalvaConclusao();

        }

        private void AlterarImagem(int id_visita, int idconclusao, string imagem, string legenda, string sequencia, string conexao)
        {
            var a = new Visita_Conclusao(conexao)
            {
                IdVisita = id_visita,
                IdVisitaConclusao = idconclusao,
                Imagem = imagem,
                Legenda = legenda,
                sequencia = sequencia
            };

            a.AlteraImagem();
        }

        private void AlterarConclusao(int id_visita, string conclusao, string conexao)
        {
            var a = new Visita_Conclusao(conexao)
            {
                IdVisita = id_visita,
                Conclusao = conclusao,
            };

            a.AlteraConclusao();
        }

        protected void BtnSalvar_Click(object sender, EventArgs e)
        {
            var conexao = Session["conexao"].ToString();

            var idVisita = Request.QueryString["IdVisita"];
            var load = new Visita_Conclusao(conexao);


            for (int i = 0; i <= 6; i++)

            {
                string imagepreview = "imagepreview" + (i + 1).ToString();
                var legenda = "txLegenda" + (i + 1).ToString();

                var div = (HtmlControl)dMain.FindControl(imagepreview);

                TextBox leg = dMain.FindControl(legenda) as TextBox;

                var urlNova = "urlNova" + (i + 1).ToString();

                var imageupload = "imageupload" + (i + 1).ToString();


                urlNova = SubirImagem(Convert.ToInt32(i.ToString()), Convert.ToInt32(idVisita));

                if (urlNova != "")
                {
                    var urlVelha = load.ExisteImagem(Convert.ToInt32(idVisita), imagepreview);

                    if (urlNova != "" && urlVelha != null)
                    {
                        if (urlNova != urlVelha)
                        {
                            var arquivo = Server.MapPath(Path.Combine("../Upload_Conclusao", (urlVelha)));
                            if (File.Exists(arquivo))
                                File.Delete(arquivo);
                        }
                        var valida = new Visita_Conclusao(conexao);
                        valida.Carrega(Convert.ToInt32(idVisita));

                        AlterarConclusao(Convert.ToInt32(idVisita), txConclusao.InnerText, conexao);                        
                        AlterarImagem(Convert.ToInt32(idVisita), Convert.ToInt32(valida.ID), urlNova, leg.Text, imagepreview, conexao);
                        div.Style["background-image"] = Page.ResolveUrl(".." + "/Upload_Conclusao/" + urlNova);
                    }
                    else
                    {
                        var Validaa = new Visita_Conclusao(conexao);
                        Validaa.Carrega(Convert.ToInt32(idVisita));

                        if(Validaa.ID != 0)
                        {
                            SalvaImagem(Convert.ToInt32(idVisita), Convert.ToInt32(Validaa.ID), urlNova, leg.Text, imagepreview, conexao);
                            div.Style["background-image"] = Page.ResolveUrl(".." + "/Upload_Conclusao/" + urlNova);
                        }
                        else
                        {
                            SalvaConclusao(Convert.ToInt32(idVisita), txConclusao.InnerText, conexao);
                            var Validab = new Visita_Conclusao(conexao);
                            Validab.Carrega(Convert.ToInt32(idVisita));
                            SalvaImagem(Convert.ToInt32(idVisita), Convert.ToInt32(Validab.ID), urlNova, leg.Text, imagepreview, conexao);
                            div.Style["background-image"] = Page.ResolveUrl(".." + "/Upload_Conclusao/" + urlNova);
                        }
                        
                    }
                }
            }

            Response.Redirect("Visitas_Capa.aspx?id=" + idVisita);

        }
    }
}