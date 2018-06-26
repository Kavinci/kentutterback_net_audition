using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kata
{
    public class Computer : Player
    {
        Cards Cards;
        public Computer()
        {
            Cards = new Cards();
        }

        public int Decide()
        {
            int ManaCost = new int();
            ManaCost = MinMax();
            return ManaCost;
        }

        public int MinMax()
        {
            int Mana = this.GetMana();
            LinkedList<int> Hand = this.GetHand();

            if (Hand.Contains(0))
            {
                return 0;
            }
            else
            {
                int ManaCost = Hand.Min();
                if (Mana >= ManaCost)
                {
                    return ManaCost;
                }
                else return -1;
            }
        }
    }
}
