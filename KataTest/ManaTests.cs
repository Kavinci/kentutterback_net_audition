using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kata;

namespace KataTest
{
    [TestClass]
    public class ManaTests
    {
        Player Player;

        [TestInitialize()]
        public void InitializeForTesting()
        {
            Player = new Player();
        }

        [TestMethod]
        public void AddMana_IncreasesMana_OnCall()
        {
            int ExpectedMana = 2;

            Player.AddMana(2);
            Assert.AreEqual(ExpectedMana, Player.GetMana());
        }

        [TestMethod]
        public void CanUseMana_ExpectedBehaviour()
        {
            int ExpectedMana = 0;

            Assert.IsTrue(Player.CanUseMana(ExpectedMana));
        }

        [TestMethod]
        public void AddManaSlots_Adds1Mana_OnCall()
        {
            int ExpectedManaSlots = 1;

            Player.AddManaSlot();
            Assert.AreEqual(ExpectedManaSlots, Player.GetManaSlots());
        }

        [TestMethod]
        public void AddManaSlots_DoesNotExceed10Slots_OnCall()
        {
            //0-10 slots
            int ExpectedManaSlots = 10;
            for (int i = 10; i >= 0; i--)
            {
                Player.AddManaSlot();
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
