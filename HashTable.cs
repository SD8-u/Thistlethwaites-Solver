using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubik_s_Cube
{
    public class HashTable
    {
        private LinkedList<Object[]>[] elements;
        private int bucketNo;
        private int count;

        public int Count
        {
            get { return count; }
        }

        public HashTable(int bucketNo)
        {
            this.bucketNo = bucketNo;
            elements = new LinkedList<Object[]>[bucketNo];
        }

        //Uses C#s GetHashCode to provide an index for a key
        private int GetIndex(Object key)
        {
            return Math.Abs(key.GetHashCode() % bucketNo);
        }

        //Retruns true or false depening on whether the key is present
        public bool Contains(Object key)
        {
            int index = GetIndex(key);
            if(elements[index] != null)
            {
                foreach (Object[] keyValue in elements[index])
                {
                    if (keyValue[0].Equals(key))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        //Returns the value stored at a specific key
        public Object FindValue(Object key)
        {
            int index = GetIndex(key);
            if(elements[index] != null)
            {
                foreach (Object[] keyValue in elements[index])
                {
                    if (keyValue[0].Equals(key))
                    {
                        return keyValue[1];
                    }
                }
            }
            return null;
        }

        //Adds only a key when values do not need to be stored
        public void Add(Object key)
        {
            count++;
            int index = GetIndex(key);
            Object[] keyValue = new object[1];
            keyValue[0] = key;
            if (elements[index] == null)
            {
                elements[index] = new LinkedList<Object[]>();
            }
            elements[index].AddLast(keyValue);
        }

        //Adds a key and a corresponding value
        public void Add(Object key, Object value)
        {
            int index = GetIndex(key);
            Object[] keyValue = new object[2];
            keyValue[0] = key; keyValue[1] = value;
            if(elements[index] == null)
            {
                elements[index] = new LinkedList<Object[]>();
            }
            elements[index].AddLast(keyValue);
        }
    }
}
