using System;

class Program
{
    static void Main(string[] args)
    {
        // EXCEEDING REQUIREMENTS:
        // I have added a tracking feature that keeps a tally of how many times
        // each activity has been performed during the session. It displays this
        // activity log when the user chooses to quit the program.

        int breathingCount = 0;
        int reflectingCount = 0;
        int listingCount = 0;

        string choice = "";

        while (choice != "4")
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit");
            Console.Write("Select a choice from the menu: ");
            choice = Console.ReadLine();

            if (choice == "1")
            {
                BreathingActivity breathingActivity = new BreathingActivity();
                breathingActivity.Run();
                breathingCount++;
            }
            else if (choice == "2")
            {
                ReflectingActivity reflectingActivity = new ReflectingActivity();
                reflectingActivity.Run();
                reflectingCount++;
            }
            else if (choice == "3")
            {
                ListingActivity listingActivity = new ListingActivity();
                listingActivity.Run();
                listingCount++;
            }
        }

        // Display session log upon exiting
        Console.Clear();
        Console.WriteLine("Activity Log for this Session:");
        Console.WriteLine($"- Breathing Activity: {breathingCount} time(s)");
        Console.WriteLine($"- Reflecting Activity: {reflectingCount} time(s)");
        Console.WriteLine($"- Listing Activity: {listingCount} time(s)");
        Console.WriteLine();
        Console.WriteLine("Thank you for using the Mindfulness Program!");
    }
}