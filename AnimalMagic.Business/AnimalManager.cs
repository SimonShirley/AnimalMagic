using System;
using System.Collections.Generic;
using System.Linq;
using AnimalMagic.Entity;

namespace AnimalMagic.Business
{
    public class AnimalManager
    {
        public ICollection<Animal> Animals { get; private set; }

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
        }

        public IEnumerable<Dog> GetDogsFromAnimalCollection()
        {
            return Animals.Where(a => a is Dog).Cast<Dog>();
        }
    }
}
