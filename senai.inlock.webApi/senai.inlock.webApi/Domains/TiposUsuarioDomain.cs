using System.ComponentModel.DataAnnotations;

namespace senai.inlock.webApi_.Domains
{
    public class TiposUsuarioDomain
    {
        public int IdTipoUsuario { get; set; }

        [Required(ErrorMessage = "O Titulo do usuario é obrigatório!")]
        public string Titulo { get; set; }

    }
}
