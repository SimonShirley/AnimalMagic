using System;
namespace AnimalMagic.Entity.Interfaces
{
    public interface IMammal : IAnimal
    {
        int Legs { get; set; }
    }
}
