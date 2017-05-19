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

        private string _stringconexao { get; set; }

        public int? ID { get; set; }

        public string Descricao { get; set; }

        public Classificacao(string stringConexao)
        {
            _conexao = new SqlConnection(stringConexao);
            _stringconexao = stringConexao;
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
        
        public List<Classificacao> Lista()
        {
            
            var classif = new  List<Classificacao>();

            _conexao.Open();

            var sql = $"SELECT ID_CLASSIFICACAO, DESCRICAO FROM TRADE_CLASSIFICACAO";
            var dr = new SqlCommand(sql, _conexao).ExecuteReader();

            while(dr.Read())
            {
                var classificacao = new Classificacao(_stringconexao);
                                
                classificacao.ID = Convert.ToInt32(dr["ID_CLASSIFICACAO"].ToString());
                classificacao.Descricao = dr["DESCRICAO"].ToString();

                classif.Add(classificacao);
            }

            _conexao.Close();

            return classif;

        }
    }
}