using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace TradeSpeedo.Model
{
    public class Relatorio
    {
        private SqlConnection _conexao;

        public string Representante { get; set; }

        public string Clifor { get; set; }

        public string Cliente { get; set; }

        public long Cnpj { get; set; }

        public string Url { get; set; }

        public string Tipo { get; set; }

        public string Classif { get; set; }

        private string _stringconexao { get; set; }
        public Relatorio(string stringConexao)
        {
            _conexao = new SqlConnection(stringConexao);
            _stringconexao = stringConexao;
        }

        public List<Relatorio> Lista()
        {
            var Relatorios = new List<Relatorio>();

            _conexao.Open();

            var sql = $"SELECT D.REPRESENTANTE, A.COD_CLIFOR, D.CLIENTE, A.CNPJ, A.URL, B.DESCRICAO, C.DESCRICAO " +
                        "FROM TRADE_IMAGEM A " +
                        "JOIN TRADE_TIPO_EXPOSICAO B ON A.ID_TIPO_EXPOSICAO = B.ID_TIPO " +
                        "JOIN TRADE_CLASSIFICACAO C ON A.ID_CLASSIFICACAO = C.ID_CLASSIFICACAO " +
                        "JOIN TRADE_CLIENTE D ON A.COD_CLIFOR = D.CLIFOR COLLATE SQL_LATIN1_GENERAL_CP1_CI_AS";
            var dr = new SqlCommand(sql, _conexao).ExecuteReader();

            while (dr.Read())
            {
                var rela = new Relatorio(_stringconexao);

                rela.Representante = dr["D.REPRESENTANTE"].ToString();
                rela.Clifor = dr["A.COD_CLIFOR"].ToString();
                rela.Cliente = dr["D.CLIENTE"].ToString();
                rela.Cnpj = Convert.ToInt64(dr["CNPJ"].ToString());
                rela.Url = dr["A.URL"].ToString();
                rela.Tipo = dr["B.DESCRICAO"].ToString();
                rela.Classif = dr["C.DESCRICAO"].ToString();

                Relatorios.Add(rela);
            }

            _conexao.Close();

            return Relatorios;
        }
    }
}