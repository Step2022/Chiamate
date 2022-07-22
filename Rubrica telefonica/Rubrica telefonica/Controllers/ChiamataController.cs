using Microsoft.AspNetCore.Mvc;
using Rubrica_telefonica.DAO;
using Rubrica_telefonica.Database;

namespace Rubrica_telefonica.Controllers
{
    public class ChiamataController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        DaoChiamata d = new DaoChiamata(new CorsoRoma2022Context());
    }
}
