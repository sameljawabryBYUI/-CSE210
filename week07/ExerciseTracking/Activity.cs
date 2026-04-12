using System;

public abstract class Activity
{
    private string _date;
    private int _minutes;

    public Activity(string date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    public int GetMinutes()
    {
        return _minutes;
    }

    // Abstract methods to be overridden by derived classes
    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    // The GetSummary method is defined here in the base class.
    // It calls the abstract methods, allowing Polymorphism to dynamically 
    // insert the correct math depending on the specific activity type.
    public string GetSummary()
    {
        // this.GetType().Name automatically gets the name of the derived class (e.g., "Running")
        return $"{_date} {this.GetType().Name} ({_minutes} min)- Distance {GetDistance():0.0} miles, Speed {GetSpeed():0.0} mph, Pace: {GetPace():0.0} min per mile";
    }
}