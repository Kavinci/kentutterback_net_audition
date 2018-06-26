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
                if(Player.GetHealth() <= 0)
                {
                    CIO.WriteToBuffer("Computer Wins!" + "\r\n" + "Good Game Player!");
                    CIO.Render();
                }
                if (Computer.GetHealth() <= 0)
                {
                    CIO.WriteToBuffer("Congrats, You Win!");
                    CIO.Render();
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
            i = 1;
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
                    ManaCost = Computer.Decide(CIO);
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
                Options += "Y: End Turn";
                Options += "\r\n" + "Your Stats: " + Player.GetHealth().ToString() + "HP " + Player.GetMana().ToString() + "MP to spend.";
                Options += "\r\n" + "Computer Stats: " + Computer.GetHealth().ToString() + "HP";
                CIO.WriteToBuffer(Options);
                CIO.Render();

                CIO.ReadToBuffer();
                switch (CIO.Input)
                {
                    case "Q":
                        if (Player.GetHand().Count() >= 1)
                        {
                            ManaCost = Player.GetHand().ElementAt(0);
                        }
                        else
                        {
                            CIO.WriteToBuffer("That is not a valid option");
                            CIO.Render();
                            ManaCost = Present();
                        }
                        break;
                    case "W":
                        if (Player.GetHand().Count() >= 2)
                        {
                            ManaCost = Player.GetHand().ElementAt(1);
                        }
                        else
                        {
                            CIO.WriteToBuffer("That is not a valid option");
                            CIO.Render();
                            ManaCost = Present();
                        }
                        break;
                    case "E":
                        if (Player.GetHand().Count() >= 3)
                        {
                            ManaCost = Player.GetHand().ElementAt(2);
                        }
                        else
                        {
                            CIO.WriteToBuffer("That is not a valid option");
                            CIO.Render();
                            ManaCost = Present();
                        }
                        break;
                    case "R":
                        if (Player.GetHand().Count() >= 4)
                        {
                            ManaCost = Player.GetHand().ElementAt(3);
                        }
                        else
                        {
                            CIO.WriteToBuffer("That is not a valid option");
                            CIO.Render();
                            ManaCost = Present();
                        }
                        break;
                    case "T":
                        if (Player.GetHand().Count() == 5)
                        {
                            ManaCost = Player.GetHand().ElementAt(4);
                        }
                        else
                        {
                            CIO.WriteToBuffer("That is not a valid option");
                            CIO.Render();
                            ManaCost = Present();
                        }
                        break;
                    case "Y":
                        ManaCost = -1;
                        break;
                    case "C":
                        CIO.Clear();
                        ManaCost = Present();
                        break;
                    case "Z":
                        CIO.Exit();
                        break;
                    default:
                        CIO.WriteToBuffer("That is not a valid option");
                        CIO.Render();
                        ManaCost = Present();
                        break;
                }
                if (!Player.CanUseMana(ManaCost))
                {
                    CIO.WriteToBuffer("You do not have enough Mana for that card");
                    CIO.Render();
                    ManaCost = Present();
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
                    CIO.WriteToBuffer("Computer plays " + ManaCost + "MP");
                    CIO.Render();
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
