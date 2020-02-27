using System;
using AnimalMagic.Entity.Interfaces;

namespace AnimalMagic.Entity
{
    public class Dog : Mammal, IDog
    {
        public override string Name { get; set; } = "";
        public override string Sound { get; set; } = "Woof";
        public override int Legs { get; set; } = 4;        

        public Dog() : base()
        {
        }

        public Dog(string name) : base(name)
        {
        }

        public Dog(string name, int legs) : base(name, legs)
        {
        }
    }
}
