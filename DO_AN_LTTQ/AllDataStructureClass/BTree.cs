/*using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace DO_AN_LTTQ.AllDataStructureClass
{
    public class BTree
    {
        public  int degree; // Bậc của B-tree
        public BTreeNode root; // Nút gốc của B-tree

        public BTree(int degree)
        {
            if (degree < 2)
                throw new ArgumentException("Degree must be at least 2 for a B-tree.");

            this.degree = degree;
            root = new BTreeNode(degree);
        }

        public void Insert(string values)
        {
            string[] valueArray = values.Split(' ');
            foreach (string value in valueArray)
            {
                if (!string.IsNullOrEmpty(value))
                {
                    InsertValue(value);
                }
                else
                {
                    throw new ArgumentException("Invalid input format.");
                }
            }
        }

        private void InsertValue(string value)
        {
            if (root.IsFull())
            {
                BTreeNode newRoot = new BTreeNode(degree);
                newRoot.Children.Add(root);
                SplitChild(newRoot, 0);
                root = newRoot;
            }

            InsertNonFull(root, value);
        }

        private void InsertNonFull(BTreeNode node, string value)
        {
            int index = node.Keys.Count - 1;

            if (node.IsLeaf())
            {
                while (index >= 0 && string.Compare(value, node.Keys[index]) < 0)
                {
                    index--;
                }
                node.Keys.Insert(index + 1, value);
            }
            else
            {
                while (index >= 0 && string.Compare(value, node.Keys[index]) < 0)
                {
                    index--;
                }
                index++;

                if (node.Children[index].IsFull())
                {
                    SplitChild(node, index);

                    if (string.Compare(value, node.Keys[index]) > 0)
                    {
                        index++;
                    }
                }

                InsertNonFull(node.Children[index], value);
            }
        }

        // Các phương thức khác của BTree mà bạn muốn triển khai
        // ...

        private void SplitChild(BTreeNode parentNode, int index)
        {
            BTreeNode nodeToSplit = parentNode.Children[index];
            BTreeNode newNode = new BTreeNode(degree);
            newNode.IsLeafNode = nodeToSplit.IsLeafNode;

            parentNode.Keys.Insert(index, nodeToSplit.Keys[degree - 1]);

            for (int j = 0; j < degree - 1; j++)
            {
                if (j < degree - 1)
                    newNode.Keys.Add(nodeToSplit.Keys[j + degree]);
                if (j < degree)
                    newNode.Children.Add(nodeToSplit.Children[j + degree]);
            }

            nodeToSplit.Keys.RemoveRange(degree - 1, degree);
            nodeToSplit.Children.RemoveRange(degree, degree);

            parentNode.Children.Insert(index + 1, newNode);
        }
        
        public class BTreeNode
        {
            public List<string> Keys { get; set; }
            public List<BTreeNode> Children { get; set; }
            public bool IsLeafNode { get; set; }

            public BTreeNode(int degree)
            {
                Keys = new List<string>();
                Children = new List<BTreeNode>();
                IsLeafNode = true;
            }

            public bool IsFull()
            {
                return Keys.Count == 2 *3 - 1;
                //return Keys.Count == 2* degree -1;
            }

            public bool IsLeaf()
            {
                return IsLeafNode;
            }
        }
    }
}
*/