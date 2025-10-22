using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarShuffle
{
    public class AsciiArt
    {
        private Dictionary<string, string> cardArt;

        public AsciiArt()
        {
            cardArt = new Dictionary<string, string>();
            InitializeAsciiArt();
        }

        private void InitializeAsciiArt()
        {
            // ace
            cardArt["AClubs"] = $@"
  _________  
 |A        | 
 |{"\u2663"}   *    | 
 |    !    | 
 |  *-+-*  | 
 |    |    | 
 |   ~~~  {"\u2663"}|
 |        V|
  ~~~~~~~~~  
";
            cardArt["ADiamonds"] = $@"
  _________  
 |A        | 
 |{"\u2666"}  /~\   | 
 |  / ^ \  | 
 | (  )    | 
 |  \ v /  | 
 |   \_/  {"\u2666"}|
 |        V|
  ~~~~~~~~~  
";
            cardArt["AHearts"] = $@"
  _________  
 |A        | 
 |{"\u2665"}   _    | 
 |   ( )   | 
 |  (_x_)  | 
 |   / \   | 
 |    I   {"\u2665"}|
 |        V|
  ~~~~~~~~~  
";
            cardArt["ASpades"] = $@"
  _________  
 |A        | 
 |{"\u2660"}   .    | 
 |   /.\   | 
 |  (_._)  | 
 |   /_\   | 
 |    |   {"\u2660"}|
 |        V|
  ~~~~~~~~~  
";

            // king
            cardArt["KClubs"] = $@"
  _________  
 |K |/|\   | 
 |{"\u2663"} /o,o\  | 
 |   \v/   | 
 |  XXXXX  | 
 |   /^\   | 
 |  o'o'o {"\u2663"}|
 |   /|\  K|
  ~~~~~~~~~  
";
            cardArt["KDiamonds"] = $@"
  _________  
 |K |/|\   | 
 |{"\u2666"} |o.o|  | 
 |   \v/   | 
 |  XXXXX  | 
 |   /^\   | 
 |  o'o'o {"\u2666"}|
 |   /|\  K|
  ~~~~~~~~~  
";
            cardArt["KHearts"] = $@"
  _________  
 |K |/|\   | 
 |{"\u2665"} |o.o|  | 
 |   \v/   | 
 |  XXXXX  | 
 |   /^\   | 
 |  o'o'o {"\u2665"}|
 |   /|\  K|
  ~~~~~~~~~  
";
            cardArt["KSpades"] = $@"
  _________  
 |K |/|\   | 
 |{"\u2660"} |o.o|  | 
 |   \v/   | 
 |  XXXXX  | 
 |   /^\   | 
 |  o'o'o {"\u2660"}|
 |   /|\  K|
  ~~~~~~~~~  
";

            // queen
            cardArt["QClubs"] = $@"
  _________  
 |Q |~~~   | 
 |{"\u2663"} /o,o\  | 
 |  \_-_/  | 
 | _-_-_-_ | 
 |  /   \  | 
 |   O O  {"\u2663"}|
 |    ~~~ Q|
  ~~~~~~~~~  
";
            cardArt["QDiamonds"] = $@"
  _________  
 |Q |~~~   | 
 |{"\u2666"} /o.o\  | 
 |  \_-_/  | 
 | _-_-_-_ | 
 |  /   \  | 
 |   O O  {"\u2666"}|
 |    ~~~ Q|
  ~~~~~~~~~  
";
            cardArt["QHearts"] = $@"
  _________  
 |Q |~~~    | 
 |{"\u2665"} /o.o\   | 
 |  \_-_/   | 
 | _-_-_-_  | 
 |  /   \   | 
 |   O O  {"\u2665"} |
 |    ~~~  Q|
  ~~~~~~~~~  
";
            cardArt["QSpades"] = $@"
  _________  
 |Q |~~~    | 
 |{"\u2660"} /o.o\   | 
 |  \_-_/   | 
 | _-_-_-_  | 
 |  /   \   | 
 |   O O  {"\u2660"} |
 |    ~~~  Q|
  ~~~~~~~~~  
";

            // jack
            cardArt["JClubs"] = $@"
  _________  
 |J /~~|_  | 
 |{"\u2663"} | o`,  | 
 |  | -|   | 
 | =~)-=~  | 
 |   |- |  | 
 |  `o' {"\u2663"} J|
 |   ~~/   |
  ~~~~~~~~~  
";
            cardArt["JDiamonds"] = $@"
  _________  
 |J /~~|_  | 
 |{"\u2666"} ( o`,  | 
 |  | -|   | 
 | =~)-=~  | 
 |   |- |  | 
 |  `o' {"\u2666"} J|
 |   ~~/   |
  ~~~~~~~~~  
";
            cardArt["JHearts"] = $@"
  _________  
 |J /~~|_  | 
 |{"\u2665"} ( o`,  | 
 |  | -|   | 
 | =~)-=~  | 
 |   |- |  | 
 |  `o' {"\u2665"} J|
 |   ~~/   |
  ~~~~~~~~~  
";
            cardArt["JSpades"] = $@"
  _________  
 |J /~~|_  | 
 |{"\u2660"} ( o`,  | 
 |  | -|   | 
 | =~)-=~  | 
 |   |- |  | 
 |  `o' {"\u2660"} J|
 |   ~~/   |
  ~~~~~~~~~  
";

            string[] suits = { "Clubs", "Diamonds", "Hearts", "Spades" };
            string[] numbers = { "2", "3", "4", "5", "6", "7", "8", "9", "10" };
            string[] suitSymbols = { "\u2663", "\u2666", "\u2665", "\u2660" };

            foreach (var number in numbers)
            {
                for (int i = 0; i < suits.Length; i++)
                {
                    string key = number + suits[i];
                    int temp = int.Parse(number);
                    string Thing()
                    {
                        if (temp > 0)
                        {
                            temp--;
                            return suitSymbols[i];
                        }
                        else
                        {
                            return " ";
                        }
                    }

                    cardArt[key] = $@"
  _________  
 |{number.PadRight(2)}       | 
 | {Thing()}  {Thing()}  {Thing()} | 
 |   {Thing()} {Thing()}   | 
 |   {Thing()} {Thing()}   | 
 | {Thing()}  {Thing()}  {Thing()} | 
 |        {number}|
  ~~~~~~~~~  
";
                }
            }
        }

        public string GetAsciiArt(Card card)
        {
            string key = card.GetCardKey();
            if (cardArt.ContainsKey(key))
            {
                return cardArt[key];
            }
            return "Card Art Not Found!";
        }
    }
}