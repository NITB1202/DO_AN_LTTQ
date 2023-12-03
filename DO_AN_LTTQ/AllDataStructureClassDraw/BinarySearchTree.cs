using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace DO_AN_LTTQ.AllDataStructureClassDraw
{
    public class BinarySearchTree<T> where T : IComparable<T>
    {
        public class Node
        {
            public T Data;
            public Node Left;
            public Node Right;

            public Node(T data)
            {
                Data = data;
                Left = null;
                Right = null;
            }
        }

        public Node root;

        public BinarySearchTree()
        {
            root = null;
        }


        public void Insert(T data)
        {
            root = InsertRecursive(root, data);
        }

        private Node InsertRecursive(Node current, T data)
        {
            if (current == null)
            {
                return new Node(data);
            }

            if (data.CompareTo(current.Data) < 0)
            {
                current.Left = InsertRecursive(current.Left, data);
            }
            else if (data.CompareTo(current.Data) > 0)
            {
                current.Right = InsertRecursive(current.Right, data);
            }

            return current;
        }

        public bool Search(T data)
        {
            return SearchRecursive(root, data);
        }

        private bool SearchRecursive(Node current, T data)
        {
            if (current == null)
            {
                return false;
            }

            if (current.Data.Equals(data))
            {
                return true;
            }
            else if (data.CompareTo(current.Data) < 0)
            {
                return SearchRecursive(current.Left, data);
            }
            else
            {
                return SearchRecursive(current.Right, data);
            }
        }

        // Phương thức duyệt Preorder
        public void PreorderTraversal(Action<T> action)
        {
            PreorderTraversalRecursive(root, action);
        }

        private void PreorderTraversalRecursive(Node current, Action<T> action)
        {
            if (current != null)
            {
                action(current.Data);
                PreorderTraversalRecursive(current.Left, action);
                PreorderTraversalRecursive(current.Right, action);
            }
        }

        // Phương thức duyệt Inorder
        public void InorderTraversal(Action<T> action)
        {
            InorderTraversalRecursive(root, action);
        }

        private void InorderTraversalRecursive(Node current, Action<T> action)
        {
            if (current != null)
            {
                InorderTraversalRecursive(current.Left, action);
                action(current.Data);
                InorderTraversalRecursive(current.Right, action);
            }
        }

        // Phương thức duyệt Postorder
        public void PostorderTraversal(Action<T> action)
        {
            PostorderTraversalRecursive(root, action);
        }

        private void PostorderTraversalRecursive(Node current, Action<T> action)
        {
            if (current != null)
            {
                PostorderTraversalRecursive(current.Left, action);
                PostorderTraversalRecursive(current.Right, action);
                action(current.Data);
            }
        }

        // Phương thức kiểm tra kích thước của cây
        public int Size()
        {
            return SizeRecursive(root);
        }

        private int SizeRecursive(Node current)
        {
            if (current == null)
            {
                return 0;
            }

            return 1 + SizeRecursive(current.Left) + SizeRecursive(current.Right);
        }

        // Phương thức tìm kiếm phần tử nhỏ nhất
        public T FindMin()
        {
            if (root == null)
            {
                throw new InvalidOperationException("Tree is empty");
            }

            Node current = root;
            while (current.Left != null)
            {
                current = current.Left;
            }
            return current.Data;
        }

        // Phương thức tìm kiếm phần tử lớn nhất
        public T FindMax()
        {
            if (root == null)
            {
                throw new InvalidOperationException("Tree is empty");
            }

            Node current = root;
            while (current.Right != null)
            {
                current = current.Right;
            }
            return current.Data;
        }
        // Các phương thức khác như Delete, Traversal (Inorder, Preorder, Postorder), Min, Max, v.v.
        public bool Delete(T data)
        {
            return DeleteNode(ref root, data);
        }

        private bool DeleteNode(ref Node current, T data)
        {
            if (current == null)
            {
                return false;
            }

            if (data.CompareTo(current.Data) < 0)
            {
                return DeleteNode(ref current.Left, data);
            }
            else if (data.CompareTo(current.Data) > 0)
            {
                return DeleteNode(ref current.Right, data);
            }
            else
            {
                if (current.Left == null)
                {
                    current = current.Right;
                }
                else if (current.Right == null)
                {
                    current = current.Left;
                }
                else
                {
                    current.Data = FindMinValue(current.Right);
                    DeleteNode(ref current.Right, current.Data);
                }
                return true;
            }
        }

        private T FindMinValue(Node node)
        {
            while (node.Left != null)
            {
                node = node.Left;
            }
            return node.Data;
        }

        // Phương thức duyệt theo cấp độ (Level Order Traversal)
        public void LevelOrderTraversal(Action<T> action)
        {
            int height = Height(root);
            for (int i = 1; i <= height; i++)
            {
                LevelOrderRecursive(root, i, action);
            }
        }

        private void LevelOrderRecursive(Node current, int level, Action<T> action)
        {
            if (current == null)
            {
                return;
            }
            if (level == 1)
            {
                action(current.Data);
            }
            else if (level > 1)
            {
                LevelOrderRecursive(current.Left, level - 1, action);
                LevelOrderRecursive(current.Right, level - 1, action);
            }
        }

        private int Height(Node node)
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
    }
}

