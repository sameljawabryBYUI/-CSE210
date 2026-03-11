using System;

public class Entry
{
    public string _date;
    public string _promptText;
    public string _entryText;
    public string _location;

    public void Display()
    {
        Console.WriteLine($"Date: {_date} | Location: {_location}");
        Console.WriteLine($"Prompt: {_promptText}");
        Console.WriteLine($"Response: {_entryText}\n");
    }
}