using System;
using System.Collections.Generic;
using System.Linq;
using AnimalMagic.Business.Interfaces;
using AnimalMagic.Entity;

namespace AnimalMagic.Business
{
    public class CatManager : ICatManager
    {
        public ICollection<Cat> Cats { get; private set; }

        public CatManager()
        {
            InitialiseCatList();
        }

        private void InitialiseCatList()
        {
            Cats = new List<Cat> {
                new Cat { Name = "Shanie" },
                new Cat { Name = "Flux", Legs = 3 },
                new Cat { Name = "Nalu" }
            };
        }

        public IEnumerable<Cat> GetCatsWithThreeLegs()
        {
            return Cats.Where(cat => cat.Legs == 3);
        }

        public IEnumerable<string> GetCatNames()
        {
            return Cats.Select(cat => cat.Name);
        }

        public void AddCat(Cat newCat)
        {
            Cats.Add(newCat);
        }
    }
}
