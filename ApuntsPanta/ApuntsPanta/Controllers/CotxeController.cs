using ApuntsPanta.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApuntsPanta.Controllers
{
    public class CotxeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult Index(Cotxes cv)
        {
           
            return View();
        }

        public IActionResult Guardar()
        {
            return Content("Guardat");
        }

        public IActionResult Guardar(CotxeViewModel cvm)
        {
            string str = "Matricula: " + cvm.ElCotxe.matricula;
            return Content(str);
        }
    }
}
