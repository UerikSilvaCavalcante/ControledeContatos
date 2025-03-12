using ControledeContatos.Enums;
using ControledeContatos.Helper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControledeContatos.Models
{
    [Table("usuarios")]
    public class UsuarioModel
    {
        [Column("Id")]
        [Display(Name ="Id")]
        public int Id { get; set; }
        [Column("Nome")]
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Digite o nome do usuario")]
        public string Nome { get; set; }
        [Column("Login")]
        [Display(Name = "Login")]
        [Required(ErrorMessage = "Digite o Login do usuario")]
        public string Login { get; set; }
        [Column("Email")]
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Digite o Email do contato")]
        [EmailAddress(ErrorMessage = "O e-mail informado não é valido!")]
        public string Email { get; set; }
        [Column("Perfil")]
        [Display(Name = "Perfil")]
        [Required(ErrorMessage = "Informe o perfil do usuario")]
        public PerfilEnum? Perfil { get; set; }

        [Column("Senha")]
        [Display(Name = "Senha")]
        [Required(ErrorMessage ="Digite a senha do usuario")]
        public string Senha { get; set; }

        [Column("DataCadastro")]
        [Display(Name = "Data Cadastro")]
        public DateTime DataCadastro { get; set; }

        [Column("DataAtualizado")]
        [Display(Name = "DataAtualizado")]
        public DateTime? DataAtualizado { get; set; }

        public virtual List<ContatoModel>? Contatos { get; set; }

        public bool SenhaValida(string senha)
        {
            return Senha == senha.GerarHash();
        }

        public void SetSenhaHash()
        {
            Senha = Senha.GerarHash();
        }

        public void SetNovaSenha(string novaSenha)
        {
            Senha = novaSenha.GerarHash();
        }

        public string GerarNovaSenha()
        {
            string novaSenha = Guid.NewGuid().ToString().Substring(0, 8);
            Senha = novaSenha.GerarHash();
            return novaSenha;
        }

    }
}
