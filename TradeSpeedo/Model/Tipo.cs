using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace TradeSpeedo.Model
{
    public class Tipo
    {
        private SqlConnection _conexao;
        public int? ID { get; set; }

        public string TIPO_DESCRICAO { get; set; }

        public Tipo(string stringConexao)
        {
            _conexao = new SqlConnection(stringConexao);
        }

        public void Carregar(int ID)
        {
            _conexao.Open();

            var sql = $"SELECT TOP 1 ID_TIPO, DESCRICAO FROM TRADE_TIPO_EXPOSICAO WHERE ID_TIPO = {ID}";
            var dr = new SqlCommand(sql, _conexao).ExecuteReader();
            if(dr.Read())
            {
                this.ID = ID;
                this.TIPO_DESCRICAO = dr["DESCRICAO"].ToString();
                dr.Close();
            }

            _conexao.Close();
        }

        public void Salvar()
        {
            _conexao.Open();

          if(this.ID == null)
            {
                

                
                var sql = $"INSERT INTO TRADE_TIPO_EXPOSICAO VALUES ('{ID}'.'{TIPO_DESCRICAO}')";
                new SqlCommand(sql, _conexao).ExecuteNonQuery();

            }

          else
            {
                var sql = $"UPDATE TRADE_TIPO_EXPOSICAO SET ID_TIPO = '{ID}', DESCRICAO = '{TIPO_DESCRICAO}' WHERE ID_TIPO = '{ID}'";
                new SqlCommand(sql, _conexao).ExecuteNonQuery();
            }


            _conexao.Close();

        }

        public void Excluir()
        {
            _conexao.Open();

            var sql = $"DELETE FROM TRADE_TIPO_EXPOSICAO WHERE ID_TIPO = {ID}";
            new SqlCommand(sql, _conexao).ExecuteNonQuery();

            _conexao.Close();


        }
    }
}