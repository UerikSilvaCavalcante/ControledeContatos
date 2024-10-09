﻿using System.ComponentModel.DataAnnotations;

namespace ControledeContatos.Models
{
    public class RedefinirSenhaModel
    {
        [Required(ErrorMessage = "Digite o Login do usuario")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Digite o email do usuario")]
        public string Email { get; set; }
    }
}
