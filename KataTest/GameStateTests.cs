using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kata;

namespace KataTest
{
    [TestClass]
    public class GameStateTests
    {
        GameState GameState = new GameState();

        [TestMethod]
        public void GetRound_returns_CurrentRound_after_NextRound()
        {
            int ExpectedRound = 0;
            //20 round test
            for(int i = 20; i >= 0; i--)
            {
                Assert.IsTrue(ExpectedRound == GameState.GetRound());
                ExpectedRound++;
                GameState.NextRound();
            }
        }
    }
}
