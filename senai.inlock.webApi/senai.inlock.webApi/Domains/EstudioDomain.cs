﻿using System.ComponentModel.DataAnnotations;

namespace senai.inlock.webApi_.Domains
{
    public class EstudioDomain
    {
        public int IdEstudio { get; set; }

        [Required(ErrorMessage = "O Nome do estúdio é obrigatório!")]
        public string Nome { get; set; }
    }
}
