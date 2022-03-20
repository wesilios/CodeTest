using CodeTest.Library;

namespace HackerRank.Solutions
{
    public class BinaryTreeSolution
    {
        public string PreOrder<T>(BinaryTreeNode<T> root)
        {
            var result = string.Empty;
            if (root == null) return result;
            result += root.Data;
            if (root.Left == null)
            {
                if (root.Right == null) return result;
                result += PreOrder(root.Right);
                return result;
            }

            if (root.Right == null)
            {
                result += PreOrder(root.Left);
                return result;
            }

            result += PreOrder(root.Left);
            result += PreOrder(root.Right);

            return result;
        }

        public string PostOrder<T>(BinaryTreeNode<T> root)
        {
            var result = string.Empty;
            if (root == null) return result;
            result += PostOrder(root.Left);
            result += PostOrder(root.Right);
            result += root.Data;

            return result;
        }

        public string InOrder<T>(BinaryTreeNode<T> root)
        {
            var result = string.Empty;
            if (root == null) return result;
            var current = root;
            while (current != null)
            {
                if (current.Left == null)
                {
                    result += current.Data;
                    current = current.Right;
                    continue;
                }

                var pre = current.Left;
                while (pre.Right != null && pre.Right != current)
                {
                    pre = pre.Right;
                }

                if (pre.Right == null)
                {
                    pre.Right = current;
                    current = current.Left;
                    continue;
                }

                pre.Right = null;
                result += current.Data;
                current = current.Right;
            }

            return result;
        }

        public int Height<T>(BinaryTreeNode<T> root)
        {
            var left = 0;
            var right = 0;
            if (root == null || root.Left == null && root.Right == null) return 0;
            var result = 1;

            left += Height(root.Left);
            right += Height(root.Right);
            
            result += right > left ? right : left;
            return result;
        }
    }
}