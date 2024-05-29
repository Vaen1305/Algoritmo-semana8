using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class List : MonoBehaviour
{
    public class SingleLinkedList<T>
    {
        class Node
        {
            public Node Next { get; set; }
            public T Value { get; set; }
            public Node(T value)
            {
                Value = value;
                Next = null;
            }
        }

        private Node head;
        private int length = 0;

        public void InsertAtStart(T value)
        {
            Node node = new Node(value);
            node.Next = head;
            head = node;
            length++;
        }

        public void InsertAtEnd(T value)
        {
            if (head == null)
            {
                InsertAtStart(value);
            }
            else
            {
                Node lastNode = GetLastNode();
                Node newNode = new Node(value);
                lastNode.Next = newNode;
                length++;
            }
        }

        public void InsertAtPosition(T value, int position)
        {
            if (position == 0)
            {
                InsertAtStart(value);
            }
            else if (position >= length)
            {
                InsertAtEnd(value);
            }
            else
            {
                Node nodePosition = head;
                int iterator = 0;
                while (iterator < position - 1)
                {
                    nodePosition = nodePosition.Next;
                    iterator++;
                }
                Node newNode = new Node(value);
                newNode.Next = nodePosition.Next;
                nodePosition.Next = newNode;
                length++;
            }
        }

        public void DeleteAtStart()
        {
            if (head == null)
            {
                return;
            }
            else
            {
                Node newHead = head.Next;
                head.Next = null;
                head = newHead;
                length--;
            }
        }

        public void DeleteAtEnd()
        {
            if (head == null || head.Next == null)
            {
                DeleteAtStart();
            }
            else
            {
                Node nodePosition = head;
                while (nodePosition.Next.Next != null)
                {
                    nodePosition = nodePosition.Next;
                }
                nodePosition.Next = null;
                length--;
            }
        }

        public void DeleteAtPosition(int position)
        {
            if (position == 0)
            {
                DeleteAtStart();
            }
            else if (position >= length)
            {
                return;
            }
            else
            {
                Node nodePosition = head;
                int iterator = 0;
                while (iterator < position - 1)
                {
                    nodePosition = nodePosition.Next;
                    iterator++;
                }
                Node nodeToDelete = nodePosition.Next;
                nodePosition.Next = nodeToDelete.Next;
                nodeToDelete.Next = null;
                length--;
            }
        }

        private Node GetLastNode()
        {
            Node lastNode = head;
            while (lastNode.Next != null)
            {
                lastNode = lastNode.Next;
            }
            return lastNode;
        }

        public void PrintAllNodes()
        {
            Node tmp = head;
            while (tmp != null)
            {
                tmp = tmp.Next;
            }
        }

        public T GetElementAt(int position)
        {
            if (position < 0 || position >= length)
            {
                return default(T);
            }

            Node current = head;
            for (int i = 0; i < position; i++)
            {
                current = current.Next;
            }

            return current.Value;
        }

        public int Count
        {
            get { return length; }
        }
    }
}
