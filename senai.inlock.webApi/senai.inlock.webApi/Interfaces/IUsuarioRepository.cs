using senai.inlock.webApi_.Domains;

namespace senai.inlock.webApi_.Interfaces
{
    public interface IUsuarioRepository
    {

        /// <summary>
        /// Login para usuários cadastrado
        /// </summary>
        /// <param name="Email"></param>
        /// <param name="Senha"></param>
        /// <returns> Usuário Login </returns>
        public UsuarioDomain Login(string Email, string Senha);
    }
}
