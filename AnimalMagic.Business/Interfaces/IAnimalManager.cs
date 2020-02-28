using System.Collections.Generic;
using AnimalMagic.Entity;

namespace AnimalMagic.Business.Interfaces
{
    public interface IAnimalManager
    {
        IEnumerable<Animal> Animals { get; }

        IEnumerable<Dog> GetDogsFromAnimalCollection();
    }
}