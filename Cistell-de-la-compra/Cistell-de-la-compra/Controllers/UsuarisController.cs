using System.Text.Json;
using Cistell_de_la_compra.Models;

using Cistell_de_la_compra.Repository.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Cistell_de_la_compra.Controllers
{
    public class UsuarisController : Controller
    {
        private IUsuarisRepository _usuarisRepository;

		public UsuarisController(IUsuarisRepository _usuarisRepository)
		{

			this._usuarisRepository = _usuarisRepository;
		}

		[HttpGet]
        public IActionResult Login()
        {
            return View();
        }



        [HttpPost]
        public IActionResult Login(string email, string password)
        {


            var userJSON = HttpContext.Session.GetString("User");

            Usuari user;

            if(userJSON == null)
            {
                string missatgeBloquejat=null;
                (user, missatgeBloquejat) = _usuarisRepository.trobar(email, password);
                if (missatgeBloquejat != null)
                {
                    TempData["ErrorMessage"] = missatgeBloquejat;
                    return View();
                }
                else
                {
                    if (user != null)
                    {
						_usuarisRepository.esborrarIntents(user);
                        userJSON = JsonSerializer.Serialize(user);
                        HttpContext.Session.SetString("User", userJSON);
                        return RedirectToAction("Index", "Productes");
                    }
                    else
                    {
                        bool verificat = _usuarisRepository.comprovarCorreu(email);
                        _usuarisRepository.controlIntents(verificat, email);
                        TempData["ErrorMessage"] = "El usuari o la contrasenya son incorrectes";


                        return RedirectToAction("Login");
                    }
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
