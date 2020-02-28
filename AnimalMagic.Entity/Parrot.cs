using System;
using AnimalMagic.Entity.Interfaces;

namespace AnimalMagic.Entity
{
    public class Parrot : Bird, IParrot
    {
        public Parrot()
        {
            Claws = 6;
            Sound = "Squawk";
        }
    }
}
