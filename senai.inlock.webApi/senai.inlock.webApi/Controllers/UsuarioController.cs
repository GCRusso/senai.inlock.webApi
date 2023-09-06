using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;
using senai.inlock.webApi_.Repositories;

namespace senai.inlock.webApi_.Controllers
{
    [Route("api/[controller]")]

    [ApiController]

    [Produces("Application/json")]
    public class UsuarioController : ControllerBase
    {
        //Objeto que receberá todos os métodos definidos na interface
        private IUsuarioRepository _usuarioRepository { get; set; }

        //Método Construtor
        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        //*************************************************** POST LOGIN **********************************************
        /// <summary>
        /// Endpoint que aciona o método login
        /// </summary>
        /// <param name="usuarioLogin"></param>
        /// <returns> Retorna os dados do usuário caso encontrado </returns>
        [HttpPost]
        public IActionResult Post(UsuarioDomain usuarioLogin)
        {

            try
            {
                UsuarioDomain usuarioBuscado = _usuarioRepository.Login(usuarioLogin.Email, usuarioLogin.Senha);

                if (usuarioBuscado == null)
                {
                    return NotFound("Email ou Senha inválidos, Por favor tente novamente!");
                }

                return Ok(usuarioBuscado);

            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
