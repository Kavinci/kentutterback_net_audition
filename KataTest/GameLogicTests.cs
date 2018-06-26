using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kata;

namespace KataTest
{
    [TestClass]
    public class GameLogicTests
    {
        GameLogic Game = new GameLogic();

        [TestInitialize()]
        public void InitializeForTesting()
        {
            Game = new GameLogic();
        }

        [TestMethod]
        public void Preparation_SetsAllInitialStats_forPlayer_onCall()
        {
            int ExpectedHealth = 30;
            int ExpectedMana = 1;
            int ExpectedHandCount = 3;
            int ExpectedDeckCount = 17;

            Game.Preparation();
            Assert.AreEqual(ExpectedHealth, Game.Player.GetHealth(), "Player Health");
            Assert.AreEqual(ExpectedMana, Game.Player.GetMana(), "Player Mana");
            Assert.AreEqual(ExpectedHandCount, Game.Player.GetHand().Count, "Player Hand Count");
            Assert.AreEqual(ExpectedDeckCount, Game.Player.GetDeck().Count, "Player Deck Count");
        }

        [TestMethod]
        public void Preparation_SetsAllInitialStats_forComputer_onCall()
        {
            int ExpectedHealth = 30;
            int ExpectedMana = 0;
            int ExpectedHandCount = 2;
            int ExpectedDeckCount = 18;

            Game.Preparation();
            Assert.AreEqual(ExpectedHealth, Game.Computer.GetHealth(), "Computer Health");
            Assert.AreEqual(ExpectedMana, Game.Computer.GetMana(), "Computer Mana");
            Assert.AreEqual(ExpectedHandCount, Game.Computer.GetHand().Count, "Computer Hand Count");
            Assert.AreEqual(ExpectedDeckCount, Game.Computer.GetDeck().Count, "Computer Deck Count");
        }

        [TestMethod]
        public void IsGameOver_returns_True_when_Health_IsLessThanOrEqualTo_Zero()
        {
            Game.Player.SubtractHealth(30);
            Assert.IsTrue(Game.IsGameOver());

            Game.Player.AddHealth(10);
            Game.Computer.SubtractHealth(32);
            Assert.IsTrue(Game.IsGameOver());
        }
    }
}
