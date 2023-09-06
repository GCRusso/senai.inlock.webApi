using senai.inlock.webApi_.Domains;

namespace senai.inlock.webApi_.Interfaces
{
    public interface IUsuarioRepository
    {
        /// <summary>
        /// Cadastra um novo objeto(Usuario)
        /// </summary>
        /// <param name="novoUsuario"> Nome do novo Usuario </param>
        void Cadastrar(UsuarioDomain novoUsuario);

        /// <summary>
        /// Lista todos os objetos cadastrados
        /// </summary>
        /// <returns> Lista com objetos </returns>
        List<UsuarioDomain> ListarTodos();

        /// <summary>
        /// Login para usuários cadastrado
        /// </summary>
        /// <param name="Email"></param>
        /// <param name="Senha"></param>
        /// <returns> Usuário Login </returns>
        public UsuarioDomain Login(string Email, string Senha);
    }
}
