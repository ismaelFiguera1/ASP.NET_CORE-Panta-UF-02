using System.Text.Json;
using Cistell_de_la_compra.Data;
using Cistell_de_la_compra.Models;
using Cistell_de_la_compra.Repository;
using Cistell_de_la_compra.ViewModel;
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





/*
        [HttpPost]
        public IActionResult ActualitzarCistell2(string[] CodiFormulari, int[] QuantitatFormulari)
        {
            // es fica com array perque al form els inputs tenen el mateix name

            ProductesRepository productsRepository = new();

            var sessio = HttpContext.Session;

            Cistell cistell;

            // Agafo la sessio i el cistell

            cistell = Cistell.ObtenirCistell(sessio);

            if (cistell != null)
            {



                // Primer sobreescribeixo el cistell

                    cistell.ModificarQuantitat(CodiFormulari, QuantitatFormulari);

                // Ara elimino del cistell els que el quantitat sigui 0

                foreach (var item in CodiFormulari)
                {
                    
                    var element = cistell.BuscarElement(item);

                    if (element!=null && element.Quantitat == 0) {
                        cistell.EliminarElement(item);
                    }
                }

                if (!cistell.Elements.Any())
                {
                    HttpContext.Session.Remove("Cistell");
                    return RedirectToAction("Index", "Productes");
                }
                else
                {
                    var productes = productsRepository.ObtenirProductes();
                    var factura = new FacturaViewModel();

                    foreach (var elementCistell in cistell.Elements)
                    {
                        foreach (var elementProducte in productes)
                        {
                            if(elementCistell.CodiProducte == elementProducte.CodiProducte)
                            {
                                factura.AfegirElement(elementCistell, elementProducte);

                            }
                        }
                    }

                    HttpContext.Session.Remove("Cistell");
                    factura.CalcularTotal();
                    return View("Factura", factura);
                }


                

            }


            return RedirectToAction("Index", "Productes");

        }

        */
    }
}
