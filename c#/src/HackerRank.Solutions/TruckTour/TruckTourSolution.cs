using System.Collections.Generic;

namespace HackerRank.Solutions.TruckTour;

public class TruckTourSolution
{
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

        return GetStartingPoint(route);
    }

    private int GetStartingPoint(Queue<GasStation> petrolPumps)
    {
        var start = 0;
        var passed = 0;
        var gas = 0;
        while (passed < petrolPumps.Count)
        {
            var gasStation = petrolPumps.Dequeue();
            gas += gasStation.Gas;
            petrolPumps.Enqueue(gasStation);
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
}