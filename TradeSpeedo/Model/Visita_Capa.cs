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

        public string Dia { get; set; }

        public int ID { get; set; }

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

        public void IdRec()
        {
            _conexao.Open();

            var sql = $"SELECT MAX(ID) AS ID from VISITA";
            var dr = new SqlCommand(sql, _conexao).ExecuteReader();

            while (dr.Read())
            {
                this.ID = Convert.ToInt32(dr["ID"].ToString());
            }

            _conexao.Close();
        }

  

        public void Carrega(int id)
        {
            _conexao.Open();
            
                var sql = $"SELECT ID, VISITA, PERIODO, REPRESENTANTE,REGIAO,OBJETIVO FROM VISITA WHERE ID = '{id}'";
                var dr = new SqlCommand(sql, _conexao).ExecuteReader();
            

            while(dr.Read())
            {
                ID = Convert.ToInt32(dr["ID"].ToString());
                Visita = dr["VISITA"].ToString();
                Periodo = dr["PERIODO"].ToString();
                Representante = dr["REPRESENTANTE"].ToString();
                Regiao = dr["REGIAO"].ToString();
                Objetivo = dr["OBJETIVO"].ToString();
            }

            _conexao.Close();
        }

        public List<Visita_Capa> Lista(int Id)
        {
            
            var dias = new List<Visita_Capa>(); ;

            _conexao.Open();

            var sql = $"SELECT ID_VISITA, DIA FROM VISITA_DETALHE WHERE ID = '{Id}'";
            var dr = new SqlCommand(sql, _conexao).ExecuteReader();

            while (dr.Read())
            {
                var dia = new Visita_Capa(_stringconexao);

                dia.ID = Convert.ToInt32(dr["ID_VISITA"].ToString());
                dia.Dia = dr["DIA"].ToString();

                dias.Add(dia);

            }

            _conexao.Close();

            return dias;
        }

    }
}