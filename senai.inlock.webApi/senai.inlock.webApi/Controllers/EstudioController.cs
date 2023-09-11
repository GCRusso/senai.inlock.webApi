using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;
using senai.inlock.webApi_.Repositories;

namespace senai.inlock.webApi_.Controllers
{
    [Route("api/[controller]")]

    [ApiController]

    [Produces("application/json")]
    public class EstudioController : ControllerBase
    {

        private IEstudioRepository _estudioRepository { get; set; }

        public EstudioController()
        {
            _estudioRepository = new EstudioRepository();
        }


        //*********************************************************************** POST ******************************************************
        /// <summary>
        /// Endpoint que aciona o método Cadastrar
        /// </summary>
        /// <param name="novoEstudio"></param>
        /// <returns> Novo objeto cadastrado </returns>
        
        //[Authorize(Roles = "Administrador")]
        [HttpPost]
        
        public IActionResult Post(EstudioDomain novoEstudio)
        {
            try
            {
                _estudioRepository.Cadastrar(novoEstudio);

                return StatusCode(201);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }


        //********************************************************************** GET  ****************************************************************************
        /// <summary>
        /// Endpoint que aciona o metodo ListarTodos no repositorio
        /// </summary>
        /// <returns> Retonar a resposta para o usuario (front-end) </returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<EstudioDomain> listaEstudio = _estudioRepository.ListarTodos();

                return Ok(listaEstudio);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }
    }
}
