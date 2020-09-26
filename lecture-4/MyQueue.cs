using System;
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

			ReverseRec(null, first);
		}

		private void ReverseRec(MyQueueNode previousNode, MyQueueNode thisNode)
		{
			if (thisNode.Next == null)
			{
				first = thisNode;

				if (previousNode == null)
					last = thisNode;
				else
					thisNode.Next = previousNode;

				return;
			}
			else
			{
				ReverseRec(thisNode, thisNode.Next);

				thisNode.Next = previousNode;

				return;
			}
		}


		public bool IsEmpty()
		{
			return first == null;
		}
	}
}
