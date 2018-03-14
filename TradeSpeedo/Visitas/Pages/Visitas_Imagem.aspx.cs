using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using TradeSpeedo.Model;

namespace TradeSpeedo.Visitas.Pages
{
    public partial class Visitas_Imagem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var conexao = Session["conexao"].ToString();

            if (!Page.IsPostBack)
            {
                var idVisita = Request.QueryString["IdVisita"];
                var idVisitaDetalhe = Request.QueryString["IdVisitaDetalhe"];
                var dia = Request.QueryString["Dia"];
                var load = new Visita_Imagem(conexao);

                for (int i = 0; i <= 9; i++)

                {
                    string imagepreview = "imagepreview" + (i + 1).ToString();

                    var valida = load.ExisteImagem(Convert.ToInt32(idVisita), Convert.ToInt32(idVisitaDetalhe), Convert.ToInt32(dia), imagepreview);


                    if (valida != null)
                    {
                        var div = (HtmlControl)dMain.FindControl(imagepreview);
                        div.Style["background-image"] = Page.ResolveUrl(".." + "/Upload/" + valida);
                    }
                }
            }
        }

        private string SubirImagem(int imagemupload, int id_visita, int id_visita_detalhe)
        {
            HttpPostedFile imagem = Request.Files[imagemupload];
            var nomeimagem = "";

            if (imagem != null && imagem.ContentLength > 0)
            {
                nomeimagem = imagem.FileName;
                imagem.SaveAs(Server.MapPath(Path.Combine("../Upload", (nomeimagem)))); //OffLine         
            }
            return nomeimagem;
        }

        private void SalvaImagem(int visita, int idVisitaDet, int Dia, string Imagem, string Sequencia, string conexao)
        {
            var imagem = new Visita_Imagem(conexao)
            {
                Id_Visita = visita,
                Id_Visita_Detalhe = idVisitaDet,
                Dia = Dia,
                imagem = Imagem,
                Sequencia = Sequencia

            };

            imagem.Salva();

        }

        private void AlteraImagem(int visita, int idVisitaDet, int Dia, string Imagem, string Sequencia, string conexao)
        {
            var imagem = new Visita_Imagem(conexao)
            {
                Id_Visita = visita,
                Id_Visita_Detalhe = idVisitaDet,
                Dia = Dia,
                imagem = Imagem,
                Sequencia = Sequencia
            };

            imagem.Altera();

        }

        public string strScript = "";


        protected void BtnSalvar_Click(object sender, EventArgs e)
        {
            var conexao = Session["conexao"].ToString();

            var idVisita = Request.QueryString["IdVisita"];
            var idVisitaDetalhe = Request.QueryString["IdVisitaDetalhe"];
            var dia = Request.QueryString["Dia"];
            var load = new Visita_Imagem(conexao);

            for (int i = 0; i <= 9; i++)

            {
                string imagepreview = "imagepreview" + (i + 1).ToString();
                var div = (HtmlControl)dMain.FindControl(imagepreview);
                var urlNova = "urlNova" + i.ToString();

                var imageupload = "imageupload" + i.ToString();

                urlNova = SubirImagem(Convert.ToInt32(i.ToString()), Convert.ToInt32(idVisita), Convert.ToInt32(idVisitaDetalhe));

                if (urlNova != "")
                {
                    var urlVelha = load.ExisteImagem(Convert.ToInt32(idVisita), Convert.ToInt32(idVisitaDetalhe), Convert.ToInt32(dia), imagepreview);

                    if (urlNova != "" && urlVelha != null)
                    {
                        if (urlNova != urlVelha)
                        {
                            var arquivo = Server.MapPath(Path.Combine("../Upload", (urlVelha)));
                            if (File.Exists(arquivo))
                                File.Delete(arquivo);
                        }
                        AlteraImagem(Convert.ToInt32(idVisita), Convert.ToInt32(idVisitaDetalhe), Convert.ToInt32(dia), urlNova, imagepreview, conexao);
                        div.Style["background-image"] = Page.ResolveUrl(".." + "/Upload/" + urlNova);
                    }
                    else
                    {
                        SalvaImagem(Convert.ToInt32(idVisita), Convert.ToInt32(idVisitaDetalhe), Convert.ToInt32(dia), urlNova, imagepreview, conexao);
                        div.Style["background-image"] = Page.ResolveUrl(".." + "/Upload/" + urlNova);
                    }
                }
            }

            Response.Redirect("Visitas_Capa.aspx?id=" + idVisita);

        }
    }
}

