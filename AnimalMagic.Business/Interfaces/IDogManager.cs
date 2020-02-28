using System.Collections.Generic;
using AnimalMagic.Entity;

namespace AnimalMagic.Business.Interfaces
{
    public interface IDogManager
    {
        ICollection<Dog> Dogs { get; }

        void AddDog(Dog newDog);
        IEnumerable<string> GetDogNames();
    }
}