using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;
using senai.inlock.webApi_.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

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

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                    new Claim(ClaimTypes.Role, usuarioBuscado.IdTipoUsuario.ToString())
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("inlock-chave-autenticacao-senai-api"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken
                    (
                       issuer: "senai.inlock.webApi.",

                       audience: "wsenai.inlock.webApi.",

                       claims: claims,

                       expires: DateTime.Now.AddMinutes(5),

                       signingCredentials: creds

                    );

                return Ok(new
                {

                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });

            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

    }
}

