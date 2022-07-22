using Microsoft.AspNetCore.Mvc;
using Rubrica_telefonica.DAO;
using Rubrica_telefonica.Database;
using Rubrica_telefonica.Utility;

namespace Rubrica_telefonica.Controllers
{
    public class ContattoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

       DaoContatto d = new DaoContatto(new CorsoRoma2022Context());

        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Edit(Contatto contatto)
        {
            ViewBag.Errore = "Errore nella modifica del contatto";
            return  d.EditContatto(contatto) ? View("Contatti") : View("Edit");

        }

        public IActionResult Contatti()
        {
            if (HttpContext.Session != null)
            {
                // HttpContext.Session.SetString("Numero", Serializzazione.Serialize(utente));
                var numero = Serializzazione.DeSerialize<Numero>(HttpContext.Session.GetString("Numero"));
                d.GetContatti(numero.IdNumero);
                return View();
            }
            else
            {
                return View("Login");
            }
        }

        


        public IActionResult Aggiungi()
        {
            return View();
        }
    }
}
