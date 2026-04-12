using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        bool quit = false;
        while (!quit)
        {
            DisplayPlayerInfo();

            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");
            
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoalDetails();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    quit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"\nYou have {_score} points.");
        Console.WriteLine($"Current Rank: {GetPlayerLevel()}");
    }

    private string GetPlayerLevel()
    {
        if (_score >= 5000) return "Legend";
        if (_score >= 2000) return "Master";
        if (_score >= 1000) return "Adept";
        if (_score >= 500) return "Apprentice";
        return "Novice";
    }

    public void ListGoalNames()
    {
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            // Extracting just the short name for the recording event menu
            string details = _goals[i].GetDetailsString();
            string nameOnly = details.Substring(details.IndexOf(']') + 2);
            int parensIndex = nameOnly.IndexOf('(');
            if(parensIndex > 0)
            {
                nameOnly = nameOnly.Substring(0, parensIndex).Trim();
            }
            Console.WriteLine($"{i + 1}. {nameOnly}");
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        string type = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();
        
        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        if (type == "1")
        {
            _goals.Add(new SimpleGoal(name, description, points));
        }
        else if (type == "2")
        {
            _goals.Add(new EternalGoal(name, description, points));
        }
        else if (type == "3")
        {
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            int target = int.Parse(Console.ReadLine());
            
            Console.Write("What is the bonus for accomplishing it that many times? ");
            int bonus = int.Parse(Console.ReadLine());
            
            _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
        }
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("You have no goals to record. Create one first!");
            return;
        }

        ListGoalNames();
        Console.Write("Which goal did you accomplish? ");
        int goalIndex = int.Parse(Console.ReadLine()) - 1;

        if (goalIndex >= 0 && goalIndex < _goals.Count)
        {
            Goal goal = _goals[goalIndex];
            
            // Check if ChecklistGoal finished this exact turn to add bonus
            bool wasComplete = goal.IsComplete();
            goal.RecordEvent();
            bool isComplete = goal.IsComplete();

            if (goal is ChecklistGoal && !wasComplete && isComplete)
            {
                // To get the exact points + bonus, we parse it directly from the string representation 
                // for simplicity, or just calculate it. It's easier to just add the base points and bonus here.
                string[] parts = goal.GetStringRepresentation().Split(',');
                int bonus = int.Parse(parts[3]);
                _score += (goal.GetPoints() + bonus);
            }
            else if (!wasComplete || goal is EternalGoal)
            {
                _score += goal.GetPoints();
            }
        }
        else
        {
            Console.WriteLine("Invalid goal selection.");
        }
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine("Goals saved successfully.");
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        if (File.Exists(filename))
        {
            string[] lines = File.ReadAllLines(filename);
            _score = int.Parse(lines[0]);
            _goals.Clear();

            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(':');
                string type = parts[0];
                string[] details = parts[1].Split(',');

                string name = details[0];
                string description = details[1];
                int points = int.Parse(details[2]);

                if (type == "SimpleGoal")
                {
                    bool isComplete = bool.Parse(details[3]);
                    _goals.Add(new SimpleGoal(name, description, points, isComplete));
                }
                else if (type == "EternalGoal")
                {
                    _goals.Add(new EternalGoal(name, description, points));
                }
                else if (type == "ChecklistGoal")
                {
                    int bonus = int.Parse(details[3]);
                    int target = int.Parse(details[4]);
                    int amountCompleted = int.Parse(details[5]);
                    _goals.Add(new ChecklistGoal(name, description, points, bonus, target, amountCompleted));
                }
            }
            Console.WriteLine("Goals loaded successfully.");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}