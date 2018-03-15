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
                load.

                for (int i = 0; i <= 6; i++)

                {
                    string imagepreview = "imagepreview" + (i + 1).ToString();

                    var valida = load.ExisteImagem(Convert.ToInt32(idVisita), imagepreview);


                    if (valida != null)
                    {
                        var div = (HtmlControl)dMain.FindControl(imagepreview);
                        div.Style["background-image"] = Page.ResolveUrl(".." + "/Upload_Conclusao/" + valida);
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

        private void Salvar(int id_visita, string conclusao, string imagem, string legenda, string sequencia, string conexao)
        {
            var a = new Visita_Conclusao(conexao)
            {
                IdVisita = id_visita,
                Conclusao = conclusao,
                Imagem = imagem,
                Legenda = legenda,
                sequencia = sequencia
            };

            a.Salva();

        }

        private void Alterar(int id_visita, string conclusao, string imagem, string legenda, string sequencia, string conexao)
        {
            var a = new Visita_Conclusao(conexao)
            {
                IdVisita = id_visita,
                Conclusao = conclusao,
                Imagem = imagem,
                Legenda = legenda,
                sequencia = sequencia
            };

            a.Altera();
        }

        protected void BtnSalvar_Click(object sender, EventArgs e)
        {
            var conexao = Session["conexao"].ToString();

            var idVisita = Request.QueryString["IdVisita"];
            var load = new Visita_Conclusao(conexao);

            for (int i = 0; i <= 6; i++)

            {
                string imagepreview = "imagepreview" + (i + 1).ToString();
                var div = (HtmlControl)dMain.FindControl(imagepreview);
                var urlNova = "urlNova" + i.ToString();

                var imageupload = "imageupload" + i.ToString();
                var legenda = "txLegenda" + i.ToString();

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

                        Alterar(Convert.ToInt32(idVisita), txConclusao.InnerText, urlNova, legenda, imagepreview, conexao);
                        div.Style["background-image"] = Page.ResolveUrl(".." + "/Upload_Conclusao/" + urlNova);
                    }
                    else
                    {
                        Salvar(Convert.ToInt32(idVisita), txConclusao.InnerText, urlNova, legenda, imagepreview, conexao);
                        div.Style["background-image"] = Page.ResolveUrl(".." + "/Upload_Conclusao/" + urlNova);
                    }
                }
            }

            Response.Redirect("Visitas_Capa.aspx?id=" + idVisita);

        }
    }
}