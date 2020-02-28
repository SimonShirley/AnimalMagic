using System.Collections.Generic;
using AnimalMagic.Entity;

namespace AnimalMagic.Business.Interfaces
{
    public interface IParrotManager
    {
        ICollection<Parrot> Parrots { get; }

        Parrot GetFirstParrot();
        Parrot GetParrotByName(string parrotName);
        IEnumerable<Parrot> GetParrotsInReverseOrder();
    }
}