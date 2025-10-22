
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSilversConnect4
{
    public class Board
    {
        const int Rows = 6;
        const int Columns = 7;
        int[,] grid = new int[Rows, Columns];


        public bool DropPiece(int player, int column)
        {
            for (int row = Rows - 1; row >= 0; row--)
            {
                if (grid[row, column] == 0)
                {
                    grid[row, column] = player;
                    return true;
                }
            }
            return false;
        }

        public bool IsColumnAvailable(int column)
        {
            return grid[0, column] == 0;
        }

        // Check for 4 in a row (horizontal, vertical, diagonal)
        public bool CheckForWinner(int player)
        {
            return CheckHorizontal(player) || CheckVertical(player) || CheckDiagonal(player);
        }

        public bool IsBoardFull()
        {
            for (int col = 0; col < Columns; col++)
            {
                if (grid[0, col] == 0)
                {
                    return false;
                }
            }
            return true;
        }

        //ASCII stuff and colors
        public void PrintBoard()
        {
            Console.Clear();

            int contentWidth = Columns * 3 - 1; 
            int padding = (Console.WindowWidth - contentWidth) / 2;
            Console.WriteLine();
            Console.Write(new string(' ', padding));
            Console.WriteLine("Connect 4");
            for (int row = 0; row < Rows; row++)
            {
                Console.Write(new string(' ', padding));
                for (int col = 0; col < Columns; col++)
                {
                    switch (grid[row, col])
                    {
                        case 0:
                            Console.Write("\u25A0 ");  // Empty space
                            break;
                        case 1:
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write("\u25A0 ");  // Player 1's piece
                            Console.ResetColor();
                            break;
                        case 2:
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("\u25A0 ");  // Player 2's piece
                            Console.ResetColor();
                            break;
                    }
                }
                Console.WriteLine();
            }
            Console.Write(new string(' ', padding));
            Console.WriteLine("1 2 3 4 5 6 7 \n");
        }

        // Helper methods for win conditions
        private bool CheckHorizontal(int player)
        {
            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Columns - 3; col++)
                {
                    if (grid[row, col] == player &&
                        grid[row, col + 1] == player &&
                        grid[row, col + 2] == player &&
                        grid[row, col + 3] == player)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool CheckVertical(int player)
        {
            for (int col = 0; col < Columns; col++)
            {
                for (int row = 0; row < Rows - 3; row++)
                {
                    if (grid[row, col] == player &&
                        grid[row + 1, col] == player &&
                        grid[row + 2, col] == player &&
                        grid[row + 3, col] == player)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool CheckDiagonal(int player)
        {
            // Bottom-left to top-right
            for (int row = 3; row < Rows; row++)
            {
                for (int col = 0; col < Columns - 3; col++)
                {
                    if (grid[row, col] == player &&
                        grid[row - 1, col + 1] == player &&
                        grid[row - 2, col + 2] == player &&
                        grid[row - 3, col + 3] == player)
                    {
                        return true;
                    }
                }
            }

            // Top-left to bottom-right
            for (int row = 0; row < Rows - 3; row++)
            {
                for (int col = 0; col < Columns - 3; col++)
                {
                    if (grid[row, col] == player &&
                        grid[row + 1, col + 1] == player &&
                        grid[row + 2, col + 2] == player &&
                        grid[row + 3, col + 3] == player)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
