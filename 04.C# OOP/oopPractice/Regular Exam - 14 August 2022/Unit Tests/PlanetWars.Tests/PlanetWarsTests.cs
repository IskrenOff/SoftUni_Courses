using NUnit.Framework;
using System;
using System.ComponentModel;

namespace PlanetWars.Tests
{
    public class Tests
    {
        [TestFixture]
        public class PlanetWarsTests
        {

            [Test]
            public void Constructor()
            {
                Planet planet = new Planet("Mars", 100);
                
                Assert.IsNotNull(planet);
            }

            [Test]
            [TestCase(null)]
            [TestCase("")]
            public void NamePropertyShouldThrowExceptionIfInvalidName(string name)
            {
                Assert.Throws<ArgumentException>(() => new Planet(name, 100.5));
            }

            [Test]
            public void Profit()
            {
                Planet planet = new Planet("Mars", 100);

                planet.Profit(20);

                Assert.AreEqual(120,planet.Budget);
            }
            [Test]
            public void SpendFunds()
            {
                Planet planet = new Planet("Mars", 100);

                Assert.Throws<InvalidOperationException>(() => planet.SpendFunds(120));
            }

            [Test]
            public void AddWeponShouldThrowInvalidOperationException()
            {
                Planet planet = new Planet("Mars",100);
                Weapon weapon1 = new Weapon("Axe", 30, 150);
                Weapon weapon2 = new Weapon("Axe", 30, 150);

                planet.AddWeapon(weapon1);

                Assert.Throws<InvalidOperationException>(() => planet.AddWeapon(weapon2));
            }

            [Test]
            public void RemoveWeapon()
            {
                Planet planet = new Planet("Mars", 100);
                Weapon weapon = new Weapon("Axe", 30, 150);

                planet.AddWeapon(weapon);

                planet.RemoveWeapon("Axe");

                Assert.AreEqual(0,planet.Weapons.Count);

            }

            [Test]
            public void UpgradeWeapon()
            {
                Planet planet = new Planet("Mars", 100);
                Weapon weapon = new Weapon("Axe", 30, 150);

                planet.AddWeapon(weapon);

                Assert.Throws<InvalidOperationException>(() => planet.UpgradeWeapon("PickAxe"));
            }

            [Test]
            public void UpgradeWeaponShouldWork()
            {
                Planet planet = new Planet("Mars", 100);
                Weapon weapon = new Weapon("Axe", 30, 150);

                planet.AddWeapon(weapon);
                planet.UpgradeWeapon("Axe");

                Assert.That(() => planet.MilitaryPowerRatio > 150);
            }

            [Test]
            public void DestructOpponent()
            {
                Planet planet1 = new Planet("Mars",100);
                Planet planet2 = new Planet("Earth",80);

                Assert.Throws<InvalidOperationException>(() => planet2.DestructOpponent(planet1));
            }

            [Test]
            public void DestructOpponentIsWorking()
            {
                Planet planet1 = new Planet("Mars", 100);
                Planet planet2 = new Planet("Earth", 80);
                Weapon weapon = new Weapon("Axe", 30, 150);

                planet1.AddWeapon(weapon);

                Assert.That(() =>planet1.DestructOpponent(planet2) == $"{planet2.Name} is destructed!");
            }
        }
    }
}
