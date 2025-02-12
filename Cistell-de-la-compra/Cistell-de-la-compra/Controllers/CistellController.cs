using System.Text.Json;
using Cistell_de_la_compra.Data;
using Cistell_de_la_compra.Models;
using Cistell_de_la_compra.ViewModel;
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

            return View(cistell); // i aqui la llista de productes
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
        public IActionResult ActualitzarCistell2(string[] CodiFormulari, int[] QuantitatFormulari)
        {
            // es fica com array perque al form els inputs tenen el mateix name



            CistellProductesViewModel cistellProductes = new CistellProductesViewModel();

            var productes = cistellProductes.ObtenirProductes();
            var cistell = cistellProductes.ObtenirCistell();



            for (int i = 0; i < CodiFormulari.Length; i++)
            {
                string codi = CodiFormulari[i];
                int quantitat = QuantitatFormulari[i];

                cistell.Elements.Add(new ElementCistell { CodiProducte = codi, Quantitat = quantitat });
            }

            HttpContext.Session.SetString("Cistell", JsonSerializer.Serialize(cistell));

			

			

			return View("Factura", cistellProductes);


        }










    }
}
