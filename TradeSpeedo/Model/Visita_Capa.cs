using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TradeSpeedo.Model
{
    public class Visita_Capa
    {
        private SqlConnection _conexao;

        public string Visita { get; set; }

        public string Periodo { get; set; }

        public string Representante { get; set; }

        public string Regiao { get; set; }

        public string Objetivo { get; set; }

        private string _stringconexao { get; set; }

        public int? ID { get; set; }

        public Visita_Capa(string stringConexao)
        {
            _conexao = new SqlConnection(stringConexao);
            _stringconexao = stringConexao;
        }

        public void Salvar()
        {
            _conexao.Open();

            
            {
                var sql = $"INSERT INTO VISITA (VISITA,PERIODO,REPRESENTANTE,REGIAO,OBJETIVO) VALUES ('{Visita}','{Periodo}','{Representante}','{Regiao}','{Objetivo}')";
                new SqlCommand(sql, _conexao).ExecuteNonQuery();            
            }
            

            _conexao.Close();
        }

        public void Altera()
        {
            _conexao.Open();

            
            {
                var sql = $"UPDATE VISITA SET VISITA = '{Visita}', PERIODO = '{Periodo}',REPRESENTANTE='{Representante}', REGIAO ='{Regiao}', OBJETIVO = '{Objetivo}' WHERE ID = '{ID}' ";
                new SqlCommand(sql, _conexao).ExecuteNonQuery();
            }

            _conexao.Close();
        }


    }
}