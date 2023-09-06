using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;
using System.Data.SqlClient;

namespace senai.inlock.webApi_.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        /// <summary>
        /// String de conexão com o banco de dados que recebe os seguintes parâmetros
        /// Data Source: Nome do Servidor
        /// Initial Catalog: Nome do banco de dados
        /// Atenticação:
        ///     - Windows: Integrated Security = true;
        ///     - SqlServer: User Id = inserir o usuario; pwd = inserir a senha;
        /// </summary>
        private string StringConexao = "Data Source = NOTE17-S15; Initial Catalog = inlock_games_Gabriel; User Id = sa; Pwd = Senai@134; TrustServerCertificate = true";

        //*********************************** CADASTRAR  **************************************
        public void Cadastrar(UsuarioDomain novoUsuario)
        {
            throw new NotImplementedException();
        }

        //*********************************** LISTAR TODOS  **************************************
        public List<UsuarioDomain> ListarTodos()
        {
            throw new NotImplementedException();
        }

        //*********************************** LOGIN  **************************************
        public UsuarioDomain Login(string Email, string Senha)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryLogin = "SELECT IdUsuario,Email FROM Usuario WHERE Email = @buscaEmail AND Senha = @buscaSenha";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(queryLogin, con))
                {
                    cmd.Parameters.AddWithValue("@buscaEmail", Email);
                    cmd.Parameters.AddWithValue("@buscaSenha", Senha);

                    rdr = cmd.ExecuteReader();
                }

                if (rdr.Read())
                {

                    UsuarioDomain usuarioEncontrado = new UsuarioDomain()
                    {
                        IdUsuario = Convert.ToInt32(rdr["IdUsuario"]),
                        Email = rdr["Email"].ToString()!,
                    };


                    return usuarioEncontrado;
                }

                else
                {
                    return null;
                }

            }
        }
    }
}

