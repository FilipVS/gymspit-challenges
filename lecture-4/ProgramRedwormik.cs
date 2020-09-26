using System;


namespace Lecture4
{
	class ProgramRedwormik
	{
		static void MainRedwormik(string[] args)
		{
			Person a = new Person();
			a.firstName = "First";
			a.lastName = "Last";
			a.age = 42;

			Person b = new Person();
			b.firstName = "Tsrif";
			b.lastName = "Tsal";
			b.age = 24;

			MyList<Person> list = new MyList<Person>();
			list.Add(a);
			list.Add(b);
			Console.WriteLine(list.Count());
			Console.WriteLine(list.Get(0) == a);
			Console.WriteLine(list.Get(1) == b);
			Console.WriteLine(list.Get(0).firstName);
			Console.WriteLine(list.Get(0).lastName);
			Console.WriteLine(list.Get(0).age);

			MyList<int> intList = new MyList<int>();
			intList.Add(15);
			intList.Add(16);
			intList.Add(31);
			Console.WriteLine(intList.Count());
			for (int i = 0; i < intList.Count(); i += 1) {
				Console.WriteLine(intList.Get(i));
			}

			MyLinkedList<int> linkList = new MyLinkedList<int>();
			linkList.AddFirst(1);
			linkList.AddLast(3);
			linkList.AddAfter(2, linkList.GetFirst());

			Console.WriteLine(linkList.Count());
			for (var node = linkList.GetFirst(); node != null; node = node.next) {
				Console.WriteLine(node.Item);
			}

			MyQueue<string> queue = new MyQueue<string>();
			queue.Enqueue("this");
			queue.Enqueue("is");
			queue.Enqueue("queue");
			Console.WriteLine(queue.Peek());
			while (!queue.IsEmpty()) {
				Console.WriteLine(queue.Dequeue());
			}

			MyStack<string> stack = new MyStack<string>();
			stack.Push("this");
			stack.Push("is");
			stack.Push("stack");
			Console.WriteLine(stack.Peek());
			while (!stack.IsEmpty()) {
				Console.WriteLine(stack.Pop());
			}

			Console.ReadKey();
		}
	}
}
