using System;
using System.Runtime.Serialization;
using AnimalMagic.Entity.Interfaces;

namespace AnimalMagic.Entity
{
    [DataContract]
    public abstract class Mammal : Animal, IMammal
    {
        [DataMember]
        public int Legs { get; set; }
    }
}
