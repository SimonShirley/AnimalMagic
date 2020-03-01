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
            List<Dog> dogCollection = _animalManager.Animals.Where(a => a is Dog).Cast<Dog>().OrderBy(d => d.Name).ToList();
            return View(dogCollection);
        }

        [HttpPost]
        public IActionResult Add(Dog dog)
        {
            if (ModelState.IsValid)
            {
                dog.Id = _animalManager.Animals.Max(a => a.Id) + 1;
                _animalManager.Animals.Add(dog);
                TempData["SuccessMessage"] = "Dog Added";
                return RedirectToAction(nameof(List));
            }

            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Edit(Dog newDog)
        {
            if (ModelState.IsValid)
            {
                if (_animalManager.Animals.FirstOrDefault(d => d.Id == newDog.Id) is Dog currentDog)
                {
                    currentDog.Name = newDog.Name;
                    currentDog.Sound = newDog.Sound;
                    currentDog.Legs = newDog.Legs;

                    TempData["SuccessMessage"] = "Dog Edited";
                }

                return RedirectToAction(nameof(List));
            }

            return View(newDog);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (!(_animalManager.Animals.FirstOrDefault(d => d.Id == id) is Dog currentDog))
            {
                TempData["ErrorMessage"] = "Invalid Dog Id";
                return RedirectToAction(nameof(List));
            }

            return View(currentDog);
        }

        [HttpDelete]
        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (_animalManager.Animals.Single(a => a.Id == id) is Dog dog)
            {
                _animalManager.Animals.Remove(dog);
                TempData["SuccessMessage"] = "Dog Deleted";
            }

            return RedirectToAction(nameof(List));
        }

        public IActionResult Details(int id)
        {
            var dog = _animalManager.Animals.SingleOrDefault(d => d.Id == id && d is Dog);

            if (dog == null)
            {
                TempData["ErrorMessage"] = "Invalid Dog Id";
                return RedirectToAction(nameof(List));
            }

            return View(dog);
        }
    }
}
