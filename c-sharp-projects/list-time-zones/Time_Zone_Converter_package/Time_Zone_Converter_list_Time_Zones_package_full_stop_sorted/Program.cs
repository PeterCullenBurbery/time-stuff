namespace Time_Zone_Converter_list_Time_Zones_package_full_stop_sorted;

using System;
using System.Linq;
using TimeZoneConverter;

class Program
{
    static void Main()
    {
        foreach (var id in TZConvert.KnownIanaTimeZoneNames.OrderBy(x => x))
            Console.WriteLine(id);
    }
}