using System;
using AnimalMagic.Entity.Interfaces;

namespace AnimalMagic.Entity
{
    public class Cat : Mammal, ICat
    {
        public Cat()
        {
            Sound = "Meow";
            Legs = 4;
        }
    }
}
