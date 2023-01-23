using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class ListController : Controller
    {
        private readonly IMenadzerListy menadzer;

        public ListController(IMenadzerListy menadzer)
        {
            this.menadzer = menadzer;
        }

        public IActionResult DodajZadanie()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DodajZadanie(Zadania zadania)
        {
            menadzer.DodajZadanie(zadania);
            return RedirectToAction("ListaZadan");
        }


        public IActionResult ListaZadan()
        {
            ViewBag.Zadania = menadzer.ListaZadan(false);
            return View();
        }

        [HttpPost]
        public IActionResult UsunZadanie(Zadania zadania)
        {
            menadzer.UsunZadanie(zadania);
            return RedirectToAction("ListaZadan");
        }

        [HttpPost]
        public IActionResult AkceptujZadanie(Zadania zadania)
        {
            menadzer.Zrobione(zadania);
            return RedirectToAction("ListaZadan");
        }

        public IActionResult ListaZrobionych()
        {
            ViewBag.Zadania = menadzer.ListaZadan(true);
            return View();
        }

        [HttpPost]
        public IActionResult EdytujZadanie(Zadania zadania)
        {
            if (zadania.Tytul == null)
            {
                ViewBag.Zadanie = menadzer.PojedynczeZadanie(zadania.IdZadania);
                return View();
            }
            else
            {
                menadzer.EdytujZadanie(zadania);
                return RedirectToAction("ListaZadan");
            }
        }
    }
}
