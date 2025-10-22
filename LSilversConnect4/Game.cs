using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSilversConnect4
{
    public class Game
    {

        Board board = new Board();
        Player player1 = new Player(1, ConsoleColor.Magenta);
        Player player2 = new Player(2, ConsoleColor.DarkYellow);

        public void Play()
        {
            
            bool gameWon = false;
            bool isDraw = false;
            Player currentPlayer = player1;

            while (!gameWon && !isDraw)
            {
                board.PrintBoard();
                currentPlayer.PrintTurn();

                int column;
                while (!int.TryParse(Console.ReadLine(), out column) || column < 1 || column > 7 || !board.IsColumnAvailable(column - 1))
                {
                    Console.WriteLine("Invalid column! Please choose a valid column (1-7) that is not full.");
                }

                board.DropPiece(currentPlayer.PlayerNumber, column - 1);

                if (board.CheckForWinner(currentPlayer.PlayerNumber))
                {
                    board.PrintBoard();
                    int padding = (Console.WindowWidth - 20) / 2;
                    Console.Write(new string(' ', padding));
                    Console.ForegroundColor = currentPlayer.Color;
                    Console.WriteLine($"Player {currentPlayer.PlayerNumber} wins!");
                    Console.WriteLine(@"
 \O    \O/  O/ '\   /`\O/     \O/  '\   /` |_O_|
  |    _Y  <|    \ /   Y___,   Y_    \ /    _|  
 / \ _| |  / \    Y    |      /  |    X   _|  \ 
_\ /_   |__| |_  /O   _|    ./   |_  /O\      |_");
                    Console.ResetColor();
                    gameWon = true;
                }
                else if (board.IsBoardFull())
                {
                    int padding = (Console.WindowWidth - 20) / 2;
                    Console.Write(new string(' ', padding));
                    board.PrintBoard();
                    Console.WriteLine("The game is a draw!");
                    isDraw = true;
                }
                else
                {
                    currentPlayer = (currentPlayer == player1) ? player2 : player1;
                }
            }
        }
    }
}

