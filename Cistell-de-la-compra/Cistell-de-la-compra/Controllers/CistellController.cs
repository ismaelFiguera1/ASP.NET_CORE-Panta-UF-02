using System.Text.Json;
using Cistell_de_la_compra.Data;
using Cistell_de_la_compra.Models;
using Cistell_de_la_compra.Repository;
using Cistell_de_la_compra.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cistell_de_la_compra.Controllers
{
    public class CistellController : Controller
    {




        public IActionResult Index()
        {

            var cistellJson = HttpContext.Session.GetString("Cistell");

            Cistell cistell;

            if(!string.IsNullOrEmpty(cistellJson))
            {
                cistell = JsonSerializer.Deserialize<Cistell>(cistellJson);
            }
            else
            {
                cistell = Cistell.CrearCistell(); // tan si com no, necessito retornar algo
            }

            

            return View(cistell); 
        }

        [HttpPost]
        public IActionResult AgafarProductes(string CodiProducteFormulari, int QuantitatFormulari)
        {
            var sessio = HttpContext.Session;

            Cistell cistell;

            // Agafo la sessio i el cistell

            cistell=Cistell.ObtenirCistell(sessio);

            if(cistell==null)
            {
                cistell = Cistell.CrearCistell();
            }

            // Ara que tinc el cistell tinc que afegir els productes

            cistell.AfegirElement(CodiProducteFormulari, QuantitatFormulari);

            string cistellJSON = JsonSerializer.Serialize(cistell);

            sessio.SetString("Cistell", cistellJSON);

            return RedirectToAction("Index", "Productes");
        }






        [HttpPost]
        public IActionResult ActualitzarCistell2(string[] CodiFormulari, int[] QuantitatFormulari, string action)
        {
            var cistellJson = HttpContext.Session.GetString("Cistell");

            Cistell cistell;

            if (!string.IsNullOrEmpty(cistellJson))
            {
                cistell = JsonSerializer.Deserialize<Cistell>(cistellJson);
            }
            else
            {
                cistell = Cistell.CrearCistell(); // tan si com no, necessito retornar algo
            }

            if(action == "comprar")
            {
                if (cistellJson != null)
                {
                    cistell.ModificarCistell(CodiFormulari, QuantitatFormulari);

                    Factura factura = new Factura();

                    factura.cistell = cistell;

                    HttpContext.Session.Remove("Cistell");
                    string facturaJSON = JsonSerializer.Serialize(factura);

                    HttpContext.Session.SetString("Factura", facturaJSON);

                    return RedirectToAction("Acceptat", "Comprar");
                }
                else
                {
                    return RedirectToAction("Cancelar", "Comprar");
                }
            }
            else if(action == "actualitzar")
            {
                if (cistellJson != null)
                {
                    cistell.ModificarCistell(CodiFormulari, QuantitatFormulari);
                    var cistellJSON = JsonSerializer.Serialize(cistell);
                    HttpContext.Session.SetString("Cistell", cistellJSON);
                    return RedirectToAction("Index", "Cistell");
                }
                else
                {
                    return RedirectToAction("Index", "Cistell");
                }
            }
            else if (action == "cancel")
            {
                return RedirectToAction("Cancelar", "Comprar");
            }

            return RedirectToAction("Cancelar", "Comprar");

        }

        
    }
}
