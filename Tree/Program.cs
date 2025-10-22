namespace Tree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // grab scores from the file.
            string[] lines = File.ReadAllLines("scores.txt");
            List<int> scores = new List<int>();
            foreach (var line in lines)
            {
                if (int.TryParse(line, out int score))
                {
                    scores.Add(score); // Add each number to the list
                }
            }

            List<int> sortedScores = QuickSort(scores);

            // build the tree 
            TreeNode root = null;
            foreach (var score in sortedScores)
            {
                root = InsertToTree(root, score); // put scores into the tree
            }

            // publish tree
            Console.WriteLine("In-Order Traversal of the Tree:");
            InOrderTraversal(root);
        }

        // QuickSort
        static List<int> QuickSort(List<int> list)
        {
            if (list.Count <= 1) return list; // return if already sorted (or empty)

            int pivot = list[list.Count / 2]; // get the middle of the list
            list.RemoveAt(list.Count / 2);

            List<int> less = new List<int>();
            List<int> greater = new List<int>();

            foreach (var num in list)
            {
                if (num <= pivot)
                    less.Add(num); // smaller = go left
                else
                    greater.Add(num); // bigger = go right
            }

            // Recursively sort and put it all together
            var sorted = QuickSort(less);
            sorted.Add(pivot);
            sorted.AddRange(QuickSort(greater));
            return sorted;
        }

        /// the treeNode is the building block for the tree.
        class TreeNode
        {
            public int Value;
            public TreeNode Left, Right;
            public TreeNode(int value) => Value = value;
        }

        // Insert scores into the tree (( one by one
        static TreeNode InsertToTree(TreeNode node, int value)
        {
            if (node == null)
            {
                return new TreeNode(value); // New node gets made here
            }

            if (value < node.Value)
            {
                node.Left = InsertToTree(node.Left, value); // smaller goes left
            }
            else
            {
                node.Right = InsertToTree(node.Right, value); // bigger goes right
            }
            return node; // return the updated tree
        }

        // In-Order Traversal: Left -> Node -> Right // shows values in order
        static void InOrderTraversal(TreeNode node)
        {
            if (node == null) return;

            InOrderTraversal(node.Left); // Check the left side first
            Console.WriteLine(node.Value); // Then the node itself
            InOrderTraversal(node.Right); // then the right side
        }
    }
}
