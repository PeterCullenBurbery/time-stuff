namespace focus_with_fucking_function;

using System;

class Program
{
    static void Main(string[] args)
    {
        // Use the first command-line argument if provided; otherwise default.
        string input_value = args.Length > 0 ? string.Join(" ", args) : "the trash";
        fucking_focus(input_value);
    }

    static void fucking_focus(string value)
    {
        // Keeps capitalization exactly as provided.
        Console.WriteLine($"It's time to stop fucking around with {value}.");
        Console.WriteLine($"It's time to take {value} seriously.");
        Console.WriteLine($"It's time to stop fucking around with {value}, and take {value} seriously. It's time to put a concerted effort into {value}.");
        Console.WriteLine($"It's time to stop fucking around with {value} and put some time into {value}.");
    }
}