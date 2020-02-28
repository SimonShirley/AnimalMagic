using System;
using AnimalMagic.Entity.Interfaces;

namespace AnimalMagic.Entity
{
    public abstract class Bird : Animal, IBird
    {
        public int Claws { get; set; }
    }
}
