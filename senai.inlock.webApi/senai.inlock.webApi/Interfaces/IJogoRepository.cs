using senai.inlock.webApi_.Domains;

namespace senai.inlock.webApi_.Interfaces
{
    public interface IJogoRepository
    {
        /// <summary>
        /// Cadastrar um novo objeto(Jogo)
        /// </summary>
        /// <param name="novoJogo">  Nome do novo jogo </param>
        void Cadastrar(JogoDomain novoJogo);

        /// <summary>
        /// Lista todos os objetos cadastrados
        /// </summary>
        /// <returns> Lista com objetos </returns>
        List<JogoDomain> ListarTodos();

    }
}
