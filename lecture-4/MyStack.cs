using System;
using System.Collections;
using System.Collections.Generic;
// https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.stack-1?view=netcore-3.1


namespace Lecture4
{
	class MyStack<T> : IEnumerable
	{
		private const int INITIAL_CAPACITY = 10;

		private T[] items = new T[INITIAL_CAPACITY];


		private int capacity = INITIAL_CAPACITY;

		public int Count { get; private set; } = 0;


		public void Push(T item)
		{
			if (Count >= capacity) {
				capacity *= 2;
				Array.Resize(ref items, capacity);
			}

			items[Count] = item;
			Count += 1;
		}


		public T Pop()
		{
			if (!(Count > 0)) {
				throw new Exception();
			}

			T item = items[Count - 1];
			items[Count - 1] = default(T);
			Count -= 1;
			return item;
		}


		public T Peek()
		{
			if (!(Count > 0)) {
				throw new Exception();
			}

			return items[Count - 1];
		}


		public void Reverse()
		{
			T tmp;

			if (Count == 0)
				return;

			int smallerIndex = 0;
			int biggerIndex = Count - 1;

			while(smallerIndex < biggerIndex)
			{
				tmp = items[smallerIndex];

				items[smallerIndex] = items[biggerIndex];

				items[biggerIndex] = tmp;

				smallerIndex++;
				biggerIndex--;
			}
		}

		public void Clear()
		{
			for (int i = 0; i < Count; i++)
				items[i] = default;

			Count = 0;

			Array.Resize(ref items, INITIAL_CAPACITY);
			capacity = INITIAL_CAPACITY;
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
			if (arrayIndex < 0)
				throw new ArgumentException("Negative array index");
			if ((array.Length - arrayIndex) < Count)
				throw new ArgumentException("There is not enough space in the array after the index");

			for(int i = 0; i < Count; i++)
			{
				array[arrayIndex] = items[i];
				arrayIndex++;
			}
		}


		public bool IsEmpty()
		{
			return !(Count > 0);
		}

		public IEnumerator GetEnumerator()
		{
			T[] itemsInitialized = new T[Count];

			for (int i = 0; i < itemsInitialized.Length; i++)
				itemsInitialized[i] = items[i];

			return new MyStackEnumerator(itemsInitialized);
		}


		private class MyStackEnumerator : IEnumerator<T>
		{
			public MyStackEnumerator(T[] items)
			{
				this.items = items;
			}

			public T Current { get; private set; }

			object IEnumerator.Current => Current;


			T[] items;
			int index = -1;


			public void Dispose()
			{
				items = null;
			}

			public bool MoveNext()
			{
				if (index < (items.Length - 1))
				{
					index++;

					Current = items[index];

					return true;
				}
				else
					return false;
			}

			public void Reset()
			{
				Current = default;

				index = -1;
			}
		}
	}
}
