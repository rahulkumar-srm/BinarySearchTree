using BinarySearchTree.Helper;
using BinarySearchTree.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    class Program
    {
        static void Main(string[] args)
        {
            AVLTreeUsingLinkedList tree = new AVLTreeUsingLinkedList();

            while (true)
            {
                Console.WriteLine
                    ("Please select an option" +
                        Environment.NewLine + "1. Create Tree" +
                        Environment.NewLine + "2. InsertNode" +
                        Environment.NewLine + "3. In-order Traversal" +
                        Environment.NewLine + "4. Level-order Traversal" +
                        Environment.NewLine + "5. Delete a node" +
                        Environment.NewLine + "0. Exit"
                    );

                if (!int.TryParse(Console.ReadLine(), out int i))
                {
                    Console.WriteLine(Environment.NewLine + "Input format is not valid. Please try again." + Environment.NewLine);
                }

                if (i == 0)
                {
                    Environment.Exit(0);
                }
                else if (i == 1)
                {
                    tree.CreateAVLTree();
                }
                else if (i == 2)
                {
                    //tree.InsertNode();
                }
                else if (i == 3)
                {
                    tree.RInOrderTraversal(tree.RootNode);
                    Console.WriteLine();
                }
                else if (i == 4)
                {
                    tree.LevelOrderTrversal(tree.RootNode);
                    Console.WriteLine();
                }
                else if (i == 5)
                {
                    Console.WriteLine("Enter the number");
                    int num = Convert.ToInt32(Console.ReadLine());

                    tree.RDeleteNode(tree.RootNode, num);
                }
                else
                {
                    Console.WriteLine("Please select a valid option.");
                }
            }
        }
    }
}
