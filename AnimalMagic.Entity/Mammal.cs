using System;
using AnimalMagic.Entity.Interfaces;

namespace AnimalMagic.Entity
{
    public abstract class Mammal : Animal, IMammal
    {
        public abstract int Legs { get; set; }
        
        public Mammal() : base()
        {
        }

        public Mammal(string name) : base(name)
        {
        }

        public Mammal(string name, int legs) : base(name)
        {
            Legs = legs;
        }
    }
}
