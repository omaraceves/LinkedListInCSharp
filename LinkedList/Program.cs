using System;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //Initialize Linked list having 1 as a value of head node
            LinkedList<int> linkedList = new LinkedList<int>(1);

            //Create subsequent nodes
            Node<int> second = linkedList.GetNewNode(2);
            Node<int> third = linkedList.GetNewNode(3);

            //Create linked list by linking the nodes to each other
            linkedList.Head.Next = second;
            second.Next = third;

            /*  Now next of second Node refers to third.  So all three 
            nodes are linked. 
  
               head            second             third 
                |                |                  | 
                |                |                  | 
            +----+------+     +----+------+     +----+------+ 
            | 1  |  o-------->| 2  |  o-------->|  3 | null | 
            +----+------+     +----+------+     +----+------+ */
            linkedList.Print(linkedList.Head);


            var head = linkedList.Head;
            linkedList.Push(7);
            var tail = linkedList.Tail;
            linkedList.Append(9);
            linkedList.PushNextTo(second, 4);
            linkedList.Print(head);

            linkedList.Delete(7);
            linkedList.Delete(9);
            linkedList.Delete(4);
            linkedList.Delete(4);
            linkedList.Append(7);

            linkedList.Print(head);

            //Finish Program
            Console.ReadLine();
        }

        
    }

    public class LinkedList<T>
    {

        private Node<T> _head = null;
        private Node<T> _tail = null;

        public Node<T> Head
        {
            get
            {
                return _head;
            }
            set
            {
                _head = value;
            }
        }

        public Node<T> Tail
        {
            get
            {
                if(_tail == null)
                {
                    _tail = GetTail(); 
                }
                return _tail;
            }
            set
            {
                _tail = value;
            }
        }


        /// <summary>
        /// Constructor for linked list
        /// </summary>
        /// <param name="head">Initial node on the list.</param>
        public LinkedList(Node<T> head)
        {
            _head = head;
        }

        /// <summary>
        /// Constructor for linked list.
        /// </summary>
        /// <param name="value">Value of initial node on the list.</param>
        public LinkedList(T value)
        {
            _head = GetNewNode(value);
        }

        /// <summary>
        /// Spawns a new node of the same type as linked list.
        /// </summary>
        /// <param name="data">Node's data</param>
        /// <returns></returns>
        public Node<T> GetNewNode(T data)
        {
            return new Node<T>(data);
        }

        /// <summary>
        /// Iterates through linked list, printing its elements
        /// </summary>
        /// <param name="head">First linked list's node</param>
        public void Print(Node<int> head)
        {
            var pointer = head;

            while (pointer != null)
            {
                Console.WriteLine("Value of this node is " + pointer.Data);
                pointer = pointer.Next;
            }
        }

        /// <summary>
        /// Inserts value on the linked list's first position
        /// </summary>
        /// <typeparam name="T">Generic type</typeparam>
        /// <param name="head">Linked lists first node</param>
        /// <param name="value">Data to push</param>
        /// <returns>Returns new node as head</returns>
        public Node<T> Push(T value)
        {
            var newNode = GetNewNode(value);

            newNode.Next = Head;
            Head = newNode;
            Console.WriteLine("Pushing " + value);

            return Head;
        }

        /// <summary>
        /// Traverse linked list to get last node
        /// </summary>
        /// <typeparam name="T">Generic type</typeparam>
        /// <param name="head">>Linked list's first node</param>
        /// <returns></returns>
        public Node<T> GetTail()
        {
            if(Head == null)
            {
                return null;
            }

            if(Head.Next == null)
            {
                return Head;
            }

            var pointer = Head;
            while (pointer.Next != null)
            {
                pointer = pointer.Next;
            }

            return pointer;
        }

        /// <summary>
        /// Pushes a new node at the end of the list.
        /// </summary>
        /// <typeparam name="T">Generic type</typeparam>
        /// <param name="tail">Linked list's last node</param>
        /// <param name="value">Data to push</param>
        /// <returns></returns>
        public Node<T> Append(T value)
        {
            var newNode = GetNewNode(value);
            Tail.Next = newNode;
            Tail = newNode;
            Console.WriteLine("Pushing " + value + " at the end of the list");

            return Tail;
        }

        /// <summary>
        /// Pushes a new node next to a given node
        /// </summary>
        /// <typeparam name="T">Generic type</typeparam>
        /// <param name="node">Linked list's given node</param>
        /// <param name="value">Data to push</param>
        public void PushNextTo(Node<T> node, T value)
        {
            var newNode = GetNewNode(value);
            newNode.Next = node.Next;
            node.Next = newNode;

            Console.WriteLine("Pushing " + value + " next to " + node.Data);
        }

        /// <summary>
        /// Deletes a given node
        /// </summary>
        /// <param name="head">Linked list's first node</param>
        /// <param name="value">Data to remove</param>
        public void Delete(T value)
        {
            //If value is found on the first node, just delete the first node.
            if(Head.Data.Equals(value))
            {
                Head = Head.Next;
                return;
            }

            //create the aux variable previous to track the previous node.
            Node<T> previous = null;
            var pointer = Head;

            //loop while until reaching the end of the list or until founding the given value
            while(pointer.Next != null && !pointer.Data.Equals(value))
            {
                previous = pointer;
                pointer = pointer.Next;
            }

            //if the end of the list was reached and node data does not match with given value, then the given value was not found.
            if(!pointer.Data.Equals(value))
            {
                Console.WriteLine("Error while deleting. Value not found: " + value);
                return;
            }

            //Make previous node pointer.Next, make pointer.Next null, this way we delete pointer.
            previous.Next = pointer.Next;
            pointer.Next = null;

            //Recalculate Tail in case we deleted the last node
            if(previous.Next == null)
            {
                Tail = previous;
            }

            Console.WriteLine("Deleting " + value);
        }
    }
    
    /// <summary>
    /// Data structure for nodes in a linked list
    /// </summary>
    /// <typeparam name="T">Generic type</typeparam>
    public class Node<T>
    {
        public T Data { get; set; } //Node Data
        public Node<T> Next { get; set; } //Pointer to Next node in a linked list


        //Initialize a node, setting pointer to null
        public Node(T data)
        {
            Data = data;
            Next = null;
        }


    }
}
