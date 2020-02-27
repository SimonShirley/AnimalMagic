using System;
using AnimalMagic.Entity.Interfaces;

namespace AnimalMagic.Entity
{
    public class Parrot : Bird, IParrot
    {
        public override string Name { get; set; } = "";
        public override string Sound { get; set; } = "Squawk";
        public override int Claws { get; set; } = 6;

        public Parrot() : base()
        {
        }

        public Parrot(string name) : base(name)
        {
        }

        public Parrot(string name, int claws) : base(name, claws)
        {
        }
    }
}
