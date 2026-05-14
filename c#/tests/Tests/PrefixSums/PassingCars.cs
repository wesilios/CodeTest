namespace Tests.PrefixSums;

public class PassingCars
{
    /// <summary>
    /// Counts the total number of cars that can pass each other based on the given array of car directions and
    /// pairs of indices representing the ranges of interest.
    /// </summary>
    /// <param name="directions">
    /// An array representing car directions, where 0 typically indicates a car traveling east and 1 indicates a car traveling west.
    /// </param>
    /// <param name="carPairs">
    /// A 2D array of integer pairs, where each pair specifies a starting and ending index
    /// that defines the range to analyze passing cars.
    /// </param>
    /// <returns>
    /// The sum of passing cars for all specified ranges in the array.
    /// </returns>
    public int CountPassingCars(int[] directions, int[][] carPairs)
    {
        var passingCarsCount = 0;
        foreach (var carPair in carPairs)
        {
            var eastboundCars = 0;

            for (var i = carPair[0]; i <= carPair[1]; i++)
            {
                if (directions[i] == 0)
                {
                    eastboundCars++;
                }
                else
                {
                    passingCarsCount += eastboundCars;
                }
            }
        }

        return passingCarsCount;
    }
}