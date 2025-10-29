using System.Collections.Generic;
using HackerRank.Solutions.TruckTour;

namespace CodeTest.HackerRank;

public class TruckTourTests
{
    [Fact]
    public void TruckTourTest()
    {
        var petrolPumps = new List<List<int>>
        {
            new List<int> { 1, 5 },
            new List<int> { 10, 3 },
            new List<int> { 3, 4 }
        };

        const int expectedResult = 1;
        var truckTour = new TruckTourSolution();
        Assert.Equal(expectedResult, truckTour.GetStartingPoint(petrolPumps));
    }
}