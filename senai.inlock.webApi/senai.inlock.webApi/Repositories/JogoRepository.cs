using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;
using System.Data.SqlClient;

namespace senai.inlock.webApi_.Repositories
{
    public class JogoRepository : IJogoRepository
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
        public void Cadastrar(JogoDomain novoJogo)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryInsert = "INSERT INTO Jogo(Nome,Descricao,DataLancamento,Valor) VALUES (@Nome,@Descricao,@DataLancamento,@Valor)";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", novoJogo.Nome);
                    cmd.Parameters.AddWithValue("@Descricao", novoJogo.Descricao);
                    cmd.Parameters.AddWithValue("@DataLancamento", novoJogo.DataLancamento);
                    cmd.Parameters.AddWithValue("@Nome", novoJogo.Nome);

                    con.Open();

                    cmd.ExecuteNonQuery();

                }
            }
        }

        //*********************************** LISTAR TODOS  ************************************** COM ERRO
        public List<JogoDomain> ListarTodos()
        {
            List<JogoDomain> listaJogo = new List<JogoDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string querySelectAll = "SELECT IdJogo, Nome,Descricao,DataLancamento,Valor FROM Jogo";
                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        JogoDomain novoJogo = new JogoDomain()
                        {
                            IdJogo = Convert.ToInt32(rdr["IdJogo"]),
                            Nome = Convert.ToString(rdr["Nome"]),
                            Descricao = Convert.ToString(rdr["Descricao"]),
                            //DataLancamento = rdr.GetDateTime(rdr.GetOrdinal("DataLancamento")),
                            Valor = Convert.ToInt32(rdr["Valor"]),


                        };
                        listaJogo.Add(novoJogo);

                    }
                }
            }

            //Retornamos a lista
            return listaJogo;
        }
    }
}
