using System;
using System.Globalization;

namespace HackerRank.Solutions;

public class TimeConversionSolution
{
    public string ConvertTime(string time)
    {
        const string pmTime = "PM";
        var isPm = time.Contains(pmTime);
        var stringTime = time.Remove(time.Length - 2);
        var result = DateTime.ParseExact(stringTime, "hh:mm:ss", CultureInfo.InvariantCulture);
        if (isPm)
        {
            result = result.AddHours(12);
        }

        return result.ToString("HH:mm:ss");
    }
}