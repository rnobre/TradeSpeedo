﻿using System;
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
                // Grava string de conexão em sessão
                Session["conexao"] = ConfigurationManager.ConnectionStrings["conexao"].ConnectionString;
            }


            {

                var conexao = Session["conexao"].ToString();
                

                var tipo = new Tipo(conexao);

                DDTipo1.DataSource = tipo.Lista();
                DDTipo1.DataTextField = "Descricao";
                DDTipo1.DataValueField = "ID";
                DDTipo1.DataBind();
                DDTipo2.DataSource = tipo.Lista();
                DDTipo2.DataTextField = "Descricao";
                DDTipo2.DataValueField = "ID";
                DDTipo2.DataBind();
                DDTipo3.DataSource = tipo.Lista();
                DDTipo3.DataTextField = "Descricao";
                DDTipo3.DataValueField = "ID";
                DDTipo3.DataBind();
                DDTipo4.DataSource = tipo.Lista();
                DDTipo4.DataTextField = "Descricao";
                DDTipo4.DataValueField = "ID";
                DDTipo4.DataBind();
                DDTipo5.DataSource = tipo.Lista();
                DDTipo5.DataTextField = "Descricao";
                DDTipo5.DataValueField = "ID";
                DDTipo5.DataBind();
            }

           
        }
                
    
        }

        
    }
