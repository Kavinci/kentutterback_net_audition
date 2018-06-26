using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;
using Kata;

namespace KataTest
{
    [TestClass]
    public class CardTests
    {
        Player Player;

        [TestInitialize()]
        public void InitializeForTesting()
        {
            Player = new Player();
        }

        [TestMethod]
        public void DeckContents_hasOneOfEachCard_on_FirstInitialization()
        {
            LinkedList<int> Deck = Player.GetDeck();

            int[] ExpectedDeck = { 0, 0, 1, 1, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 5, 5, 6, 6, 7, 8 };
            Assert.IsTrue(ExpectedDeck.All(Deck.Contains));
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
        public void Output_of_CanDrawACardFromDeck_with_CardsInDeck()
        {
            Assert.IsTrue(Player.CanDrawACardFromDeck());
        }

        [TestMethod]
        public void Output_of_CanDrawACardFromDeck_without_CardsInDeck()
        {
            for(int i = Player.GetDeck().Count; i > 0; i--)
            {
                Player.RemoveTopCardFromDeck();
            }
            Assert.IsFalse(Player.CanDrawACardFromDeck());
        }

        [TestMethod]
        public void WhenPlayersHandHasFiveCards_AddTopCardFromDeckToHand_DrawsACardFromTheDeckAndDoesNotAddToHand()
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
            }
            Assert.IsTrue(Player.GetHand().Count <= 5);
        }

        [TestMethod]
        public void CanPlayACardFromHand_returns_True_when_CardExists_in_Hand()
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
        public void PlayACard_from_Hand_RemovesCard_from_Hand_ifCardExists()
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
