using System;
using AnimalMagic.Entity.Interfaces;

namespace AnimalMagic.Entity
{
    public abstract class Mammal : Animal, IMammal
    {
        public int Legs { get; set; }
    }
}
