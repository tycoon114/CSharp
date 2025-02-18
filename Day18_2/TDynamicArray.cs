﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Day18_2
{
    class TDynamicArray<T>
    {
        protected T[] objects = new T[10];

        protected int count = 0;

        public int Count
        {
            get
            {
                return count;
            }
        }

        public T this[int index]
        {
            get
            {
                return objects[index];
            }
            set
            {
                if (index < objects.Length)
                {
                    objects[index] = value;
                }
            }
        }


        public TDynamicArray()
        {
        }

        ~TDynamicArray()
        {
        }

        public void Add(T item)
        {
            if (count >= objects.Length)
            {
                ExtendSpace();
            }
            objects[count] = item;
            count++;
        }

        protected void ExtendSpace()
        {
            T[] newObject = new T[objects.Length * 2];

            for (int i = 0; i < objects.Length; ++i)
            {
                newObject[i] = objects[i];
            }
            objects = null;
            objects = newObject;
        }

        public bool Remove(T item)
        {
            for (int i = 0; i < Count; ++i)
            {
                if (item.Equals(objects[i]))
                {
                    return RemoveAt(i);
                }
            }
            return false;
        }

        public bool RemoveAt(int index)
        {
            if (index >= 0 && index < Count)
            {
                for (int i = index; i < Count - 1; ++i)
                {
                    objects[i] = objects[i + 1];
                }
                count--;
                return true;
            }
            return false;
        }

        public void Insert(int insertIndex, T value)
        {
            if (objects.Length == count)
            {
                ExtendSpace();
            }

            for (int i = count; i > insertIndex; --i)
            {
                objects[i] = objects[i - 1];
            }
            objects[insertIndex ] = value;
            count++;


        }

    }
}
