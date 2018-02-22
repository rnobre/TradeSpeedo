using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace TradeSpeedo.Model
{
    public class Classificacao
    {
        private string _stringconexao;

        public int ID { get; set; }
        public string Descricao { get; set; }

        // Construtores
        public Classificacao() { }
        public Classificacao(string stringConexao) =>
            _stringconexao = stringConexao;

        /// <summary>
        /// Carrega a classificação de acordo com o ID
        /// </summary>
        public void Carregar(int ID)
        {
            using (var conexao = new SqlConnection(_stringconexao))
            {
                conexao.Open();

                var sql = $"SELECT * FROM TRADE_CLASSIFICACAO WHERE ID_CLASSIFICACAO = '{ID}'";
                using (var dr = new SqlCommand(sql, conexao).ExecuteReader())
                {
                    if (dr.Read())
                    {
                        this.ID = ID;
                        this.Descricao = dr["DESCRICAO"].ToString();
                    }
                }
            }
        }

        /// <summary>
        /// Salva a classificação atual no banco
        /// </summary>
        public void Salvar()
        {
            string sql;

            if (this.ID == 0)
                sql = $"INSERT INTO TRADE_CLASSIFICACAO (DESCRICAO) VALUES ('{Descricao}')";
            else
                sql = $@"UPDATE TRADE_CLASSIFICACAO 
                        SET  DESCRICAO ='{Descricao}' 
                        WHERE ID_CLASSIFICACAO = '{ID}'";

            using (var conexao = new SqlConnection(_stringconexao))
            {
                conexao.Execute(sql); // Salva

                if(this.ID == 0)
                    this.ID = conexao.QueryFirst<int>("SELECT @@IDENTITY"); // Carrega novo ID
            }
        }

        /// <summary>
        /// Exclui a classiicação do banco de dados
        /// </summary>
        public void Excluir()
        {
            var sql = $"DELETE FROM TRADE_CLASSIFICACAO WHERE ID_CLASSIFICACAO = '{ID}'";
            using (var conexao = new SqlConnection(_stringconexao))
                conexao.Execute(sql);       
        }

        /// <summary>
        /// Retorna uma lista de todas as classificações do banco
        /// </summary>
        public static List<Classificacao> Lista(string stringConexao)
        {
            var sql = "SELECT ID_CLASSIFICACAO 'ID', Descricao FROM TRADE_CLASSIFICACAO";

            using (var conexao = new SqlConnection(stringConexao))
                return conexao.Query<Classificacao>(sql).ToList();
        }
    }
}