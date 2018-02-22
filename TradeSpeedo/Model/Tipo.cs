using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace TradeSpeedo.Model
{
    public class Tipo
    {
        private string _stringconexao;

        public int ID { get; set; }
        public string Descricao { get; set; }

        public Tipo() { }
        public Tipo(string stringConexao) => _stringconexao = stringConexao;

        public void Carregar(int ID)
        {
            using (var conexao = new SqlConnection(_stringconexao))
            {
                var sql = $"SELECT TOP 1 ID_TIPO, DESCRICAO FROM TRADE_TIPO_EXPOSICAO WHERE ID_TIPO = {ID}";

                // Aqui eu fiz uma experiêcia e carreguei usando dapper, espero que funcione...
                var tipo = conexao.QueryFirst<Tipo>(sql);

                if (tipo != null)
                {
                    this.ID = tipo.ID;
                    this.Descricao = tipo.Descricao;
                }
                else throw new Exception("Tipo não encontrado");
            }
        }

        public void Salvar()
        {
            // Aqui usei um tipo compacto de IF, chama-se operador ternário.
            // Eu deixei o código com IF comentado abaixo, pra você comparar. Os dois funcionam.

            string sql = (ID == 0)
                ? $"INSERT INTO TRADE_TIPO_EXPOSICAO ( DESCRICAO)  VALUES ('{Descricao}')"
                : sql = $"UPDATE TRADE_TIPO_EXPOSICAO SET ID_TIPO = '{ID}', DESCRICAO = '{Descricao}' WHERE ID_TIPO = '{ID}'";

            /*
            string sql;
            if (ID == 0)
                sql = $"INSERT INTO TRADE_TIPO_EXPOSICAO ( DESCRICAO)  VALUES ('{Descricao}')";
            else
                sql = $"UPDATE TRADE_TIPO_EXPOSICAO SET ID_TIPO = '{ID}', DESCRICAO = '{Descricao}' WHERE ID_TIPO = '{ID}'";
            */
            
            using (var conexao = new SqlConnection(_stringconexao))
                conexao.Execute(sql);

        }

        public void Excluir()
        {
            var sql = $"DELETE FROM TRADE_TIPO_EXPOSICAO WHERE ID_TIPO = {ID}";

            using (var conexao = new SqlConnection(_stringconexao))
                conexao.Execute(sql);
        }

        // Aqui eu coloquei uma palavra chamada STATIC na construção do método
        // Com ela, a gente não precisa dar um NEW TIPO() pra usar esse método.
        public static List<Tipo> Lista(string stringConexao)
        {
            var sql = "Select ID_TIPO 'ID', Descricao From TRADE_TIPO_EXPOSICAO";

            using (var conexao = new SqlConnection(stringConexao))
                return conexao.Query<Tipo>(sql).ToList();
        }


    }
}