using System;

class Program
{
    static void Main(string[] args)
    {
        // Ask the user for their grade percentage
        Console.Write("What is your grade percentage? ");
        string answer = Console.ReadLine();
        int percentage = int.Parse(answer);

        string letter = "";
        string sign = "";

        // Determine the core letter grade
        if (percentage >= 90)
        {
            letter = "A";
        }
        else if (percentage >= 80)
        {
            letter = "B";
        }
        else if (percentage >= 70)
        {
            letter = "C";
        }
        else if (percentage >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // Determine the +/- sign (Stretch Challenge)
        int lastDigit = percentage % 10;

        if (lastDigit >= 7)
        {
            sign = "+";
        }
        else if (lastDigit < 3)
        {
            sign = "-";
        }
        else
        {
            sign = "";
        }

        // Handle the A and F exceptions (Stretch Challenge)
        if (letter == "A" && sign == "+")
        {
            sign = "";
        }

        if (letter == "F")
        {
            sign = "";
        }

        // Display the final letter grade with sign
        Console.WriteLine($"Your letter grade is: {letter}{sign}");

        // Determine pass or fail message
        if (percentage >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course.");
        }
        else
        {
            Console.WriteLine("Keep trying! You'll get it next time.");
        }
    }
}