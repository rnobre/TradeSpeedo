using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace TradeSpeedo.Model
{
    public class Cliente
    {
        private string _stringconexao;

        public int ID { get; set; }
        public string Clifor { get; set; }
        public string Clientes { get; set; }
        public long Cnpj { get; set; }
        public string Representante { get; set; }
        public string Clifor_Repre { get; set; }
        public string NomeCompleto { get; set; }

        // Construtores
        public Cliente() { }
        public Cliente(string stringConexao) => _stringconexao = stringConexao;

        public static List<Cliente> Lista(string cliforRepresentante, string stringConexao)
        {
            var sql = $@"
                SELECT Clifor, Cliente 'Clientes', Cnpj, Representante, Clifor_Repre,
                LTRIM(RTRIM(CLIFOR)) + ' - ' + CONVERT(VARCHAR(20), CNPJ) + ' - ' + CLIENTE 'NomeCompleto'
                FROM TRADE_CLIENTE WHERE CLIFOR_REPRE = '{cliforRepresentante}'";

            using (var conexao = new SqlConnection(stringConexao))
                return conexao.Query<Cliente>(sql).ToList();
        }

        public void Carregar(string Clifor)
        {
            using (var conexao = new SqlConnection(_stringconexao))
            {
                conexao.Open();

                var sql = $"SELECT CLIFOR, CLIENTE, CNPJ,REPRESENTANTE,CLIFOR_REPRE FROM TRADE_CLIENTE WHERE CLIFOR = {Clifor}";
                using (var dr = new SqlCommand(sql, conexao).ExecuteReader())
                {
                    if (dr.Read())
                    {
                        this.Clifor = dr["CLIFOR"].ToString();
                        this.Clientes = dr["CLIENTE"].ToString();
                        this.Cnpj = Convert.ToInt64(dr["CNPJ"].ToString());
                        this.Representante = dr["REPRESENTANTE"].ToString();
                        this.Clifor_Repre = dr["CLIFOR_REPRE"].ToString();
                    }
                }
            }
        }

    }

}
