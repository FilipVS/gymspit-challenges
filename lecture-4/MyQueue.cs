﻿using System;
// https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.queue-1?view=netcore-3.1


namespace Lecture4
{
	class MyQueue<T>
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

			while(thisNode.Next != null)
			{
				if(previousPreviousNode != null)
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

				if(previousPreviousNode != null)
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


		public bool IsEmpty()
		{
			return first == null;
		}
	}
}
