using System;
using System.Collections.Generic;
using AnimalMagic.Business.Interfaces;
using AnimalMagic.Entity;
using Microsoft.AspNetCore.Mvc;

namespace AnimalMagic.Web.Controllers
{
    public class AnimalsController : Controller
    {
        private readonly IAnimalManager _animalManager;

        public AnimalsController(IAnimalManager animalManager)
        {
            _animalManager = animalManager;
        }

        public IActionResult Index()
        {
            return RedirectToAction(nameof(List));
        }

        public IActionResult List()
        {
            return View(_animalManager.Animals);
        }

        // Return list of animals as Json - This might be cheating!!
        [HttpGet]
        public IEnumerable<Animal> GetAnimals() => _animalManager.Animals;
    }
}
