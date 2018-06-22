using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kata;

namespace KataTest
{
    [TestClass]
    public class GameLogicTests
    {
        GameLogic Game = new GameLogic();

        [TestMethod]
        public void PlayerTurn_ExpectedBehaviour()
        {

        }

        [TestMethod]
        public void Preparation_ExpectedBehaviour()
        {
            int ExpectedHealth = 30;
            int ExpectedMana = 1;
            int ExpectedHandCount = 3;
            int ExpectedDeckCount = 17;

            Game.Preparation();
            Assert.AreEqual(ExpectedHealth, Game.Player.GetHealth(), "Health");
            Assert.AreEqual(ExpectedMana, Game.Player.GetMana(), "Mana");
            Assert.AreEqual(ExpectedHandCount, Game.Player.GetHand().Count, "Hand Count"); 
            Assert.AreEqual(ExpectedDeckCount, Game.Player.GetDeck().Count, "Deck Count");

            Assert.AreEqual(ExpectedHealth, Game.Computer.GetHealth(), "Health");
            Assert.AreEqual(ExpectedMana, Game.Computer.GetMana(), "Mana");
            Assert.AreEqual(ExpectedHandCount, Game.Computer.GetHand().Count, "Hand Count");
            Assert.AreEqual(ExpectedDeckCount, Game.Computer.GetDeck().Count, "Deck Count");
        }

        [TestMethod]
        public void BleedingSpecialRules_ExpectedBehaviour()
        {
            Game.Player.AddHealth(30);
            do
            {
                Game.Player.RemoveTopCardFromDeck();
            } while (Game.Player.GetDeck().Count > 0);
            Assert.IsTrue(Game.SpecialRuleBleeding());
        }

        [TestMethod]
        public void IsGameOver_ExpectedBehaviour()
        {
            Game.Player.SubtractHealth(30);
            Assert.IsTrue(Game.IsGameOver());

            Game.Computer.SubtractHealth(30);
            Assert.IsTrue(Game.IsGameOver());
        }
    }
}
