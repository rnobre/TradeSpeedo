using System.Data.SqlClient;

namespace TradeSpeedo.Model
{
    // Representa um usuário do sistema no banco de dados
    public class Usuario
    {
        public string Login { get; set; }
        public string Nome { get; set; }
        public string Clifor { get; set; }
        
        // Construtor de usuário
        public Usuario (string login, string Nome, string Clifor )
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
            // Valida se login e senha existem
            var conexao = new SqlConnection(stringConexao); // Conexão com banco de dados
            conexao.Open();

            var sql = $"SELECT TOP 1 CLIFOR, USUARIO, NOME, PASSW, EMAIL, INATIVO FROM TRADE_USUARIO WHERE USUARIO = '{login}' AND PASSW = '{senha}' ";
            var dr = new SqlCommand(sql, conexao).ExecuteReader(); // Executa query e retorna consulta
            if(dr.Read())
            {
                var nome = dr["NOME"].ToString(); // Nome do usuário no banco de dados
                var clifor = dr["CLIFOR"].ToString();
                return new Usuario(login, nome,clifor); // Retorna usuário encontrado
                
             
            }
               
            if(dr == null)
            {
                //Pesquisar como apresentar o erro
            }       
          
            // Se não encontrar, retorna nulo
            return null;
            
        }
    }
}