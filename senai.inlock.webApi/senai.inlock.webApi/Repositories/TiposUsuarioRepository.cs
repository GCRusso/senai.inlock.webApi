using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;
using System.Data.SqlClient;

namespace senai.inlock.webApi_.Repositories
{
    public class TiposUsuarioRepository : ITiposUsuarioRepository
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


        //*********************************** CADASTRAR  **************************************
        public void Cadastrar(TiposUsuarioDomain novoTipoUsuario)
        {

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryInsert = "INSERT INTO TiposUsuario(Titulo) VALUES (@Titulo)";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@Titulo", novoTipoUsuario.Titulo);

                    con.Open();

                    cmd.ExecuteNonQuery();

                }
            }
        }


        //************************************************************************ LISTAR TODOS *******************************************************************
        /// <summary>
        /// Método para listar todos os objetos
        /// </summary>
        /// <returns> Lista de objetos </returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<TiposUsuarioDomain> ListarTodos()
        {

            //Instanciamos a lista com uma nova lista `listaFilmes`
            List<TiposUsuarioDomain> listaTiposUsuario = new List<TiposUsuarioDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string querySelectAll = "SELECT IdTipoUsuario, Titulo FROM TiposUsuario";
                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        TiposUsuarioDomain tiposUsuario = new TiposUsuarioDomain()
                        {
                            IdTipoUsuario = Convert.ToInt32(rdr["IdTipoUsuario"]),
                          
                            Titulo = Convert.ToString(rdr["Titulo"]),


                        };
                        listaTiposUsuario.Add(tiposUsuario);

                    }
                }
            }

            //Retornamos a lista
            return listaTiposUsuario;
        }
    }
}
