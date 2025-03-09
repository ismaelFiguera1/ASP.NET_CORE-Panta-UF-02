using System.Text.Json;
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
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            UsuarisRepository ur = new UsuarisRepository();

            var userJSON = HttpContext.Session.GetString("User");

            Usuari user;

            if(userJSON != null)
            {
                user = JsonSerializer.Deserialize<Usuari>(userJSON);
            }
            else
            {
                user = ur.trobar(email, password);
                if(user != null)
                {
                    userJSON = JsonSerializer.Serialize(user);
                    HttpContext.Session.SetString("User", userJSON);
                    return RedirectToAction("Index", "Productes");
                }
                else
                {
                    TempData["ErrorMessage"] = "El usuari o la contrasenya son incorrectes";
                    return RedirectToAction("Login");
                }
            }

            

            return View();
        }
    }
}
