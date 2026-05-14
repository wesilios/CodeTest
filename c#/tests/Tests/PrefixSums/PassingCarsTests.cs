namespace Tests.PrefixSums;

public class PassingCarsTests
{
    [Theory]
    [InlineData("0,1,0,1,1", "0,4", 5)] // 1. Basic single range (Your example logic)
    [InlineData("0,1", "0,1|0,1", 2)] // 2. Multiple identical ranges (Summation check)
    [InlineData("1,1,0,0", "0,3", 0)] // 3. No passing possible (West before East)
    // 4. Multi-range with different start points
    // Range [0,3] has 4 passes ({0,0} pass {1,1})
    // Range [2,3] has 0 passes (only {1,1} exists)
    [InlineData("0,0,1,1", "0,3|2,3", 4)]
    // 5. Large gaps
    [InlineData("0,0,0,0,1", "0,4", 4)]
    // 6. Alternating directions
    // Range [0,2]: 0 passes 1 at index 1 (1 pass)
    // Range [1,3]: 0 at index 2 passes 1 at index 3 (1 pass)
    [InlineData("0,1,0,1", "0,2|1,3", 2)]
    public void CountPassingCarsTest(string directionString, string ranges, int expectedPasses)
    {
        // Arrange
        var directions = directionString.Split(',').Select(int.Parse).ToArray();
        var carPairs = ranges.Split('|').Select(range => range.Split(',').Select(int.Parse).ToArray()).ToArray();

        // Act
        var solution = new PassingCars();

        // Assert
        Assert.Equal(expectedPasses, solution.CountPassingCars(directions, carPairs));
    }
}