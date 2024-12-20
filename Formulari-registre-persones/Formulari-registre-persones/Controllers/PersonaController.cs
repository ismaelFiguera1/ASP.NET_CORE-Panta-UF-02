using Microsoft.AspNetCore.Mvc;

namespace Formulari_registre_persones.Controllers
{
    public class PersonaController : Controller
    {
        public IActionResult FormulariRegistre()
        {
            return View();
        }

        public IActionResult Guardar()
        {
            return Content("Persona registrada guardada correctament");
        }
    }
}
