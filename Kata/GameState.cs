using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kata
{
    public class GameState
    {
        public enum ActivePlayerOptions
        {
            Player,
            Computer
        }
        
        private ActivePlayerOptions ActivePlayer { get; set; }

        private int Round { get; set; }

        public GameState()
        {
            Round = 0;
            ActivePlayer = ActivePlayerOptions.Player;
        }

        public void NextRound()
        {
            Round++;
        }

        public int GetRound()
        {
            return Round;
        }

        public ActivePlayerOptions GetActivePlayer()
        {
            return ActivePlayer;
        }

        public void SwitchActivePlayer()
        {
            switch (ActivePlayer)
            {
                case ActivePlayerOptions.Player:
                    ActivePlayer = ActivePlayerOptions.Computer;
                    break;
                case ActivePlayerOptions.Computer:
                    ActivePlayer = ActivePlayerOptions.Player;
                    break;
            }
        }
    }
}
