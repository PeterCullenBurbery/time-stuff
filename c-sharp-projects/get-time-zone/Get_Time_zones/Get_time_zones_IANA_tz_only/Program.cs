namespace Get_time_zones_IANA_tz_only;

using System;
using NodaTime;

class Program
{
    static DateTimeZone GetTimeZone()
    {
        // Returns the system's local time zone from Noda Time's provider
        return DateTimeZoneProviders.Tzdb.GetSystemDefault();
    }

    static void Main()
    {
        var tz = GetTimeZone();
        Console.WriteLine($"Local time zone: {tz.Id}");
    }
}