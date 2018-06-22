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
    }
}
