namespace Get_time_zones_version_001_snake_case;

using System;
using System.Linq;
using NodaTime;
using NodaTime.TimeZones;

class Program
{
    static void Main()
    {
        var tzdb_source = TzdbDateTimeZoneSource.Default;

        // Get the system's time zone as an IANA ID
        string iana_id = tzdb_source.map_time_zone_id(TimeZoneInfo.Local.Id);

        Console.WriteLine($"tzdb version: {tzdb_source.VersionId}");
        Console.WriteLine($"your time zone: {iana_id}");
    }
}

static class time_zone_source_extensions
{
    public static string map_time_zone_id(this TzdbDateTimeZoneSource tzdb_source, string windows_id)
    {
        // Match "territory 001" for canonical mapping
        var map_zone = tzdb_source.WindowsMapping.MapZones
            .FirstOrDefault(m => m.WindowsId == windows_id && m.Territory == "001");

        if (map_zone != null && map_zone.TzdbIds.Count > 0)
        {
            return map_zone.TzdbIds[0];
        }

        // Fallback to original ID if mapping fails
        return windows_id;
    }
}