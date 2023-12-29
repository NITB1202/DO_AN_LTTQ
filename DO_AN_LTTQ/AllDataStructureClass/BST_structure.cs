namespace DO_AN_LTTQ.AllDataStructureClass
{
    internal class BST_Structure
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
        public BST_Structure(int t)
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
        // Method to delete a node with given data
        public void Delete(string data)
        {
            root = DeleteRecursive(root, data);
        }

        private Node DeleteRecursive(Node current, string data)
        {
            if (current == null)
                return null;

            if (data.Equals(current.Data))
            {
                // Node with only one child or no child
                if (current.Left == null)
                    return current.Right;
                else if (current.Right == null)
                    return current.Left;

                // Node with two children: Get the inorder successor (smallest in the right subtree)
                current.Data = FindSmallestValue(current.Right);
                current.Right = DeleteRecursive(current.Right, current.Data);
            }
            else if (compare(data, current.Data) == -1)
                current.Left = DeleteRecursive(current.Left, data);
            else
                current.Right = DeleteRecursive(current.Right, data);

            return current;
        }

        private string FindSmallestValue(Node root)
        {
            return root.Left == null ? root.Data : FindSmallestValue(root.Left);
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

        // Method to search for a node with given data
        public bool Search(string data)
        {
            return SearchRecursive(root, data);
        }

        private bool SearchRecursive(Node current, string data)
        {
            if (current == null)
                return false;

            if (data.Equals(current.Data))
                return true;

            if (compare(data, current.Data) == -1)
                return SearchRecursive(current.Left, data);
            else
                return SearchRecursive(current.Right, data);
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
        public string FindMin()
        {
            if (root == null)
                return null;

            Node currentNode = root;
            while (currentNode.Left != null)
            {
                currentNode = currentNode.Left;
            }
            return currentNode.Data;
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

        public int CountNodes()
        {
            return CountNodesRecursive(root);
        }
        private int CountNodesRecursive(Node node)
        {
            if (node == null)
                return 0;

            return 1 + CountNodesRecursive(node.Left) + CountNodesRecursive(node.Right);
        }

        public string FindMax()
        {
            if (root == null)
                return null;

            Node currentNode = root;
            while (currentNode.Right != null)
            {
                currentNode = currentNode.Right;
            }
            return currentNode.Data;
        }


    }
}
