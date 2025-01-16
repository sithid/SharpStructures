using SharpStructures.Structures;

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

            Structures.LinkedList list = new Structures.LinkedList();
            
            Console.WriteLine();
            Console.WriteLine($"Linked List Count: {list.Count}");
            Console.WriteLine($"Linked List ToString: {list.ToString()}");
            Console.WriteLine();

            Structures.Node head = list.InsertAtHead(1);

            Console.WriteLine($"\tInserting Node At Head:{head.Data}");
            Console.WriteLine($"\t\tHead:{list.Head.Data}");
            Console.WriteLine($"\t\tTail:{list.Tail.Data}");

            for (int i = 2; i <= 10; i++)
            {
                Structures.Node n = list.InsertAtTail(i);

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

            int x = list.RemoveHead();
            int y = list.RemoveTail();
            int z = list.RemoveAt(5);

            Node temp = new Node(5);
            int w = list.RemoveAfter(temp);

            Console.WriteLine();
            Console.WriteLine("Linked List: Remove Head, Remove Tail, Remove After (5), Remove At (5)");
            Console.WriteLine($"\tCount: {list.Count}");
            Console.WriteLine($"\tHead: {list.Head.Data}");
            Console.WriteLine($"\tTail: {list.Tail.Data}");
            Console.WriteLine($"\tList {{ {list.ToString()} }}");
            Console.WriteLine($"\tRemoved Node Data: Head: {x}, Tail: {y}, After: {z}, At: {w}");
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("Linked List: ");
            Console.WriteLine($"\tCount: {list.Count}");
            Console.WriteLine($"\tHead: {list.Head.Data}");
            Console.WriteLine($"\tTail: {list.Tail.Data}");
            Console.WriteLine($"\tList {{ {list.ToString()} }}");
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
