using System;
using System.Runtime.Serialization;
using AnimalMagic.Entity.Interfaces;

namespace AnimalMagic.Entity
{
    [DataContract]
    public abstract class Animal : IAnimal
    {
        [DataMember]
        public string Name { get; set; }
        public string Sound { get; set; }
    }
}
