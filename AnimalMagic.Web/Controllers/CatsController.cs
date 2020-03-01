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
                cat.Id = _animalManager.Animals.Max(a => a.Id) + 1;
                _animalManager.Animals.Add(cat);
                TempData["SuccessMessage"] = "New Cat Added";
                return RedirectToAction(nameof(List));
            }

            return View(cat);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Edit(Cat newCat)
        {
            if (ModelState.IsValid)
            {
                if (_animalManager.Animals.FirstOrDefault(c => c.Id == newCat.Id) is Cat currentCat)
                {
                    currentCat.Name = newCat.Name;
                    currentCat.Sound = newCat.Sound;
                    currentCat.Legs = newCat.Legs;

                    TempData["SuccessMessage"] = "Cat Edited";
                }
                                
                return RedirectToAction(nameof(List));
            }

            return View(newCat);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (!(_animalManager.Animals.FirstOrDefault(c => c.Id == id) is Cat currentCat))
            {
                TempData["ErrorMessage"] = "Invalid Cat Id";
                return RedirectToAction(nameof(List));
            }

            return View(currentCat);
        }

        [HttpDelete]
        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (_animalManager.Animals.Single(a => a.Id == id) is Cat cat)
            {
                _animalManager.Animals.Remove(cat);
                TempData["SuccessMessage"] = "Cat Deleted";
            }

            return RedirectToAction(nameof(List));
        }
    }
}
