using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kata
{
    public class GameLogic
    {
        PlayerObject Player;

        public GameLogic()
        {
            Player = new PlayerObject();
        }

        public void StartGame()
        {
            Player.Shuffle();
        }
    }
}
