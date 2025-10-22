using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

static class Program
{
    static void Main()
    {
        string filePath = "scores.txt";
        List<int> scores = ReadData(filePath);

        Console.WriteLine("Original Scores: ");
        PrintScoresWithColor(scores);

        TestSortingAlgorithm("Bubble Sort", scores, BubbleSort);
        TestSortingAlgorithm("Insertion Sort", scores, InsertionSort);
        TestSortingAlgorithm("Selection Sort", scores, SelectionSort);
        TestSortingAlgorithm("Heap Sort", scores, HeapSort);
        TestSortingAlgorithm("Quick Sort", scores, QuickSort);
        TestSortingAlgorithm("Merge Sort", scores, MergeSort);
    }

    static List<int> ReadData(string filePath)
    {
        var scores = new List<int>();
        foreach (var line in File.ReadAllLines(filePath))
       {
            var numbers = line.Split(' ');
            foreach (var number in numbers)
            {
                if (int.TryParse(number, out int score))
                {
                    scores.Add(score);
                }
            }
        }
        return scores;
    }

    static void TestSortingAlgorithm(string name, List<int> originalData, Action<List<int>> sortMethod)
    {
        var data = new List<int>(originalData);
        var stopwatch = Stopwatch.StartNew();
        sortMethod(data);
        stopwatch.Stop();

        Console.WriteLine($"{name} Results:");
        PrintScoresWithColor(data);
        Console.WriteLine($"Time Taken: {stopwatch.ElapsedMilliseconds} ms");
        Console.WriteLine();
    }

    static void PrintScoresWithColor(List<int> scores)
    {
        foreach (var score in scores)
        {
            SetConsoleColor(score);
            Console.Write($"{score} ");
        }
        Console.ResetColor();
        Console.WriteLine();
    }

    static void SetConsoleColor(int score)
    {
        if (score <= 39)
            Console.ForegroundColor = ConsoleColor.Red;
        else if (score <= 59)
            Console.ForegroundColor = ConsoleColor.Yellow;
        else if (score <= 69)
            Console.ForegroundColor = ConsoleColor.Green;
        else if (score <= 79)
            Console.ForegroundColor = ConsoleColor.Cyan;
        else if (score <= 89)
            Console.ForegroundColor = ConsoleColor.Blue;
        else
            Console.ForegroundColor = ConsoleColor.Magenta;
    }

    // Bubble Sort: Repeatedly swap adjacent elements if they are in the wrong order
    static void BubbleSort(List<int> data)
    {
        for (int i = 0; i < data.Count - 1; i++)
        {
            for (int j = 0; j < data.Count - i - 1; j++)
            {
                if (data[j] > data[j + 1])
                {
                    (data[j], data[j + 1]) = (data[j + 1], data[j]); // Swap
                }
            }
        }
    }

    // Insertion Sort: Build the sorted list one element at a time
    static void InsertionSort(List<int> data)
    {
        for (int i = 1; i < data.Count; i++)
        {
            int key = data[i];
            int j = i - 1;
            while (j >= 0 && data[j] > key)
            {
                data[j + 1] = data[j];
                j--;
            }
            data[j + 1] = key;
        }
    }

    // Selection Sort: Find the minimum element and place it at the start
    static void SelectionSort(List<int> data)
    {
        for (int i = 0; i < data.Count - 1; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < data.Count; j++)
            {
                if (data[j] < data[minIndex])
                {
                    minIndex = j;
                }
            }
            (data[i], data[minIndex]) = (data[minIndex], data[i]); // Swap
        }
    }

    // Heap Sort: Build a max-heap and extract the maximum element
    static void HeapSort(List<int> data)
    {
        int n = data.Count;

        // Build max heap
        for (int i = n / 2 - 1; i >= 0; i--)
            Heapify(data, n, i);

        // Extract elements from heap
        for (int i = n - 1; i > 0; i--)
        {
            (data[0], data[i]) = (data[i], data[0]); // Swap
            Heapify(data, i, 0);
        }
    }

    static void Heapify(List<int> data, int n, int i)
    {
        int largest = i;
        int left = 2 * i + 1;
        int right = 2 * i + 2;

        if (left < n && data[left] > data[largest])
            largest = left;

        if (right < n && data[right] > data[largest])
            largest = right;

        if (largest != i)
        {
            (data[i], data[largest]) = (data[largest], data[i]); // Swap
            Heapify(data, n, largest);
        }
    }

    // Quick Sort: Divide and conquer, using a pivot
    static void QuickSort(List<int> data)
    {
        QuickSort(data, 0, data.Count - 1);
    }

    static void QuickSort(List<int> data, int low, int high)
    {
        if (low < high)
        {
            int pi = Partition(data, low, high);
            QuickSort(data, low, pi - 1);
            QuickSort(data, pi + 1, high);
        }
    }

    static int Partition(List<int> data, int low, int high)
    {
        int pivot = data[high];
        int i = low - 1;

        for (int j = low; j < high; j++)
        {
            if (data[j] < pivot)
            {
                i++;
                (data[i], data[j]) = (data[j], data[i]); // Swap
            }
        }

        (data[i + 1], data[high]) = (data[high], data[i + 1]); // Swap
        return i + 1;
    }

    // Merge Sort: Divide and conquer, merging sorted halves
    static void MergeSort(List<int> data)
    {
        if (data.Count <= 1)
            return;

        int mid = data.Count / 2;
        var left = new List<int>(data.GetRange(0, mid));
        var right = new List<int>(data.GetRange(mid, data.Count - mid));

        MergeSort(left);
        MergeSort(right);
        Merge(data, left, right);
    }

    static void Merge(List<int> data, List<int> left, List<int> right)
    {
        int i = 0, j = 0, k = 0;

        while (i < left.Count && j < right.Count)
        {
            if (left[i] <= right[j])
                data[k++] = left[i++];
            else
                data[k++] = right[j++];
        }

        while (i < left.Count)
            data[k++] = left[i++];

        while (j < right.Count)
            data[k++] = right[j++];
    }
}
