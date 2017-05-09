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
        
        public string RetornaClientes()
        {

            consulta = "SELECT " +
                        "LTRIM(RTRIM(B.CLIENTE_ATACADO)) " +
                        "LTRIM(RTRIM(A.CLIFOR)) " +
                        "FROM[LINX_PRODUCAO].DBO.CADASTRO_CLI_FOR  A " +
                        "JOIN[LINX_PRODUCAO].DBO.CLIENTES_ATACADO B ON A.NOME_CLIFOR = B.CLIENTE_ATACADO AND A.CLIFOR = B.CLIFOR " +
                        "WHERE b.INATIVO = 0 " +
                        "and a.INDICA_CLIENTE = '1' " +
                        "and a.INDICA_FILIAL = '0' " +
                        "and a.INDICA_FORNECEDOR = '0' " +
                        "ORDER BY b.CLIFOR ";
            var conexao = new SqlConnection(conn);
            SqlCommand comando = new SqlCommand(consulta, conexao);
            SqlDataReader dr = null;

            var clientes = new StringBuilder();


            try
            {
                conexao.Open();
                dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine(dr.GetString(1));

                    clientes.Append("{");
                    clientes.AppendLine(" 'clienteatacado' : '" + dr["CLIENTE_ATACADO"].ToString() + "', ");
                    clientes.AppendLine(" 'clifor' : '" + dr["CLIFOR"].ToString() + "', ");
                    clientes.Append("},");
                }

                dr.Close();
                return clientes.ToString();
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