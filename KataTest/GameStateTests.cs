using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kata;

namespace KataTest
{
    [TestClass]
    public class GameStateTests
    {
        GameState GameState;

        [TestInitialize()]
        public void InitializeForTesting()
        {
            GameState = new GameState();
        }

        [TestMethod]
        public void NextRound_IncrementsRound_onCall()
        {
            int ExpectedRound = 1;
            int CurrentRound = GameState.GetRound();

            GameState.NextRound();
            Assert.AreEqual(ExpectedRound, GameState.GetRound()); 
        }

        [TestMethod]
        public void SwitchActivePlayer_TogglesActivePlayer_onCall()
        {
            GameState.ActivePlayerOptions ActivePlayer = GameState.GetActivePlayer();
            GameState.SwitchActivePlayer();
            Assert.AreNotEqual(ActivePlayer, GameState.GetActivePlayer());
        }
    }
}
