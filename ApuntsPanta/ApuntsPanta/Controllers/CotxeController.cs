using Microsoft.AspNetCore.Mvc;

namespace ApuntsPanta.Controllers
{
    public class CotxeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Guardar()
        {
            return Content("Guardat");
        }
    }
}
