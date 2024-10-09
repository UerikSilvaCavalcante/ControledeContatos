using ControledeContatos.Models;

namespace ControledeContatos.Repositorio
{
	public interface IUsuarioRepositorio
	{
		UsuarioModel ListaPorId(int id); 
		UsuarioModel BuscarPorLogin(string Login);
		UsuarioModel BuscarPorEmailLogin(string email , string Login);
		List<UsuarioModel> BuscarTodos();
        UsuarioModel Adicionar(UsuarioModel usuario);
        UsuarioModel Atualizar(UsuarioModel usuario);
		UsuarioModel AlterarSenha(AlterarSenhaModel alterarSenhaModel);


		bool Apagar(int id);
	}
}
