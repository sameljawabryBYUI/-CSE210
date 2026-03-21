using System;

// EXCEEDING REQUIREMENTS:
// To exceed core requirements, I modified the Scripture.HideRandomWords() method 
// to only select words that are currently unhidden. It creates a temporary list of 
// unhidden words, selects random indexes from that list, and removes them as it goes 
// so it never wastes a turn trying to hide an already-hidden word.

class Program
{
    static void Main(string[] args)
    {
        // Set up the scripture reference and text
        Reference reference = new Reference("Proverbs", 3, 5, 6);
        string text = "Trust in the Lord with all thine heart and lean not unto thine own understanding; in all thy ways acknowledge him, and he shall direct thy paths.";
        
        Scripture scripture = new Scripture(reference, text);

        string userInput = "";

        while (userInput != "quit" && !scripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.WriteLine("Press enter to continue or type 'quit' to finish:");
            
            userInput = Console.ReadLine();

            // Hide 3 words at a time when enter is pressed
            if (userInput != "quit")
            {
                scripture.HideRandomWords(3);
            }
        }

        // Final display to show the fully hidden scripture before exiting
        if (scripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.WriteLine("You've memorized the scripture! Goodbye.");
        }
    }
}