namespace CodeTest.TimeComplexity;

public class FrogJumpTest
{
    [Theory]
    [InlineData(10, 85, 30, 3)]
    [InlineData(10, 100, 30, 3)]
    [InlineData(10, 110, 30, 4)]
    public void FrogJump(int x, int y, int step, int expected)
    {
        Assert.Equal(expected, Solution(x, y, step));
        Assert.Equal(expected, SolutionTwo(x, y, step));
    }

    private int Solution(int x, int y, int d)
    {
        var numberJump = 0;
        while (y > x)
        {
            x += d;
            numberJump++;
        }

        return numberJump;
    }

    private int SolutionTwo(int x, int y, int d)
    {
        var gap = y - x;
        if (gap % d == 0)
        {
            return gap / d;
        }

        return gap / d + 1;
    }
}