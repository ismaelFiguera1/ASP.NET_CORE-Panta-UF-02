using FormulariRegistreUsuaris.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace FormulariRegistreUsuaris.Controllers
{
    public class HomeController : Controller
    {




        public IActionResult Resultat()
            {
            Usuari myuser = new Usuari
            {
                nom = "Pere",
            };


            ModelState.ClearValidationState(nameof(Usuari));
            if(!TryValidateModel(myuser, nameof(Usuari)))
            {
                return Content("ERROR");
            }
            else
            {
                return Content("OK");
            }
        }




        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
