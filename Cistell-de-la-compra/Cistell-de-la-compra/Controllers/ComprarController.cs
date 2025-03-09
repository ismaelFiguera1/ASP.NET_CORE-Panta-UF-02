using Cistell_de_la_compra.Models;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace Cistell_de_la_compra.Controllers
{
    public class ComprarController : Controller
    {
        public IActionResult Cancelar()
        {
            var cistell = HttpContext.Session.GetString("Cistell");

            if(cistell!=null)
            {
                HttpContext.Session.Remove("Cistell");
            }

            
            return View();
        }

        public IActionResult Acceptat()
        {
            var facturaJSON = HttpContext.Session.GetString("Factura");

            var factura = JsonSerializer.Deserialize<Factura>(facturaJSON);


            return View(factura);

            
        }
    }
}
