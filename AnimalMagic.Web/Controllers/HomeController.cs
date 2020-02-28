using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AnimalMagic.Web.Models;
using AnimalMagic.Business.Interfaces;
using AnimalMagic.Business;
using AnimalMagic.Entity;

namespace AnimalMagic.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAnimalManager _animalManager;

        public HomeController(ILogger<HomeController> logger, IAnimalManager animalManager)
        {
            _logger = logger;
            _animalManager = animalManager;
        }

        public IActionResult Index()
        {
            return View(_animalManager.Animals);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        // Return list of animals as Json - This might be cheating!!
        [HttpGet]
        public IEnumerable<Animal> GetAnimals() => _animalManager.Animals;

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
