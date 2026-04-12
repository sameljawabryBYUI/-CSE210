using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create instances of each activity
        Running runningActivity = new Running("03 Nov 2022", 30, 3.0);
        Cycling cyclingActivity = new Cycling("04 Nov 2022", 45, 12.0);
        Swimming swimmingActivity = new Swimming("05 Nov 2022", 20, 40);

        // Put them all into a single list of type Activity
        List<Activity> activities = new List<Activity>();
        activities.Add(runningActivity);
        activities.Add(cyclingActivity);
        activities.Add(swimmingActivity);

        Console.WriteLine("Exercise Tracking Summaries:\n");

        // Iterate through the list and call GetSummary() on each
        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}