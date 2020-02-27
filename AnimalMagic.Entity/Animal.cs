using System;
using AnimalMagic.Entity.Interfaces;

namespace AnimalMagic.Entity
{
    public abstract class Animal : IAnimal
    {
        public abstract string Name { get; set; }
        public abstract string Sound { get; set; }

        public Animal() : this("", "")
        {
        }

        public Animal(string name) : this(name, "")
        {
        }

        public Animal(string name, string sound)
        {
            Name = name;
            Sound = sound;
        }
    }
}
