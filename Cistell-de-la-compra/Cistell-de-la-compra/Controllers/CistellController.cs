using System.Text.Json;
using Cistell_de_la_compra.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cistell_de_la_compra.Controllers
{
    public class CistellController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ActualitzarCistell(Cistell cistell)
        {
            // Aqui serialitzo la cesta a JSON i ho guardo en la sessio
            HttpContext.Session.SetString("Cistell", JsonSerializer.Serialize(cistell));

           
            return RedirectToAction("Index", "Productes");
        }



        public IActionResult LeerCistell()
        {
            // Obtener el JSON guardado en la sesión
            var cistellJson = HttpContext.Session.GetString("Cistell");

            if (!string.IsNullOrEmpty(cistellJson))
            {
                // Deserializar el JSON a un objeto Cistell
                var cistell = JsonSerializer.Deserialize<Cistell>(cistellJson);

                // Mostrar valores (para probar)
                Console.WriteLine($"Cocacola: {cistell.Cocacola}");
                Console.WriteLine($"Patata: {cistell.Patata}");
                Console.WriteLine($"Lejia: {cistell.Lejia}");
            }
            else
            {
                Console.WriteLine("El cesto está vacío o no existe en la sesión.");
            }

            return RedirectToAction("Index", "Productes");
        }


    }
}
