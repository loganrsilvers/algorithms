using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace MazeGame
{
    internal class World
    {
        private string[,] Grid;
        private int Rows;
        private int Cols;

        public World(string[,] grid)
        {
            Grid = grid;
            Rows = Grid.GetLength(0);
            Cols = Grid.GetLength(1);
        }

        public void Draw()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    string str = Grid[i, j];
                    SetCursorPosition(j, i);
                    if (str == "X")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Write(str);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Write(str);
                    }
                }
            }
        }

        public string getThing(int x, int y)
        {
            return Grid[y, x];
        }

        public bool IsWalkable(int x, int y)
        {
            if (x < 0 || y < 0 || x >= Cols || y >= Rows) return false;

            return Grid[y, x] == " " || Grid[y, x] == "X";

        }
    }
}
