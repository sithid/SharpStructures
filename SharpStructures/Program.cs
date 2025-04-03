using SharpStructures.Structures;
using SharpStructures.Structures.Generic;
using System;
using System.Runtime.CompilerServices;

namespace SharpStructures
{
    public class Program
    {
        public static void Main() {
            Console.WriteLine("Welcome to SharpStructures, a collection of data structures written in C#.");
            Console.WriteLine("This program was created to help me learn more about various data stuctures.");
            Console.WriteLine("Press any key to countinue.\n\r");
            Console.ReadKey();

            RunTestMenu();
        }

        private static void RunTestMenu() {
            Console.Clear();
            Console.WriteLine("Run tests for which structure? ");
            Console.WriteLine("1: Deque");
            Console.WriteLine("q: Exit");

            string input = Console.ReadLine();

            if (string.IsNullOrEmpty(input)) {
                return;
            }

            if (input.Equals("1")) {
                TestLLRun();
            }
            else {
                return;
            }
        }

        #region Deque Test Methods
        private static void TestLLRun() {
            Console.Clear();
            var list = new Structures.Generic.Deque<int>();

            Console.WriteLine($"Testing Deque<int>");
            Console.WriteLine("Empty Linked List: ");
            Console.WriteLine($"Linked List Count: {list.Count}");
            Console.WriteLine($"Linked List ToString: {list.ToString()}");

            Console.WriteLine();
            Console.ReadKey();

            TestLLAdd(list);

            Console.WriteLine();
            Console.ReadKey();

            TestLLRemove(list);

            Console.WriteLine();
            Console.ReadKey();
            
            TestLLConverted(list);

            Console.WriteLine("Press any key to return to test menu.");
            Console.ReadKey();

            RunTestMenu();
        }

        private static void TestLLAdd( Structures.Generic.Deque<int> list ) {
            Console.WriteLine("Testing InsertAtHead: ");
            
            Node<int> head = list.InsertAtHead(1);

            Console.WriteLine($"Inserting Node At Head:{head.Data}\n\r");
            Console.WriteLine("Testing InsertAtTail:");

            for (int i = 2; i <= 100; i++) {
                Node<int> n = list.InsertAtTail((i * i) - 1);
                Console.WriteLine($"Inserting Node At Tail:{n.Data}");
            }

            Console.WriteLine();
            Console.WriteLine($"Count: {list.Count}");
            Console.WriteLine($"Head: {list.Head.Data}");
            Console.WriteLine($"Tail: {list.Tail.Data}");
            Console.WriteLine($"Values :: {list.ToString()}");
            Console.WriteLine();
        }

        private static void TestLLRemove(Structures.Generic.Deque<int> list) {
            Console.WriteLine("Testing RemoveAfter: ");

            int x = list.RemoveAfter(5);

            Console.WriteLine($"Removed Node Data: After: {x}\n\r");
            Console.WriteLine("Testing RemoveAt: ");

            for (int i = 0; i < list.Count; i += 5) {
                int y = list.RemoveAt(i);
                Console.WriteLine($"Removed Node Data: At: {y}");
            }

            Console.WriteLine();
            Console.WriteLine($"Deque Information: ");
            Console.Write($"Count: {list.Count}\n\r" +
                          $"Head: {list.Head.Data.ToString()}\n\r" +
                          $"Tail: {list.Tail.Data.ToString()}\n\r");
            Console.WriteLine($"Data: {list.ToString()}");
        }

        private static void TestLLConverted(Structures.Generic.Deque<int> list) {
            var gList = list.ToList();
            int[] arr = list.ToArray();

            Console.WriteLine("Linked List: Converting to List<int>");
            Console.WriteLine($"List<int> :: {gList}");
            Console.Write($"Values :: ");

            foreach (int nodeData in gList) {
                Console.Write($"{nodeData} ");
            }

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Linked List: Converting to array.");
            Console.WriteLine($"int[] :: {arr}");
            Console.Write($"Values :: ");

            foreach (int nodeData in arr) {
                Console.Write($"{nodeData} ");
            }

            Console.WriteLine("\n\r");
        }
        #endregion
    }
}
