using System.Data.SqlClient;

namespace TradeSpeedo.Model
{
    // Representa um usuário do sistema no banco de dados
    public class Usuario
    {
        public string Login { get; set; }
        public string Nome { get; set; }
        
        // Construtor de usuário
        public Usuario (string login, string Nome)
        {
            this.Login = login;
            this.Nome = Nome;
        }

        /// <summary>
        /// Se credenciais do usuário estiverem corretas, retorna um objeto de usuário, senão retorna nulo
        /// </summary>
        public static Usuario RetornaUsuario(string login, string senha, string stringConexao)
        {
            // Valida se login e senha existem
            var conexao = new SqlConnection(stringConexao); // Conexão com banco de dados
            conexao.Open();

            var sql = $"SELECT TOP 1 LOGIN, NOME FROM USUARIOS WHERE LOGIN = {login};";
            var dr = new SqlCommand(sql, conexao).ExecuteReader(); // Executa query e retorna consulta
            if(dr.Read())
            {
                var nome = dr["NOME"].ToString(); // Nome do usuário no banco de dados
                return new Usuario(login, nome); // Retorna usuário encontrado
            }

            // Se não encontrar, retorna nulo
            return null;
        }
    }
}