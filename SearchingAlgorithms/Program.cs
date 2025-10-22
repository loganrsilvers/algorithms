using System.Diagnostics;

namespace SearchingAlgorithms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Load scores from file
            string[] lines = File.ReadAllLines("scores.txt");
            List<int> scores = new List<int>();
            foreach (var line in lines)
            {
                if (int.TryParse(line, out int score))
                    scores.Add(score);
            }
            scores.Sort(); // Ensure the data is sorted

            // Get input from the user
            Console.WriteLine("Enter a score to search for:");
            if (!int.TryParse(Console.ReadLine(), out int target))
            {
                Console.WriteLine("Invalid input. Exiting.");
                return;
            }

            // Perform searches
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nPerforming Linear Search...");
            PerformSearch("Linear Search", scores, target, LinearSearch);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\nPerforming Binary Search...");
            PerformSearch("Binary Search", scores, target, BinarySearch);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nPerforming Interpolation Search...");
            PerformSearch("Interpolation Search", scores, target, InterpolationSearch);
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void PerformSearch(string algorithm, List<int> data, int target, Func<List<int>, int, int> searchMethod)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            int index = searchMethod(data, target);

            stopwatch.Stop();
            Console.WriteLine($"{algorithm}:");
            Console.WriteLine($"- Result: {(index != -1 ? $"Found at index {index}" : "Not Found")}");
            Console.WriteLine($"- Time Taken: {stopwatch.ElapsedTicks} ticks");
        }

        static int LinearSearch(List<int> data, int target)
        {
            for (int i = 0; i < data.Count; i++)
            {
                if (data[i] == target)
                    return i;
            }
            return -1;
        }

        static int BinarySearch(List<int> data, int target)
        {
            int left = 0, right = data.Count - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (data[mid] == target)
                    return mid;
                if (data[mid] < target)
                    left = mid + 1;
                else
                    right = mid - 1;
            }
            return -1;
        }

        static int InterpolationSearch(List<int> data, int target)
        {
            int low = 0, high = data.Count - 1;
            while (low <= high && target >= data[low] && target <= data[high])
            {
                if (low == high)
                {
                    if (data[low] == target)
                        return low;
                    return -1;
                }

                int pos = low + ((target - data[low]) * (high - low) / (data[high] - data[low]));
                if (data[pos] == target)
                    return pos;
                if (data[pos] < target)
                    low = pos + 1;
                else
                    high = pos - 1;
            }
            return -1;
        }
    }
}
