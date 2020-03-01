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
                parrot.Id = _animalManager.Animals.Max(a => a.Id) + 1;
                _animalManager.Animals.Add(parrot);
                TempData["SuccessMessage"] = "Parrot Added";
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

                    TempData["SuccessMessage"] = "Parrot Edited";
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
            {
                _animalManager.Animals.Remove(parrot);
                TempData["SuccessMessage"] = "Parrot Deleted";
            }

            return RedirectToAction(nameof(List));
        }

        public IActionResult Details(int id)
        {
            var parrot = _animalManager.Animals.SingleOrDefault(p => p.Id == id && p is Parrot);

            if (parrot == null)
            {
                TempData["ErrorMessage"] = "Invalid Parrot Id";
                return RedirectToAction(nameof(List));
            }

            return View(parrot);
        }
    }
}
