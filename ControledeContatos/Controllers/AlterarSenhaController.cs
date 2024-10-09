using Microsoft.AspNetCore.Mvc;
using ControledeContatos.Models;
using ControledeContatos.Repositorio;
using ControledeContatos.Helper;

namespace ControledeContatos.Controllers
{
    public class AlterarSenhaController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ISessao _sessao;

        public AlterarSenhaController(IUsuarioRepositorio usuarioRepositorio, ISessao sessao)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _sessao = sessao;
        }

        public IActionResult Index()
        {
            return View();
        }



        [HttpPost]
        public IActionResult Alterar(AlterarSenhaModel model)
        {
            try
            {
                UsuarioModel usuarioLogado = _sessao.BuscarSessaoUsuario();
                model.Id = usuarioLogado.Id;

                if (ModelState.IsValid)
                {

                    _usuarioRepositorio.AlterarSenha(model);
                    TempData["MensagemSucesso"] = "Senha alterada com suceso!";
                    return View("Index", model);
                }
                return View("Index", model);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos alterar sua senha, tente novamente, detalhe do erro: {erro.Message}";
                return View("Index", model);
                throw;
            }
        }
    }
}
