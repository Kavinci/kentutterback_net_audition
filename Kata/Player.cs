using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kata
{
    public class Player
    {
        Cards Cards;
        private int ManaSlotMax { get; set; }
        private int ManaSlots { get; set; }
        private int Mana { get; set; }
        private int HealthSlotMax { get; set; }
        private int Health { get; set; }
        private LinkedList<int> Deck { get; set; }
        private LinkedList<int> Hand { get; set; }

        public Player()
        {
            ManaSlotMax = 10;
            ManaSlots = 0;
            Mana = ManaSlots;
            HealthSlotMax = 30;
            Health = HealthSlotMax;
            Cards = new Cards();
            Deck = new LinkedList<int>(Cards.Deck);
            ShuffleDeck();
            Hand = new LinkedList<int>();
        }

        public void AddMana(int NumOfMP)
        {
            Mana += NumOfMP;
        }

        public void AddManaSlot()
        {
            if (ManaSlots <= ManaSlotMax)
            {
                ManaSlots += 1;
            }
        }

        public void RefillMana()
        {
            Mana = ManaSlots;
        }

        public bool CanUseMana(int NumOfMP)
        {
            if (NumOfMP <= Mana)
            {
                return true;
            }
            else return false;
        }

        public void UseMana(int NumOfMP)
        {
            Mana -= NumOfMP;
        }

        public int GetMana()
        {
            return Mana;
        }

        public int GetManaSlots()
        {
            return ManaSlots;
        }

        public void AddHealth(int NumOfHP)
        {
            if (Health < HealthSlotMax && Health + NumOfHP < HealthSlotMax)
            {
                Health = NumOfHP;
            }
            else if (Health < HealthSlotMax && Health + NumOfHP > HealthSlotMax)
            {
                Health = HealthSlotMax;
            }
        }

        public void SubtractHealth(int NumOfHP)
        {
            Health -= NumOfHP;
        }

        public int GetHealth()
        {
            return Health;
        }

        public bool IsHealthDepleted()
        {
            if (Health <= 0)
            {
                return true;
            }
            else return false;
        }

        public LinkedList<int> GetDeck()
        {
            return Deck;
        }

        public LinkedList<int> GetHand()
        {
            return Hand;
        }

        public void ShuffleDeck()
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

        public bool CanDrawACardFromDeck()
        {
            if (Deck.Count >= 1) return true;
            else return false;
        }

        public bool CanAddCardToHand()
        {
            if (Hand.Count <= 4) return true;
            else return false;
        }

        public void AddTopCardFromDeckToHand()
        {
            Hand.AddLast(Deck.First());
        }

        public void RemoveTopCardFromDeck()
        {
            Deck.RemoveFirst();
        }

        public bool CanPlayCard(int MPValue)
        {
            if (Hand.Contains(MPValue)) return true;
            else return false;
        }

        public void RemoveCardFromHand(int MPValue)
        {
            Hand.Remove(MPValue);
        }
    }
}
