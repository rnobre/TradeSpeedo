using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;

namespace TradeSpeedo.Utils
{
    public class Visita_Relatorio
    {
        private SqlConnection _conexao;

        private string _stringconexao { get; set; }

        public int id { get; set; }

        public string visita { get; set; }

        public string representante { get; set; }

        public string periodo { get; set; }

        public string objetivo { get; set; }

        public int dia { get; set; }

        public DateTime data { get; set; }

        public string cliente { get; set; }

        public string local { get; set; }

        public string comprador { get; set; }

        public string perfil { get; set; }

        public string sortimento { get; set; }

        public string exposicao { get; set; }

        public string concorrente { get; set; }

        public string comentario { get; set; }

        public string h1 { get; set; }

        public string ht1 { get; set; }

        public string h2 { get; set; }

        public string ht2 { get; set; }

        public string h3 { get; set; }

        public string ht3 { get; set; }

        public string h4 { get; set; }

        public string ht4 { get; set; }

        public string imagem { get; set; }

        public string conclusao { get; set; }

        public string legenda { get; set; }




        public Visita_Relatorio(string stringconexao)
        {
            _conexao = new SqlConnection(stringconexao);
            _stringconexao = stringconexao;
        }

        public Visita_Relatorio(SqlConnection conexao)
        {
        }

        public void MontaCorpo(int id)
        {
            using (var conexao = new SqlConnection())
            {
                conexao.Open();
                string sql;

                sql = $@"SELECT A.VISITA " +
                                ",A.REPRESENTANTE " +
                                ",A.PERIODO " +
                                ",A.OBJETIVO " +
                                ",B.DIA " +
                                ",B.DATA " +
                                ",C.CLIENTE " +
                                ",B.LOCAL " +
                                ",B.COMPRADOR " +
                                ",D.DESCRICAO as 'PERFIL' " +
                                ",E.DESCRICAO as 'SORTIMENTO' " +
                                ",F.DESCRICAO as 'EXPOSICAO' " +
                                ",B.CONCORRENTE " +
                                ",B.COMENTARIOS " +
                                ",B.H1 " +
                                ",B.HT1 " +
                                ",B.H2 " +
                                ",B.HT2 " +
                                ",B.H3 " +
                                ",B.HT3 " +
                                ",B.H4 " +
                                ",B.HT4	 " +
                         "FROM VISITA A " +
                         "LEFT JOIN VISITA_DETALHE B ON A.ID = B.ID_VISITA " +
                         "JOIN VISITA_CLIENTE C ON B.ID_CLIFOR = C.ID " +
                         "JOIN VISITA_PERFIL D ON B.ID_PERFIL = D.ID " +
                         "JOIN VISITA_SORTIMENTO E ON B.ID_SORTIMENTO = E.ID " +
                         "JOIN VISITA_EXPOSICAO F ON B.ID_EXPOSICAO = F.ID " +
                         "WHERE A.ID = '" + id + "'";

                using (var dr = new SqlCommand(sql, conexao).ExecuteReader())
                {
                    while (dr.Read())
                    {
                        visita = dr["VISITA"].ToString();
                        representante = dr["REPRESENTANTE"].ToString();
                        periodo = dr["PERIODO"].ToString();
                        objetivo = dr["OBJETIVO"].ToString();
                        dia = Convert.ToInt32(dr["DIA"].ToString());
                        data = Convert.ToDateTime(dr["DATA"].ToString());
                        cliente = dr["CLIENTE"].ToString();
                        local = dr["LOCAL"].ToString();
                        comprador = dr["COMPRADOR"].ToString();
                        perfil = dr["PERFIL"].ToString();
                        sortimento = dr["SORTIMENTO"].ToString();
                        exposicao = dr["EXPOSICAO"].ToString();
                        concorrente = dr["CONCORRENTE"].ToString();
                        comentario = dr["COMENTARIOS"].ToString();
                        h1 = dr["H1"].ToString();
                        ht1 = dr["HT1"].ToString();
                        h2 = dr["H2"].ToString();
                        ht2 = dr["HT2"].ToString();
                        h3 = dr["H3"].ToString();
                        ht3 = dr["HT3"].ToString();
                        h4 = dr["H4"].ToString();
                        ht4 = dr["HT4"].ToString();

                    }
                }
            }
        }

        public void MontaImagem(int idVisita, int idVisitaDetalhe)
        {
            using (var conexao = new SqlConnection())
            {
                conexao.Open();
                string sql;

                sql = $@"SELECT IMAGEM " +
                            "FROM VISITA_IMAGEM " +
                        "WHERE ID_VISITA = '" + idVisita + "'" +
                        "AND ID_VISITA_DETALHE = '" + idVisitaDetalhe + "'";

                using (var dr = new SqlCommand(sql, conexao).ExecuteReader())
                {
                    while (dr.Read())
                    {
                        imagem = dr["IMAGEM"].ToString();
                    }
                }
            }
        }

        public void MontaConclusao(int idVisita)
        {
            using (var conexao = new SqlConnection())
            {
                conexao.Open();
                string sql;

                sql = $@"SELECT ID " +
                                ",CONCLUSAO " +
                      "FROM VISITA_CONCLUSAO " +
                      "WHERE ID_VISITA = '" + idVisita + "'";

                using (var dr = new SqlCommand(sql, conexao).ExecuteReader())
                {
                    while (dr.Read())
                    {
                        id = Convert.ToInt32(dr["ID"].ToString());
                        conclusao = dr["CONCLUSAO"].ToString();
                    }
                }
            }
        }

        public void MontaConclusaoImg(int idVisita, int idConclusao)
        {
            using (var conexao = new SqlConnection())
            {
                conexao.Open();
                string sql;

                sql = $@"SELECT IMAGEM " +
                                ",LEGENDA " +
                      "FROM VISITA_CONCLUSAO_IMG " +
                      "WHERE ID_VISITA = '" + idVisita + "'" +
                      "AND ID_CONCLUSAO = '" + idConclusao + "'";

                using (var dr = new SqlCommand(sql, conexao).ExecuteReader())
                {
                    while (dr.Read())
                    {
                        imagem = dr["IMAGEM"].ToString();
                        legenda = dr["LEGENDA"].ToString();
                    }
                }
            }
        }

    }
}