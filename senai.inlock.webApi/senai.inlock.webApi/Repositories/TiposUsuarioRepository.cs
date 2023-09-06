using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;

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
        private string StringConexao = "Data Source = NOTE17-S15; Initial Catalog = inlock_games_Gabriel; User Id = sa; Pwd = Senai@134; TrustServerCertificate = true";
        

        //*********************************** CADASTRAR  **************************************
        public void Cadastrar(TiposUsuarioDomain novoTipoUsuario)
        {
            throw new NotImplementedException();
        }

        //*********************************** LISTAR TODOS  **************************************
        public List<TiposUsuarioDomain> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
