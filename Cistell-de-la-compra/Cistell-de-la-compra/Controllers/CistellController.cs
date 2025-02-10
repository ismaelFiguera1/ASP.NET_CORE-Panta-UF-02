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
        public IActionResult ActualitzarCistell(string CodiProducteFormulari, int QuantitatFormulari)
        {
            // Aqui recupero de la sessio el cistel, en certs casos pot ser null
            var cistellSessio = HttpContext.Session.GetString("Cistell");

            Cistell cistell;


            // Si la llista d'elements del cistell de la sessio NO esta buit agafo la llista de la sessio i ho fico a la variable
            if(!string.IsNullOrEmpty(cistellSessio))
            {
                cistell = JsonSerializer.Deserialize<Cistell>(cistellSessio);
            }
            else                                         // en cas contrari creo una llista d'elements buida
            {
                cistell = new Cistell();
            }

            // Aixi controlo que a la sessio hi hagi un cistell i si no es va sobreescribint


            /* Aqui mirem si l'element del formulari existeix ja al cistell, ho fem comparant un a un els codis de la llista amb el del formulari, si existeix l'element l'agafa,
            si no queda a null */
            ElementCistell element = null;
            foreach (var item in cistell.Elements)
            {
                if (item.CodiProducte == CodiProducteFormulari)
                {
                    element = item;
                    break;
                }
            }


            // Si l'element existeix a la llista, SEMPRE la quantitat sera 1, en canvi si no hi es ficara l'element amb els valors del formulari a la llista

            if (element != null)
            {
                element.Quantitat = 1;
            }
            else
            {
                cistell.Elements.Add(new ElementCistell { CodiProducte = CodiProducteFormulari, Quantitat = QuantitatFormulari });
            }

            // despres agafem el cistell amb la llista i ho pujem a la sessio

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





        [HttpGet]
        public IActionResult DebugCistell()
        {
            // Recupera el JSON del cistell desde la sesión
            var cistellJson = HttpContext.Session.GetString("Cistell");

            if (string.IsNullOrEmpty(cistellJson))
            {
                Console.WriteLine("No hay cistell en la sesión.");
                return Content("No hay cistell en la sesión.");
            }
            else
            {
                Console.WriteLine("Contenido del cistell en sesión:");
                Console.WriteLine(cistellJson);

                // También se puede deserializar para iterar sobre los elementos si se desea
                var cistell = JsonSerializer.Deserialize<Cistell>(cistellJson);
                foreach (var elemento in cistell.Elements)
                {
                    Console.WriteLine($"Código Producto: {elemento.CodiProducte}, Cantidad: {elemento.Quantitat}");
                }

                return Content("El contenido del cistell se ha listado en la terminal.");
            }
        }




    }
}
