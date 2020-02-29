using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimalMagic.Business.Interfaces;
using AnimalMagic.Entity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AnimalMagic.Web.Controllers
{
    public class DogsController : Controller
    {
        private readonly IAnimalManager _animalManager;

        public DogsController(IAnimalManager animalManager)
        {
            _animalManager = animalManager;
        }

        public IActionResult Index()
        {
            return RedirectToAction(nameof(List));
        }

        public IActionResult List()
        {
            List<Dog> dogCollection = _animalManager.Animals.Where(a => a is Dog).Cast<Dog>().ToList();
            return View(dogCollection);
        }

        [HttpPost]
        public IActionResult Add(Dog dog)
        {
            if (ModelState.IsValid)
            {
                _animalManager.Animals.Add(dog);
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
