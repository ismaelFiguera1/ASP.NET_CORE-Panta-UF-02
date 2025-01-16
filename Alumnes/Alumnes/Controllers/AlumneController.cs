using Alumnes.Models;
using Microsoft.AspNetCore.Mvc;

namespace Alumnes.Controllers
{
    public class AlumneController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            // Aqui li passo la data maxima
            var fechaMaxima = DateTime.Now.AddYears(-5).ToString("yyyy-MM-dd");
            ViewBag.FechaMaxima = fechaMaxima;
            return View();
        }



        [HttpPost]
        public IActionResult Index(Alumne alumne)
        {
            if (!ModelState.IsValid)
            {
                // Si hay errores de validación, vuelve a la vista con el modelo y los mensajes de error.
                return View(alumne);
            }
            else
            {
                return View("Guardar", alumne);
            }
        }
    }
}
