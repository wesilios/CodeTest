using System.Globalization;

namespace HackerRank.Solutions;

public class TimeConversionSolution
{
    /// <summary>
    /// Converts a 12-hour format time string into a 24-hour format time string.
    /// </summary>
    /// <param name="time">The time string in 12-hour format (e.g., "hh:mm:ssAM" or "hh:mm:ssPM").</param>
    /// <returns>The converted time string in 24-hour format (e.g., "HH:mm:ss").</returns>
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