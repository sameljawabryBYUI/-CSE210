using System;

// EXCEEDS CORE REQUIREMENTS:
// To exceed the core requirements, I implemented a "Leveling and Title System."
// As the user records events and gains points, their rank dynamically updates.
// The GoalManager checks the user's score and assigns a title (e.g., Novice, 
// Apprentice, Adept, Master, or Legend). This title is displayed next to 
// their score on the main menu, adding an extra layer of gamification to keep 
// the user motivated on their Eternal Quest.

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}