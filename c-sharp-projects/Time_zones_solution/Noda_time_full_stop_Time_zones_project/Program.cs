namespace Noda_time_full_stop_Time_zones_project;

using System;
using NodaTime.TimeZones;

class Program
{
    static void Main()
    {
        var source = TzdbDateTimeZoneSource.Default;
        Console.WriteLine($"tzdb version: {source.VersionId}");

        // Canonical IDs only (recommended for clean lists)
        foreach (var id in source.CanonicalIdMap.Keys)
            Console.WriteLine(id);
    }
}