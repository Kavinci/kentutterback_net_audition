using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Kata;

namespace KataTest
{
    [TestClass]
    public class FirstRoundTests
    {
        PlayerObject Player = new PlayerObject();

        [TestMethod]
        public void CheckDeckContains()
        {
            LinkedList<int> Deck = Player.GetDeck();

            int[] expectedDeck = { 0, 0, 1, 1, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 5, 5, 6, 6, 7, 8 };

            for (int i = Deck.Count; i > 0; i--)
            {
                Assert.IsTrue(Deck.Contains(expectedDeck[i - 1]));
                Deck.Remove(expectedDeck[i - 1]);
            }
        }
    }
}
