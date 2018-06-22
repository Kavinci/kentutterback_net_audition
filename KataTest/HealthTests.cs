using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kata;

namespace KataTest
{
    [TestClass]
    public class HealthTests
    {
        Player Player = new Player();

        [TestMethod]
        public void GetHealth_ExpectedBehaviour()
        {
            int initHealth = 30;
            Assert.AreEqual(initHealth, Player.GetHealth());
        }

        [TestMethod]
        public void SubtractHealth_ExpectedBehaviour()
        {
            int initHealth = 26;
            Player.SubtractHealth(4);
            Assert.AreEqual(initHealth, Player.GetHealth());
        }

        [TestMethod]
        public void AddHealth_ExpectedBehaviour()
        {
            int initHealth = 30;
            Player.AddHealth(5);
            Assert.AreEqual(initHealth, Player.GetHealth());
        }

        [TestMethod]
        public void IsHealthDepleted_ExpectedBehaviour()
        {
            Player.SubtractHealth(31);
            Assert.IsTrue(Player.IsHealthDepleted());
        }
    }
}
