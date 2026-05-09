using HackerRank.Solutions.TruckTour;

namespace Tests.HackerRank;

public class TruckTourTests
{
    [Fact]
    public void TruckTourTest()
    {
        var petrolPumps = new List<List<int>>
        {
            new() { 1, 5 },
            new() { 10, 3 },
            new() { 3, 4 }
        };

        const int expectedResult = 1;
        var truckTour = new TruckTourSolution();
        Assert.Equal(expectedResult, truckTour.GetStartingPoint(petrolPumps));
    }
}