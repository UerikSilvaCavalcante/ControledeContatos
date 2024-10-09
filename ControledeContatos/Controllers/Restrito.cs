using Microsoft.AspNetCore.Mvc;

namespace ControledeContatos.Controllers
{
    public class Restrito : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
