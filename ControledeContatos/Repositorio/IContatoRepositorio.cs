using ControledeContatos.Models;

namespace ControledeContatos.Repositorio
{
	public interface IContatoRepositorio
	{
		ContatoModel ListaPorId(int id); 
		List<ContatoModel> BuscarTodos(int usuarioId);
		ContatoModel Adicionar(ContatoModel contato);
		ContatoModel Atualizar(ContatoModel contato);

		bool Apagar(int id);
	}
}
