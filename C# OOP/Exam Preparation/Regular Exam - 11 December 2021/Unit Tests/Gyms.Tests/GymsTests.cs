using System;
using NUnit.Framework;

namespace Gyms.Tests
{
    [TestFixture]
    public class GymsTests
    {
        [Test]
        public void ConstructorShouldCreateGymWithValidData()
        {
            Gym gym = new Gym("Anita", 4);

            Assert.That(gym, Is.Not.Null);
            Assert.AreEqual("Anita", gym.Name);
            Assert.AreEqual(4, gym.Capacity);
            Assert.AreEqual(0, gym.Count);

        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void NameShouldThrowExceptionIfNameIsNullOrEmpty(string name)
        {
            Assert.That(() =>
            {
                var gym = new Gym(name, 4);
            },
            Throws.Exception.TypeOf<ArgumentNullException>(),
            "Invalid gym name.");
        }

        [Test]
        public void CapacitySouldThrowExceptionIfNumberIsNegative()
        {
            Assert.Throws<ArgumentException>(() => new Gym("Anita", -1));
        }

        [Test]
        public void AddAtleAddAthleteMethodShouldThrowExceptionIfGymIsFullcapacity()
        {
            Gym gym = new Gym("Anita", 2);
            gym.AddAthlete(new Athlete("Bob"));
            gym.AddAthlete(new Athlete("Mitko"));

            Assert.Throws<InvalidOperationException>(() => gym.AddAthlete(new Athlete("Asq")));
        }

        [Test]
        public void RemoveMethodShouldThrowExceptionIfAthleteDoesNotExist()
        {
            Gym gym = new Gym("Anita", 2);
            gym.AddAthlete(new Athlete("Bob"));
            gym.AddAthlete(new Athlete("Mitko"));

            Assert.Throws<InvalidOperationException>(() => gym.RemoveAthlete("Sonya"));
        }

        [Test]
        public void RemoveMethodShouldReduceCountOfAthletes()
        {
            Gym gym = new Gym("Anita", 2);
            gym.AddAthlete(new Athlete("Bob"));
            gym.AddAthlete(new Athlete("Mitko"));

            gym.RemoveAthlete("Bob");

            Assert.AreEqual(1, gym.Count);
        }

        [Test]
        public void InjureAthleteShouldThrowExceptionIfAthleteDoesNotExist()
        {
            Gym gym = new Gym("Anita", 2);
            gym.AddAthlete(new Athlete("Bob"));
            gym.AddAthlete(new Athlete("Mitko"));

            Assert.Throws<InvalidOperationException>(() => gym.InjureAthlete("Asq"));
        }

        [Test]
        public void InjureMethodShouldReturnInjuresAthletes()
        {
            Gym gym = new Gym("Anita", 2);
            gym.AddAthlete(new Athlete("Bob"));
            gym.AddAthlete(new Athlete("Mitko"));

            Athlete injuredAthlete = gym.InjureAthlete("Bob");

            Assert.AreEqual(true, injuredAthlete.IsInjured);
            Assert.AreEqual("Bob", injuredAthlete.FullName);
        }

        [Test]
        public void ReportMethodShouldReturnInfoAboutGymAndAthletes()
        {
            Gym gym = new Gym("Anita", 3);
            gym.AddAthlete(new Athlete("Bob"));
            gym.AddAthlete(new Athlete("Mitko"));
            gym.AddAthlete(new Athlete("Lili"));

            Athlete injuredAthlete = gym.InjureAthlete("Bob");

            string report = gym.Report();

            Assert.AreEqual("Active athletes at Anita: Mitko, Lili", report);
        }
    }
}
