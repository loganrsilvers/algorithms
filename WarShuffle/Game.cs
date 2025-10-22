using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarShuffle
{
    public class Game
    {
        private Deck player1Deck = new Deck(new List<Card>());
        private Deck player2Deck = new Deck(new List<Card>());
        private AsciiArt art;

        public Game()
        {
            art = new AsciiArt();
            InitializeDeck();
            PlayGame();
        }

        private void InitializeDeck()
        {
            int[] values = { 14, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
            string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
            string[] ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

            Deck fullDeck = new Deck(new List<Card>());

            foreach (var suit in suits)
            {
                for (int i = 0; i < ranks.Length; i++)
                {
                    fullDeck.Cards.Add(new Card(ranks[i], suit, values[i]));
                }
            }
            Shuffle.FisherYates(fullDeck);

            int halfDeckSize = fullDeck.Cards.Count / 2;
            player1Deck.Cards = fullDeck.Cards.GetRange(0, halfDeckSize);
            player2Deck.Cards = fullDeck.Cards.GetRange(halfDeckSize, halfDeckSize);
        }

        public void PlayGame()
        {
            int round = 1;
            while (player1Deck.Cards.Count > 0 && player2Deck.Cards.Count > 0)
            {
                Console.WriteLine($"\nRound {round}:");

                Card player1Card = player1Deck.DrawCard();
                Card player2Card = player2Deck.DrawCard();

                Console.WriteLine("Player 1's card:");
                switch (player1Card.GetSuit())
                {
                    case "Diamonds":
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        break;
                    case "Hearts":
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    case "Spades":
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        break;
                    case "Clubs":
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }
                Console.WriteLine(art.GetAsciiArt(player1Card));
                Console.WriteLine($"{player1Card.Rank} of {player1Card.GetSuit()}");
                Console.ResetColor();
                Console.ReadKey();



                // compare
                int comparison = player1Card.CompareTo(player2Card);
                Console.WriteLine("Player 2's card:");
                switch (player2Card.GetSuit())
                {
                    case "Diamonds":
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        break;
                    case "Hearts":
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    case "Spades":
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        break;
                    case "Clubs":
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }
                Console.WriteLine(art.GetAsciiArt(player2Card));
                Console.WriteLine($"{player2Card.Rank} of {player2Card.GetSuit()}");
                Console.ResetColor();
                Console.ReadKey();

                if (comparison > 0)
                {
                    Console.WriteLine("Player 1 wins the round!");
                    Console.ReadKey();
                    player1Deck.Cards.Add(player1Card);
                    player1Deck.Cards.Add(player2Card);
                }
                else if (comparison < 0)
                {
                    Console.WriteLine("Player 2 wins the round!");
                    Console.ReadKey();
                    player2Deck.Cards.Add(player1Card);
                    player2Deck.Cards.Add(player2Card);
                }
                else
                {
                    Console.WriteLine("It's a tie!");
                }

                Console.WriteLine($"Player 1 Deck Size: {player1Deck.Cards.Count}");
                Console.WriteLine($"Player 2 Deck Size: {player2Deck.Cards.Count}");
                Console.WriteLine($"Current round: {round}");

                Console.ReadKey();
                Console.Clear();

                round++;
            }

            if (player1Deck.Cards.Count > 0)
            {
                Console.WriteLine("Player 1 wins the game!");
            }
            else
            {
                Console.WriteLine("Player 2 wins the game!");
            }
        }
    }
}
