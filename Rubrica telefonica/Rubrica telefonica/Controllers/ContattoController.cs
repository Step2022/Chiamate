using Microsoft.AspNetCore.Mvc;
using Rubrica_telefonica.DAO;
using Rubrica_telefonica.Database;

namespace Rubrica_telefonica.Controllers
{
    public class ContattoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

       DaoContatto d = new DaoContatto(new CorsoRoma2022Context());


        
    }
}
