namespace Get_current_timestamp_version_002_full_stop_YYYY_MM_DD_full_stop_standard;

using System;

class Program
{
    static void Main()
    {
        // Get current date
        DateTime now = DateTime.Now;

        // Format as YYYY_MM_DD
        string formattedDate = now.ToString("yyyy_MM_dd");

        Console.WriteLine("Current Date: " + formattedDate);
    }
}