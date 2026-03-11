using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string file)
    {
        using (StreamWriter outputFile = new StreamWriter(file))
        {
            foreach (Entry entry in _entries)
            {
                // Using ~~ as a separator to avoid issues with user commas
                outputFile.WriteLine($"{entry._date}~~{entry._location}~~{entry._promptText}~~{entry._entryText}");
            }
        }
        Console.WriteLine("Journal saved successfully.");
    }

    public void LoadFromFile(string file)
    {
        if (File.Exists(file))
        {
            _entries.Clear(); 
            string[] lines = File.ReadAllLines(file);

            foreach (string line in lines)
            {
                string[] parts = line.Split("~~");
                
                if (parts.Length == 4) 
                {
                    Entry newEntry = new Entry();
                    newEntry._date = parts[0];
                    newEntry._location = parts[1];
                    newEntry._promptText = parts[2];
                    newEntry._entryText = parts[3];
                    
                    _entries.Add(newEntry);
                }
            }
            Console.WriteLine("Journal loaded successfully.");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}