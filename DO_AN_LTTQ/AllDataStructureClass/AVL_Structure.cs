using System;

namespace DO_AN_LTTQ.AllDataStructureClass
{
    internal class AVL_Structure
    {
        int type = -1;

        public class Node
        {
            public string Data;
            public Node Left;
            public Node Right;
            public int Height;

            public Node(string data)
            {
                Data = data;
                Left = null;
                Right = null;
                Height = 1;
            }
        }

        public Node root;
        public AVL_Structure(int t)
        {
            root = null;
            type = t;
        }

        public int Height(Node node)
        {
            if (node == null)
                return 0;
            return node.Height;
        }

        private int BalanceFactor(Node node)
        {
            if (node == null)
                return 0;
            return Height(node.Left) - Height(node.Right);
        }

        private Node RightRotate(Node y)
        {
            Node x = y.Left;
            Node T2 = x.Right;

            x.Right = y;
            y.Left = T2;

            y.Height = Math.Max(Height(y.Left), Height(y.Right)) + 1;
            x.Height = Math.Max(Height(x.Left), Height(x.Right)) + 1;

            return x;
        }

        private Node LeftRotate(Node x)
        {
            Node y = x.Right;
            Node T2 = y.Left;

            y.Left = x;
            x.Right = T2;

            x.Height = Math.Max(Height(x.Left), Height(x.Right)) + 1;
            y.Height = Math.Max(Height(y.Left), Height(y.Right)) + 1;

            return y;
        }

        public void Insert(string data)
        {
            root = InsertRecursive(root, data);
        }

        private Node InsertRecursive(Node node, string data)
        {
            if (node == null)
                return new Node(data);

            int compareResult = compare(data, node.Data);

            if (compareResult < 0)
                node.Left = InsertRecursive(node.Left, data);
            else if (compareResult > 0)
                node.Right = InsertRecursive(node.Right, data);
            else // Duplicate keys not allowed in AVL
                return node;

            node.Height = 1 + Math.Max(Height(node.Left), Height(node.Right));

            int balance = BalanceFactor(node);

            // Left Left Case
            if (balance > 1 && compare(data,node.Left.Data) < 0)
                return RightRotate(node);

            // Right Right Case
            if (balance < -1 && compare(data, node.Right.Data) > 0)
                return LeftRotate(node);

            // Left Right Case
            if (balance > 1 && compare(data, node.Left.Data) > 0)
            {
                node.Left = LeftRotate(node.Left);
                return RightRotate(node);
            }

            // Right Left Case
            if (balance < -1 && compare(data, node.Right.Data) < 0)
            {
                node.Right = RightRotate(node.Right);
                return LeftRotate(node);
            }

            return node;
        }

        public void InorderTraversal(Action<string> action)
        {
            InorderTraversalRecursive(root, action);
        }

        private void InorderTraversalRecursive(Node node, Action<string> action)
        {
            if (node != null)
            {
                InorderTraversalRecursive(node.Left, action);
                action(node.Data);
                InorderTraversalRecursive(node.Right, action);
            }
        }
        public void PreorderTraversal(Action<string> action)
        {
            PreorderTraversalRecursive(root, action);
        }

        private void PreorderTraversalRecursive(Node node, Action<string> action)
        {
            if (node != null)
            {
                action(node.Data);
                PreorderTraversalRecursive(node.Left, action);
                PreorderTraversalRecursive(node.Right, action);
            }
        }

        public void PostorderTraversal(Action<string> action)
        {
            PostorderTraversalRecursive(root, action);
        }

        public void PostorderTraversalRecursive(Node node, Action<string> action)
        {
            if (node != null)
            {
                PostorderTraversalRecursive(node.Left, action);
                PostorderTraversalRecursive(node.Right, action);
                action(node.Data);
            }
        }
        public bool Search(string data)
        {
            return SearchRecursive(root, data);
        }

        private bool SearchRecursive(Node node, string data)
        {
            if (node == null)
                return false;

            int compareResult= compare(data, node.Data);
            if (compareResult == 0)
                return true;
            else if (compareResult < 0)
                return SearchRecursive(node.Left, data);
            else
                return SearchRecursive(node.Right, data);
        }

        public void Delete(string data)
        {
            root = DeleteRecursive(root, data);
        }

        private Node DeleteRecursive(Node node, string data)
        {
            if (node == null)
                return node;
            int compareResult = compare(data, node.Data);


            if (compareResult < 0)
                node.Left = DeleteRecursive(node.Left, data);
            else if (compareResult > 0)
                node.Right = DeleteRecursive(node.Right, data);
            else
            {
                // Nếu nút có một hoặc không có con
                if (node.Left == null || node.Right == null)
                {
                    Node temp = node.Left ?? node.Right;

                    if (temp == null)
                    {
                        temp = node;
                        node = null;
                    }
                    else
                    {
                        node = temp;
                    }
                }
                else
                {
                    // Nút có hai con, lấy nút kế tiếp (nút nhỏ nhất bên phải) trong cây con bên phải
                    Node temp = GetMinValueNode(node.Right);

                    node.Data = temp.Data;

                    node.Right = DeleteRecursive(node.Right, temp.Data);
                }
            }

            if (node == null)
                return node;

            node.Height = 1 + Math.Max(Height(node.Left), Height(node.Right));

            // Cân bằng cây AVL sau mỗi lần xóa
            int balance = BalanceFactor(node);

            // Trường hợp Left Left
            if (balance > 1 && BalanceFactor(node.Left) >= 0)
                return RightRotate(node);

            // Trường hợp Left Right
            if (balance > 1 && BalanceFactor(node.Left) < 0)
            {
                node.Left = LeftRotate(node.Left);
                return RightRotate(node);
            }

            // Trường hợp Right Right
            if (balance < -1 && BalanceFactor(node.Right) <= 0)
                return LeftRotate(node);

            // Trường hợp Right Left
            if (balance < -1 && BalanceFactor(node.Right) > 0)
            {
                node.Right = RightRotate(node.Right);
                return LeftRotate(node);
            }

            return node;
        }

        private Node GetMinValueNode(Node node)
        {
            while (node.Left != null)
                node = node.Left;

            return node;
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
        private int compare(string a, string b)
        {
            if (type != 2)
            {
                if (float.Parse(a) < float.Parse(b))
                    return -1;
                else if (float.Parse(a) == float.Parse(b))
                    return 0;
                else return 1;
            }
            else
            {
                if (a[0] < b[0])
                    return -1;
                else if (a[0] == b[0])
                    return 0;
                else 
                    return 1;
            }
        }
    }
}
