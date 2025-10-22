namespace BagIterator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bag<int> bag = new Bag<int>();
            bag.Add(1);
            bag.Add(2);
            bag.Add(3);
            bag.Add(4);
            bag.Add(5);

            // Display the bag elements in different colors
            DisplayBagElements(bag, ConsoleColor.Cyan);
            DisplayBagElements(bag, ConsoleColor.Magenta);
            DisplayBagElements(bag, ConsoleColor.Yellow);
            DisplayBagElements(bag, ConsoleColor.Green);
            DisplayBagElements(bag, ConsoleColor.Red);
        }
        private static void DisplayBagElements(Bag<int> bag, ConsoleColor color)
        {
            Console.Clear();
            Console.ForegroundColor = color;
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Randomized Bag Elements:");

            var iterator = bag.GetIterator();
            while (iterator.HasNext())
            {
                Console.Write("\n    ");
                Console.Write(iterator.Next());
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}