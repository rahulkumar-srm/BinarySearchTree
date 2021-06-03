using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree.Model
{
    internal class QueueNode
    {
        internal AVLTreeNode Data { get; set; }
        internal QueueNode Next { get; set; }

        public QueueNode(AVLTreeNode data)
        {
            Data = data;
            Next = null;
        }
    }
}
