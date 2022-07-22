using Microsoft.AspNetCore.Mvc;
using Rubrica_telefonica.DAO;
using Rubrica_telefonica.Database;
using Rubrica_telefonica.Models;
using System.Diagnostics;

namespace Rubrica_telefonica.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        DaoContatto daoContatto = new DaoContatto(new CorsoRoma2022Context());
        DaoChiamata daoChiamata = new DaoChiamata(new CorsoRoma2022Context());

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}