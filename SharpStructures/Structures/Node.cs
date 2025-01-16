using System.Runtime.CompilerServices;

namespace SharpStructures.Structures
{
    public class Node
    {
        public int Data { get; set; } = 0;
        public Node Next { get; set; } = null;

        public Node( int data, Node next = null )
        {
            this.Data = data;
            this.Next = next;
        }

        public Node(int data) : this(data, null)
        {
        }

        public Node() : this(0, null)
        {
        }

        public override string ToString()
        {
            if( Next != null )
                return $"{this.Data}, {this.Next.ToString()}";
            else
                return $"{this.Data}, NULL ";
        }
    }
}
