using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{


    public class BinarySearchTree
    {
        public class TreeNode
        {
            public int Value;
            public TreeNode Left;
            public TreeNode Right;

            public TreeNode(int value)
            {
                Value = value;
                Left = null;
                Right = null;
            }
        }

        private TreeNode root;

        public BinarySearchTree()
        {
            root = null;
        }

        public void Insert(int value)
        {
            root = InsertRec(root, value);
        }

        private TreeNode InsertRec(TreeNode node, int value)
        {
            if (node == null)
            {
                return new TreeNode(value);
            }

            if (value < node.Value)
            {
                node.Left = InsertRec(node.Left, value);
            }
            else if (value > node.Value)
            {
                node.Right = InsertRec(node.Right, value);
            }

            return node;
        }

        public bool Search(int value)
        {
            return SearchRec(root, value);
        }

        private bool SearchRec(TreeNode node, int value)
        {
            if (node == null)
            {
                return false;
            }

            if (value == node.Value)
            {
                return true;
            }
            else if (value < node.Value)
            {
                return SearchRec(node.Left, value);
            }
            else
            {
                return SearchRec(node.Right, value);
            }
        }

        public void Delete(int value)
        {
            root = DeleteRec(root, value);
        }

        private TreeNode DeleteRec(TreeNode node, int value)
        {
            if (node == null)
            {
                return node;
            }

            if (value < node.Value)
            {
                node.Left = DeleteRec(node.Left, value);
            }
            else if (value > node.Value)
            {
                node.Right = DeleteRec(node.Right, value);
            }
            else
            {
            
                if (node.Left == null)
                    return node.Right;
                else if (node.Right == null)
                    return node.Left;

               
                node.Value = MinValue(node.Right);

             
                node.Right = DeleteRec(node.Right, node.Value);
            }

            return node;
        }

        private int MinValue(TreeNode node)
        {
            int minValue = node.Value;
            while (node.Left != null)
            {
                minValue = node.Left.Value;
                node = node.Left;
            }
            return minValue;
        }

        public void InOrderTraversal()
        {
            InOrderRec(root);
            Console.WriteLine();
        }

        private void InOrderRec(TreeNode node)
        {
            if (node != null)
            {
                InOrderRec(node.Left);
                Console.Write(node.Value + " ");
                InOrderRec(node.Right);
            }
        }
    }

}
