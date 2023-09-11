using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;
using senai.inlock.webApi_.Repositories;

namespace senai.inlock.webApi_.Controllers
{
    [Route("api/[controller]")]

    [ApiController]

    [Produces("Application/json")]
    public class TiposUsuarioController : ControllerBase
    {
        private ITiposUsuarioRepository _tiposUsuarioRepository { get; set; }

    public TiposUsuarioController()
        {
            _tiposUsuarioRepository = new TiposUsuarioRepository();
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
                List<TiposUsuarioDomain> listaTiposUsuario = _tiposUsuarioRepository.ListarTodos();

                return Ok(listaTiposUsuario);
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
        /// <param name="novoTipoUsuario"></param>
        /// <returns> Objeto recebido na requisição </returns>
        [HttpPost]
        public IActionResult Post(TiposUsuarioDomain novoTipoUsuario)
        {

            try
            {
                //_generoRepository utiliza os metodos, foi declarado no inicio do codigo
                //Fazendo a chamada do metodo passando como parametro o objeto
                _tiposUsuarioRepository.Cadastrar(novoTipoUsuario);

                //Retorna um status code 201
                return StatusCode(201);
            }

            catch (Exception erro)
            {
                //Retorna um BadRequest, mensagem de erro
                return BadRequest(erro.Message);
            }
        }

    }
}
