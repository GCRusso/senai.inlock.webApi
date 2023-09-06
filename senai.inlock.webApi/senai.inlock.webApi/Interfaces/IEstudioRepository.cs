using senai.inlock.webApi_.Domains;

namespace senai.inlock.webApi_.Interfaces
{
    public interface IEstudioRepository
    {
        /// <summary>
        /// Cadastrar um novo objeto(Estúdio)
        /// </summary>
        /// <param name="novoEstudio"> Nome do novo objeto </param>
        void Cadastrar(EstudioDomain novoEstudio);

        /// <summary>
        /// Listar todos os objetos(Estúdios) cadastrados
        /// </summary>
        /// <returns> Lista com objetos </returns>
        List<EstudioDomain> ListarTodos();
    }
}
