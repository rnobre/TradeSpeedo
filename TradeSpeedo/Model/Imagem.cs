using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace TradeSpeedo.Model
{
    
    public class Imagem

    {
        private SqlConnection _conexao;
        private object v;

        public int ID { get; set; }

        public string CLIFOR { get; set; }

        public string CNPJ { get; set; }

        public string URL { get; set; }

        public int TIPO_EXPOSICAO { get; set; }

        public int ID_CLASSIFICACAO { get; set; }

        public Imagem(string stringConexao)
        {
            _conexao = new SqlConnection(stringConexao);
        }  

        public void Carregar(int ID)
        {
            _conexao.Open();

            var sql = $"SELECT TOP 1 ID_IMAGEM,COD_CLIFOR,CNPJ,URL,ID_TIPO_EXPOSICAO,ID_CLASSIFICACAO FROM TRADE_IMAGEM WHERE ID_IMAGEM = {ID}";
            var dr = new SqlCommand(sql, _conexao).ExecuteReader(); // Executa query e retorna consulta
            if (dr.Read())
            {
                this.CLIFOR = dr["COD_CLIFOR"].ToString();
                this.CNPJ = dr["CNPJ"].ToString();
                this.URL = dr["URL"].ToString();
                this.TIPO_EXPOSICAO = Convert.ToInt32(dr["ID_TIPO_EXPOSICAO"].ToString());
                this.ID_CLASSIFICACAO = Convert.ToInt32(dr["ID_TIPO_EXPOSICAO"].ToString());
                dr.Close();
            }

            _conexao.Close();
        }

        public void Salvar()
        {

        }

        public void Exluir()
        {

        }        

    }
}

