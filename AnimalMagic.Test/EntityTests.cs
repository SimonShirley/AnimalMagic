using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AnimalMagic.Entity;

namespace AnimalMagic.Test
{
    [TestClass]
    public class EntityTests
    {
        [TestMethod]
        public void isCatAMammalTest()
        {
            var cat = new Cat { Name = "Shanie" };
            Assert.IsInstanceOfType(cat, typeof(Mammal));
        }

        [TestMethod]
        public void isCatAnAnimalTest()
        {
            var cat = new Cat { Name = "Shanie" };
            Assert.IsInstanceOfType(cat, typeof(Animal));
        }

        [TestMethod]
        public void isCatABirdTest()
        {
            var cat = new Cat { Name = "Shanie" };
            Assert.IsNotInstanceOfType(cat, typeof(Bird));
        }

        [TestMethod]
        public void isDogAMammalTest()
        {
            var dog = new Dog { Name = "Blazer", Legs = 4 };
            Assert.IsInstanceOfType(dog, typeof(Mammal));
        }

        [TestMethod]
        public void isDogAnAnimalTest()
        {
            var dog = new Dog { Name = "Blazer", Legs = 3 };
            Assert.IsInstanceOfType(dog, typeof(Animal));
        }

        [TestMethod]
        public void isDogABirdTest()
        {
            var dog = new Dog { Name = "Duke" };
            Assert.IsNotInstanceOfType(dog, typeof(Bird));
        }

        [TestMethod]
        public void isParrotAnAnimal()
        {
            var parrot = new Parrot { Name = "Bluey" };
            Assert.IsInstanceOfType(parrot, typeof(Animal));
        }

        [TestMethod]
        public void isParrotAMammal()
        {
            var parrot = new Parrot { Name = "Bluey" };
            Assert.IsNotInstanceOfType(parrot, typeof(Mammal));
        }

        [TestMethod]
        public void isParrotABird()
        {
            var parrot = new Parrot { Name = "Bluey", Claws = 8 };
            Assert.IsInstanceOfType(parrot, typeof(Bird));
        }
    }
}
