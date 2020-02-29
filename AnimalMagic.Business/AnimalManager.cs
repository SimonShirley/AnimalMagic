using System;
using System.Collections.Generic;
using System.Linq;
using AnimalMagic.Business.Interfaces;
using AnimalMagic.Entity;

namespace AnimalMagic.Business
{
    public class AnimalManager : IAnimalManager
    {
        public ICollection<Animal> Animals { get; set; }

        public AnimalManager()
        {
            InitialiseAnimalCollection();
        }

        private void InitialiseAnimalCollection()
        {
            var animalCollection = new List<Animal>();
            animalCollection.AddRange(GetCats());
            animalCollection.AddRange(GetDogs());
            animalCollection.AddRange(GetParrots());

            Animals = animalCollection;
        }

        private static IEnumerable<Cat> GetCats() => new List<Cat> {
            new Cat { Name = "Shanie" },
            new Cat { Name = "Flux", Legs = 3 },
            new Cat { Name = "Nalu" }
        };

        private static IEnumerable<Dog> GetDogs() => new List<Dog> {
            new Dog { Name = "Duke" },
            new Dog { Name = "Shilo" },
            new Dog { Name = "Blazer" }
        };

        private static IEnumerable<Parrot> GetParrots() => new List<Parrot>
        {
            new Parrot { Name = "Bluey" },
            new Parrot { Name = "George" },
            new Parrot { Name = "Charlie" }
        };
    }
}
