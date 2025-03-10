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

            if(userJSON == null)
            {
                user = ur.trobar(email, password);
                if (user != null)
                {
                    userJSON = JsonSerializer.Serialize(user);
                    HttpContext.Session.SetString("User", userJSON);
                    return RedirectToAction("Index", "Productes");
                }
                else
                {
                    bool verificat = ur.comprovarCorreu(email);
                    TempData["ErrorMessage"] = "El usuari o la contrasenya son incorrectes";
                    var intentsjson = HttpContext.Session.GetString("Intents");
                    int intents;
                    if(intentsjson==null)
                    {
                        intents = 1;
                    }
                    else
                    {
                        intents = JsonSerializer.Deserialize<int>(intentsjson);
                        intents++;
                    }
                    ur.controlIntents(intents);
                    intentsjson= JsonSerializer.Serialize(intents);
                    HttpContext.Session.SetString("Intents", intentsjson);
                    return RedirectToAction("Login");
                }
            }

            

            return View();
        }

        
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("User");
            TempData["ErrorMessage"] = "Has tancat la sessio";
            return RedirectToAction("Login");
        }
    }
}
