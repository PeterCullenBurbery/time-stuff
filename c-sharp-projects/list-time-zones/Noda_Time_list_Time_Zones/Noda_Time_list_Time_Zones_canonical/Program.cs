namespace Noda_Time_list_Time_Zones_canonical;

using System;
using System.Linq;
using NodaTime.TimeZones;

class Program
{
    static void Main()
    {
        var source = TzdbDateTimeZoneSource.Default;
        Console.WriteLine($"tzdb version: {source.VersionId}");

        var canonicalIds = source.CanonicalIdMap
            .Where(kv => kv.Key == kv.Value)                 // keep only canonical IDs
            .Select(kv => kv.Key);

        foreach (var id in canonicalIds)
            Console.WriteLine(id);
    }
}