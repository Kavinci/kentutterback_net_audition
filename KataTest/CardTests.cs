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
        public void DeckCountHasOneLess_after_RemoveTopCardFromDeck()
        {
            int initCount = Player.GetDeck().Count;
            Player.RemoveTopCardFromDeck();
            Assert.IsTrue(Player.GetDeck().Count < initCount);
        }

        [TestMethod]
        public void CanDrawACardFromDeck_returnsTrue_when_CardsExistInDeck()
        {
            Assert.IsTrue(Player.CanDrawACardFromDeck());
        }

        [TestMethod]
        public void PlayersHand_cannotExceedFiveCards()
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
    }
}
