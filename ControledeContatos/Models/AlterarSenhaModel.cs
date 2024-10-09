using System.ComponentModel.DataAnnotations;

namespace ControledeContatos.Models
{
    public class AlterarSenhaModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite a sua senha atual do usuario")]
        public string SenhaAtual { get; set; }
        [Required(ErrorMessage = "Digite uma nova senha para usuario")]
        public string NovaSenha { get; set; }
        [Required(ErrorMessage = "Confirme a sua nova senha")]
        [Compare("NovaSenha", ErrorMessage ="Senhas não se igualam")]
        public string ConfirmarNovaSenha { get; set; }
    }
}
