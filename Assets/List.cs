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
            length = length + 1;
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
                length = length + 1;
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

            }
            else
            {
                Node nodePosition = head;
                int iterator = 0;
                while (iterator < position - 1)
                {
                    nodePosition = nodePosition.Next;
                    iterator = iterator + 1;
                }
                Node newNode = new Node(value);
                newNode.Next = nodePosition.Next;
                nodePosition.Next = newNode;
                length = length + 1;
            }
        }

        public void DeleteAtStart()
        {
            if (head == null)
            {

            }
            else
            {
                Node newHead = head.Next;
                head.Next = null;
                head = newHead;
                length = length - 1;
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
                length = length - 1;
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

            }
            else
            {
                Node nodePosition = head;
                int iterator = 0;
                while (iterator < position - 1)
                {
                    nodePosition = nodePosition.Next;
                    iterator = iterator + 1;
                }
                Node nodeToDelete = nodePosition.Next;
                nodePosition.Next = nodeToDelete.Next;
                nodeToDelete.Next = null;
                length = length - 1;
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
                Debug.Log(tmp.Value + " ");
                tmp = tmp.Next;
            }
        }

        public T GetElementAt(int position)
        {
            if (position < 0 || position >= length)
            {
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
