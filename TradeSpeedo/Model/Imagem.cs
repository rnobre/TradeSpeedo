using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace TradeSpeedo.Model
{

    public class Imagem
    {
        private string _stringconexao;

        public int ID { get; set; }
        public string Clifor { get; set; }
        public string Cnpj { get; set; }
        public string Url { get; set; }
        public int TipoExposicaoID { get; set; }
        public int ClassificacaoID { get; set; }
        public int Sequencia { get; set; }
        public DateTime Data { get; set; }

        // Construtores
        public Imagem() { }
        public Imagem(string stringConexao) => _stringconexao = stringConexao;

        public void Carregar(int ID)
        {
            using (var conexao = new SqlConnection(_stringconexao))
            {
                conexao.Open();

                var sql = $@"SELECT TOP 1 COD_CLIFOR, CNPJ, URL, ID_TIPO_EXPOSICAO, ID_CLASSIFICACAO, SEQUENCIA, DATA
                    FROM TRADE_IMAGEM WHERE ID_IMAGEM = {ID}";

                using (var dr = new SqlCommand(sql, conexao).ExecuteReader())
                {
                    if (dr.Read())
                    {
                        this.ID = ID;
                        this.Clifor = dr["COD_CLIFOR"].ToString();
                        this.Cnpj = dr["CNPJ"].ToString();
                        this.Url = dr["URL"].ToString();
                        this.TipoExposicaoID = Convert.ToInt32(dr["ID_TIPO_EXPOSICAO"].ToString());
                        this.ClassificacaoID = Convert.ToInt32(dr["ID_CLASSIFICACAO"].ToString());
                        this.Sequencia = Convert.ToInt32(dr["SEQUENCIA"].ToString());
                        this.Data = Convert.ToDateTime(dr["DATA"].ToString());
                    }
                    else
                        throw new Exception("Imagem não encontrada");
                }
            }
        }

        public void Carregar(string clifor, int sequencia)
        {
            using (var conexao = new SqlConnection(_stringconexao))
            {
                conexao.Open();

                var sql = $@"SELECT TOP 1 ID_IMAGEM, CNPJ, URL, ID_TIPO_EXPOSICAO, ID_CLASSIFICACAO
                            FROM TRADE_IMAGEM WHERE COD_CLIFOR = '{clifor}' and SEQUENCIA = {sequencia} ";

                using (var dr = new SqlCommand(sql, conexao).ExecuteReader())
                {
                    if (dr.Read())
                    {
                        this.ID = Convert.ToInt32(dr["ID_IMAGEM"].ToString());
                        this.Clifor = clifor;
                        this.Cnpj = dr["CNPJ"].ToString();
                        this.Url = dr["URL"].ToString();
                        this.TipoExposicaoID = Convert.ToInt32(dr["ID_TIPO_EXPOSICAO"].ToString());
                        this.ClassificacaoID = Convert.ToInt32(dr["ID_CLASSIFICACAO"].ToString());
                        this.Sequencia = sequencia;
                    }
                    else
                        throw new Exception("Imagem não encontrada");
                }    
            }
        }

        public static List<Imagem> Lista(string clifor, string stringConexao)
        {
            var sql = $@"SELECT TOP 1 ID_IMAGEM 'ID', COD_CLIFOR 'clifor'
                        Cnpj, Url, ID_TIPO_EXPOSICAO 'TipoExposicaoID', 
                        ID_CLASSIFICACAO 'ClassificacaoID'
                        FROM TRADE_IMAGEM WHERE COD_CLIFOR = '{clifor}'";

            using (var conexao = new SqlConnection(stringConexao))
                return conexao.Query<Imagem>(sql).ToList();
        }

        public void Salvar()
        {
            string sql;

            if (this.ID == 0)
                sql = $"INSERT INTO TRADE_IMAGEM (COD_CLIFOR,CNPJ,URL,ID_TIPO_EXPOSICAO,ID_CLASSIFICACAO, SEQUENCIA, DATA) VALUES ('{Clifor}', '{Cnpj}', '{Url}', '{TipoExposicaoID}', '{ClassificacaoID}','{Sequencia}', getdate())";
            else if (this.Url != "")
                sql = $"UPDATE TRADE_IMAGEM SET COD_CLIFOR= '{Clifor}' ,CNPJ= '{Cnpj}' ,ID_TIPO_EXPOSICAO = '{TipoExposicaoID}' ,URL = '{Url}',ID_CLASSIFICACAO = '{ClassificacaoID}', SEQUENCIA = '{Sequencia}', DATA = getdate() WHERE COD_CLIFOR = '{Clifor}' AND ID_IMAGEM = '{ID}' ";
            else
                sql = $"UPDATE TRADE_IMAGEM SET COD_CLIFOR= '{Clifor}' ,CNPJ= '{Cnpj}' ,ID_TIPO_EXPOSICAO = '{TipoExposicaoID}' ,ID_CLASSIFICACAO = '{ClassificacaoID}', SEQUENCIA = '{Sequencia}', DATA = getdate() WHERE COD_CLIFOR = '{Clifor}' AND ID_IMAGEM = '{ID}' ";

            using (var conexao = new SqlConnection(_stringconexao))
                conexao.Execute(sql);
        }

        public void Excluir()
        {
            var sql = $"DELETE FROM TRADE_IMAGEM WHERE ID_IMAGEM = {this.ID}";

            using (var conexao = new SqlConnection(_stringconexao))
                conexao.Execute(sql);
        }

    }
}

