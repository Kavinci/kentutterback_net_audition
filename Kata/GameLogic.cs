using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kata
{
    public class GameLogic
    {
        Player Player;
        GameState GameState;
        Cards Cards;

        public GameLogic()
        {
            Cards = new Cards();
            Player = new Player(Cards);
            GameState = new GameState();
        }

        public void StartGame()
        {
            
        }
    }
}
