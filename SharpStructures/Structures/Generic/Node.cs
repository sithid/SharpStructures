using System.Runtime.CompilerServices;

namespace SharpStructures.Structures.Generic
{
    public class Node<T>
    {
        /// <summary>
        /// The integer data for this node.
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// The next node in the linked list after this one.
        /// </summary>
        public Node<T> Next { get; set; } = null;

        /// <summary>
        /// Creates an instance of node with the supplied data and next node.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="next"></param>
        public Node( T data, Node<T> next = null )
        {
            this.Data = data;
            this.Next = next;
        }

        /// <summary>
        /// Creates an instance of Node with the supplied data.
        /// </summary>
        /// <param name="data"></param>
        public Node(T data) : this(data, null)
        {
        }

        /// <summary>
        /// Node default constructor.  Creates a node whos data is 0 and whos next node is null.
        /// </summary>
        public Node() : this( default(T), null)
        {
        }

        /// <summary>
        /// Formats and returns a string representation of this Node.
        /// </summary>
        /// <returns>A string representing this nodes data and next node.</returns>
        public override string ToString()
        {
            if( Next != null )
                return $"{this.Data}, {this.Next.ToString()}";
            else
                return $"{this.Data}, NULL";
        }
    }
}
