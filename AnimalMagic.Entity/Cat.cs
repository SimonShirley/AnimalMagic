using System;
using AnimalMagic.Entity.Interfaces;

namespace AnimalMagic.Entity
{
    public class Cat : Mammal, ICat
    {
        public override string Name { get; set; } = "";
        public override string Sound { get; set; } = "Meow";
        public override int Legs { get; set; } = 4;

        public Cat() : base()
        {
        }

        public Cat(string name) : base(name)
        {
        }

        public Cat(string name, int legs) : base(name, legs)
        {
        }
    }
}
