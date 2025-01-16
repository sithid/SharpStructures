using System.Security.Principal;
using System.Text;

namespace SharpStructures.Structures
{
    public class LinkedList
    {
        /// <summary>
        /// The first node in the linked list.
        /// </summary>
        public Node Head { get; set; } = null;

        /// <summary>
        /// The last node in the linked list.
        /// </summary>
        public Node Tail { get; set; } = null;

        /// <summary>
        /// The total number of nodes in the linked list.
        /// </summary>
        public int Count { get; set; } = 0;

        /// <summary>
        /// Default constructor for LinkedList.
        /// </summary>
        public LinkedList() {
        }

        /// <summary>
        /// Inserts a node at the head of the linked list.
        /// </summary>
        /// <param name="data"></param>
        /// <returns>The inserted node.</returns>
        public Node InsertAtHead(int data) {
            Node head = new Node(data, Head);

            this.Head = head;

            if( Count == 0) {
                Tail = head;
            }

            ++this.Count;

            return this.Head;
        }

        /// <summary>
        /// Inserts a node at the tail of the linked list.
        /// </summary>
        /// <param name="data"></param>
        /// <returns>The inserted node.</returns>
        public Node InsertAtTail(int data) {
            
            if( Head == null ) {
                return InsertAtHead(data);
            }

            this.Tail.Next = new Node(data);

            this.Tail = this.Tail.Next;

            Count++;

            return this.Tail;
        }

        /// <summary>
        /// Removes the first node in the list (Head) and returns the data stored.
        /// </summary>
        /// <returns> The data stored in the removed Head node.</returns>
        /// <exception cref="InvalidOperationException"></exception>
        public int RemoveHead() {

            if (Head == null) {
                throw new InvalidOperationException();
            }

            int data = this.Head.Data;

            this.Head = this.Head.Next;
            this.Count--;
            
            if( this.Head == null || this.Count == 0) {
                this.Tail = null;
            }

            return data;
        }

        /// <summary>
        /// Removes the last node in the list (Tail) and returns the data stored.
        /// </summary>
        /// <returns>The data stored in the removed Tail node.</returns>
        /// <exception cref="InvalidOperationException"></exception>
        public int RemoveTail() {

            if( this.Tail == null ) {
                throw new InvalidOperationException();
            }

            int data = this.Tail.Data;

            Node tail = this.Head;

            while( tail.Next.Next != null) {
                tail = tail.Next;
            }

            this.Tail = tail;
            this.Tail.Next = null;
            --Count;

            if( this.Count == 0) {
                this.Head = null;
                this.Tail = null;
            }

            return data;
        }

        /// <summary>
        /// Find a node at the specified index ( 0-based indexing ).
        /// </summary>
        /// <param name="index"></param>
        /// <returns>Returns the node at the specified index.</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public Node FindNodeAt( int index ) {
            if( index < 0 || index > this.Count - 1 ) {
                throw new ArgumentOutOfRangeException();
            }

            if (index == 0) {
                return this.Head;
            }

            if (index == this.Count - 1) {
                return this.Tail;
            }

            Node temp = this.Head;

            int count = 1;

            while( count <= index && temp != null ) {
            
                temp = temp.Next;
                count++;
            }

            return temp;
        }

        /// <summary>
        /// Removes a node AFTER the given node.
        /// </summary>
        /// <param name="toRemove"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public int RemoveAfter(int index ) {
            if( index < 0 ) {
                throw new ArgumentOutOfRangeException("index");
            }

            Node previousNode = FindNodeAt(index);
            Node nodeToRemove = previousNode.Next;

            if (nodeToRemove == null) {
                throw new InvalidOperationException("Node does not exist.");
            }

            int data = nodeToRemove.Data;

            previousNode.Next = nodeToRemove.Next; // Bypass the node to remove

            if (nodeToRemove == Tail) {
                Tail = previousNode; // Update Tail if necessary
            }

            Count--;
            return data;
        }

        /// <summary>
        /// Removes the node at the specified index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns>Returns the data of the removed node.</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public int RemoveAt(int index) {
            if (index < 0 || index > Count - 1) { 
                throw new ArgumentOutOfRangeException();
            }

            if (index == 0) {
                return this.RemoveHead();
            }
            if (index == Count - 1) {
                return this.RemoveTail();
            }

            Node previousNode = this.FindNodeAt(index - 1);
            Node nodeToRemove = previousNode.Next;

            int data = nodeToRemove.Data;

            Node temp = nodeToRemove.Next;

            if (temp != null) {
                previousNode.Next = temp;
            }

            --Count;
            return data;
        }

        /// <summary>
        /// Formats and returns a string representing the linked list.
        /// </summary>
        /// <returns>A string representing the linked list ([ Count, Node Data: ...])</returns>
        public override string ToString() {
            if (Head == null) {
                return "[Count: 0, Empty List]";
            }

            StringBuilder sb = new StringBuilder();
            sb.Append($"[ Count: {Count}, Node Data: ");

            Node current = Head;

            while (current != null) {
                sb.Append($"{current.Data}");
                if (current.Next != null) {
                    sb.Append(" , ");
                }
                current = current.Next;
            }

            sb.Append(" ]");
            return sb.ToString();
        }
    }
}
