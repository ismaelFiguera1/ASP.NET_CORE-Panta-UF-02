using Cistell_de_la_compra.Data;
using Cistell_de_la_compra.Models;
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

        public IActionResult InserirProducte()
        {
            return View("InserirProducte");
        }


        [HttpPost]
        public async Task<IActionResult> InserirProducte(Producte nouProducte)
        {
            if(!ModelState.IsValid)
            {
                return View(nouProducte);
            }

            

            var (resultat , missatge) = await Productes.AfegirProducte(nouProducte);

            

            if (resultat)
            {
                TempData["Missatge"]=missatge; 
                // Es guarda el missatge a TempData baix la clau "Missatge"
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Error = missatge;  
                // ViewBag es una propietat de ASPNET de passar les dades del controlador a la vista,
                // en aquest cas el missatge de error
                return View(nouProducte);
            }

            // La diferencia entre TempData i ViewBag, es en que TempData soporta els "redirect to action",
            // es a dir ViewBag per passar a la mateixa vista, tempData per passar a altres vistes
        }
    }
}
