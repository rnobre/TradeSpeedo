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

namespace TradeSpeedo.Pages
{
    public partial class Index : System.Web.UI.Page
    {
        string conn = ConfigurationManager.ConnectionStrings["SQL_Intranet"].ConnectionString;
        string consulta;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        
        public string RetornaUsuarios()
        {

            consulta = "SELECT " +
                        "LTRIM(RTRIM(CLIFOR)) " +
                        "LTRIM(RTRIM(CLIENTE)) " +
                        "LTRIM(RTRIM(CNPJ)) " +
                        "LTRIM(RTRIM(REPRESENTANTE)) " +
                        "FROM TRADE_CLIENTE ";            
            var conexao = new SqlConnection(conn);
            SqlCommand comando = new SqlCommand(consulta, conexao);
            SqlDataReader dr = null;

            var usuarios = new StringBuilder();


            try
            {
                conexao.Open();
                dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine(dr.GetString(1));

                    usuarios.Append("{");
                    usuarios.AppendLine(" 'clienteatacado' : '" + dr["CLIENTE_ATACADO"].ToString() + "', ");
                    usuarios.AppendLine(" 'clifor' : '" + dr["CLIFOR"].ToString() + "', ");
                    usuarios.Append("},");
                }

                dr.Close();
                return usuarios.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro - " + ex.Message);
            }
            finally
            {
                conexao.Close();
            }

            return "";


        }

        
    }
}