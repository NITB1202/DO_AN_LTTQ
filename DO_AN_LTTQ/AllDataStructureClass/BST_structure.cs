using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO_AN_LTTQ.AllDataStructureClass
{
    internal class BST_structure
    {
        int type = -1;
        public class Node
        {
            public string Data;
            public Node Left;
            public Node Right;

            public Node(string data)
            {
                Data = data;
                Left = null;
                Right = null;
            }
        }
        public Node root;
        public BST_structure(int t)
        {
            root = null;
            type = t;
        }
        public void Insert(string data)
        {
            root = InsertRecursive(root, data);
        }
        private Node InsertRecursive(Node current, string data)
        {
            if (current == null)
                return new Node(data);
            if (compare(data,current.Data) == -1)
                current.Left = InsertRecursive(current.Left, data);
            else
                current.Right = InsertRecursive(current.Right, data);
            return current;
        }
        private int compare(string a, string b)
        {
            if(type!=2)
            {
                if (float.Parse(a) < float.Parse(b))
                    return -1;
                else
                    return 1;
            }
            else
            {
                if (a[0] < b[0])
                    return -1;
                else
                    return 1;
            }
        }
        public int Height(Node node)
        {
            if (node == null)
            {
                return 0;
            }
            else
            {
                int leftHeight = Height(node.Left);
                int rightHeight = Height(node.Right);

                return Math.Max(leftHeight, rightHeight) + 1;
            }
        }
        public void PreorderTraversalRecursive(Node current, List<string> save_data)
        {
            if (current != null)
            {
                save_data.Add(current.Data);
                PreorderTraversalRecursive(current.Left, save_data);
                PreorderTraversalRecursive(current.Right, save_data);
            }
        }
    }
}
