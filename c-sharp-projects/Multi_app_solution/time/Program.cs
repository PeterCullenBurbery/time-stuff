namespace time;

using System;

class Program
{
    static void Main()
    {
        DateTime now = DateTime.Now;

        // Each tick = 100 nanoseconds
        long nanosecondsTotal = (now.Ticks % TimeSpan.TicksPerSecond) * 100;

        // Break into milliseconds, microseconds, and nanoseconds
        long milliseconds = nanosecondsTotal / 1_000_000;
        long microseconds = (nanosecondsTotal / 1_000) % 1_000;
        long nanoseconds = nanosecondsTotal % 1_000;

        // Format: YYYY_MMM_DDD_HHH_MMM_SSS_mmm_uuu_nnn
        string formattedTimestamp =
            $"{now:yyyy}_{now.Month:D3}_{now.Day:D3}_{now.Hour:D3}_{now.Minute:D3}_{now.Second:D3}_{milliseconds:D3}_{microseconds:D3}_{nanoseconds:D3}";

        Console.WriteLine(formattedTimestamp);
    }
}