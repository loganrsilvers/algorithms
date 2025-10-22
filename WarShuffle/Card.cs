using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarShuffle
{
    public class Card
    {
        public string Rank { get; set; }
        public string Suit { get; set; }
        public int Value { get; set; }

        public Card(string rank, string suit, int value)
        {
            Rank = rank;
            Suit = suit;
            Value = value;
        }

        public override string ToString()
        {
            return $"{Value} of {Suit}";
        }
        public string GetCardKey()
        {
            return $"{Rank}{Suit}";
        }
        public string GetSuit()
        {
            return Suit;
        }
        public int CompareTo(Card other)
        {
            if (other == null)
            {
                return 1;
            }
            else
            {
                return this.Value.CompareTo(other.Value);
            }
        }
    }
}
