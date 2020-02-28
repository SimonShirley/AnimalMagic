using System;
using System.Runtime.Serialization;
using AnimalMagic.Entity.Interfaces;

namespace AnimalMagic.Entity
{
    [DataContract]
    public abstract class Bird : Animal, IBird
    {
        [DataMember]
        public int Claws { get; set; }
    }
}
