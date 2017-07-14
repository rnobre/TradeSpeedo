using System.Web;
using System.Data.SqlClient;
using System.Text;
using System.IO;

namespace TradeSpeedo.Utils
{
    public class Relatorio
    {
        private SqlConnection _conexao;


        public Relatorio(string stringConexao)
        {
            _conexao = new SqlConnection(stringConexao);

        }        
        public string RetornaRelatorio()
        {
            _conexao.Open();
            
            var sql = "SELECT " +
                         "D.REPRESENTANTE " +
                         ",A.COD_CLIFOR " +
                         ",D.CLIENTE " +
                         ",A.CNPJ " +
                         ",CASE WHEN A.URL <> '' THEN A.URL ELSE 'Image/Camera_box.png' END as URL" + 
                         ",B.DESCRICAO as Tipo " +
                         ",C.DESCRICAO as Classif " +
                         "FROM TRADE_IMAGEM as A " +
                         "JOIN TRADE_TIPO_EXPOSICAO as B ON A.ID_TIPO_EXPOSICAO = B.ID_TIPO " +
                         "JOIN TRADE_CLASSIFICACAO C ON A.ID_CLASSIFICACAO = C.ID_CLASSIFICACAO " +
                         "JOIN TRADE_CLIENTE D ON A.COD_CLIFOR = D.CLIFOR COLLATE SQL_LATIN1_GENERAL_CP1_CI_AS";
            var comando = new SqlCommand(sql, _conexao);
            SqlDataReader dr = null;

            var relatorio = new StringBuilder();




            dr = comando.ExecuteReader();
            relatorio.Append("<table cellpadding = '0' cellspacing ='0' border = '1' width = '500px' style= 'border - width:1px; border-style:solid; '>");
            relatorio.Append("<tr style='font-weight:bold;'><td align = 'center' style='color:#FFFFFF; font-weight: bold;background-color:#D2232A;'>Representante</td>");
            relatorio.Append("<td align = 'center' style='color:#FFFFFF; font-weight: bold; background-color:#D2232A;'>Clifor</td>");
            relatorio.Append("<td align = 'center' style='color:#FFFFFF; font-weight: bold; background-color:#D2232A;'>Cliente</td>");
            relatorio.Append("<td align = 'center' style='color:#FFFFFF; font-weight: bold; background-color:#D2232A;'>Foto</td>");
            relatorio.Append("<td align = 'center' style='color:#FFFFFF; font-weight: bold; background-color:#D2232A;'>Tipo</td>");
            relatorio.Append("<td align = 'center' style='color:#FFFFFF; font-weight: bold; background-color:#D2232A;'>Classifica&ccedil;&atilde;o</td></tr>");


            int clinha = 0;
            var color = "";
            while (dr.Read())
            {
                if (clinha % 2 == 0)
                {
                    color = " style='background-color:#CCCCCC' ";
                }
                else
                {
                    color = "";
                }
                clinha++;
                relatorio.AppendLine("<tr align = 'center'>");
                relatorio.AppendLine("<td height='60' " + color + ">" + dr["REPRESENTANTE"].ToString() + "</td>");
                relatorio.AppendLine("<td height='60' " + color + ">" + dr["COD_CLIFOR"].ToString() + "</td>");
                relatorio.AppendLine("<td height='60' " + color + ">" + dr["CLIENTE"].ToString() + "</td>");
                relatorio.AppendLine("<td width='60' height='60' " + color + "><img align = 'middle' border'0' width='60' height='59' style='margin: 2px; padding: 2; ' src='http://sistematrade.com.br/Uploads/" + dr["URL"].ToString() + "'" + "/></td>");
                relatorio.AppendLine("<td height='60' " + color + ">" + dr["Tipo"].ToString() + "</td>");
                relatorio.AppendLine("<td height='60' " + color + ">" + dr["Classif"].ToString() + "</td></tr>");
            }
            relatorio.AppendLine("</table>");
            dr.Close();
            _conexao.Close();
            return relatorio.ToString();
        }

        public string RetornaRelatorio(string repre)
        {
            _conexao.Open();
            var sql = "SELECT " +
                         "D.REPRESENTANTE " +
                         ",A.COD_CLIFOR " +
                         ",D.CLIENTE " +
                         ",A.CNPJ " +
                         ",CASE WHEN A.URL <> '' THEN A.URL ELSE 'Image/Camera_box.png' END as URL" +
                         ",B.DESCRICAO as Tipo " +
                         ",C.DESCRICAO as Classif " +
                         "FROM TRADE_IMAGEM as A " +
                         "JOIN TRADE_TIPO_EXPOSICAO as B ON A.ID_TIPO_EXPOSICAO = B.ID_TIPO " +
                         "JOIN TRADE_CLASSIFICACAO C ON A.ID_CLASSIFICACAO = C.ID_CLASSIFICACAO " +
                         "JOIN TRADE_CLIENTE D ON A.COD_CLIFOR = D.CLIFOR COLLATE SQL_LATIN1_GENERAL_CP1_CI_AS " +
                         "WHERE D.REPRESENTANTE ='" + repre + "'";

            var comando = new SqlCommand(sql, _conexao);
            SqlDataReader dr = null;

            var relatorio = new StringBuilder();




            dr = comando.ExecuteReader();
            relatorio.Append("<table cellpadding = '0' cellspacing ='0' border = '1' width = '500px' style= 'border - width:1px; border-style:solid; '>");
            relatorio.Append("<tr style='font-weight:bold;'><td align = 'center' style='color:#FFFFFF; font-weight: bold;background-color:#D2232A;'>Representante</td>");
            relatorio.Append("<td align = 'center' style='color:#FFFFFF; font-weight: bold; background-color:#D2232A;'>Clifor</td>");
            relatorio.Append("<td align = 'center' style='color:#FFFFFF; font-weight: bold; background-color:#D2232A;'>Cliente</td>");
            relatorio.Append("<td align = 'center' style='color:#FFFFFF; font-weight: bold; background-color:#D2232A;'>Foto</td>");
            relatorio.Append("<td align = 'center' style='color:#FFFFFF; font-weight: bold; background-color:#D2232A;'>Tipo</td>");
            relatorio.Append("<td align = 'center' style='color:#FFFFFF; font-weight: bold; background-color:#D2232A;'>Classifica&ccedil;&atilde;o</td></tr>");


            int clinha = 0;
            var color = "";
            while (dr.Read())
            {
                if (clinha % 2 == 0)
                {
                    color = " style='background-color:#CCCCCC' ";
                }
                else
                {
                    color = "";
                }
                clinha++;
                relatorio.AppendLine("<tr align = 'center'>");
                relatorio.AppendLine("<td height='60' " + color + ">" + dr["REPRESENTANTE"].ToString() + "</td>");
                relatorio.AppendLine("<td height='60' " + color + ">" + dr["COD_CLIFOR"].ToString() + "</td>");
                relatorio.AppendLine("<td height='60' " + color + ">" + dr["CLIENTE"].ToString() + "</td>");
                relatorio.AppendLine("<td width='60' height='60' " + color + "><img align = 'middle' border'0' width='60' height='59' style='margin: 2px; padding: 2; ' src='http://sistematrade.com.br/Uploads/" + dr["URL"].ToString() + "'" + "/></td>");
                relatorio.AppendLine("<td height='60' " + color + ">" + dr["Tipo"].ToString() + "</td>");
                relatorio.AppendLine("<td height='60' " + color + ">" + dr["Classif"].ToString() + "</td></tr>");
            }
            relatorio.AppendLine("</table>");
            dr.Close();
            _conexao.Close();
            return relatorio.ToString();
        }
    }
}