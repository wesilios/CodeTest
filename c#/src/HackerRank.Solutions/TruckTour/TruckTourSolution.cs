namespace HackerRank.Solutions.TruckTour;

public class TruckTourSolution
{
    /// <summary>
    /// Determines the starting petrol pump index from which a truck can complete a circular tour.
    /// </summary>
    /// <param name="petrolPumps">
    /// A list of petrol pumps where each petrol pump is represented as a list of two integers:
    /// the amount of petrol provided by the pump and the distance to the next pump.
    /// </param>
    /// <returns>
    /// The index of the starting petrol pump that allows for a complete circular tour.
    /// Returns -1 if no such starting point exists.
    /// </returns>
    public int GetStartingPoint(List<List<int>> petrolPumps)
    {
        var route = new Queue<GasStation>();
        foreach (var petrolPump in petrolPumps)
        {
            route.Enqueue(new GasStation
            {
                Gas = petrolPump[0],
                Next = petrolPump[1]
            });
        }

        var start = 0;
        var passed = 0;
        var gas = 0;
        while (passed < petrolPumps.Count)
        {
            var gasStation = route.Dequeue();
            gas += gasStation.Gas;
            route.Enqueue(gasStation);
            if (gas >= gasStation.Next)
            {
                passed++;
                gas -= gasStation.Next;
                continue;
            }

            start += passed + 1;
            passed = 0;
            gas = 0;
        }

        return start;
    }

    private struct GasStation
    {
        public int Gas { get; set; }
        public int Next { get; set; }
    }
}