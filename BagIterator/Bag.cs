using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BagIterator
{
    public class Bag<T>
    {
        private LinkedList<T> list = new LinkedList<T>();

        public void Add(T element)
        {
            list.Add(element);
        }

        public int Size()
        {
            return list.Count;
        }

        public Iterator<T> GetIterator()
        {
            return new Iterator<T>(list);
        }
    }
}
