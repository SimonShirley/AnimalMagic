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
            new Cat { Id = 1, Name = "Shanie" },
            new Cat { Id = 2, Name = "Flux", Legs = 3 },
            new Cat { Id = 3, Name = "Nalu" }
        };

        private static IEnumerable<Dog> GetDogs() => new List<Dog> {
            new Dog { Id = 4, Name = "Duke" },
            new Dog { Id = 5, Name = "Shilo" },
            new Dog { Id = 6, Name = "Blazer" }
        };

        private static IEnumerable<Parrot> GetParrots() => new List<Parrot>
        {
            new Parrot { Id = 7, Name = "Bluey" },
            new Parrot { Id = 8, Name = "George" },
            new Parrot { Id = 9, Name = "Charlie" }
        };

        public IDictionary<string, object> GetCategorisedAnimals()
        {
            var animalCollection = new Dictionary<string, object>
            {
                {
                    "Cats",
                    Animals.Where(c => c is Cat).Cast<Cat>().Select(c => new
                    {
                        c.Id,
                        c.Name,
                        c.Legs,
                        c.Sound,
                        Type = c.GetType().Name
                    })
                },

                {
                    "Dogs",
                    Animals.Where(d => d is Dog).Cast<Dog>().Select(d => new
                    {
                        d.Id,
                        d.Name,
                        d.Legs,
                        d.Sound,
                        Type = d.GetType().Name
                    })
                },

                {
                    "Parrots",
                    Animals.Where(p => p is Parrot).Cast<Parrot>().Select(p => new
                    {
                        p.Id,
                        p.Name,
                        p.Claws,
                        p.Sound,
                        Type = p.GetType().Name
                    })
                }
            };

            return animalCollection;
        }
    }
}
