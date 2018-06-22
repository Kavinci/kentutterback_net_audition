using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kata
{
    public class PlayerObject
    {
        Cards Cards;
        private int Mana { get; set; }
        private int Health { get; set; }
        private LinkedList<int> Deck { get; set; }
        private LinkedList<int> Hand { get; set; }

        public PlayerObject()
        {
            Mana = 0;
            Health = 30;
            Cards = new Cards();
            Deck = new LinkedList<int>(Cards.Deck);
            Shuffle();
            Hand = new LinkedList<int>();
        }

        public void AddMana(int NumOfMP)
        {
            Mana = NumOfMP;
        }

        public bool SubtractMana(int NumOfMP)
        {
            Mana -= NumOfMP;
            if (Mana == 0)
            {
                return true;
            }
            else return false;
        }

        public int GetMana()
        {
            return Mana;
        }

        public void AddHealth(int NumOfHP)
        {
            Health = NumOfHP;
        }

        public bool SubtractHealth(int NumOfHP)
        {
            Health -= NumOfHP;
            if (Health == 0)
            {
                return true;
            }
            else return false;
        }

        public int GetHealth()
        {
            return Health;
        }

        public LinkedList<int> GetDeck()
        {
            return Deck;
        }

        public LinkedList<int> GetHand()
        {
            return Hand;
        }

        public void Shuffle()
        {
            LinkedList<int> ShuffledDeck = new LinkedList<int>();

            for (int i = Deck.Count; i > 0; i--)
            {
                int x = new Random().Next(0, i);
                ShuffledDeck.AddFirst(Deck.ElementAt(x));
                Deck.Remove(Deck.ElementAt(x));
            }
            Deck.Clear();
            Deck = ShuffledDeck;
        }

        public bool Draw(int NumOfCards)
        {
            bool success = false;
            if (Deck.Count > 0 && Deck.Count >= NumOfCards)
            {
                for (; NumOfCards > 0; NumOfCards--)
                {
                    Hand.AddLast(Deck.First<int>());
                    Deck.RemoveFirst();
                }
                success = true;
            }
            return success;
        }

        public bool PlayACard(int MPValue, int Index, out int MPValueOut)
        {
            bool Success = false;
            MPValueOut = 0;
            //Index Action
            if (MPValue < 0 && Index >= 0)
            {
                if (Index + 1 <= Hand.Count)
                {
                    MPValueOut = Hand.ElementAt<int>(Index);
                    Hand.Remove(MPValueOut);
                    Success = true;
                }
            }
            //MPValue Action
            if (Index < 0 && MPValue >= 0)
            {
                if (Hand.Contains(MPValue))
                {
                    MPValueOut = MPValue;
                    Hand.Remove(MPValueOut);
                    Success = true;
                }
            }
            return Success;
        }
    }
}
