using Microsoft.AspNetCore.Mvc;
using Rubrica_telefonica.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Rubrica_telefonica.DAO;
using Rubrica_telefonica.Database;
using Rubrica_telefonica.Utility;

namespace Rubrica_telefonica.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        DaoNumero daoNum = new DaoNumero(new CorsoRoma2022Context());
        DaoContatto daoCont = new DaoContatto(new CorsoRoma2022Context());
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public string Login(string numerotelefono)
        {
            var num = Serializzazione.Serialize(daoNum.CheckNumero(numerotelefono));
            HttpContext.Session.SetString("Numero",num);
            return num;
        }
        public IActionResult Contatti()
        {
            if (HttpContext.Session.GetString("Numero") != null)
            {
                Numero num = Serializzazione.DeSerialize<Numero>(HttpContext.Session.GetString("Numero"));
                return View(daoCont.GetContatti(num.IdNumero));
            }
            else
            {
                return View();
            }
            
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