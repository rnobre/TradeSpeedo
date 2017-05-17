using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace TradeSpeedo.Model
{
    public class Classificacao
    {
        private SqlConnection _conexao;
        public int? ID { get; set; }

        public string Descricao { get; set; }

        public Classificacao(string stringConexao)
        {
            _conexao = new SqlConnection(stringConexao);
        }

        public void Carregar(int ID)
        {
            _conexao.Open();

            var sql = $"SELECT * FROM TRADE_CLASSIFICACAO WHERE ID_CLASSIFICACAO = '{ID}'";
            var dr = new SqlCommand(sql, _conexao).ExecuteReader();
            if (dr.Read())
            {
                this.ID = ID;
                this.Descricao = dr["DESCRICAO"].ToString();
                dr.Close();
            }

            _conexao.Close();

        }

        public void Salvar()
        {
            _conexao.Open();

            if (this.ID == null)
            {


                var sql = $"INSERT INTO TRADE_CLASSIFICACAO (DESCRICAO )VALUES ('{Descricao}')";
                new SqlCommand(sql, _conexao).ExecuteNonQuery();
            }

            else
            {
                var sql = $"UPDATE TRADE_CLASSIFICACAO SET ID_CLASSIFICACAO = '{ID}', DESCRICAO ='{Descricao}' WHERE ID_CLASSIFICACAO = '{ID}'";
                new SqlCommand(sql, _conexao).ExecuteNonQuery();
            }
        }

        public void Excluir()
        {
            _conexao.Open();

            var sql = $"DELETE FROM TRADE_CLASSIFICACAO WHERE ID_CLASSIFICACAO = '{ID}'";
            new SqlCommand(sql, _conexao).ExecuteNonQuery();

            _conexao.Close();
        }
    }
}