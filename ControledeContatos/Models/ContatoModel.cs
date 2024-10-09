using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControledeContatos.Models
{
    [Table("Contatos")]
	public class ContatoModel
	{
        [Column("Id")]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Column("Nome")]
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Digite o nome do contato")]
		public string Nome { get; set; }

        [Column("Email")]
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Digite o Email do contato")]
        [EmailAddress(ErrorMessage ="O e-mail informado não é valido!")]
        public string Email { get; set; }

        [Column("Celualar")]
        [Display(Name = "Celular")]
        [Required(ErrorMessage = "Digite o Celular do contato")]
        [Phone(ErrorMessage ="Digite um telefone valido")]
        public string Celular { get; set; }   

        [Column("UsuarioId")]
        [Display(Name = "UsuarioId")]
        public int? UsuarioId { get; set; }

        public UsuarioModel? UsuariO { get; set; }
    }
}
