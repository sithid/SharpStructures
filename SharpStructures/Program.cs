using SharpStructures.Structures;
using System.Runtime.InteropServices.Marshalling;

namespace SharpStructures
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to SharpStructures, a collection of data structures written in C#.");
            Console.WriteLine("This program was created to help me learn more about various data stuctures.");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();

            LinkedList list = new LinkedList();
            
            Console.WriteLine();
            Console.WriteLine($"Linked List Count: {list.Count}");
            Console.WriteLine($"Linked List ToString: {list.ToString()}");
            Console.WriteLine();

            Node head = list.InsertAtHead(1);

            Console.WriteLine($"\tInserting Node At Head:{head.Data}");
            Console.WriteLine($"\t\tHead:{list.Head.Data}");
            Console.WriteLine($"\t\tTail:{list.Tail.Data}");

            for (int i = 2; i <= 10000; i++)
            {
                Node n = list.InsertAtTail(i);

                Console.WriteLine($"\tInserting Node At Tail:{n.Data}");
                Console.WriteLine($"\t\tHead:{list.Head.Data}");
                Console.WriteLine($"\t\tTail:{list.Tail.Data}");
            }

            Console.WriteLine();
            Console.WriteLine("Linked List:");
            Console.WriteLine($"\tCount: {list.Count}");
            Console.WriteLine($"\tHead: {list.Head.Data}");
            Console.WriteLine($"\tTail: {list.Tail.Data}");
            Console.WriteLine($"\tList {{ {list.ToString()} }}");
            Console.WriteLine();

            int x = list.RemoveAfter(5);

            Console.WriteLine();
            Console.WriteLine("Linked List: Remove At (index 0)");
            Console.WriteLine($"\tCount: {list.Count}");
            Console.WriteLine($"\tHead: {list.Head.Data}");
            Console.WriteLine($"\tTail: {list.Tail.Data}");
            Console.WriteLine($"\tList {{ {list.ToString()} }}");
            Console.WriteLine($"\tRemoved Node Data: At: {x}");
            Console.WriteLine();

            int y = list.RemoveAt(5);

            Console.WriteLine();
            Console.WriteLine("Linked List: Remove After (index 0)");
            Console.WriteLine($"\tCount: {list.Count}");
            Console.WriteLine($"\tHead: {list.Head.Data}");
            Console.WriteLine($"\tTail: {list.Tail.Data}");
            Console.WriteLine($"\tList {{ {list.ToString()} }}");
            Console.WriteLine($"\tRemoved Node Data: After: {y}");
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("Linked List: ");
            Console.WriteLine($"\tCount: {list.Count}");
            Console.WriteLine($"\tHead: {list.Head.Data}");
            Console.WriteLine($"\tTail: {list.Tail.Data}");
            Console.WriteLine($"\tList {{ {list.ToString()} }}");
            Console.WriteLine();

            List<int> gList = list.ToList();
            int[] arr = list.ToArray();

            Console.WriteLine("Linked List: Converting to List<int>");
            Console.WriteLine($"List<int> :: {gList}");
            Console.Write($"\tValues :: ");

            foreach (int nodeData in gList) {
                Console.Write($"{nodeData} "); 
            }

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Linked List: Converting to array.");
            Console.WriteLine($"int[] :: {arr}");
            Console.Write($"\tValues :: ");

            foreach (int nodeData in arr) {
                Console.Write($"{nodeData} ");
            }

            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
