using System.Text.Json;
using Cistell_de_la_compra.Data;
using Cistell_de_la_compra.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cistell_de_la_compra.Controllers
{
    public class CistellController : Controller
    {
        public IActionResult Index()
        {
            var productes = Productes.ObtenirProductes();
            var cistellJson = HttpContext.Session.GetString("Cistell");

            Cistell cistell;

            if(!string.IsNullOrEmpty(cistellJson))
            {
                cistell = JsonSerializer.Deserialize<Cistell>(cistellJson);
            }
            else
            {
                cistell = new Cistell(); // tan si com no, necessito retornar algo
            }

            ViewData["Cistell"] = cistell; // Aqui envio a la view el model cistell

            return View(productes); // i aqui la llista de productes
        }

        [HttpPost]
        public IActionResult ActualitzarCistell(Cistell cistell)
        {
            // Aqui serialitzo la cesta a JSON i ho guardo en la sessio
            HttpContext.Session.SetString("Cistell", JsonSerializer.Serialize(cistell));

           
            return RedirectToAction("Index", "Productes");
        }



        [HttpPost]
        public IActionResult ActualitzarCistell2(Cistell cistell)
        {
            // Aqui serialitzo la cesta a JSON i ho guardo en la sessio
            HttpContext.Session.SetString("Cistell", JsonSerializer.Serialize(cistell));

            var productes = Productes.ObtenirProductes();
            var cistellJson = HttpContext.Session.GetString("Cistell");

            Cistell cistell1;

            if (!string.IsNullOrEmpty(cistellJson))
            {
                cistell1 = JsonSerializer.Deserialize<Cistell>(cistellJson);
            }
            else
            {
                cistell1 = new Cistell();
            }

            ViewData["Cistell"] = cistell1;


            return View("Factura", productes);
        }



    }
}
