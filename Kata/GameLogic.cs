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
            CIO = new ConsoleInterface("Trading Card Game" + "\r\n");
        }

        public void StartGame()
        {
            Preparation();
            GameLoop();
        }

        public void GameLoop()
        {
            int ManaCost = new int();
            if (!IsGameOver())
            {
                ManaCost = Decision(GameState.GetActivePlayer());
                if (ManaCost >= 0)
                {
                    PlayCard(ManaCost, GameState.GetActivePlayer());
                }
                else
                {
                    GameState.SwitchActivePlayer();
                    switch (GameState.GetActivePlayer())
                    {
                        case GameState.ActivePlayerOptions.Player:
                            GameState.NextRound();
                            Player.AddManaSlot();
                            Player.RefillMana();
                            if (Player.CanDrawACardFromDeck())
                            {
                                if (Player.CanAddCardToHand())
                                {
                                    Player.AddTopCardFromDeckToHand();
                                    Player.RemoveTopCardFromDeck();
                                }
                                else Player.RemoveTopCardFromDeck();
                            }
                            else
                            {
                                //Bleed out rule
                                Player.SubtractHealth(1);
                            }
                            break;
                        case GameState.ActivePlayerOptions.Computer:
                            Computer.AddManaSlot();
                            Computer.RefillMana();
                            if (Computer.CanDrawACardFromDeck())
                            {
                                if (Computer.CanAddCardToHand())
                                {
                                    Computer.AddTopCardFromDeckToHand();
                                    Computer.RemoveTopCardFromDeck();
                                }
                                else Computer.RemoveTopCardFromDeck();
                            }
                            else
                            {
                                //Bleed out rule
                                Computer.SubtractHealth(1);
                            }
                            break;
                    }
                }
                GameLoop();
            }
            else
            {
                if(Player.GetHealth() == 0)
                {
                    CIO.WriteToBuffer("Computer Wins! \r\n Good Game Player!");
                    CIO.Render();
                    Console.ReadKey();
                }
                if (Computer.GetHealth() == 0)
                {
                    CIO.WriteToBuffer("Congrats, You Win!");
                    CIO.Render();
                    Console.ReadKey();
                }
            }
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

        public int Decision(GameState.ActivePlayerOptions Active)
        {
            int ManaCost = new int();
            switch (Active)
            {
                case GameState.ActivePlayerOptions.Player:
                    ManaCost = Present();
                    break;
                case GameState.ActivePlayerOptions.Computer:
                    ManaCost = Computer.Decide();
                    break;
            }
            return ManaCost;
        }

        public int Present()
        {
            int ManaCost = new int();
            if (Player.GetMana() == 0 && !Player.CanPlayCard(0))
            {
                ManaCost = -1;
            }
            else
            {
                string[] choices = { "Q", "W", "E", "R", "T", "Y" };
                string Options = "Your cards are ";
                for (int i = 0; i < Player.GetHand().Count; i++)
                {
                        Options += choices[i] + ": " + Player.GetHand().ElementAt(i).ToString() + "MP ";
                }
                Options += "Y: Skip Turn";
                Options += "\r\n" + "Your Stats: " + Player.GetHealth().ToString() + "HP " + Player.GetMana().ToString() + "MP to spend.";
                Options += "\r\n" + "Computer Stats: " + Computer.GetHealth().ToString() + "HP";
                CIO.WriteToBuffer(Options);
                CIO.Render();

                CIO.ReadToBuffer();
                switch (CIO.Input)
                {
                    case "Q":
                        ManaCost = Player.GetHand().ElementAt(0);
                        break;
                    case "W":
                        ManaCost = Player.GetHand().ElementAt(1);
                        break;
                    case "E":
                        ManaCost = Player.GetHand().ElementAt(2);
                        break;
                    case "R":
                        ManaCost = Player.GetHand().ElementAt(3);
                        break;
                    case "T":
                        ManaCost = Player.GetHand().ElementAt(4);
                        break;
                    case "Y":
                        ManaCost = -1;
                        break;
                    case "C":
                        CIO.Clear();
                        Present();
                        break;
                    case "Z":
                        CIO.Exit();
                        Present();
                        break;
                    default:
                        CIO.WriteToBuffer("That is not a valid option");
                        CIO.Render();
                        Present();
                        break;
                }
                if (!Player.CanUseMana(ManaCost))
                {
                    CIO.WriteToBuffer("You do not have enough Mana for that card");
                    CIO.Render();
                    Present();
                }
            }
            return ManaCost;
        }

        public void PlayCard(int ManaCost, GameState.ActivePlayerOptions Active)
        {
            switch (Active)
            {
                case GameState.ActivePlayerOptions.Player:
                    Player.RemoveCardFromHand(ManaCost);
                    Player.UseMana(ManaCost);
                    Computer.SubtractHealth(ManaCost);
                    break;
                case GameState.ActivePlayerOptions.Computer:
                    Computer.RemoveCardFromHand(ManaCost);
                    Computer.UseMana(ManaCost);
                    Player.SubtractHealth(ManaCost);
                    break;
            }
        }

        public bool IsGameOver()
        {
            if (Player.IsHealthDepleted() || Computer.IsHealthDepleted()) return true;
            else return false;
        }
    }
}
