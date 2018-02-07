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
    public partial class Visitas_Imagem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var conexao = Session["conexao"].ToString();

            if (!Page.IsPostBack)
            {
                //imagepreview1.Style["background-image"] = Page.ResolveUrl(".." + "/Upload/" + "cego.jpg");
                //imagepreview1.Style["background-size"] = "contain";
            }



        }

        //public string PegaImagem(string imagemupload, int id_visita, int id_visita_detalhe)
        //{       

        //    HttpPostedFile imagem = Request.Files[imagemupload];
        //    string nomeimagem = "";

        //    if(imagem != null && imagem.ContentLength > 0)
        //    {
        //        string extimage = Path.GetExtension(imagem.FileName).ToLower();
        //        nomeimagem = imagemupload + '_' + extimage;
        //        imagem.SaveAs(Server.MapPath(Path.Combine("/Upload", (nomeimagem))));
        //    }
        //    return nomeimagem;
        //}


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

        private void SalvaImagem(int visita, int idVisitaDet, string Imagem, string conexao)
        {
            var imagem = new Visita_Imagem(conexao)
            {
                Id_Visita = visita,
                Id_Visita_Detalhe = idVisitaDet,
                imagem = Imagem
            };

            imagem.Salva();

        }

        public string strScript = "";
      

        protected void BtnSalvar_Click(object sender, EventArgs e)
        {
            var conexao = Session["conexao"].ToString();

            var idvisita = new Visita_Imagem(conexao);
            idvisita.idVisita();
            var idvisitadet = new Visita_Imagem(conexao);
            idvisitadet.idVisitaDetalhe();
            var load = new Visita_Imagem(conexao);
            load.Carrega(idvisita.ID, idvisitadet.ID);
            


            for (int i = 0; i <= 9; i++)
                
                {
               
                
                    string imagepreview = "imagepreview" + (i+1).ToString();
                    var div = (HtmlControl)dMain.FindControl(imagepreview);
                    var urlNova = "urlNova" + i.ToString();
                    var urlVelha = "urlVelha" + i.ToString();
                    var imageupload = "imageupload" + i.ToString();

                    urlNova = SubirImagem(Convert.ToInt32(i.ToString()), idvisita.ID, idvisitadet.ID);

                    if (urlNova != "")
                    {

                        urlVelha = load.imagem;

                        if (urlNova != "" && urlVelha != null)
                        {
                            var arquivo = Server.MapPath(Path.Combine("../Upload", (urlVelha)));
                            if (File.Exists(arquivo))
                                File.Delete(arquivo);
                        }

                        SalvaImagem(idvisita.ID, idvisitadet.ID, urlNova, conexao);
                        div.Style["background-image"] = Page.ResolveUrl(".." + "/Upload/" + urlNova);

                    }
                }

            strScript = "alert('Dia salvo com sucesso.');";

            Response.Redirect("Visitas_Capa.aspx");

        }
        }
    }

