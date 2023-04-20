using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedDesigndProject.dynamicArray
{
    //To call in  reverse we gave to call IEnumerable item.Reverse()  :)
    public class DynamicArray<T> : IEnumerable where T : class
    {
        int position = -1;
        T[] array;
        public DynamicArray() {
            this.array = new T[0];
        }
        int count = 0;
        public int Count => count;

        public bool IsReadOnly => throw new NotImplementedException();

        public void Add(T item)
        {
            count++;
            T[] temp = new T[count];
            for (int i = 0; i<count-1;i++)
            {
                temp[i] = array[i];
            }
            temp[count] = item;
            array = temp;
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator GetEnumerator()
        {
            return this.array.GetEnumerator();
        }

        public bool Remove(T item)
        {
            T[] temp = new T[array.Length];
            if (item == null) { return false; }
            for (int i =0; i < array.Length; i++)
            {
                if (array[i].Equals(item))
                {
                    i++;
                }
                if (i<array.Length)
                {
                    temp[i] = array[i];
                }
            }
            array = temp; //kopytko
            return true;
        }
        public T? Find(T _item)
        {
            if (_item == null) return null;
            foreach(var item in this.array)
            {
                if (item.Equals(_item))
                {
                    return item;
                }
            }
            return null;
        }
    }
}

