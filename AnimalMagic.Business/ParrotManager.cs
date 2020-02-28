using System;
using System.Collections.Generic;
using System.Linq;
using AnimalMagic.Entity;

namespace AnimalMagic.Business
{
    public class ParrotManager
    {
        public ICollection<Parrot> Parrots { get; private set; }

        public ParrotManager()
        {
            InitialiseParrotCollection();
        }

        private void InitialiseParrotCollection()
        {
            Parrots = new List<Parrot>
            {
                new Parrot { Name = "Bluey" },
                new Parrot { Name = "George" },
                new Parrot { Name = "Charlie" }
            };
        }

        public IEnumerable<Parrot> GetParrotsInReverseOrder()
        {
            return Parrots.OrderByDescending(p => p.Name);
        }

        public Parrot GetParrotByName(string parrotName)
        {
            return Parrots.Where(p => p.Name.Equals(parrotName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
        }

        public Parrot GetFirstParrot()
        {
            return Parrots.FirstOrDefault();
        }
    }
}
