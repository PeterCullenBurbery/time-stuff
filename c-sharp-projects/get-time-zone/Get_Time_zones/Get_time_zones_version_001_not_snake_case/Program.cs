namespace Get_time_zones_version_001_not_snake_case;

using System;
using NodaTime;
using NodaTime.TimeZones;

class Program
{
    static void Main()
    {
        var source = TzdbDateTimeZoneSource.Default;

        // Get the system's time zone as an IANA ID
        string ianaId = source.MapTimeZoneId(TimeZoneInfo.Local.Id);

        Console.WriteLine($"tzdb version: {source.VersionId}");
        Console.WriteLine($"Your time zone: {ianaId}");
    }
}

static class TimeZoneSourceExtensions
{
    public static string MapTimeZoneId(this TzdbDateTimeZoneSource source, string windowsId)
    {
        // Match "territory 001" for canonical mapping
        var mapZone = source.WindowsMapping.MapZones
            .FirstOrDefault(m => m.WindowsId == windowsId && m.Territory == "001");

        if (mapZone != null && mapZone.TzdbIds.Count > 0)
        {
            return mapZone.TzdbIds[0];
        }

        // Fallback to original ID if mapping fails
        return windowsId;
    }
}