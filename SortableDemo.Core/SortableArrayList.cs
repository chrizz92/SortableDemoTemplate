using System;
using System.Collections.Generic;

namespace SortableDemo.Core
{
    public class SortableArrayList
    {
        private const int ArrayEnlargeChunk = 10;
        private IComparable[] _items;
        private int _itemCount = 0;

        public SortableArrayList()
        {
            _items = new IComparable[ArrayEnlargeChunk];
        }

        public void Add(IComparable item)
        {
            if (_items.Length <= _itemCount)
            {
                //Array muss vergrößert werden
                EnlargeItemsArray();
            }

            _items[_itemCount] = item;
            _itemCount++;
        }

        private void EnlargeItemsArray()
        {
            IComparable[] enlargedArray = new IComparable[_items.Length + ArrayEnlargeChunk];
            for (int i = 0; i < _items.Length; i++)
            {
                enlargedArray[i] = _items[i];
            }
            _items = enlargedArray;
        }

        /// <summary>
        /// Inserts the element in the list at the specified index
        /// </summary>
        /// <param name="index"></param>
        /// <param name="item"></param>
        public void Insert(int index, IComparable item)
        {
            if (index >= 0)
            {
                while (Count() < index)
                {
                    EnlargeItemsArray();
                }
                _items[index] = item;
                _itemCount++;
            }
        }

        /// <summary>
        /// Removes the first occurrence of a specific object from the list
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Remove(IComparable item)
        {
            for (int i = 0; i < _itemCount; i++)
            {
                if (item.CompareTo(_items[i]) == 0)
                {
                    _items[i] = null;
                    _itemCount--;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Removes the element at the specified index
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index)
        {
            if (index < Count())
            {
                _items[index] = null;
                _itemCount--;
            }
        }

        /// <summary>
        /// Reverses the order of the elements in the entire list
        /// </summary>
        public void Reverse()
        {
            IComparable[] reversedList = new IComparable[Count()];
            int index = 0;
            for (int i = Count() - 1; i >= 0; i--)
            {
                reversedList[index] = _items[i];
                index++;
            }
            _items = reversedList;
        }

        /// <summary>
        /// Sorts the elements in the entire list using the default comparer
        /// </summary>
        public void Sort()
        {
            for (int i = 0; i < _itemCount; i++)
            {
                for (int j = i; j < _itemCount; j++)
                {
                }
            }
        }

        /// <summary>
        /// Gets the number of elements in the list
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return _itemCount;
        }

        /// <summary>
        /// Returns the biggest element (without sorting the list)
        /// </summary>
        /// <returns></returns>
        public IComparable GetHighestElement()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Indexer returns element at the specified index (read only indexer)
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public IComparable this[int index]
        {
            get
            {
                if (index >= 0 && index < _itemCount)
                    return _items[index];
                else
                    throw new IndexOutOfRangeException();
            }
        }
    }
}