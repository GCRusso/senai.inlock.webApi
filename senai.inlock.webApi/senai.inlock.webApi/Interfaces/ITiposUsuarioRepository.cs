using senai.inlock.webApi_.Domains;

namespace senai.inlock.webApi_.Interfaces
{
    public interface ITiposUsuarioRepository
    {
        /// <summary>
        /// Cadastra um novo objeto(TipoDeUsuario)
        /// </summary>
        /// <param name="novoTipoUsuario"> Nome do novo TipoDeUsuario </param>
        void Cadastrar(TiposUsuarioDomain novoTipoUsuario);

        /// <summary>
        /// Lista todos os objetos cadastrados
        /// </summary>
        /// <returns> Lista com objetos </returns>
        List<TiposUsuarioDomain> ListarTodos();
    }
}
