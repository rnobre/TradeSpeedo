using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TradeSpeedo.Model
{
    public class Visita_Imagem
    {
        private SqlConnection _conexao;

        public int ID { get; set; }

        public int Id_Visita { get; set; }

        public int Id_Visita_Detalhe { get; set; }

        public string imagem { get; set; }

        private string _stringconexao { get; set; }

        public Visita_Imagem(string stringConexao)
        {
            _conexao = new SqlConnection(stringConexao);
            _stringconexao = stringConexao;
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

            var sql = $"INSERT INTO VISITA_IMAGEM (ID_VISITA, ID_VISITA_DETALHE, IMAGEM) VALUES ('{Id_Visita}','{Id_Visita_Detalhe}','{imagem}')";
            new SqlCommand(sql, _conexao).ExecuteNonQuery();
        }

        public List<Visita_Imagem> Lista(int IdVisita, int idVisitaDet, string simagem)
        {
            var imagens = new List<Visita_Imagem>();

            _conexao.Open();

            var sql = $"SELECT ID, ID_VISITA, ID_VISITA_DETALHE, IMAGEM FROM VISITA_IMAGEM WHERE ID_VISITA ='{IdVisita}' and ID_VISITA_DETALHE = '{idVisitaDet}' and IMAGEM = '{simagem}'";
            var dr = new SqlCommand(sql, _conexao).ExecuteReader();

            while(dr.Read())
            {
                var imagem = new Visita_Imagem(_stringconexao);

                imagem.ID = Convert.ToInt32(dr["ID"].ToString());
                imagem.Id_Visita = Convert.ToInt32(dr["ID_VISITA"].ToString());
                imagem.Id_Visita_Detalhe = Convert.ToInt32(dr["ID_VISITA_DETALHE"].ToString());
                imagem.imagem = dr["IMAGEM"].ToString();

                imagens.Add(imagem);
            }

            _conexao.Close();

            return imagens;
        }

        public void Carrega(int IdVisita, int idVisitaDet)
        {
            _conexao.Open();

            var sql = $"SELECT TOP 1 ID, ID_VISITA, ID_VISITA_DETALHE, IMAGEM FROM VISITA_IMAGEM WHERE ID_VISITA ='{IdVisita}' and ID_VISITA_DETALHE = '{idVisitaDet}'";
            var dr = new SqlCommand(sql, _conexao).ExecuteReader();

            while(dr.Read())
            {
                this.ID = Convert.ToInt32(dr["ID"].ToString());
                this.Id_Visita = Convert.ToInt32(dr["ID_VISITA"].ToString());
                this.Id_Visita_Detalhe = Convert.ToInt32(dr["ID_VISITA_DETALHE"].ToString());
                this.imagem = dr["IMAGEM"].ToString();

                dr.Close();
            }
            _conexao.Close();
        }

    }
}