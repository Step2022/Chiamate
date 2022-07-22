using Microsoft.AspNetCore.Mvc;

namespace Rubrica_telefonica.Controllers
{
    public class ContattoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Aggiungi()
        {
            return View();
        }
    }
}
