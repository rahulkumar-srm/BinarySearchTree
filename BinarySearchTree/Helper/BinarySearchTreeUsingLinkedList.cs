using BinarySearchTree.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree.Helper
{
    internal class BinarySearchTreeUsingLinkedList
    {
        internal TreeNode RootNode { get; set; }

        internal void CreateBinaryTree()
        {
            Console.WriteLine("Enter the root value");
            int num = Convert.ToInt32(Console.ReadLine());

            TreeNode node = new TreeNode(num);
            RootNode = node;

            while (true)
            {
                Console.WriteLine("Enter the number");
                num = Convert.ToInt32(Console.ReadLine());

                if (num == -1)
                    break;

                TreeNode parentNode = RSearchParentNode(RootNode, null, num);

                if (parentNode == null)
                {
                    Console.WriteLine("Duplicate numbers are not allowed");
                }
                else
                {
                    node = new TreeNode(num);

                    if (parentNode.Data < num)
                    {
                        parentNode.Rchild = node;
                    }
                    else
                    {
                        parentNode.Lchild = node;
                    }
                }
            }
        }

        internal void InsertNode()
        {
            Console.WriteLine("Enter the number");
            int num = Convert.ToInt32(Console.ReadLine());

            TreeNode node;

            if (RootNode == null)
            {
                node = new TreeNode(num);
                RootNode = node;
            }
            else
            {
                TreeNode parentNode = RSearchParentNode(RootNode, null, num);

                if (parentNode == null)
                {
                    Console.WriteLine("Duplicate numbers are not allowed");
                }
                else
                {
                    node = new TreeNode(num);

                    if (parentNode.Data < num)
                    {
                        parentNode.Rchild = node;
                    }
                    else
                    {
                        parentNode.Lchild = node;
                    }
                }
            }
        }

        internal TreeNode RDeleteNode(TreeNode node, int num)
        {
            TreeNode tempNode;

            if (node == null)
            {
                return null;
            }

            if (node.Lchild == null && node.Rchild == null)
            {
                if (node == RootNode)
                {
                    RootNode = null;
                }

                return null;
            }

            if (num < node.Data)
            {
                node.Lchild = RDeleteNode(node.Lchild, num);
            }
            else if (num > node.Data)
            {
                node.Rchild = RDeleteNode(node.Rchild, num);
            }
            else
            {
                if (node.Lchild != null)
                {
                    tempNode = InPre(node.Lchild);
                    node.Data = tempNode.Data;
                    node.Lchild = RDeleteNode(node.Lchild, tempNode.Data);
                }
                else
                {
                    tempNode = InSucc(node.Rchild);
                    node.Data = tempNode.Data;
                    node.Rchild = RDeleteNode(node.Rchild, tempNode.Data);
                }
            }

            return node;
        }

        private TreeNode InPre(TreeNode node)
        {
            while (node != null && node.Rchild != null)
            {
                node = node.Rchild;
            }
            return node;
        }

        private TreeNode InSucc(TreeNode node)
        {
            while (node != null && node.Lchild != null)
            {
                node = node.Lchild;
            }
            return node;
        }

        private TreeNode RSearchNode(TreeNode rootNode, int num)
        {
            if (rootNode != null)
            {
                if (rootNode.Data == num)
                {
                    return rootNode;
                }
                else
                {
                    if (num > rootNode.Data)
                    {
                        return RSearchParentNode(rootNode.Rchild, rootNode, num);
                    }
                    else
                    {
                        return RSearchParentNode(rootNode.Lchild, rootNode, num);
                    }
                }
            }

            return null;
        }

        private TreeNode RSearchParentNode(TreeNode rootNode, TreeNode prevNode, int num)
        {
            if (rootNode == null)
            {
                return prevNode;
            }

            if (rootNode.Data != num)
            {
                if (num > rootNode.Data)
                {
                    return RSearchParentNode(rootNode.Rchild, rootNode, num);
                }
                else
                {
                    return RSearchParentNode(rootNode.Lchild, rootNode, num);
                }
            }

            return null;
        }

        internal void RInOrderTraversal(TreeNode rootNode)
        {
            if (rootNode != null)
            {
                RInOrderTraversal(rootNode.Lchild);
                Console.Write(rootNode.Data + " ");
                RInOrderTraversal(rootNode.Rchild);
            }
        }

        internal void GenerateTreeFromPre(int[] num)
        {
            StackUsingLinkedList stack = new StackUsingLinkedList();

            TreeNode parentNoode = new TreeNode(num[0]);
            RootNode = parentNoode;

            int i = 1;
            TreeNode node;

            while (i < num.Length)
            {
                if (num[i] < parentNoode.Data)
                {
                    node = new TreeNode(num[i++]);
                    parentNoode.Lchild = node;

                    stack.Push(parentNoode);
                    parentNoode = node;
                }
                else if (num[i] > parentNoode.Data)
                {
                    int data = stack.StackTop() == null ? int.MaxValue : stack.StackTop().Data;
                    if (num[i] < data)
                    {
                        node = new TreeNode(num[i++]);
                        parentNoode.Rchild = node;
                        parentNoode = node;
                    }
                    else
                    {
                        parentNoode = stack.Pop();
                    }
                }
            }
        }
    }
}
