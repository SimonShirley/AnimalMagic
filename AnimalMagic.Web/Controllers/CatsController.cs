using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimalMagic.Business.Interfaces;
using AnimalMagic.Entity;
using Microsoft.AspNetCore.Mvc;

namespace AnimalMagic.Web.Controllers
{
    public class CatsController : Controller
    {
        private readonly IAnimalManager _animalManager;

        public CatsController(IAnimalManager animalManager)
        {
            _animalManager = animalManager;
        }

        public IActionResult Index()
        {
            return RedirectToAction(nameof(List));
        }

        public IActionResult List()
        {
            List<Cat> catCollection = _animalManager.Animals.Where(a => a is Cat).Cast<Cat>().OrderBy(c => c.Name).ToList();
            return View(catCollection);
        }

        [HttpPost]
        public IActionResult Add(Cat cat)
        {
            if (ModelState.IsValid)
            {
                _animalManager.Animals.Add(cat);
                TempData["AnimalAdded"] = true;
                return RedirectToAction(nameof(List));
            }

            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
    }
}
