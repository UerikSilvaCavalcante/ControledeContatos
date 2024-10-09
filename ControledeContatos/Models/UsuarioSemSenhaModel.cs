using ControledeContatos.Enums;
using System.ComponentModel.DataAnnotations;

namespace ControledeContatos.Models
{
    public class UsuarioSemSenhaModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome do usuario")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite o Login do usuario")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Digite o Email do usuario")]
        [EmailAddress(ErrorMessage = "O e-mail informado não é valido!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Informe o perfil do usuario")]
        public PerfilEnum? Perfil { get; set; }
  
    }
}
