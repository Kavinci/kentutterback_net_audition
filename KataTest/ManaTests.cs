using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kata;

namespace KataTest
{
    [TestClass]
    public class ManaTests
    {
        Player Player = new Player();

        [TestMethod]
        public void AddMana_ExpectedIncrease()
        {
            int ExpectedMana = 0;
            for(int i = 10; i >= 0; i--)
            {
                Assert.AreEqual(ExpectedMana, Player.GetMana());
                Player.AddMana(1);
                ExpectedMana++;
            }
            Player.UseMana(10);
        }

        [TestMethod]
        public void CanUseMana_ExpectedBehaviour()
        {
            int ExpectedMana = 0;
            Assert.IsTrue(Player.CanUseMana(ExpectedMana));
        }

        [TestMethod]
        public void AddManaSlots_ExpectedBehaviour()
        {
            //0-10 Check
            int ExpectedManaSlots = 0;
            for (int i = 10; i >= 0; i--)
            {
                Assert.AreEqual(ExpectedManaSlots, Player.GetManaSlots());
                Player.AddManaSlot();
                ExpectedManaSlots++;
            }
            //Over 10 slot check
            Player.AddManaSlot();
            Assert.AreEqual(ExpectedManaSlots, Player.GetManaSlots());
        }

        [TestMethod]
        public void RefillMana_ExpectedBehaviour()
        {
            Player.RefillMana();
            Assert.AreEqual(Player.GetManaSlots(), Player.GetMana());
        }
    }
}
