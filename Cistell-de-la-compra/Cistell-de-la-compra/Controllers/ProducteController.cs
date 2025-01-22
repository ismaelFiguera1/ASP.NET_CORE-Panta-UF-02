using Microsoft.AspNetCore.Mvc;

namespace Cistell_de_la_compra.Controllers
{
    public class ProducteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
