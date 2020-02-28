using System;
using System.Collections.Generic;
using System.Linq;
using AnimalMagic.Entity;

namespace AnimalMagic.Business
{
    public class DogManager
    {
        public ICollection<Dog> Dogs { get; private set; }

        public DogManager()
        {
            InitialiseDogList();
        }

        private void InitialiseDogList()
        {
            Dogs = new List<Dog> {
                new Dog { Name = "Duke" },
                new Dog { Name = "Shilo" },
                new Dog { Name = "Blazer" }
            };
        }

        public IEnumerable<string> GetDogNames()
        {
            return Dogs.OrderBy(dog => dog.Name).Select(dog => dog.Name);
        }

        public void AddDog(Dog newDog)
        {
            Dogs.Add(newDog);
        }
    }
}