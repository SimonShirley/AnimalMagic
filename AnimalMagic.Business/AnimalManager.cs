using System;
using System.Collections.Generic;
using System.Linq;
using AnimalMagic.Business.Interfaces;
using AnimalMagic.Entity;
using Microsoft.Extensions.Caching.Memory;

namespace AnimalMagic.Business
{
    public class AnimalManager : IAnimalManager
    {
        private readonly IMemoryCache _cache;

        public ICollection<Animal> Animals {
            get
            {
                _cache.TryGetValue("AnimalCollection", out ICollection<Animal> animals);

                if (animals == null)
                {
                    animals = InitialiseAnimalCollection();
                    _cache.Set("AnimalCollection", animals, DateTime.Today.AddDays(1));
                }

                return animals;
            }
        }

        public AnimalManager(IMemoryCache cache)
        {
            _cache = cache;
        }

        private ICollection<Animal> InitialiseAnimalCollection()
        {
            var animalCollection = new List<Animal>();
            animalCollection.AddRange(GetCats());
            animalCollection.AddRange(GetDogs());
            animalCollection.AddRange(GetParrots());

            return animalCollection;
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
