using System.Text;

namespace SharpStructures.Structures
{
    public class LinkedList
    {
        public Node Head { get; set; } = null;
        public int Count { get; set; } = 0;

        public LinkedList()
        {
        }

        public Node InsertAtHead(int data)
        {
            Node head = new Node(data, Head);

            this.Head = head;
            ++this.Count;

            return this.Head;
        }

        public Node InsertAtTail(int data)
        {
            Node tail = this.Head;

            while( tail.Next != null )
                tail = tail.Next;

            tail.Next = new Node(data, null);

            Count++;
            return GetTail();
        }

        public Node GetTail()
        {
            Node tail = this.Head;

            while (tail.Next != null)
                tail = tail.Next;

            return tail;
        }

        public override string ToString()
        {
            if (Head == null)
            {
                return "[Count: 0, Empty List]";
            }

            StringBuilder sb = new StringBuilder();
            sb.Append($"[ Count: {Count}, Node Data: ");

            Node current = Head;

            while (current != null)
            {
                sb.Append($"{current.Data}");
                if (current.Next != null)
                {
                    sb.Append(" , ");
                }
                current = current.Next;
            }

            sb.Append(" ]");
            return sb.ToString();
        }
    }
}
