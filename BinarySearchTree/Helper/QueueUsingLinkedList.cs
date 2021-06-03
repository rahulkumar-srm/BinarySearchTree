using BinarySearchTree.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree.Helper
{
    internal class QueueUsingLinkedList
    {
        internal QueueNode Front { get; set; }
        internal QueueNode Rear { get; set; }

        internal void Enqueue(AVLTreeNode treeNode)
        {
            QueueNode node = new QueueNode(treeNode);

            if (node == null)
            {
                Console.WriteLine("Queue is null.");
            }
            else
            {
                if (Front == null)
                {
                    Rear = Front = node;
                }
                else
                {
                    Rear.Next = node;
                    Rear = Rear.Next;
                }
            }
        }

        internal bool IsEmpty()
        {
            return Front == null;
        }

        internal AVLTreeNode Dequeue()
        {
            if (Front == null)
            {
                return null;
            }
            else
            {
                if (Front.Next == null)
                {
                    Rear = Front.Next;
                }

                QueueNode tempNode = Front;
                Front = Front.Next;
                return tempNode.Data;
            }
        }

        internal void Display()
        {
            QueueNode tempNode = Front;

            while (tempNode != null)
            {
                Console.WriteLine(tempNode.Data);
                tempNode = tempNode.Next;
            }
        }
    }
}
