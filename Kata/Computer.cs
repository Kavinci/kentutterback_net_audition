using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kata
{
    public class Computer : Player
    {
        Cards Cards;
        ConsoleInterface CIO;
        public Computer()
        {
            Cards = new Cards();
        }

        public int Decide(ConsoleInterface cio)
        {
            CIO = cio;
            int ManaCost = new int();
            ManaCost = MinMax();
            return ManaCost;
        }

        public int MinMax()
        {
            int Mana = this.GetMana();
            LinkedList<int> Hand = this.GetHand();
            if (Hand.Count > 0)
            {
                if (Hand.Contains(0))
                {
                    return 0;
                }
                else if (Hand.Contains(Mana))
                {
                    return Mana;
                }
                else
                {
                    int ManaCost = -1;
                    List<int> PossibleManaCost = new List<int>();
                    for (int i = 1; i < Mana && i != Mana; i++)
                    {
                        PossibleManaCost.Add(Mana - i);
                    }

                    IEnumerable<int> search = from x in PossibleManaCost where Hand.Contains(x) orderby x select x;
                    
                    if(search.Count() > 0)
                    {
                        ManaCost = search.Max();
                    }
                    else
                    {
                        ManaCost = -1;
                        CIO.WriteToBuffer("Computer Ends Turn" + "\r\n");
                        CIO.Render();
                    }
                    return ManaCost;
                }
            }
            else
            {
                CIO.WriteToBuffer("Computer Ends Turn" + "\r\n");
                CIO.Render();
                return -1;
            }
        }
    }
}
