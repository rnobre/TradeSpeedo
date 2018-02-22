using Dapper;
using System.Data.SqlClient;

namespace TradeSpeedo.Model
{
    // Representa um usuário do sistema no banco de dados
    public class Usuario
    {
        public string Login { get; set; }
        public string Nome { get; set; }
        public string Clifor { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public bool Inativo { get; set; }

        public Usuario() { }
        public Usuario(string login, string Nome, string Clifor)
        {
            this.Login = login;
            this.Nome = Nome;
            this.Clifor = Clifor;
        }

        /// <summary>
        /// Se credenciais do usuário estiverem corretas, retorna um objeto de usuário, senão retorna nulo
        /// </summary>
        public static Usuario RetornaUsuario(string login, string senha, string stringConexao)
        {
            using (var conexao = new SqlConnection(stringConexao))
            {
                var sql = $@"SELECT TOP 1 Clifor, USUARIO 'Login', Nome, PASSW 'Senha', Email, Inativo
                            FROM TRADE_USUARIO WHERE USUARIO = '{login}' AND PASSW = '{senha}' ";

                var usuario = conexao.QueryFirst<Usuario>(sql);
                if (usuario != null)
                    return usuario;
            }
            return null;
        }

        public static Usuario RetornaUsuarioV(string login, string senha, string stringConexao)
        {
            var conexao = new SqlConnection(stringConexao);
            conexao.Open();

            var sql = $"SELECT TOP 1 ID, USUARIO, NOME, PASSW, EMAIL, INATIVO FROM VISITA_USUARIO WHERE USUARIO = '{login}' AND PASSW = '{senha}' ";
            var dr = new SqlCommand(sql, conexao).ExecuteReader();
            if (dr.Read())
            {
                var nome = dr["NOME"].ToString();
                var usuario = dr["USUARIO"].ToString();
                return new Usuario(login, nome, usuario);

            }
            return null;
        }
    }
}