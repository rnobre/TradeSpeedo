using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace TradeSpeedo.Model
{
    public class Visitas_Conclusao
    {
        private SqlConnection _conexao;

        public int ID { get; set; }

        public int Id_Visita { get; set; }

        public int Id_Visita_Detalhe { get; set; }

        public string imagem { get; set; }

        public int Dia { get; set; }

        public string Sequencia { get; set; }

        private string _stringconexao { get; set; }


        public Visitas_Conclusao(string stringConexao)
        {
            _conexao = new SqlConnection(stringConexao);
            _stringconexao = stringConexao;
        }

        public Visitas_Conclusao()
        {

        }


        public void idVisita()
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

        public void idVisitaDetalhe()
        {
            _conexao.Open();

            var sql = $"SELECT MAX(ID) AS ID from VISITA_DETALHE";
            var dr = new SqlCommand(sql, _conexao).ExecuteReader();

            while (dr.Read())
            {
                this.ID = Convert.ToInt32(dr["ID"].ToString());
            }

            _conexao.Close();
        }

        public void Salva()
        {
            _conexao.Open();

            var sql = $"INSERT INTO VISITA_IMAGEM (ID_VISITA, ID_VISITA_DETALHE, DIA, IMAGEM, SEQUENCIA) VALUES ('{Id_Visita}','{Id_Visita_Detalhe}','{Dia}','{imagem}', '{Sequencia}')";
            new SqlCommand(sql, _conexao).ExecuteNonQuery();

            _conexao.Close();
        }

        public void Altera()
        {
            _conexao.Open();

            var sql = $"UPDATE VISITA_IMAGEM SET IMAGEM = '{imagem}' WHERE ID_VISITA = '{Id_Visita}' AND ID_VISITA_DETALHE = '{Id_Visita_Detalhe}' AND DIA = '{Dia}' AND SEQUENCIA = '{Sequencia}' AND ID = '{ID}'";
            new SqlCommand(sql, _conexao).ExecuteNonQuery();

            _conexao.Close();
        }


        public List<Visitas_Conclusao> Lista(int IdVisita, int idVisitaDet, int dia) =>
            _conexao
                .Query<Visitas_Conclusao>("SELECT ID, Id_Visita, Id_Visita_Detalhe, imagem, Sequencia " +
                                        "FROM VISITA_IMAGEM  " +
                                        "WHERE ID_VISITA ='" + IdVisita + "' and ID_VISITA_DETALHE = '" + idVisitaDet + "' and DIA = '" + dia + "'")
            .ToList();


        public string ExisteImagem(int IdVisita, int idVisitaDet, int Dia, string Sequencia)
        {
            using (var conexao = new SqlConnection(_stringconexao))
            {
                conexao.Open();

                var sql = $"SELECT TOP 1 IMAGEM FROM VISITA_IMAGEM WHERE ID_VISITA ='{IdVisita}' and ID_VISITA_DETALHE = '{idVisitaDet}' and DIA = '{Dia}' and SEQUENCIA = '{Sequencia}'";
                var dr = new SqlCommand(sql, conexao).ExecuteReader();

                if (dr.Read())
                {
                    return dr["IMAGEM"].ToString();
                }
                else
                {
                    return null;
                }
            }

        }
    }
}