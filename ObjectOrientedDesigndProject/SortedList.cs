using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedDesigndProject
{
    public class SortedList <T>  
    {
        private List<T> list;
        private Func<T,T, bool> predicate;
        public T this[int key]
        { get { return list[key]; }}
       public SortedList(Func<T, T, bool> function,List<T>?_list = null)
        {
            if (!(_list is null))
                list = _list;
            else 
                list = new List<T>();
            predicate = function;
        } 
        public void Add (T item)
        {
            bool hasBeenAdded = false;
            List<T> temp = new List<T> ();
            if (list.Count==0)
            {
                list.Add(item);
                return;
            }
            for(int i =0; i < list.Count ; i++)
            {
                temp.Add (list[i]);
                if (i+1 > list.Count-1) { break; }
                if (!hasBeenAdded && !predicate(list[i],item) && predicate(list[i+1],item))
                {
                    temp.Add(item) ;
                    hasBeenAdded = true;
                }
            }
            if (!hasBeenAdded) { temp.Add(item); }
            list = temp;
        }
        public void Delete (T item)
        {
            List<T> temp = new List<T>();
            for (int i = 0; i < list.Count; i++)
            {
                if (!item.Equals(list[i]))
                    temp.Add(list[i]);
            }
            list = temp;
        }
        public int Find(T item)
        {
            return binarySearch(0,list.Count-1,item);
        }

        private int binarySearch( int l, int r, T x)
        {
            if (r >= l)
            {
                int mid = l + (r - l) / 2;
                if (x.Equals(list[mid]))
                    return mid;
                if (!predicate(list[mid],x))
                    return binarySearch( l, mid - 1, x);
                return binarySearch( mid + 1, r, x);
            }
            return -1;
        }

        public IEnumerable<T> GetEnumerator()
        {
            int position = 0; // state
            while (position<list.Count)
            {

                yield return list[position];
                position++;
            }
        }
        public IEnumerable<T> GetReverseEnumerator()
        {
            int position = list.Count; // state
            while (position > 0)
            {
                position--;
                yield return list[position];
            }
        }

    }
}
