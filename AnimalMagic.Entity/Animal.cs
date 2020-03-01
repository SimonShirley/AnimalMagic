using System;
using System.Runtime.Serialization;
using AnimalMagic.Entity.Interfaces;

namespace AnimalMagic.Entity
{
    [DataContract]
    public abstract class Animal : IAnimal
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Sound { get; set; }
    }
}
