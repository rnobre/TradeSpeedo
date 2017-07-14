using System;
using System.Collections.Generic;
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
        public int Sequencia { get; set; }
        private string _stringconexao { get; set; }

        public Imagem(string stringConexao)
        {
            _conexao = new SqlConnection(stringConexao);
            _stringconexao = stringConexao;
        }

        public void Carregar(int ID)
        {
            _conexao.Open();

            var sql = $"SELECT TOP 1 COD_CLIFOR,CNPJ,URL,ID_TIPO_EXPOSICAO,ID_CLASSIFICACAO, SEQUENCIA FROM TRADE_IMAGEM WHERE ID_IMAGEM = {ID}";
            var dr = new SqlCommand(sql, _conexao).ExecuteReader(); // Executa query e retorna consulta
            if (dr.Read())
            {
                this.ID = ID;
                this.Clifor = dr["COD_CLIFOR"].ToString();
                this.Cnpj = dr["CNPJ"].ToString();
                this.Url = dr["URL"].ToString();
                this.TipoExposicaoID = Convert.ToInt32(dr["ID_TIPO_EXPOSICAO"].ToString());
                this.ClassificacaoID = Convert.ToInt32(dr["ID_CLASSIFICACAO"].ToString());
                this.Sequencia = Convert.ToInt32(dr["SEQUENCIA"].ToString());
                dr.Close();
            }

            _conexao.Close();


        }

        public void Carregar(string clifor, int sequencia)
        {
            _conexao.Open();

            var sql = $"SELECT TOP 1 ID_IMAGEM,CNPJ,URL,ID_TIPO_EXPOSICAO,ID_CLASSIFICACAO FROM TRADE_IMAGEM WHERE COD_CLIFOR = '{clifor}' and SEQUENCIA = {sequencia} ";
            var dr = new SqlCommand(sql, _conexao).ExecuteReader(); // Executa query e retorna consulta
            if (dr.Read())
            {
                this.ID = Convert.ToInt32(dr["ID_IMAGEM"].ToString());
                this.Clifor = clifor;
                this.Cnpj = dr["CNPJ"].ToString();
                this.Url = dr["URL"].ToString();
                this.TipoExposicaoID = Convert.ToInt32(dr["ID_TIPO_EXPOSICAO"].ToString());
                this.ClassificacaoID = Convert.ToInt32(dr["ID_CLASSIFICACAO"].ToString());
                this.Sequencia = sequencia;
                dr.Close();
            }

            _conexao.Close();
        }

        public List<Imagem> Lista(string clifor)
        {
            var imagens = new List<Imagem>();

            _conexao.Open();
            var sql = $"SELECT TOP 1 ID_IMAGEM,CNPJ,URL,ID_TIPO_EXPOSICAO,ID_CLASSIFICACAO FROM TRADE_IMAGEM WHERE COD_CLIFOR = '{clifor}'";
            var dr = new SqlCommand(sql, _conexao).ExecuteReader();

            while (dr.Read())
            {
                var imagem = new Imagem(_stringconexao);

                imagem.Url = dr["URL"].ToString();

                imagens.Add(imagem);
            }

            _conexao.Close();

            return imagens;

        }

        public void Salvar()
        {
            _conexao.Open();

            string sql;

            if (this.ID == 0)
            {
                sql = $"INSERT INTO TRADE_IMAGEM (COD_CLIFOR,CNPJ,URL,ID_TIPO_EXPOSICAO,ID_CLASSIFICACAO, SEQUENCIA) VALUES ('{Clifor}', '{Cnpj}', '{Url}', '{TipoExposicaoID}', '{ClassificacaoID}','{Sequencia}')";
            }
            else if (this.Url != "")
            {
                sql = $"UPDATE TRADE_IMAGEM SET COD_CLIFOR= '{Clifor}' ,CNPJ= '{Cnpj}' ,ID_TIPO_EXPOSICAO = '{TipoExposicaoID}' ,URL = '{Url}',ID_CLASSIFICACAO = '{ClassificacaoID}', SEQUENCIA = '{Sequencia}' WHERE COD_CLIFOR = '{Clifor}' AND ID_IMAGEM = '{ID}' ";
            }
            else
            {
                sql = $"UPDATE TRADE_IMAGEM SET COD_CLIFOR= '{Clifor}' ,CNPJ= '{Cnpj}' ,ID_TIPO_EXPOSICAO = '{TipoExposicaoID}' ,ID_CLASSIFICACAO = '{ClassificacaoID}', SEQUENCIA = '{Sequencia}' WHERE COD_CLIFOR = '{Clifor}' AND ID_IMAGEM = '{ID}' ";
            }

            new SqlCommand(sql, _conexao).ExecuteNonQuery();

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

