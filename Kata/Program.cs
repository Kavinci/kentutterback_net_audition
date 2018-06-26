using System;

namespace Kata
{
    class Program
    {
        static void Main()
        {
            GameLogic Game = new GameLogic();
            Game.StartGame();
            PlayAgain();
        }

        static void PlayAgain()
        {
            Console.WriteLine("\r\n" + "Would you like to play again? y/n" + "\r\n");
            string key = Console.ReadKey().KeyChar.ToString().ToUpper();
            if(key == "Y")
            {
                Main();
            }
            else if(key == "N")
            {
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("That is not a valid input" + "\r\n");
            }
        }
    }
}
