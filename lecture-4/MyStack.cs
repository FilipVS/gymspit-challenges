using System;
// https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.stack-1?view=netcore-3.1


namespace Lecture4
{
	class MyStack<T>
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


		public bool IsEmpty()
		{
			return !(Count > 0);
		}
	}
}
