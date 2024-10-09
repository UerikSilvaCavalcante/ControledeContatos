using ControledeContatos.Data;
using ControledeContatos.Models;
using Microsoft.EntityFrameworkCore;

namespace ControledeContatos.Repositorio
{
	public class UsuarioRepositorio : IUsuarioRepositorio
	{
		private readonly BancoContext _bancoContext;

		public UsuarioRepositorio(BancoContext bancoContext)
		{
			_bancoContext = bancoContext;
		}
        public UsuarioModel BuscarPorLogin(string Login)
        {
            return _bancoContext.Usuarios.FirstOrDefault(x => x.Login.ToUpper() == Login.ToUpper());
        }

        public UsuarioModel BuscarPorEmailLogin(string email, string Login)
        {
            return _bancoContext.Usuarios.FirstOrDefault(x => x.Email.ToUpper() == email.ToUpper() && x.Login.ToUpper() == Login.ToUpper());
        }

        public UsuarioModel Adicionar(UsuarioModel usuario)
		{
			//gravar no banco de dados
			usuario.DataCadastro = DateTime.UtcNow;
			usuario.SetSenhaHash();
			_bancoContext.Usuarios.Add(usuario);
			_bancoContext.SaveChanges();
			return usuario;
		}

        public bool Apagar(int id)
        {
            UsuarioModel usuarioDB = ListaPorId(id);
			if(usuarioDB == null) throw new System.Exception("Houve um erro na deleção do Usuario");

			_bancoContext.Usuarios.Remove(usuarioDB);
			_bancoContext.SaveChanges();

			return true;

        }

        public UsuarioModel Atualizar(UsuarioModel usuario)
        {
            UsuarioModel usuarioDB= ListaPorId(usuario.Id);
			if (usuarioDB == null) throw new System.Exception("Houve um erro na autalização");

            usuarioDB.Nome = usuario.Nome;
			usuarioDB.Login = usuario.Login;
            usuarioDB.Email = usuario.Email;
            usuarioDB.DataAtualizado = DateTime.UtcNow;
            usuarioDB.Perfil = usuario.Perfil;
            usuarioDB.Senha = usuario.Senha;

			_bancoContext.Usuarios.Update(usuarioDB);
			_bancoContext.SaveChanges();

			return usuarioDB;
        }

       
        public List<UsuarioModel> BuscarTodos()
        {
			return _bancoContext.Usuarios
                .Include(x => x.Contatos)
                .ToList();
        }

        public UsuarioModel ListaPorId(int id)
        {
			return _bancoContext.Usuarios.FirstOrDefault(x => x.Id == id);
        }

        public UsuarioModel AlterarSenha(AlterarSenhaModel alterarSenhaModel)
        {
            UsuarioModel usuarioDB = ListaPorId(alterarSenhaModel.Id);
            if(usuarioDB == null) throw new Exception("Houve um erro na atualização da senha");

            if (!usuarioDB.SenhaValida(alterarSenhaModel.SenhaAtual)) throw new Exception("Senha atual não confere");
            if (usuarioDB.SenhaValida(alterarSenhaModel.NovaSenha)) throw new Exception("Nova Senha de ser diferente da senha atual");

            usuarioDB.SetNovaSenha(alterarSenhaModel.NovaSenha);
            usuarioDB.DataAtualizado = DateTime.UtcNow;

            _bancoContext.Usuarios.Update(usuarioDB);
            _bancoContext.SaveChanges();

            return usuarioDB;
           
        }
    }
}
