using Cistell_de_la_compra.Data;
using Microsoft.AspNetCore.Mvc;

namespace Cistell_de_la_compra.Controllers
{
    public class ProductesController : Controller
    {
        public IActionResult Index()
        {
            var productes = Productes.ObtenirProductes();    /* Aqui fem una instancia del model per recuperar el llistat i ho passarem a la llista */



            return View(productes);    /* A la vista li passem un model */
        }
    }
}
