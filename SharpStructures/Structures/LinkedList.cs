using System.Text;

namespace SharpStructures.Structures
{
    public class LinkedList
    {
        public Node Head { get; set; } = null;
        public Node Tail { get; set; } = null;
        public int Count { get; set; } = 0;

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
        /// Removes a node AFTER the given node.
        /// </summary>
        /// <param name="toRemove"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public int RemoveAfter(Node previousNode ) {

            if (previousNode == null) {
                throw new InvalidOperationException();
            }

            Node nodeToRemove = this.Head;

            while( nodeToRemove != null) {
                if (nodeToRemove.Data == previousNode.Data)
                    break;
                else
                    nodeToRemove = nodeToRemove.Next;
            }
            if (nodeToRemove == null) {
                throw new InvalidOperationException();
            }

            int data = nodeToRemove.Data;
            Node nextNode = nodeToRemove.Next;

            if (nextNode == null) {
                this.Tail = previousNode;
            }
            else {
                previousNode.Next = nextNode;
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
        public int RemoveAt( int index ) {
            // Our linked list does not have an index 0, or atleast, we don't look at it as index 0.
            // There is no actual indexing here, no arrays or Generic Lists involved, we do not have
            // to call the head index 0.
            if( index < 0 || index > Count - 1 ) { // If we make this index >= count, it will be out of bounds.
                throw new ArgumentOutOfRangeException();
            }

            if (index == 0) {
                return RemoveHead();
            }
            if (index == Count - 1) {
                return RemoveTail();
            }
             
            Node nodeToRemove = this.Head;
            Node previousNode = null;

            for (int i = 0; i < index; i++) { // nodeToRemove = index, nodeToRemove.Next = index + 1
                previousNode = nodeToRemove;
                nodeToRemove = nodeToRemove.Next;
            }

            int data = nodeToRemove.Data;

            Node temp = nodeToRemove.Next;

            if( temp != null ) {
                previousNode.Next = temp;
            }

            --Count;
            return data;
        }

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
