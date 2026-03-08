using System;

class Program
{
    static void Main(string[] args)
    {
        string playAgain = "yes";

        // Stretch Challenge: Outer loop to play the whole game again
        while (playAgain == "yes")
        {
            // Core Requirement 3: Generate a random number between 1 and 100
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 101);

            int guess = -1;
            int guessCount = 0;

            // Core Requirement 2: Loop until the guess is correct
            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());

                // Stretch Challenge: Keep track of guesses
                guessCount++;

                // Core Requirement 1: Higher/Lower/Guessed logic
                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                }
            }

            // Stretch Challenge: Inform user of guess count
            Console.WriteLine($"It took you {guessCount} guesses.");

            // Stretch Challenge: Ask to play again
            Console.Write("Do you want to play again? (yes/no) ");
            playAgain = Console.ReadLine();
        }
    }
}