using Cistell_de_la_compra.Data;
using Cistell_de_la_compra.Models;
using Cistell_de_la_compra.Repository.interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Cistell_de_la_compra.Controllers
{
    public class ProductesController : Controller
    {
        private IProductesRepository _productsRepository;

        public ProductesController(IProductesRepository pr)
        {
            this._productsRepository = pr;
        }



		public IActionResult Index()
        {
            var userJSON = HttpContext.Session.GetString("User");


            Usuari user;

            if (userJSON == null)
            {
				TempData["ErrorMessage"] = "Per veurer els productes tens que iniciar la sessio";
				return RedirectToAction("Login", "Usuaris");
			}
            else
            {
				user = JsonSerializer.Deserialize<Usuari>(userJSON);
			}

            if (user.isAdmin == true)
            {
                TempData["ErrorMessage"] = "El teu usuari te permissos de administracio";
                return RedirectToAction("InserirProducte");
            }

            
            var productes = _productsRepository.ObtenirProductes();  



            return View(productes);    /* A la vista li passem els productes */
        }

        [HttpGet]
        public IActionResult InserirProducte()
        {
            var userJSON = HttpContext.Session.GetString("User");

            if(userJSON == null)
            {
                TempData["ErrorMessage"] = "Per afegir productes tens que iniciar sessio";
                return RedirectToAction("Login", "Usuaris");
            }

            Usuari user = JsonSerializer.Deserialize<Usuari>(userJSON);

            if(user.isAdmin == false)
            {
                TempData["ErrorMessage"] = "El teu usuari no te permissos de administracio";
                return RedirectToAction("Index");
            }



            return View();
        }


        [HttpPost]
        public async Task<IActionResult> InserirProducte(Producte nouProducte)
        {
            if(!ModelState.IsValid)
            {
                return View(nouProducte);
            }

            

            var (resultat , missatge) = await _productsRepository.AfegirProducte(nouProducte);

            

            if (resultat)
            {
                TempData["MissatgeExit"]=missatge;
                // Es guarda el missatge a TempData baix la clau "MissatgeExit"
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
