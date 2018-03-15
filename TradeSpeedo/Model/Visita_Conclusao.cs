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

        private string _stringconexao { get; set; }

        public int IdVisita { get; set; }

        public string Conclusao { get; set; }

        public string Imagem { get; set; }

        public string Legenda { get; set; }

        public string sequencia { get; set; }


        public Visita_Conclusao(string stringConexao)
        {
            _conexao = new SqlConnection(stringConexao);
            _stringconexao = stringConexao;
        }

        public void Salva()
        {
            string sql;

            sql = $@"INSERT INTO VISITA_CONCLUSAO (ID_VISITA, CONCLUSAO, IMAGEM, LEGENDA, SEQUENCIA)
                    VALUES ('{IdVisita}','{Conclusao}','{Imagem}','{Legenda}', '{sequencia}')";

            using (var conexao = new SqlConnection(_stringconexao))
                conexao.Execute(sql);
        }

        public void Altera()
        {
            string sql;

            sql = $@"UPDATE VISITA_CONCLUSAO SET CONCLUSAO = '{Conclusao}' , IMAGEM = '{Imagem}' , LEGENDA = '{Legenda}', SEQUENCIA = '{sequencia}' WHERE ID_VISITA = '{IdVisita}'";

            using (var conexao = new SqlConnection(_stringconexao))
                conexao.Execute(sql);
        }

        public List<Visitas_Conclusao> Lista(int IdVisita) =>
        _conexao
            .Query<Visitas_Conclusao>("SELECT TOP 1 ID, ID_VISITA, CONCLUSAO, IMAGEM, LEGENDA, SEQUENCIA  " +
                                    "FROM VISITA_CONCLUSAO  " +
                                    "WHERE ID_VISITA ='" + IdVisita + "'")
        .ToList();

        public string ExisteImagem(int IdVisita, string Sequencia)
        {
            using (var conexao = new SqlConnection(_stringconexao))
            {
                conexao.Open();

                var sql = $"SELECT TOP 1 IMAGEM FROM VISITA_CONCLUSAO WHERE ID_VISITA ='{IdVisita}' and SEQUENCIA = '{Sequencia}'";
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

    }
}