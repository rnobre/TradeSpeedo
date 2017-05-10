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

        public int ID { get; set; }
        public string Clifor { get; set; }
        public string Cnpj { get; set; }
        public string Url { get; set; }
        public int TipoExposicaoID { get; set; }
        public int ClassificacaoID { get; set; }

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
                this.ID = ID;
                this.Clifor = dr["COD_CLIFOR"].ToString();
                this.Cnpj = dr["CNPJ"].ToString();
                this.Url = dr["URL"].ToString();
                this.TipoExposicaoID = Convert.ToInt32(dr["ID_TIPO_EXPOSICAO"].ToString());
                this.ClassificacaoID = Convert.ToInt32(dr["ID_CLASSIFICACAO"].ToString());
                dr.Close();
            }

            _conexao.Close();
        }

        public void Salvar()
        {
            _conexao.Open();


            if(this.ID == null)

            {
                var imagem = new Imagem(_conexao);

                imagem.Clifor = "00003";
                imagem.Cnpj = "000030303030";
                imagem.Url = "icmiewmew.ocm.br";
                imagem.TipoExposicaoID = 2;
                imagem.ClassificacaoID = 1;

                var sql = $"INSERT INTO TRADE_IMAGEM VALUES ('{Clifor}', '{Cnpj}', '{Url}', '{TipoExposicaoID}', '{ClassificacaoID}'";
                new SqlCommand(sql, _conexao).ExecuteNonQuery();

            }

            else
            {
                var sql = $"UPDATE TRADE_IMAGEM SET COD_CLIFOR= '{Clifor}' ,CNPJ= '{Cnpj}' ,URL= '{Url}' ,ID_TIPO_EXPPOSICAO = '{TipoExposicaoID}' , ID_CLASSIFICACAO = '{ClassificacaoID}'";
                new SqlCommand(sql, _conexao).ExecuteNonQuery();
            }
            _conexao.Close();

        }

        public void Excluir()
        {
            _conexao.Open();

            var sql = $"DELETE FROM TRADE_IMAGEM WHERE ID_IMAGEM = {this.ID}";
            new SqlCommand(sql, _conexao).ExecuteNonQuery();

            _conexao.Close();
        }        

    }
}

