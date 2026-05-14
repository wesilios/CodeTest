using Libraries;

namespace HackerRank.Solutions;

public class BinaryTreeSolution
{
    /// <summary>
    /// Traverses the binary tree in pre-order fashion (root, left, right) and returns
    /// a concatenated string representation of the node data.
    /// </summary>
    /// <typeparam name="T">The type of the data stored in the binary tree nodes.</typeparam>
    /// <param name="root">The root node of the binary tree to traverse. Null if the tree is empty.</param>
    /// <returns>A concatenated string representation of the binary tree node data in pre-order order.
    /// Returns an empty string if the root is null.</returns>
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

    /// <summary>
    /// Traverses the binary tree in post-order fashion (left, right, root) and returns
    /// a concatenated string representation of the node data.
    /// </summary>
    /// <typeparam name="T">The type of the data stored in the binary tree nodes.</typeparam>
    /// <param name="root">The root node of the binary tree to traverse. Null if the tree is empty.</param>
    /// <returns>A concatenated string representation of the binary tree node data in post-order order.
    /// Returns an empty string if the root is null.</returns>
    public string PostOrder<T>(BinaryTreeNode<T> root)
    {
        var result = string.Empty;
        if (root == null) return result;
        result += PostOrder(root.Left);
        result += PostOrder(root.Right);
        result += root.Data;

        return result;
    }

    /// <summary>
    /// Traverses the binary tree in in-order fashion (left, root, right) and returns
    /// a concatenated string representation of the node data.
    /// </summary>
    /// <typeparam name="T">The type of the data stored in the binary tree nodes.</typeparam>
    /// <param name="root">The root node of the binary tree to traverse. Null if the tree is empty.</param>
    /// <returns>A concatenated string representation of the binary tree node data in in-order order.
    /// Returns an empty string if the root is null.</returns>
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

    /// <summary>
    /// Calculates the height of a binary tree, which is defined as the number of edges
    /// on the longest path from the root node to a leaf node.
    /// </summary>
    /// <typeparam name="T">The type of the data stored in the binary tree nodes.</typeparam>
    /// <param name="root">The root node of the binary tree. Null if the tree is empty.</param>
    /// <returns>The height of the binary tree as an integer. Returns 0 if the tree is empty or contains only the root node.</returns>
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