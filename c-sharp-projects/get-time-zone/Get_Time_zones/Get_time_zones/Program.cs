namespace Get_time_zones;

using System;
using NodaTime;
using TimeZoneConverter;

class Program
{
    static (string iana, string windows) GetTimeZone()
    {
        // Get the local IANA time zone ID
        string iana = DateTimeZoneProviders.Tzdb.GetSystemDefault().Id;

        // Convert to the Windows time zone ID
        string windows = TZConvert.IanaToWindows(iana);

        return (iana, windows);
    }

    static void Main()
    {
        var (iana, windows) = GetTimeZone();
        Console.WriteLine($"Local IANA time zone:    {iana}");
        Console.WriteLine($"Local Windows time zone: {windows}");
    }
}