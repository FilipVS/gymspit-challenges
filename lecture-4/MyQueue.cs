using System;
using System.Collections;
using System.Collections.Generic;
// https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.queue-1?view=netcore-3.1


namespace Lecture4
{
	class MyQueue<T> : IEnumerable
	{
		class MyQueueNode
		{
			public T Item { get; }
			public MyQueueNode Next { get; set; }


			public MyQueueNode(T item, MyQueueNode next)
			{
				Item = item;
				Next = next;
			}
		}

		private MyQueueNode first = null;

		private MyQueueNode last = null;


		public int Count { get; private set; } = 0;


		public void Enqueue(T item)
		{
			MyQueueNode node = new MyQueueNode(item, null);
			if (first == null) {
				first = node;
			}
			if (last != null) {
				last.Next = node;
			}
			last = node;

			Count++;
		}


		public T Dequeue()
		{
			if (first == null) {
				throw new Exception();
			}

			if (first == last) {
				last = null;
			}

			T item = first.Item;
			first = first.Next;

			Count--;

			return item;
		}


		public T Peek()
		{
			if (first == null) {
				throw new Exception();
			}

			return first.Item;
		}


		public void Reverse()
		{
			if (first == null)
				return;

			ReverseLoop(null, null, first);
		}

		private void ReverseLoop(MyQueueNode previousPreviousNode, MyQueueNode previousNode, MyQueueNode thisNode)
		{
			bool lastSet = false;

			while (thisNode.Next != null)
			{
				if (previousPreviousNode != null)
				{
					previousNode.Next = previousPreviousNode;

					if (!lastSet)
					{
						last = previousPreviousNode;
						previousPreviousNode.Next = null;

						lastSet = true;
					}
				}

				previousPreviousNode = previousNode;
				previousNode = thisNode;
				thisNode = thisNode.Next;
			}

			first = thisNode;

			if (previousNode == null)
			{
				last = thisNode;
				thisNode.Next = null;
			}
			else
			{
				thisNode.Next = previousNode;

				if (previousPreviousNode != null)
				{
					previousNode.Next = previousPreviousNode;

					if (!lastSet)
					{
						last = previousPreviousNode;
						previousPreviousNode.Next = null;
					}
				}
				else if (!lastSet)
				{
					last = previousNode;
					previousNode.Next = null;
				}
			}


		}


		public void Clear()
		{
			if (first == null)
				return;

			MyQueueNode thisNode = first;
			MyQueueNode nextNode = thisNode.Next;

			while(thisNode.Next != null)
			{
				nextNode = thisNode.Next;
				thisNode = null;
			}

			thisNode = null;

			first = null;
			last = null;

			Count = 0;
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
			MyQueueNode node = first;

			if (node == null)
				return;

			if (arrayIndex < 0)
				throw new ArgumentException("Negative array index");
			if ((array.Length - arrayIndex) < Count)
				throw new ArgumentException("There is not enough space in the array after the index");

			while(node.Next != null)
			{
				array[arrayIndex] = node.Item;

				arrayIndex++;

				node = node.Next;
			}

			array[arrayIndex] = node.Item;
		}


		public bool IsEmpty()
		{
			return first == null;
		}

		public IEnumerator GetEnumerator()
		{
			return new MyQueueEnumerator(first);
		}


		private class MyQueueEnumerator : IEnumerator<T>
		{
			public MyQueueEnumerator(MyQueueNode first)
			{
				current = first;
				this.first = first;
			}

			public object Current => currentItem;

			T IEnumerator<T>.Current => currentItem;

			MyQueueNode current;
			MyQueueNode first;

			T currentItem;

			bool currentItemSet = false;

			public void Dispose()
			{
				currentItem = default;
			}

			public bool MoveNext()
			{
				if (current.Next == null)
					return false;
				else
				{
					if (!currentItemSet)
					{
						currentItem = current.Item;

						currentItemSet = true;
					}
					else
					{
						current = current.Next;

						currentItem = current.Item;
					}

					return true;
				}
			}

			public void Reset()
			{
				current = first;

				currentItem = default;

				currentItemSet = false;
			}
		}
	}
}
