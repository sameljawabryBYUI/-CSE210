using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        
        // Approach: Initialize a new list of integers
        List<int> numbers = new List<int>();
        int userNumber = -1;

        // Core Requirement 1: Ask for numbers and append to list until 0 is entered
        while (userNumber != 0)
        {
            Console.Write("Enter number: ");
            userNumber = int.Parse(Console.ReadLine());

            if (userNumber != 0)
            {
                numbers.Add(userNumber);
            }
        }

        // Core Requirement 2: Compute the sum
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }
        Console.WriteLine($"The sum is: {sum}");

        // Core Requirement 3: Compute the average
        // We cast sum to a double to ensure we get a decimal result
        double average = ((double)sum) / numbers.Count;
        Console.WriteLine($"The average is: {average}");

        // Core Requirement 4: Find the max
        int max = numbers[0];
        foreach (int number in numbers)
        {
            if (number > max)
            {
                max = number;
            }
        }
        Console.WriteLine($"The largest number is: {max}");

        // Stretch Challenge 1: Find the smallest positive number
        int smallestPositive = int.MaxValue;
        foreach (int number in numbers)
        {
            if (number > 0 && number < smallestPositive)
            {
                smallestPositive = number;
            }
        }
        
        // Only print if a positive number was actually found
        if (smallestPositive != int.MaxValue)
        {
            Console.WriteLine($"The smallest positive number is: {smallestPositive}");
        }

        // Stretch Challenge 2: Sort the list and display it
        numbers.Sort();
        Console.WriteLine("The sorted list is:");
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }
    }
}