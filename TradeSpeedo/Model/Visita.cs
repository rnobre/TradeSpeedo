using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace TradeSpeedo.Model
{
    public class Visita
    {
        private string _stringconexao;

        public int ID { get; set; }
        public string Descricao { get; set; }

        public Visita() { }
        public Visita(string stringConexao) => _stringconexao = stringConexao;

        public static List<Visita> Lista(string stringConexao)
        {
            var sql = "SELECT ID, VISITA 'Descricao' FROM VISITA";

            using (var conexao = new SqlConnection(stringConexao))
                return conexao.Query<Visita>(sql).ToList();
        }
    }
}