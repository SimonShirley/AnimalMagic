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
            List<Parrot> parrotCollection = _animalManager.Animals.Where(a => a is Parrot).Cast<Parrot>().OrderBy(p => p.Name).ToList();
            return View(parrotCollection);
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

        [HttpPost]
        public IActionResult Edit(Parrot newParrot)
        {
            if (ModelState.IsValid)
            {
                if (_animalManager.Animals.FirstOrDefault(p => p.Id == newParrot.Id) is Parrot currentParrot)
                {
                    currentParrot.Name = newParrot.Name;
                    currentParrot.Sound = newParrot.Sound;
                    currentParrot.Claws = newParrot.Claws;
                }

                return RedirectToAction(nameof(List));
            }

            return View(newParrot);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (!(_animalManager.Animals.FirstOrDefault(p => p.Id == id) is Parrot currentParrot))
            {
                TempData["ErrorMessage"] = "Invalid Parrot Id";
                return RedirectToAction(nameof(List));
            }

            return View(currentParrot);
        }

        [HttpDelete]
        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (_animalManager.Animals.Single(a => a.Id == id) is Parrot parrot)
                _animalManager.Animals.Remove(parrot);

            return RedirectToAction(nameof(List));
        }
    }
}
