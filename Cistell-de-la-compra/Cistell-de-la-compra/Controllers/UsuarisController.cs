using Cistell_de_la_compra.Models;
using Cistell_de_la_compra.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Cistell_de_la_compra.Controllers
{
    public class UsuarisController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View(new Usuari());
        }

        [HttpPost]
        public IActionResult Login(Usuari usuari)
        {
            UsuarisRepository ur = new();
            if (!ur.Existeix(usuari.email)) {
                ModelState.AddModelError("email", "Usuari inexistent");
            }
            else if(!ur.CheckUsuari(usuari.email, usuari.password))
            {
				ModelState.AddModelError("password", "Contrasenya incorrecta");
			}

            if(ModelState.IsValid)
            {
                Usuari u = ur.GetUsuari(usuari.email);
                Usuari.GuardarUsuariSessio(HttpContext, usuari.email);
                RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}
