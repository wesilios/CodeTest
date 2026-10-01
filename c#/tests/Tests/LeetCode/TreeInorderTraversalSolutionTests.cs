using LeetCode.Solutions;

namespace Tests.LeetCode;

public class TreeInorderTraversalSolutionTests
{
    [Theory]
    [InlineData("1,,2,3", "1,3,2")]
    [InlineData("", "")]
    [InlineData("1", "1")]
    [InlineData("1,2,3,4,5,6,7", "4,2,5,1,6,3,7")]
    [InlineData("1,2,,3", "3,2,1")]
    [InlineData("1,,2,,3", "1,2,3")]
    public void InorderTraversalTest(string input, string expected)
    {
        // Arrange
        var root = BuildTree(input);
        var solution = new TreeInorderTraversalSolution();

        // Act
        var result = solution.InorderTraversal(root);

        // Assert
        var expectedResult = string.IsNullOrWhiteSpace(expected)
            ? Array.Empty<int>()
            : expected.Split(',').Select(int.Parse).ToArray();

        Assert.Equal(expectedResult, result);
    }

    private static TreeNode BuildTree(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            return null;
        }

        var tokens = input.Split(',');
        if (tokens.Length == 0 || string.IsNullOrWhiteSpace(tokens[0]) || tokens[0] == "null")
        {
            return null;
        }

        var root = new TreeNode(int.Parse(tokens[0].Trim()));
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        var i = 1;
        while (queue.Count > 0 && i < tokens.Length)
        {
            var current = queue.Dequeue();

            if (i < tokens.Length)
            {
                var leftVal = tokens[i++].Trim();
                if (!string.IsNullOrEmpty(leftVal) && leftVal != "null")
                {
                    current.Left = new TreeNode(int.Parse(leftVal));
                    queue.Enqueue(current.Left);
                }
            }

            if (i >= tokens.Length) continue;
            var rightVal = tokens[i++].Trim();
            if (string.IsNullOrEmpty(rightVal) || rightVal == "null") continue;
            current.Right = new TreeNode(int.Parse(rightVal));
            queue.Enqueue(current.Right);
        }

        return root;
    }
}