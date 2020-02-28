using System;
using AnimalMagic.Entity.Interfaces;

namespace AnimalMagic.Entity
{
    public class Dog : Mammal, IDog
    {
        public Dog()
        {
            Legs = 4;
            Sound = "Woof";
        }
    }
}
