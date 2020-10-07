using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture4
{
    class Program
    {
        static void Main(string[] args)
        {
            MyQueue<int> myQueue = new MyQueue<int>();
            MyStack<int> myStack = new MyStack<int>();

            
            #region Reverse methods tests
            for (int i = 1; i <= 10; i++)
                myQueue.Enqueue(i);

            myQueue.Reverse();

            while (!myQueue.IsEmpty())
                Console.WriteLine(myQueue.Dequeue());

            Console.ReadKey();
            Console.Clear();

            for (int i = 1; i <= 10; i++)
                myStack.Push(i);

            myStack.Reverse();

            while (!myStack.IsEmpty())
                Console.WriteLine(myStack.Pop());

            Console.ReadKey();
            Console.Clear();
            #endregion


        }
    }
}
