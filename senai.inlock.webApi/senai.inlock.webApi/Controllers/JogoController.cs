using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;
using senai.inlock.webApi_.Repositories;

namespace senai.inlock.webApi_.Controllers
{
    [Route("api/[controller]")]

    [ApiController]

    [Produces("Application/json")]
    public class JogoController : ControllerBase
    {
        private IJogoRepository _jogoRepository { get; set; }

        public JogoController()
        {
            _jogoRepository = new JogoRepository();
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
                List<JogoDomain> listaJogo = _jogoRepository.ListarTodos();

                return Ok(listaJogo);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }


        //**********************************************************************  POST  ****************************************************************************
        /// <summary>
        /// Endpoint que aciona o metodo de cadastro
        /// </summary>
        /// <param name="novoJogo"></param>
        /// <returns> Objeto recebido na requisição </returns>
        [HttpPost]
        public IActionResult Post(JogoDomain novoJogo)
        {

            try
            {

                _jogoRepository.Cadastrar(novoJogo);

                return StatusCode(201);
            }

            catch (Exception erro)
            {
             
                return BadRequest(erro.Message);
            }
        }

    }
}
