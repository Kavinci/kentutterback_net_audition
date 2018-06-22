using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kata
{
    public class GameLogic
    {
        public Player Player;
        public Computer Computer;
        public GameState GameState;
        public ConsoleInterface CIO;

        public GameLogic()
        {
            Player = new Player();
            Computer = new Computer();
            GameState = new GameState();
            CIO = new ConsoleInterface("Trading Card Game");
        }

        public void StartGame()
        {
            Preparation();
            GameLoop();
        }

        public void GameLoop()
        {
            //GameLoop();
        }

        public void Preparation()
        {
            //Player
            int i = 2;
            Player.AddManaSlot();
            Player.RefillMana();
            while (i >= 0)
            {
                Player.AddTopCardFromDeckToHand();
                Player.RemoveTopCardFromDeck();
                i--;
            }

            //Computer
            i = 2;
            Computer.AddManaSlot();
            Computer.RefillMana();
            while (i >= 0)
            {
                Computer.AddTopCardFromDeckToHand();
                Computer.RemoveTopCardFromDeck();
                i--;
            }
        }

        public bool IsGameOver()
        {
            if (Player.IsHealthDepleted() || Computer.IsHealthDepleted()) return true;
            else return false;
        }

        public bool SpecialRuleBleeding()
        {
            if (Player.GetHealth() > 0 && Player.GetDeck().Count == 0) return true;
            else return false;
        }
    }
}
