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

            for (int i = 1; i <= 10; i++)
            {
                Structures.Node n = list.InsertAtHead(i);

                Console.Write($"\tInserting Node:{n.Data} => ");

                if (n.Next != null)
                    Console.WriteLine($"{n.Next.ToString()}");
                else
                    Console.WriteLine("NULL");
            }

            Console.WriteLine();
            Console.WriteLine($"Linked List Count: {list.Count}");
            Console.WriteLine($"Linked List ToString: {list.ToString()}");
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
