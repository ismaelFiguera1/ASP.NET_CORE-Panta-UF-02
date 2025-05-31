using Microsoft.AspNetCore.Mvc;
using TaskAplication.Models;
using TaskAplication.Repository.Interfaces;

namespace TaskAplication.Controllers
{
    public class TasquesController : Controller
    {

        private ITasquesRepository _tasquesRepository;

        public TasquesController(ITasquesRepository pr)
        {
            this._tasquesRepository = pr;
        }



        [HttpGet]
        public IActionResult Index()
        {
            var llistaTasques = _tasquesRepository.getTasques();
            return View(llistaTasques);
        }

        [HttpPost]
        public IActionResult Esborrar(int idForm)
        {
            bool esborrat = _tasquesRepository.deleteTasques(idForm);
            if (esborrat)
            {
                TempData["Message"] = "Tasca esborrada correctament";
            }
            else
            {
                TempData["Message"] = "La tasca no s'ha pogut esborrar";
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult FormulariAlta()
        {
            Tasca task = new Tasca();
            return View("NewTask", task);
        }

        [HttpPost]
        public IActionResult FormulariAlta(Tasca tascaFormulari)
        {

            if (!ModelState.IsValid)
            {
                return View("NewTask", tascaFormulari);
            }


            bool alta = _tasquesRepository.postTasques(tascaFormulari);


            if (alta)
            {
                TempData["Message"] = "Tasca pujada";
            }
            else
            {
                TempData["Message"] = "Error al pujar la tasca";
            }
            return RedirectToAction("FormulariAlta");
        }
    }
}
