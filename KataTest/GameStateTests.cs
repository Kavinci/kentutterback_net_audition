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
            int InitialRound = 0;
            int CurrentRound = GameState.GetRound();

            GameState.NextRound();
            Assert.AreNotEqual(InitialRound, GameState.GetRound()); 
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
