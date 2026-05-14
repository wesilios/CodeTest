using Libraries.Algorithm;

namespace Tests.PrefixSums;

public class PrefixSumTests
{
    [Theory]
    [InlineData(new[] { 3,1,4,1,5 }, new []{3,4,8,9,14})]
    public void PrefixSum(int[] originalArray, int[] prefixArray)
    {
        // Arrange
        var solution = new PrefixSuffixSum();
        
        // Act & Assert
        Assert.Equal(prefixArray, solution.PrefixSum(originalArray));
    }
}