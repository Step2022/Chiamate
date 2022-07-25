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

        DaoChiamata daoChia = new DaoChiamata(new CorsoRoma2022Context());
        DaoContatto daoCont = new DaoContatto(new CorsoRoma2022Context());
        [HttpPost]
        public IActionResult Start(int idChiamante, string numeroRicevente)
        {
            Chiamatum chiam = daoChia.StartChiamata(idChiamante, numeroRicevente);
            if (daoCont.checkContatto(idChiamante, chiam.IdRicevente) == true) {
                Contatto cont = daoCont.GetContatto(chiam.IdRicevente, chiam.IdChiamante);
                ViewData["contatto"] = cont;
            }
            return View(chiam);
        }
        [HttpPost]
        public string End(int idChiamata)
        {
            try
            {
                Chiamatum chia = daoChia.EndChiamata(idChiamata);
                return "Success";
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return "Error";
            }
        }
    }
}
