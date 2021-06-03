using BinarySearchTree.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree.Helper
{
    internal class StackUsingLinkedList
    {
        private StackNode top = null;

        internal bool IsEmpty()
        {
            return top == null;
        }

        internal void Push(TreeNode treeNode)
        {
            StackNode node = new StackNode(treeNode);

            if (node == null)
            {
                Console.WriteLine("Stack overflow");
            }
            else
            {
                node.Next = top;
                top = node;
            }
        }

        internal TreeNode Pop()
        {
            if (top == null)
            {
                return null;
            }
            else
            {
                StackNode tempNode = top;
                top = top.Next;
                return tempNode.Data;
            }
        }

        internal TreeNode StackTop()
        {
            if (top != null)
            {
                return top.Data;
            }
            return null;
        }
    }
}
