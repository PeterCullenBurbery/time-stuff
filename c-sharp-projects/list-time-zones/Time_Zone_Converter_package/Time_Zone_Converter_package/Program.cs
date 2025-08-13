namespace Time_Zone_Converter_package;

using System;
using TimeZoneConverter;

class Program
{
    static void Main()
    {
        foreach (var id in TZConvert.KnownIanaTimeZoneNames)
            Console.WriteLine(id);
    }
}