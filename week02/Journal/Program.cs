using System;

// CREATIVITY AND EXCEEDING REQUIREMENTS:
// To exceed the core requirements, I added a "_location" member variable to the Entry class. 
// This allows the user to log the specific city or airport they are writing from, which is 
// excellent for keeping a travel or flight log. The Save and Load methods in Journal.cs 
// were updated to handle this 4th piece of data, using a custom "~~" separator to avoid 
// conflicts with commas in the text.

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        bool running = true;

        Console.WriteLine("Welcome to the Journal Program!");

        while (running)
        {
            Console.WriteLine("\nPlease select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");
            
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                string prompt = promptGenerator.GetRandomPrompt();
                Console.WriteLine(prompt);
                Console.Write("> ");
                string response = Console.ReadLine();
                
                Console.Write("Location (e.g., City or Airport Code): ");
                string location = Console.ReadLine();

                Entry newEntry = new Entry();
                newEntry._date = DateTime.Now.ToShortDateString();
                newEntry._promptText = prompt;
                newEntry._entryText = response;
                newEntry._location = location;

                journal.AddEntry(newEntry);
            }
            else if (choice == "2")
            {
                journal.DisplayAll();
            }
            else if (choice == "3")
            {
                Console.Write("What is the filename to load? ");
                string file = Console.ReadLine();
                journal.LoadFromFile(file);
            }
            else if (choice == "4")
            {
                Console.Write("What is the filename to save as? ");
                string file = Console.ReadLine();
                journal.SaveToFile(file);
            }
            else if (choice == "5")
            {
                Console.WriteLine("Goodbye!");
                running = false;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
        }
    }
}