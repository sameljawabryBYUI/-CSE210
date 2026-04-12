using System;

public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus) : base(name, description, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;
    }

    // Constructor used for loading from a file
    public ChecklistGoal(string name, string description, int points, int bonus, int target, int amountCompleted) : base(name, description, points)
    {
        _amountCompleted = amountCompleted;
        _target = target;
        _bonus = bonus;
    }

    public override void RecordEvent()
    {
        if (_amountCompleted < _target)
        {
            _amountCompleted++;
            int pointsEarned = _points;

            if (_amountCompleted == _target)
            {
                pointsEarned += _bonus;
                Console.WriteLine($"Congratulations! You have completed the checklist and earned a bonus of {_bonus} points!");
            }

            Console.WriteLine($"Congratulations! You have earned {pointsEarned} points!");
        }
        else
        {
            Console.WriteLine("You have already completed this checklist goal.");
        }
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    public override string GetDetailsString()
    {
        string checkbox = IsComplete() ? "[X]" : "[ ]";
        return $"{checkbox} {_shortName} ({_description}) -- Currently completed: {_amountCompleted}/{_target}";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{_shortName},{_description},{_points},{_bonus},{_target},{_amountCompleted}";
    }
}