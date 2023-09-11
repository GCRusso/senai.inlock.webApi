using Microsoft.AspNetCore.Authorization;
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

        //*************************************************** POST CADASTRO  **********************************************
        /// <summary>
        /// Endpoint que aciona o método Cadastrar
        /// </summary>
        /// <param name="novoUsuario"></param>
        /// <returns> Retorna os dados do novo objeto </returns>
        [HttpPost("criar")]


        public IActionResult Post2(UsuarioDomain novoUsuario)
        {

            try
            {
                //_generoRepository utiliza os metodos, foi declarado no inicio do codigo
                //Fazendo a chamada do metodo passando como parametro o objeto
                _usuarioRepository.Cadastrar(novoUsuario);

                //Retorna um status code 201
                return StatusCode(201);
            }

            catch (Exception erro)
            {
                //Retorna um BadRequest, mensagem de erro
                return BadRequest(erro.Message);
            }
        }


        //********************************************************************** GET  ****************************************************************************
        /// <summary>
        /// Endpoint que aciona o metodo ListarTodos no repositorio
        /// </summary>
        /// <returns> retorna a respota para o usuario(front-end) </returns>
        [HttpGet]

        public IActionResult Get()
        {
            try
            {
                //se tiver acesso e estiver tudo certo ele entrega a lista de generos
                //cria uma lista que recebe os dados da requisicao
                List<UsuarioDomain> listaUsuario = _usuarioRepository.ListarTodos();

                //retorna a lista com o formato JSON com o status code OK(200) 
                return Ok(listaUsuario);
            }
            catch (Exception erro)
            {
                //se caso nao tiver acesso ou estiver algo errado ele entrega um erro
                //Retorna um status code BadRequest(400) e a mensagem do erro
                return BadRequest(erro.Message);
            }

        }
    }
}
