using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedDesigndProject
{
    public static class Algosy <T> where T:class
    {
        public static void ForEach(IEnumerable<T> iterator, Action<T> func)
        {
            foreach(T item in iterator)
            {
                func(item);
            }
        }
        public static int CountIf(IEnumerable<T> iterator, Func<T, bool> func)
        {
            int sum = 0;
            foreach (T item in iterator)
            {
                if(func(item))
                    sum++;
            }
            return sum;
        }
        public static T Find(IEnumerable<T> iterator, Func<T, bool> func)
        {
            foreach (T item in iterator)
            {
                if (func(item)) { return item; }
            }
            return null;
        }

    }
}
