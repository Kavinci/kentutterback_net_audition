using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kata
{
    public class GameState
    {
        private int Round { get; set; }

        public GameState()
        {
            Round = 0;
        }

        public void NextRound()
        {
            Round++;
        }

        public int GetRound()
        {
            return Round;
        }
    }
}
