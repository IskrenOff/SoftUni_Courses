namespace Presents.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class PresentsTests
    {
        [Test]
        public void ConstructorShoulWorkProperly()
        {
            Bag bag = new Bag();
            Assert.IsNotNull(bag);
        }

        [Test]
        public void CreateMethodShouldThrowExceptionIfPresentIsNull()
        {
            Bag bag = new Bag();
            Present present = null;

            Assert.Throws<ArgumentNullException>(() => bag.Create(present));
        }

        [Test]
        public void CreateMethodShouldThrowExceptionIfPresentExist()
        {
            Bag bag = new Bag();
            Present present = new Present("Dildo", 69);
            bag.Create(present);

            Assert.Throws<InvalidOperationException>(() => bag.Create(present));
        }

        [Test]
        public void CreateMethodShouldReturnCorrectMessage()
        {
            Bag bag = new Bag();
            Present present = new Present("Dildo", 69);
            string message = bag.Create(present);

            Assert.AreEqual($"Successfully added present {present.Name}.", message);
        }

        [Test]
        public void RemoveShouldReturnTrueIfPresentIsInBag()
        {
            Bag bag = new Bag();
            Present present = new Present("Dildo", 69);
            bag.Create(present);

            bool result = bag.Remove(present);

            Assert.AreEqual(true, result);
        }

        [Test]
        public void RemoveShouldReturnFalseIfPresentIsNotInBag()
        {
            Bag bag = new Bag();
            Present present = new Present("Dildo", 69);

            bool result = bag.Remove(present);

            Assert.AreEqual(false, result);
        }

        [Test]
        public void GetPresentWithLeastMagicShouldReturnTheLeastMagicalPresent()
        {
            Bag bag = new Bag();

            Present present1 = new Present("Socks", 5.8);
            Present present2 = new Present("Earrings", 10.5);
            Present present3 = new Present("Toy Truck", 15.8);

            bag.Create(present1);
            bag.Create(present2);
            bag.Create(present3);

            Present leastMagical = bag.GetPresentWithLeastMagic();

            Assert.AreEqual(present1.Magic, leastMagical.Magic);
        }

        [Test]
        public void GetPresentShouldReturnPresentWithGivenName()
        {
            Bag bag = new Bag();

            Present present1 = new Present("Socks", 5.8);
            Present present2 = new Present("Earrings", 10.5);
            Present present3 = new Present("Toy Truck", 15.8);

            bag.Create(present1);
            bag.Create(present2);
            bag.Create(present3);

            Present currentPresent = bag.GetPresent("Earrings");

            Assert.AreEqual(present2.Name, currentPresent.Name);
        }

        [Test]
        public void GetPresentsShouldreturnCollectionOfPresents()
        {
            Bag bag = new Bag();

            Present present1 = new Present("Socks", 5.8);
            Present present2 = new Present("Earrings", 10.5);
            Present present3 = new Present("Toy Truck", 15.8);

            bag.Create(present1);
            bag.Create(present2);
            bag.Create(present3);

            var presents = bag.GetPresents();

            Assert.AreEqual(3, presents.Count);
        }
    }
}
