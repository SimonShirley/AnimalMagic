using System;
using System.Collections.Generic;
using System.Linq;
using AnimalMagic.Business.Interfaces;
using AnimalMagic.Entity;

namespace AnimalMagic.Business
{
    public class AnimalManager : IAnimalManager
    {
        public IEnumerable<Animal> Animals { get; private set; }

        public AnimalManager()
        {
            InitialiseAnimalCollection();
        }

        private void InitialiseAnimalCollection()
        {
            var catManager = new CatManager();
            var dogManager = new DogManager();
            var parrotManager = new ParrotManager();

            var animalCollection = new List<Animal>();
            animalCollection.AddRange(catManager.Cats);
            animalCollection.AddRange(dogManager.Dogs);
            animalCollection.AddRange(parrotManager.Parrots);

            Animals = animalCollection;
        }

        public IEnumerable<Dog> GetDogsFromAnimalCollection()
        {
            return Animals.Where(a => a is Dog).Cast<Dog>();
        }
    }
}
