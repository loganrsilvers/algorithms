using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagIterator
{
    public class Iterator<T>
    {
        //public Node<T> Next(Node<T> numberNode1)
        //{
        //    Node<int> next = numberNode1;
        //    while (next != null)
        //    {
        //        Console.WriteLine(next.value);
        //        next = next.next;
        //    }
        //}
        private List<T> randomizedList;
        private int currentIndex;

        public Iterator(LinkedList<T> list)
        {
            randomizedList = new List<T>();
            Node<T>? current = list.Head;
            while (current != null)
            {
                randomizedList.Add(current.Data);
                current = current.Next;
            }

            Random rand = new Random();
            for (int i = 0; i < randomizedList.Count; i++)
            {
                int randomIndex = rand.Next(i, randomizedList.Count);
                T temp = randomizedList[i];
                randomizedList[i] = randomizedList[randomIndex];
                randomizedList[randomIndex] = temp;
            }
            currentIndex = 0;
        }

        public bool HasNext()
        {
            return currentIndex < randomizedList.Count;
        }

        public T Next()
        {
            if (HasNext())
            {
                return randomizedList[currentIndex++];
            }
            throw new InvalidOperationException("no more");
        }
    }
}
