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

        public int ID { get; set; }

        public string Descricao { get; set; }

        public Visita(string stringConexao)
        {
            _conexao = new SqlConnection(stringConexao);
            _stringconexao = stringConexao;
        }


        public List<Visita> Lista()
        {
            var visitas = new List<Visita>();


            _conexao.Open();

            var sql = $"SELECT ID,VISITA FROM VISITA";
            var dr = new SqlCommand(sql, _conexao).ExecuteReader();

            while (dr.Read())
            {
                var visita = new Visita(_stringconexao);

                visita.ID = Convert.ToInt32(dr["ID"].ToString());
                visita.Descricao = dr["VISITA"].ToString();


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