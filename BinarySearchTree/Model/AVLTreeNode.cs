using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree.Model
{
    internal class AVLTreeNode
    {
        internal int Data { get; set; }
        internal int Height { get; set; }
        internal AVLTreeNode Lchild { get; set; }
        internal AVLTreeNode Rchild { get; set; }

        public AVLTreeNode(int data)
        {
            Data = data;
            Height = 1;
            Lchild = null;
            Rchild = null;
        }
    }
}
