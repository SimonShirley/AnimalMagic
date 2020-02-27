using System;
using AnimalMagic.Entity.Interfaces;

namespace AnimalMagic.Entity
{
    public abstract class Bird : Animal, IBird
    {
        public abstract int Claws { get; set; }

        public Bird() : base()
        {
        }

        public Bird(string name) : base(name)
        {
        }

        public Bird(string name, int claws) : base(name)
        {
            Claws = claws;
        }
    }
}
