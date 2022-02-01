using System.Linq;
using HackerRank.Solutions;
using Xunit;

namespace CodeTest.HackerRank
{
    public class IntersectionOfTwoArraysSolutionTests
    {
        [Theory]
        [InlineData("1 2 2 1", "2 2", "2")]
        [InlineData("4 9 5", "9 4 9 8 4", "9 4")]
        public void IntersectionNoDuplicationTest(string numOneArray, string numTwoArray, string expectedResult)
        {
            var nums1 = numOneArray.Split();

            var nums2 = numTwoArray.Split();

            var expected = expectedResult.Split();

            var intersectionOfTwoArray = new IntersectionOfTwoArraysSolution();

            var result = intersectionOfTwoArray.IntersectionNoDuplication(nums1, nums2);

            Assert.Equal(expected.Length, result.Length);
            foreach (var i in expected)
            {
                Assert.Contains(i, result);
            }
        }

        [Theory]
        [InlineData("1 2 2 1", "2 2", "2 2")]
        [InlineData("4 9 5", "9 4 9 8 4", "9 4")]
        [InlineData("4 9 5 4 9", "9 4 9 8 4", "9 9 4 4")]
        [InlineData("3 1 2", "1 1", "1")]
        public void IntersectionDuplicationTest(string numOneArray, string numTwoArray, string expectedResult)
        {
            var nums1 = numOneArray.Split();

            var nums2 = numTwoArray.Split();

            var expected = expectedResult.Split().OrderBy(c => c).ToArray();

            var intersectionOfTwoArray = new IntersectionOfTwoArraysSolution();

            var result = intersectionOfTwoArray.IntersectionDuplication(nums1, nums2);

            result = result.OrderBy(c => c).ToArray();

            Assert.Equal(expected.Length, result.Length);
            for (var i = 0; i < expected.Length; i++)
            {
                Assert.Equal(expected[i], result[i]);
            }
        }
    }
}