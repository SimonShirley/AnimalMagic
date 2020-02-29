using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimalMagic.Business.Interfaces;
using AnimalMagic.Entity;
using Microsoft.AspNetCore.Mvc;

namespace AnimalMagic.Web.Controllers
{
    public class ParrotsController : Controller
    {
        private readonly IAnimalManager _animalManager;

        public ParrotsController(IAnimalManager animalManager)
        {
            _animalManager = animalManager;
        }

        public IActionResult Index()
        {
            return RedirectToAction(nameof(List));
        }

        public IActionResult List()
        {
            List<Parrot> dogCollection = _animalManager.Animals.Where(a => a is Parrot).Cast<Parrot>().OrderBy(p => p.Name).ToList();
            return View(dogCollection);
        }

        [HttpPost]
        public IActionResult Add(Parrot parrot)
        {
            if (ModelState.IsValid)
            {
                _animalManager.Animals.Add(parrot);
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
