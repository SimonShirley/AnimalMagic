using System;
using AnimalMagic.Entity.Interfaces;

namespace AnimalMagic.Entity
{
    public abstract class Animal : IAnimal
    {
        public string Name { get; set; }
        public string Sound { get; set; }
    }
}
