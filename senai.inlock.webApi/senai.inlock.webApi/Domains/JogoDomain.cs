using System.ComponentModel.DataAnnotations;

namespace senai.inlock.webApi_.Domains
{
    public class JogoDomain
    {
        public int IdJogo { get; set; }

        public int IdEstudio { get; set; }

        [Required(ErrorMessage = "O Nome do jogo é obrigatório!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A Descrição do jogo é obrigatória!")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "A Data de lançamento é obrigatória!")]
        public DateTime DataLancamento { get; set; }

        [Required(ErrorMessage = "O Valor é obrigatório!")]
        public float Valor { get; set; }


    }
}
