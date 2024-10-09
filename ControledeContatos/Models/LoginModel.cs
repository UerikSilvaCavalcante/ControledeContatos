using System.ComponentModel.DataAnnotations;

namespace ControledeContatos.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Digite o Login do usuario")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Digite a Senha do usuario")]
        public string Senha { get; set; }

    }
}
