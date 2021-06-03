using BinarySearchTree.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree.Helper
{
    internal class AVLTreeUsingLinkedList
    {
        internal AVLTreeNode RootNode { get; set; }

        internal void CreateAVLTree()
        {
            Console.WriteLine("Enter the root value");
            int num = Convert.ToInt32(Console.ReadLine());

            RootNode = RInsertNode(RootNode, num);

            while (true)
            {
                Console.WriteLine("Enter the number");
                num = Convert.ToInt32(Console.ReadLine());

                if (num == -1)
                    break;

                RInsertNode(RootNode, num);
            }
        }

        internal void RInOrderTraversal(AVLTreeNode rootNode)
        {
            if (rootNode != null)
            {
                RInOrderTraversal(rootNode.Lchild);
                Console.Write(rootNode.Data + " ");
                RInOrderTraversal(rootNode.Rchild);
            }
        }

        internal AVLTreeNode RInsertNode(AVLTreeNode node, int num)
        {
            if (node == null)
            {
                node = new AVLTreeNode(num);
                return node;
            }

            if (num < node.Data)
            {
                node.Lchild = RInsertNode(node.Lchild, num);
            }
            else if (num > node.Data)
            {
                node.Rchild = RInsertNode(node.Rchild, num);
            }
            else
            {
                return null;
            }

            node.Height = NodeHeight(node);

            if (BalanceFactor(node) == 2 && BalanceFactor(node.Lchild) == 1)
                return LLRotation(node);
            else if (BalanceFactor(node) == 2 && BalanceFactor(node.Lchild) == -1)
                return LRRotation(node);
            else if (BalanceFactor(node) == -2 && BalanceFactor(node.Rchild) == -1)
                return RRRotation(node);
            else if (BalanceFactor(node) == -2 && BalanceFactor(node.Rchild) == 1)
                return RLRotation(node);

            return node;
        }

        internal AVLTreeNode RDeleteNode(AVLTreeNode node, int num)
        {
            if (node == null)
            {
                return null;
            }

            if (node.Rchild == null && node.Lchild == null)
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
                if (node.Rchild != null)
                {
                    AVLTreeNode tempNode = InSucc(node.Rchild);
                    node.Data = tempNode.Data;
                    node.Rchild = RDeleteNode(node.Rchild, tempNode.Data);
                }
                else
                {
                    AVLTreeNode tempNode = InPre(node.Lchild);
                    node.Data = tempNode.Data;
                    node.Lchild = RDeleteNode(node.Lchild, tempNode.Data);
                }
            }

            node.Height = NodeHeight(node);

            if (BalanceFactor(node) == 2 && BalanceFactor(node.Lchild) == 1)
                return LLRotation(node);
            else if (BalanceFactor(node) == 2 && BalanceFactor(node.Lchild) == -1)
                return LRRotation(node);
            else if (BalanceFactor(node) == 2 && BalanceFactor(node.Lchild) == 0)
                return LLRotation(node);
            else if (BalanceFactor(node) == -2 && BalanceFactor(node.Rchild) == -1)
                return RRRotation(node);
            else if (BalanceFactor(node) == -2 && BalanceFactor(node.Rchild) == 1)
                return RLRotation(node);
            else if (BalanceFactor(node) == -2 && BalanceFactor(node.Rchild) == 0)
                return RRRotation(node);

            return node;
        }

        internal void LevelOrderTrversal(AVLTreeNode rootNode)
        {
            QueueUsingLinkedList queue = new QueueUsingLinkedList();

            queue.Enqueue(rootNode);

            while (!queue.IsEmpty())
            {
                rootNode = queue.Dequeue();
                Console.Write(rootNode.Data + " ");
                if (rootNode.Lchild != null)
                    queue.Enqueue(rootNode.Lchild);

                if (rootNode.Rchild != null)
                    queue.Enqueue(rootNode.Rchild);
            };
        }

        private AVLTreeNode InPre(AVLTreeNode node)
        {
            while (node != null && node.Rchild != null)
            {
                node = node.Rchild;
            }
            return node;
        }

        private AVLTreeNode InSucc(AVLTreeNode node)
        {
            while (node != null && node.Lchild != null)
            {
                node = node.Lchild;
            }
            return node;
        }

        private AVLTreeNode LLRotation(AVLTreeNode node)
        {
            AVLTreeNode lNode = node.Lchild;
            AVLTreeNode lrNode = lNode.Rchild;

            lNode.Rchild = node;
            node.Lchild = lrNode;

            node.Height = NodeHeight(node);
            lNode.Height = NodeHeight(lNode);

            if (RootNode == node)
                RootNode = lNode;

            return lNode;
        }

        private AVLTreeNode RRRotation(AVLTreeNode node)
        {
            AVLTreeNode rNode = node.Rchild;
            AVLTreeNode rlNode = rNode.Lchild;

            rNode.Lchild = node;
            node.Rchild = rlNode;

            node.Height = NodeHeight(node);
            rNode.Height = NodeHeight(rNode);

            if (RootNode == node)
                RootNode = rNode;

            return rNode;
        }

        private AVLTreeNode LRRotation(AVLTreeNode node)
        {
            AVLTreeNode lNode = node.Lchild;
            AVLTreeNode lrNode = lNode.Rchild;

            lNode.Rchild = lrNode.Lchild;
            node.Lchild = lrNode.Rchild;

            lrNode.Lchild = lNode;
            lrNode.Rchild = node;

            lNode.Height = NodeHeight(lNode);
            node.Height = NodeHeight(node);
            lrNode.Height = NodeHeight(lrNode);

            if (RootNode == node)
                RootNode = lrNode;

            return lrNode;
        }

        private AVLTreeNode RLRotation(AVLTreeNode node)
        {
            AVLTreeNode rNode = node.Rchild;
            AVLTreeNode rlNode = rNode.Lchild;

            rNode.Lchild = rlNode.Rchild;
            node.Rchild = rlNode.Lchild;

            rlNode.Rchild = rNode;
            rlNode.Lchild = node;

            rNode.Height = NodeHeight(rNode);
            node.Height = NodeHeight(node);
            rlNode.Height = NodeHeight(rlNode);

            if (RootNode == node)
                RootNode = rlNode;

            return rlNode;
        }

        private int NodeHeight(AVLTreeNode node)
        {
            int hl = 0, hr = 0;

            if (node != null)
            {
                hl = node.Lchild != null ? node.Lchild.Height : 0;
                hr = node.Rchild != null ? node.Rchild.Height : 0;
            }

            return hl > hr ? hl + 1 : hr + 1;
        }

        private int BalanceFactor(AVLTreeNode node)
        {
            int hl = 0, hr = 0;

            if (node != null)
            {
                hl = node.Lchild != null ? node.Lchild.Height : 0;
                hr = node.Rchild != null ? node.Rchild.Height : 0;
            }

            return hl - hr;
        }
    }
}
