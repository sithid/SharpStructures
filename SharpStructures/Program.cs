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
            Console.WriteLine($"\t\tTail:{list.GetTail().Data}");

            for (int i = 2; i <= 10; i++)
            {
                Structures.Node n = list.InsertAtTail(i);

                Console.WriteLine($"\tInserting Node At Tail:{n.Data}");
                Console.WriteLine($"\t\tHead:{list.Head.Data}");
                Console.WriteLine($"\t\tTail:{list.GetTail().Data}");
            }

            Console.WriteLine();
            Console.WriteLine("Linked List:");
            Console.WriteLine($"\tCount: {list.Count}");
            Console.WriteLine($"\tHead: {list.Head.Data}");
            Console.WriteLine($"\tTail: {list.GetTail().Data}");
            Console.WriteLine($"\tList {{ {list.ToString()} }}");
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
