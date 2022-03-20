using CodeTest.Library;
using HackerRank.Solutions;
using Xunit;

namespace CodeTest.HackerRank.BinaryTrees
{
    public class BinaryTreeSolutionTests
    {
        [Fact]
        public void PreOrderTest()
        {
            var root = TestCase();
            const string expected = "12453";
            var binaryTreeSolution = new BinaryTreeSolution();
            Assert.Equal(expected, binaryTreeSolution.PreOrder(root));
        }

        [Fact]
        public void PostOrderTest()
        {
            var root = TestCase();
            const string expected = "45231";
            var binaryTreeSolution = new BinaryTreeSolution();
            Assert.Equal(expected, binaryTreeSolution.PostOrder(root));
        }

        [Fact]
        public void InOrderTest()
        {
            var root = TestCase();
            const string expected = "42513";
            var binaryTreeSolution = new BinaryTreeSolution();
            Assert.Equal(expected, binaryTreeSolution.InOrder(root));
        }

        [Fact]
        public void GetHeightTest()
        {
            var root = TestCase();
            const int expected = 2;
            var binaryTreeSolution = new BinaryTreeSolution();
            Assert.Equal(expected, binaryTreeSolution.Height(root));
        }

        private BinaryTreeNode<string> TestCase()
        {
            var root = new BinaryTreeNode<string>("1")
            {
                Left = new BinaryTreeNode<string>("2"),
                Right = new BinaryTreeNode<string>("3")
            };
            root.Left.Left = new BinaryTreeNode<string>("4");
            root.Left.Right = new BinaryTreeNode<string>("5");
            return root;
        }
    }
}