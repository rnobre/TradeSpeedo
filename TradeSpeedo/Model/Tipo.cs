using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace TradeSpeedo.Model
{
    public class Tipo
    {
        private SqlConnection _conexao;

        private string _stringconexao { get; set; }

        public int? ID { get; set; }

        public string Descricao { get; set; }

        public Tipo(string stringConexao)
        {
            _conexao = new SqlConnection(stringConexao);
            _stringconexao = stringConexao;
        }

        public void Carregar(int ID)
        {
            _conexao.Open();

            var sql = $"SELECT TOP 1 ID_TIPO, DESCRICAO FROM TRADE_TIPO_EXPOSICAO WHERE ID_TIPO = {ID}";
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



                var sql = $"INSERT INTO TRADE_TIPO_EXPOSICAO ( DESCRICAO)  VALUES ('{Descricao}')";
                new SqlCommand(sql, _conexao).ExecuteNonQuery();

            }

            else
            {
                var sql = $"UPDATE TRADE_TIPO_EXPOSICAO SET ID_TIPO = '{ID}', DESCRICAO = '{Descricao}' WHERE ID_TIPO = '{ID}'";
                new SqlCommand(sql, _conexao).ExecuteNonQuery();
            }


            _conexao.Close();

        }

        public void Excluir()
        {
            _conexao.Open();

            var sql = $"DELETE FROM TRADE_TIPO_EXPOSICAO WHERE ID_TIPO = {ID}";
            new SqlCommand(sql, _conexao).ExecuteNonQuery();

            _conexao.Close();


        }

        public List<Tipo> Lista()
        {
            var tipos = new List<Tipo>();

            _conexao.Open();


            var sql = $"select ID_TIPO,DESCRICAO from TRADE_TIPO_EXPOSICAO";
            var dr = new SqlCommand(sql, _conexao).ExecuteReader();

            while (dr.Read())
            {
                var tipo = new Tipo(_stringconexao);

                tipo.ID = Convert.ToInt32(dr["ID_TIPO"].ToString());               
                tipo.Descricao = dr["DESCRICAO"].ToString();

                tipos.Add(tipo);
            }



            _conexao.Close();

            return tipos;
        }

    
    }
}