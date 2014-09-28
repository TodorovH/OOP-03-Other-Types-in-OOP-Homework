using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericList
{
    [Version(1.23)]
    public class GenericList<T> where T : IComparable<T>
    {
        const int DefaultCapacity = 16;

        private T[] elements;
        private int count = 0;

        public GenericList(int capacity = DefaultCapacity)
        {
            this.elements = new T[capacity];
        }

        public int Count
        {
            get
            {
                return this.count;
            }
        }

        public void Add(T element)
        {
            if (count >= elements.Length)
            {
                Expand();
            }
            this.elements[count] = element;
            count++;
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= this.count)
                {
                    throw new IndexOutOfRangeException(string.Format("Invalid index: {}.", index));
                }
                T result = this.elements[index];
                return result;
            }
            set
            {
                this.elements[index] = value;
            }
        }

        public void RemoveByIndex(int index)
        {
            try
            {
                if (index < this.count-1)
                {
                    for (int i = index; i < this.count; i++)
                    {
                        this.elements[i] = this.elements[i + 1];
                    }
                    this.count--;
                }
                else if (index == this.count-1)
                {
                    this.count--;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
            catch (IndexOutOfRangeException)
            {
                throw new IndexOutOfRangeException(string.Format("Index {0} out of range.", index));
            }
        }

        public int IndexOf(T element)
        {
            for (int i = 0; i < this.count-1; i++)
            {
                if (this.elements[i].Equals(element))
                {
                    return i;
                }
            }
            return -1;
        }

        public bool Contains(T element)
        {
            if (this.IndexOf(element) != -1)
            {
                return true;
            }
            return false;
        }

        public void Insert(int index, T element)
        {
            try
            {
                if (index < 0)
                {
                    throw new IndexOutOfRangeException();
                }
                if (index >= this.elements.Length)
                {
                    Expand();
                }
                for (int i = this.count; i > index; i--)
                {
                    this.elements[i] = this.elements[i - 1];
                }
                this.count++;
                this.elements[index] = element;
              
            }
            catch (IndexOutOfRangeException)
            {
                throw new IndexOutOfRangeException(string.Format("Index {0} is out of range.", index));
            }
        }

        public void Clear()
        {
            this.elements = new T[this.elements.Length];
            this.count = 0;
        }

        public void Expand()
        {
            T[] tempList = new T[this.elements.Length * 2];
            Array.Copy(this.elements, tempList, this.elements.Length);
            this.elements = tempList;
        }

        public override string ToString()
        {
            string result = "";

            foreach (T element in elements)
            {
                result += element + ", ";
            }


            return result.ToString().Trim(' ', ',');
        } 

        public T Min()
        {
            var min = this.elements[0];
            for (int i = 0; i < this.elements.Length; i++)
            {
                if (min.CompareTo(this.elements[i]) > 0)
                {
                    min = this.elements[i];
                }
            }
            return min;
        }

        public T Max()
        {
            var max = this.elements[0];
            for (int i = 0; i < this.elements.Length; i++)
            {
                if (max.CompareTo(this.elements[i]) < 0)
                {
                    max = this.elements[i];
                }
            }
            return max;
        }
    }
}
