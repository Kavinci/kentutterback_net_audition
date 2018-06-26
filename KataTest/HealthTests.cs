using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kata;

namespace KataTest
{
    [TestClass]
    public class HealthTests
    {
        Player Player;

        [TestInitialize()]
        public void InitializeForTesting()
        {
            Player = new Player();
        }

        [TestMethod]
        public void GetHealth_returns_InitialHealth_after_Initialization()
        {
            int initHealth = 30;
            Assert.AreEqual(initHealth, Player.GetHealth());
        }

        [TestMethod]
        public void SubtractHealth_from_FullHealth()
        {
            int initHealth = 26;
            Player.SubtractHealth(4);
            Assert.AreEqual(initHealth, Player.GetHealth());
        }

        [TestMethod]
        public void AddHealth_to_MediumHealth_shouldNot_Increase_MoreThan_MaxHealth()
        {
            int initHealth = 30;
            Player.SubtractHealth(7);
            Player.AddHealth(10);
            Assert.AreEqual(initHealth, Player.GetHealth());
        }

        [TestMethod]
        public void AddHealth_to_MediumHealth_should_Increase()
        {
            int expectedHealth = 28;
            Player.SubtractHealth(7);
            Player.AddHealth(5);
            Assert.AreEqual(expectedHealth, Player.GetHealth());
        }

        [TestMethod]
        public void IsHealthDepleted_returns_True_when_Health_isLessThanOrEqualTo_Zero()
        {
            Player.SubtractHealth(31);
            Assert.IsTrue(Player.IsHealthDepleted());
        }
    }
}
