using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarShuffle
{
    public class Shuffle
    {
        public static void FisherYates(Deck deck)
        {
            Random rand = new Random();

            // log numbers from 1 through N (deck.Cards.Count)
            for (int i = deck.Cards.Count - 1; i > 0; i--)
            {
                // Pick random number from 1 - the number of remaining numbers
                int k = rand.Next(i + 1);

                // Counting from the low end, strike out the kth number not yet struck out /// write it down at the end of the separate list
                Card temp = deck.Cards[i];
                deck.Cards[i] = deck.Cards[k];
                deck.Cards[k] = temp;

                // repeat from step 2 until all the numbers have been struck out
                // sequence of numbers written down in step 3 is now a random permutation of the original numbers
                // iterate backwards and swapping each element with a random earlier (or the same) element 
            }
        }
    }
}
