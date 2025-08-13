namespace List_time_zones_001_version;

using System;
using System.Collections.Generic;
using TimeZoneConverter;

class Program
{
    static void Main()
    {
        HashSet<string> ianaZones = new HashSet<string>();

        // Get all system time zones
        foreach (var tz in TimeZoneInfo.GetSystemTimeZones())
        {
            // Convert Windows ID to IANA ID
            try
            {
                string iana = TZConvert.WindowsToIana(tz.Id);
                ianaZones.Add(iana);
            }
            catch
            {
                // If already IANA or not convertible, skip
            }
        }

        // Add common IANA zones (in case they don't exist in Windows mapping)
        foreach (var iana in TZConvert.KnownIanaTimeZoneNames)
        {
            ianaZones.Add(iana);
        }

        // Sort and print
        List<string> sortedZones = new List<string>(ianaZones);
        sortedZones.Sort();

        foreach (var zone in sortedZones)
        {
            Console.WriteLine(zone);
        }
    }
}