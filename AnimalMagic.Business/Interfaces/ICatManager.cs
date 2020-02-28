using System.Collections.Generic;
using AnimalMagic.Entity;

namespace AnimalMagic.Business.Interfaces
{
    public interface ICatManager
    {
        ICollection<Cat> Cats { get; }

        void AddCat(Cat newCat);
        IEnumerable<string> GetCatNames();
        IEnumerable<Cat> GetCatsWithThreeLegs();
    }
}