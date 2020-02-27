using System;
namespace AnimalMagic.Entity.Interfaces
{
    public interface IBird : IAnimal
    {
        int Claws { get; set; }
    }
}
