using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using TradeSpeedo.Model;

namespace TradeSpeedo.Model
{
    public class Cliente
    {
        private SqlConnection _conexao;

        public string Clifor { get; set; }

        public string Clientes { get; set; }

        public long Cnpj { get; set; }

        public string Representante { get; set; }

        public string Clifor_Repre { get; set; }

        private string _stringconexao { get; set; }

        public string NomeCompleto { get; set; }

        public Cliente(string stringConexao)
        {
            _conexao = new SqlConnection(stringConexao);
            _stringconexao = stringConexao;
        }

        public List<Cliente> Lista(string cliforRepresentante)
        {
            var clientes = new List<Cliente>();
            

            _conexao.Open();

            var sql = $"SELECT CLIFOR,CLIENTE,CNPJ,REPRESENTANTE, CLIFOR_REPRE FROM TRADE_CLIENTE WHERE CLIFOR_REPRE = {cliforRepresentante}";
            var dr = new SqlCommand(sql, _conexao).ExecuteReader();

            while (dr.Read())
            {
                var cliente = new Cliente(_stringconexao);

                cliente.Clifor = dr["CLIFOR"].ToString();
                cliente.Clientes = dr["CLIENTE"].ToString();
                cliente.Cnpj = Convert.ToInt64(dr["CNPJ"].ToString());
                cliente.Representante = dr["REPRESENTANTE"].ToString();
                cliente.NomeCompleto = dr["CLIFOR"].ToString() + ' ' + '-' + ' ' + Convert.ToInt64(dr["CNPJ"].ToString()) + ' ' + '-' + ' ' + dr["CLIENTE"].ToString();


                clientes.Add(cliente);
            }



            _conexao.Close();

            return clientes;


        }
    }

}
