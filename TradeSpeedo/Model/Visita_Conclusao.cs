using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TradeSpeedo.Model
{
    public class Visita_Conclusao
    {
        private SqlConnection _conexao;

        public int ID { get; set; }

        private string _stringconexao { get; set; }

        public int IdVisita { get; set; }

        public int IdVisitaConclusao { get; set; }

        public string Conclusao { get; set; }

        public string Imagem { get; set; }

        public string Legenda { get; set; }

        public string sequencia { get; set; }


        public Visita_Conclusao(string stringConexao)
        {
            _conexao = new SqlConnection(stringConexao);
            _stringconexao = stringConexao;
        }

        public void SalvaImagem()
        {
            string sql;                   

            sql = $@"INSERT INTO VISITA_CONCLUSAO_IMG (ID_VISITA, ID_CONCLUSAO,IMAGEM,LEGENDA,SEQUENCIA)
                    VALUES ('{IdVisita}','{IdVisitaConclusao}','{Imagem}','{Legenda}', '{sequencia}')";

            using (var conexao = new SqlConnection(_stringconexao))
                conexao.Execute(sql);
        }

        public void SalvaConclusao()
        {
            string sql;           

            sql = $@"INSERT INTO VISITA_CONCLUSAO (ID_VISITA, CONCLUSAO)
                    VALUES ('{IdVisita}','{Conclusao}')";           

            using (var conexao = new SqlConnection(_stringconexao))
                conexao.Execute(sql);
        }


        public void AlteraConclusao()
        {
            string sql;
            

            sql = $@"UPDATE VISITA_CONCLUSAO " +
                                    "SET ID_VISITA = '" + IdVisita + "'" +
                                    ",CONCLUSAO = '" + Conclusao + "'" +
                             "WHERE ID_VISITA = '"+ IdVisita +"'";    

            using (var conexao = new SqlConnection(_stringconexao))
                conexao.Execute(sql);
        }

        public void AlteraImagem()
        {
            string sql;         

   
            sql = $@"UPDATE VISITA_CONCLUSAO_IMG " +
                                  "SET ID_VISITA = '" + IdVisita + "'" +
                                  ",ID_CONCLUSAO = '" + IdVisitaConclusao + "'" +
                                  ",IMAGEM = '" + Imagem + "'" +
                                  ",LEGENDA = '" + Legenda + "'" +
                                  ",SEQUENCIA = '" + sequencia + "'" +
                          "WHERE ID_VISITA = '" + IdVisita + "'" +
                          "AND ID_CONCLUSAO = '" + IdVisitaConclusao + "'" +
                          "AND SEQUENCIA = '" + sequencia + "'";

            using (var conexao = new SqlConnection(_stringconexao))
                conexao.Execute(sql);
        }

        public List<Visitas_Conclusao> Lista(int IdVisita) =>
        _conexao
            .Query<Visitas_Conclusao>("SELECT TOP 1 A.ID_VISITA, A.CONCLUSAO, B.IMAGEM, B.LEGENDA, B.SEQUENCIA  " +
                                    "FROM VISITA_CONCLUSAO A "+
                                    "JOIN VISITA_CONCLUSAO_IMG B ON A.ID_VISITA = B.ID_VISITA AND A.ID = B.ID_CONCLUSAO  " +
                                    "WHERE A.ID_VISITA ='" + IdVisita + "'")
        .ToList();


        public string ExisteImagem(int IdVisita, string Sequencia)
        {
            using (var conexao = new SqlConnection(_stringconexao))
            {
                conexao.Open();

                var sql = $"SELECT TOP 1 IMAGEM FROM VISITA_CONCLUSAO_IMG WHERE ID_VISITA ='{IdVisita}' and SEQUENCIA = '{Sequencia}'";
                var dr = new SqlCommand(sql, conexao).ExecuteReader();

                if (dr.Read())
                {
                    return dr["IMAGEM"].ToString();
                }
                else
                {
                    return null;
                }
            }

        }


        public void Valida(int IdVisita)
        {
            using (var conexao = new SqlConnection(_stringconexao))
            {
                conexao.Open();
                var sql = $@"SELECT TOP 1 ID FROM VISITA_CONCLUSAO WHERE ID_VISITA = '{IdVisita}'";

                using (var dr = new SqlCommand(sql, conexao).ExecuteReader())
                {
                    if (dr.Read())
                    {
                        ID = Convert.ToInt32(dr["ID"].ToString());
                    }
                }

            }
        }

        public void Carrega(int Id)
        {
            using (var conexao = new SqlConnection(_stringconexao))
            {
                conexao.Open();
                var sql = $@"SELECT TOP 1 A.ID,A.ID_VISITA, A.CONCLUSAO, B.IMAGEM, B.LEGENDA, B.SEQUENCIA " +
                            "FROM VISITA_CONCLUSAO A " +
                            "LEFT JOIN VISITA_CONCLUSAO_IMG B ON A.ID_VISITA = B.ID_VISITA AND A.ID = B.ID_CONCLUSAO " +
                            "WHERE A.ID_VISITA ='" + Id + "'";
                var dr = new SqlCommand(sql, conexao).ExecuteReader();

               while(dr.Read())
                {
                    ID = Convert.ToInt32(dr["ID"].ToString());
                    IdVisita = Convert.ToInt32(dr["ID_VISITA"].ToString());
                    Conclusao = dr["CONCLUSAO"].ToString();
                    Imagem = dr["IMAGEM"].ToString();
                    Legenda = dr["LEGENDA"].ToString();
                    sequencia = dr["SEQUENCIA"].ToString();
                }
            }
        }

        public void CarregaLoad(int Id, string preview)
        {
            using (var conexao = new SqlConnection(_stringconexao))
            {
                conexao.Open();
                var sql = $@"SELECT TOP 1 A.ID,A.ID_VISITA, A.CONCLUSAO, B.IMAGEM, B.LEGENDA, B.SEQUENCIA " +
                            "FROM VISITA_CONCLUSAO A " +
                            "LEFT JOIN VISITA_CONCLUSAO_IMG B ON A.ID_VISITA = B.ID_VISITA AND A.ID = B.ID_CONCLUSAO " +
                            "WHERE A.ID_VISITA ='" + Id + "'" +
                            "AND B.SEQUENCIA = '" + preview +"'";
                var dr = new SqlCommand(sql, conexao).ExecuteReader();

                while (dr.Read())
                {
                    ID = Convert.ToInt32(dr["ID"].ToString());
                    IdVisita = Convert.ToInt32(dr["ID_VISITA"].ToString());
                    Conclusao = dr["CONCLUSAO"].ToString();
                    Imagem = dr["IMAGEM"].ToString();
                    Legenda = dr["LEGENDA"].ToString();
                    sequencia = dr["SEQUENCIA"].ToString();
                }
            }
        }
    }
}