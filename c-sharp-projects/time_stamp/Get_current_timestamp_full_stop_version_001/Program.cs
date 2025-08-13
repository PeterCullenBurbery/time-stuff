namespace Get_current_timestamp_full_stop_version_001;

using System;

class Program
{
    static void Main()
    {
        // Get current date and time with time zone info
        DateTimeOffset timestamp = DateTimeOffset.Now;

        Console.WriteLine("Current Timestamp: " + timestamp);
    }
}