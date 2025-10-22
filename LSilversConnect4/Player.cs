using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSilversConnect4
{
    internal class Player
    {
        public int PlayerNumber { get; private set; }
        public ConsoleColor Color { get; private set; }

        public Player(int number, ConsoleColor color)
        {
            PlayerNumber = number;
            Color = color;
        }

        public void PrintTurn()
        {

            int padding = (Console.WindowWidth - 20) / 2;
            Console.Write(new string(' ', padding));

            Console.ForegroundColor = Color;
            Console.Write($"Player {PlayerNumber}");
            Console.ResetColor();
            Console.WriteLine("'s turn.");
            Console.Write(new string(' ', padding));
            Console.WriteLine("Choose a column (1-7): ");
            Console.Write(new string(' ', padding));
            Console.WriteLine("(type a number below)");
            Console.Write(new string(' ', padding));
        }
    }
}
