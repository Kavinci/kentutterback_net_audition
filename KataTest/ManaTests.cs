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
        public void CanUseMana_returns_True_when_RequestedManaIsAvailable()
        {
            int ExpectedMana = 0;

            Assert.IsTrue(Player.CanUseMana(ExpectedMana));
        }

        [TestMethod]
        public void CanUseMana_returns_False_when_RequestedManaIsNotAvailable()
        {
            int ExpectedMana = 2;

            Assert.IsFalse(Player.CanUseMana(ExpectedMana));
        }

        [TestMethod]
        public void AddManaSlots_AddsOneManaSlot_OnCall()
        {
            int ExpectedManaSlots = 1;

            Player.AddManaSlot();
            Assert.AreEqual(ExpectedManaSlots, Player.GetManaSlots());
        }

        [TestMethod]
        public void AddManaSlots_DoesNotExceedTenSlots_when_CalledMoreThanTenTimes()
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
        public void RefillMana_RefillsMana_upTo_ManaSlots_onCall()
        {
            Player.RefillMana();
            Assert.AreEqual(Player.GetManaSlots(), Player.GetMana());
        }
    }
}
