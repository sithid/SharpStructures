using System.ComponentModel;
using System.Security.Principal;
using System.Text;

namespace SharpStructures.Structures.Generic
{
    public class Deque<T>
    {
        /// <summary>
        /// The first node in the linked list.
        /// </summary>
        public Node<T> Head { get; set; }

        /// <summary>
        /// The last node in the linked list.
        /// </summary>
        public Node<T> Tail { get; set; }

        /// <summary>
        /// The total number of nodes in the linked list.
        /// </summary>
        public int Count { get; set; } = 0;

        /// <summary>
        /// Default constructor for Deque.
        /// </summary>
        public Deque() {
        }

        /// <summary>
        /// Inserts a node at the head of the linked list.
        /// </summary>
        /// <param name="data"></param>
        /// <returns>The inserted node.</returns>
        public Node<T> InsertAtHead(T data) {
            Node<T> head = new Node<T>(data, Head);

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
        public Node<T> InsertAtTail(T data) {
            
            if( Head == null ) {
                return InsertAtHead(data);
            }

            this.Tail.Next = new Node<T>(data);

            this.Tail = this.Tail.Next;

            Count++;

            return this.Tail;
        }

        /// <summary>
        /// Removes the first node in the list (Head) and returns the data stored.
        /// </summary>
        /// <returns> The data stored in the removed Head node.</returns>
        /// <exception cref="InvalidOperationException"></exception>
        public T RemoveHead() {

            if (Head == null) {
                throw new InvalidOperationException();
            }

            T data = this.Head.Data;

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
        public T RemoveTail() {

            if( this.Tail == null ) {
                throw new InvalidOperationException();
            }

            T data = this.Tail.Data;

            Node<T> tail = this.Head;

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
        public Node<T> FindNodeAt( int index ) {
            if( index < 0 || index > this.Count - 1 ) {
                throw new ArgumentOutOfRangeException();
            }

            if (index == 0) {
                return this.Head;
            }

            if (index == this.Count - 1) {
                return this.Tail;
            }

            Node<T> temp = this.Head;

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
        public T RemoveAfter(int index ) {
            if( index < 0 ) {
                throw new ArgumentOutOfRangeException("index");
            }

            Node<T> previousNode = FindNodeAt(index);
            Node<T> nodeToRemove = previousNode.Next;

            if (nodeToRemove == null) {
                throw new InvalidOperationException("Node does not exist.");
            }

            T data = nodeToRemove.Data;

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
        public T RemoveAt(int index) {
            if (index < 0 || index > Count - 1) { 
                throw new ArgumentOutOfRangeException();
            }

            if (index == 0) {
                return this.RemoveHead();
            }
            if (index == Count - 1) {
                return this.RemoveTail();
            }

            Node<T> previousNode = this.FindNodeAt(index - 1);
            Node<T> nodeToRemove = previousNode.Next;

            T data = nodeToRemove.Data;

            Node<T> temp = nodeToRemove.Next;

            if (temp != null) {
                previousNode.Next = temp;
            }

            --Count;
            return data;
        }

        public List<T> ToList() {
            List<T> gList = new List<T>();

            for( int i = 0; i < this.Count; i++) {
                Node<T> n = this.FindNodeAt(i);

                if (n != null) {
                    gList.Add(n.Data);
                }
            }

            return gList;
        }

        public T[] ToArray() {
            T[] array = new T[Count];

            for( int i = 0; i < Count; i++) {
                Node<T> n = this.FindNodeAt(i);
                
                if( n != null ) {
                    array[i] = n.Data;
                }
            }

            return array;
        }
        /// <summary>
        /// Formats and returns a string representing the linked list.
        /// </summary>
        /// <returns>A string representing the linked list ([ Count, Node Data: ...])</returns>
        public override string ToString() {
            if (Head == null) {
                return "0, null";
            }

            StringBuilder sb = new StringBuilder();

            Node<T> current = Head;

            while (current != null) {
                sb.Append($"{current.Data}");
                if (current.Next != null) {
                    sb.Append(" ");
                }
                current = current.Next;
            }

            return sb.ToString();
        }
    }
}
