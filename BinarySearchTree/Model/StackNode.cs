using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree.Model
{
    internal class StackNode
    {
        internal TreeNode Data { get; set; }
        internal StackNode Next { get; set; }

        public StackNode(TreeNode data)
        {
            Data = data;
            Next = null;
        }
    }
}
