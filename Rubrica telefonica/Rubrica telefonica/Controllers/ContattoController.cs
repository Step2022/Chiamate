﻿using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Edit(int IdContatto)
        {
            var numero = Serializzazione.DeSerialize<Numero>(HttpContext.Session.GetString("Numero"));
           var contatto= d.GetContatto(IdContatto, numero.IdNumero);
            return View(contatto);
        }
        [HttpPost]
        public IActionResult Edit(Contatto contatto, string Cellulare)
        {
            ViewBag.Errore = "Errore nella modifica del contatto";
            return  d.EditContatto(contatto, Cellulare) ? RedirectToAction("Contatti","Home") : View("Edit");

        }
        /*  fatta matteo uguale nell index
        public IActionResult Contatti()
        {
            if (HttpContext.Session.GetString("Numero") != null)
            {
                // HttpContext.Session.SetString("Numero", Serializzazione.Serialize(numero));
                var numero = Serializzazione.DeSerialize<Numero>(HttpContext.Session.GetString("Numero"));
               var contatti= d.GetContatti(numero.IdNumero);
                return View(contatti);
            }
            else
            {
                return View("Login");
            }
        }
        */


        [HttpGet]
        public IActionResult Aggiungi()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Aggiungi(Contatto contatto, string Cellulare)
        {

            if (HttpContext.Session.GetString("Numero") != null)
            {
                Numero numero = Serializzazione.DeSerialize<Numero>(HttpContext.Session.GetString("Numero"));
                contatto.IdPropietario = numero.IdNumero;

                var cellulare = dNumero.CheckNumero(Cellulare);
                contatto.IdCellulare = cellulare.IdNumero;
                ViewBag.Succes = "Errore nell'aggiuta del contatto";
                return d.AddContatto(contatto) ? RedirectToAction("Contatti", "Home") : View("Aggiungi");
            }
            else
            {
                return View("Index", "Home");
            }
        }

        public IActionResult Remove(int idContatto)
        {
            var numero = Serializzazione.DeSerialize<Numero>(HttpContext.Session.GetString("Numero"));
            d.RemoveContatto(idContatto, numero.IdNumero);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Dettaglio(int IdContatto)
        {
            var numero = Serializzazione.DeSerialize<Numero>(HttpContext.Session.GetString("Numero"));

            return d.GetContattoInclude(IdContatto, numero.IdNumero) != null ? View(d.GetContattoInclude(IdContatto, numero.IdNumero)) : RedirectToAction("Contatti", "Home");
        }
    }
}
