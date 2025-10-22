using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGame
{
    internal class Player
    {
        public int X { get; set; }
        public int Y { get; set; }
        private string Name { get; set; }
        private ConsoleColor playerColor;
        public Player(int x, int y)
        {
            X = x;
            Y = y;
            Name = "O";
            playerColor = ConsoleColor.Magenta;
        }
        public void Draw()
        {
            Console.ForegroundColor = playerColor;
            Console.SetCursorPosition(X, Y);
            Console.Write(Name);
            Console.ResetColor();
        }
    }
}
