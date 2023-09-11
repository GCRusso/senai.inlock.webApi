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
        
        // Utilizar esta STRING NO SENAI // private string StringConexao = "Data Source = NOTE17-S15; Initial Catalog = inlock_games_Gabriel; User Id = sa; Pwd = Senai@134; TrustServerCertificate = true";
        private string StringConexao = "Data Source = GCRUSSO; Initial Catalog = inlock_games_Gabriel; Integrated Security = true;";
 

        //*********************************** CADASTRAR  ************************************** FALTA ADICIONAR O ID DO TIPO DE USUARIO
        /// <summary>
        /// Método para cadastrar usuarios
        /// </summary>
        /// <param name="novoUsuario"></param>
        public void Cadastrar(UsuarioDomain novoUsuario)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryInsert = "INSERT INTO Usuario(Email,Senha) VALUES (@Email, @Senha )";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    
                    cmd.Parameters.AddWithValue("@Email", novoUsuario.Email);
                    cmd.Parameters.AddWithValue("@Senha", novoUsuario.Senha);
                    

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }


        //*********************************** LISTAR TODOS  ************************************** COM ERRO
        public List<UsuarioDomain> ListarTodos()
        {

            //Instanciamos a lista com uma nova lista `listaFilmes`
            List<UsuarioDomain> listaUsuario = new List<UsuarioDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string querySelectAll = "SELECT IdUsuario, Usuario.Email FROM Usuario INNER JOIN TiposUsuario ON TiposUsuario.IdTipoUsuario = Usuario.IdUsuario";
                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        UsuarioDomain usuario = new UsuarioDomain()
                        {
                  
                            IdUsuario = Convert.ToInt32(rdr["IdUsuario"]),
                            Email = Convert.ToString(rdr["Email"]),

                            tipoUsuario = new TiposUsuarioDomain()
                            {
                                IdTipoUsuario = Convert.ToInt32(rdr["IdTipoUsuario"]),
                                Titulo = Convert.ToString(rdr["Titulo"]),

                            }
                        };



                        listaUsuario.Add(usuario);

                    }
                }
            }

            //Retornamos a lista
            return listaUsuario;
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

