namespace LeetCode.Solutions;

public class TreeNode
{
    public int Val;
    public TreeNode Left;
    public TreeNode Right;

    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        Val = val;
        Left = left;
        Right = right;
    }
}

public class TreeInorderTraversalSolution
{
    public IList<int> InorderTraversal(TreeNode root)
    {
        var result = new List<int>();
        if (root is null) return result;

        if (root.Left is not null)
        {
            result.AddRange(InorderTraversal(root.Left));
        }

        result.Add(root.Val);

        if (root.Right is not null)
        {
            result.AddRange(InorderTraversal(root.Right));
        }

        return result;
    }
}
