using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree.Model
{
    internal class TreeNode
    {
        internal int Data { get; set; }
        internal TreeNode Lchild { get; set; }
        internal TreeNode Rchild { get; set; }

        public TreeNode(int data)
        {
            Data = data;
            Lchild = null;
            Rchild = null;
        }
    }
}
