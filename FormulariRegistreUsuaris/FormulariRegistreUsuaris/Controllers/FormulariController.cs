using Microsoft.AspNetCore.Mvc;

namespace FormulariRegistreUsuaris.Controllers
{
    public class FormulariController : Controller
    {
        public IActionResult Formulari()
        {
            return View();
        }
    }
}
