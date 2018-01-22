using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TradeSpeedo.Model
{
    public class Visita
    {
        private SqlConnection _conexao;

        private string _stringconexao { get; set; }

        public string visita { get; set; }

        public Visita(string stringConexao)
        {
            _conexao = new SqlConnection(stringConexao);
            _stringconexao = stringConexao;
        }


        public List<Visita> Lista()
        {
            var visitas = new List<Visita>();


            _conexao.Open();

            var sql = $"select VISITA from VISITA";
            var dr = new SqlCommand(sql, _conexao).ExecuteReader();

            while (dr.Read())
            {
                var visita = new Visita(_stringconexao);

                visita.visita = dr["VISITA"].ToString();

                visitas.Add(visita);
            }
            _conexao.Close();

            return visitas;
        }

        public void Carrega()

        {
            _conexao.Open();

            var sql = $"";
        }
    }
}