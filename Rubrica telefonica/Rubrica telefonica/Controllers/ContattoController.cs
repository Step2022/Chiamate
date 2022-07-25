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
        DaoNumero dNumero = new DaoNumero(new CorsoRoma2022Context());


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
                // HttpContext.Session.SetString("Numero", Serializzazione.Serialize(numero));
                var numero = Serializzazione.DeSerialize<Numero>(HttpContext.Session.GetString("Utente"));
                d.GetContatti(numero.IdNumero);
                return View();
            }
            else
            {
                return View("Login");
            }
        }



        [HttpGet]
        public IActionResult Aggiungi()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Aggiungi(Contatto contatto, string Cellulare)
        {

            //    var numero = Serializzazione.DeSerialize<Numero>(HttpContext.Session.GetString("Utente"));
            //    contatto.IdPropietario = numero.IdNumero;

            var numero=    dNumero.CheckNumero(Cellulare);
            contatto.IdCellulare = numero.IdNumero;
            ViewBag.Succes = "Errore nell'aggiuta del contatto";
          return  d.AddContatto(contatto) ?  View("Contatti"):View("Aggiungi");
        }
    }
}
