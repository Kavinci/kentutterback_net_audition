using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Kata;

namespace KataTest
{
    [TestClass]
    public class CardTests
    {
        Player Player = new Player();

        [TestMethod]
        public void DeckContents_hasOneOfEachCard_on_FirstInitialization()
        {
            LinkedList<int> Deck = Player.GetDeck();

            int[] ExpectedDeck = { 0, 0, 1, 1, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 5, 5, 6, 6, 7, 8 };

            for (int i = Deck.Count; i > 0; i--)
            {
                Assert.IsTrue(Deck.Contains(ExpectedDeck[i - 1]));
                Deck.Remove(ExpectedDeck[i - 1]);
            }
        }

        [TestMethod]
        public void DeckCountHasOneLess_after_DrawOneCard()
        {
            for (int i = Player.GetDeck().Count; i > 0; i--)
            {
                int inCount = Player.GetDeck().Count;
                Player.RemoveTopCardFromDeck();
                Assert.IsTrue(Player.GetDeck().Count < inCount);
            }
        }

        [TestMethod]
        public void Output_of_CanDrawACardFromDeck()
        {
            Assert.IsTrue(Player.CanDrawACardFromDeck());
        }

        [TestMethod]
        public void HandCount_never_Exceeds5Cards()
        {
            for (int i = Player.GetDeck().Count; i >= 1; i--)
            {
                if (Player.CanDrawACardFromDeck())
                {
                    if (Player.CanAddCardToHand())
                    {
                        Player.AddTopCardFromDeckToHand();
                    }
                    Player.RemoveTopCardFromDeck();
                }
                Assert.IsTrue(Player.GetHand().Count <= 5 && Player.GetHand().Count >= 0);
            }
        }

        [TestMethod]
        public void Output_of_CanPlayACardFromHand()
        {
            //Build Hand
            for (int i = 3; i >= 0; i--)
            {
                Player.AddTopCardFromDeckToHand();
                Player.RemoveTopCardFromDeck();
            }
            Assert.IsTrue(Player.CanPlayCard(Player.GetHand().First.Value));
        }

        [TestMethod]
        public void PlayACard_from_Hand()
        {
            int initHandCount = Player.GetHand().Count;
            for (int i = 3; i >= 0; i--)
            {
                Player.AddTopCardFromDeckToHand();
                Player.RemoveTopCardFromDeck();
            }

            if (Player.CanPlayCard(Player.GetHand().First.Value))
            {
                Player.RemoveCardFromHand(Player.GetHand().First.Value);
            }
            Assert.AreNotEqual(initHandCount, Player.GetHand().Count);
        }
    }
}
