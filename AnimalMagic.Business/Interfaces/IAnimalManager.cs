using System.Collections.Generic;
using AnimalMagic.Entity;

namespace AnimalMagic.Business.Interfaces
{
    public interface IAnimalManager
    {
        ICollection<Animal> Animals { get; }
    }
}