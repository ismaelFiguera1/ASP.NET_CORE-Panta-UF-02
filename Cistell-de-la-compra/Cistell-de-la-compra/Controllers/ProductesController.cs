using Cistell_de_la_compra.Data;
using Cistell_de_la_compra.Models;
using Cistell_de_la_compra.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Cistell_de_la_compra.Controllers
{
    public class ProductesController : Controller
    {
        public IActionResult Index()
        {

            ProductesRepository productsRepository = new();
            var productes = productsRepository.ObtenirProductes();  



            return View(productes);    /* A la vista li passem els productes */
        }

        [HttpGet]
        public IActionResult InserirProducte()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> InserirProducte(Producte nouProducte)
        {
            if(!ModelState.IsValid)
            {
                return View(nouProducte);
            }

            ProductesRepository productesRepository = new();

            var (resultat , missatge) = await productesRepository.AfegirProducte(nouProducte);

            

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
