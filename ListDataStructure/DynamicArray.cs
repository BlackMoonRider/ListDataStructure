using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListDataStructure
{
    public class DynamicArray
    {
        private object[] array;

        public DynamicArray()
        {
            Clear();
        }

        public object this[int i]
        {
            get => array[i];
            set => array[i] = value;
        }

        public int Count { get => array.Length; }

        private object[] GetNewEmptyArray()
        {
            int newArrayLength = array.Length + 1;
            return new object[newArrayLength];
        }

        private bool SplitArrayAtIndex(int index, out object[] outputArray1, out object[] outputArray2)
        {
            object[] inputArray = array;

            if (index >= inputArray.Length - 1)
            {
                outputArray1 = null;
                outputArray2 = null; 
                return false;
            }

            outputArray1 = new object[index];

            for (int i = 0; i < outputArray1.Length; i++)
            {
                outputArray1[i] = inputArray[i];
            }

            outputArray2 = new object[inputArray.Length - index];

            for (int i = index; i < outputArray2.Length + index; i++)
            {
                outputArray2[i - index] = inputArray[i];
            }

            return true;
        }

        public void Add(object item)
        {
            object[] newArray = GetNewEmptyArray();

            array.CopyTo(newArray, 0);
            newArray[newArray.Length - 1] = item;
            array = newArray;
        }

        public void Insert(int index, object item)
        {
            if (index == array.Length)
            {
                Add(item);
                return;
            }

            if (index == 0)
            {
                object[] newArray = GetNewEmptyArray();
                newArray[0] = item;
                for (int i = 1; i < newArray.Length; i++)
                {
                    newArray[i] = array[i - 1];
                }
                array = newArray;
                return;
            }

            if (index + 1 > array.Length)
            {
                object[] newArray = new object[index + 1];
                for (int i = 0; i < array.Length; i++)
                {
                    newArray[i] = array[i];
                }
                newArray[index] = item;
                array = newArray;
            }

            if (index + 1 < array.Length)
            {
                object[] newArrayBeforeIndex;
                object[] newArrayAfterIndex;

                if (!SplitArrayAtIndex(index, out newArrayBeforeIndex, out newArrayAfterIndex))
                    return;

                object[] newArray = GetNewEmptyArray();
                newArrayBeforeIndex.CopyTo(newArray, 0);
                newArray[index] = item;
                newArrayAfterIndex.CopyTo(newArray, index + 1);
                array = newArray;

            }

        }

        public void RemoveAt(int index)
        {
            if (index == 0)
            {
                object[] newArray = new object[array.Length - 1];

                for (int i = 1; i < array.Length; i++)
                {
                    newArray[i - 1] = array[i];
                }

                array = newArray;
            }

            if (index > 0 && index < array.Length)
            {
                object[] newArray = new object[array.Length - 1];

                object[] newArrayBeforeIndex;
                object[] newArrayAfterIndex;

                if (!SplitArrayAtIndex(index, out newArrayBeforeIndex, out newArrayAfterIndex))
                    return;

                newArrayBeforeIndex.CopyTo(newArray, 0);
                for (int i = 1; i < newArrayAfterIndex.Length; i++)
                {
                    newArray[i + index - 1] = newArrayAfterIndex[i];
                }
                array = newArray;
            }
        }

        public int IndexOf(object item)
        {
            int index = -1;
            Type objType = item.GetType();

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].GetType() == objType)
                    if (item.GetHashCode() == array[i].GetHashCode())
                    {
                        index = i;
                        break;
                    }
            }

            return index;
        }

        public void Remove(object item)
        {
            int index = IndexOf(item);

            if (index == -1)
                return;
            else
                RemoveAt(index);
        }

        public bool Contains(object item)
        {
            bool contains = false;

            if (IndexOf(item) != -1)
                contains = true;

            return contains;
        }

        public void Reverse()
        {
            object[] reversedArray = new object[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                reversedArray[i] = array[array.Length - 1 - i];
            }

            array = reversedArray;
        }

        public void Clear()
        {
            array = new object[0];
        }

        public object[] ToArray()
        {
            return array;
        }
    }
}
