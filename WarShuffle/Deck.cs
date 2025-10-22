using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarShuffle
{
    public class Deck
    {
        public List<Card> Cards { get; set; }

        public Deck(List<Card> cards)
        {
            Cards = new List<Card>(cards);
        }

        public Card DrawCard()
        {
            if (Cards.Count == 0)
            {
                throw new InvalidOperationException("No more cards in the deck!");
            }

            Card cardToDraw = Cards[0];
            Cards.RemoveAt(0);
            return cardToDraw;
        }

        public void DisplayDeck(AsciiArt art)
        {
            foreach (var card in Cards)
            {
                switch (card.GetSuit())
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
                Console.WriteLine(art.GetAsciiArt(card));
                Console.ResetColor();
            }
        }
    }
}
