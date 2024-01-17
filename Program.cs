using System;
using System.Collections.Generic;

internal class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the dice throwing simulator!\n");
        Print p = new Print();
        p.GetUserInput(); // calls GetUserInput to initialize code
    }
}

internal class Print
{
    public void GetUserInput()
    {
        Console.WriteLine("How many dice rolls would you like to simulate? ");
        string diceInputString = Console.ReadLine();

        if (!int.TryParse(diceInputString, out int diceInput))
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
            return;
        }

        Dice dice = new Dice(diceInput);
        dice.PrintHistogram();
    }
}

internal class Dice
{
    private int[] rollCounts;

    public Dice(int numRolls) // passes in diceInput as numRolls 
    {
        rollCounts = new int[11]; // Indices 2 through 12 for the combinations

        var random = new Random(); // have to call random class to be able to utilize the random method 

        for (int i = 0; i < numRolls; i++)
        {
            int die1 = random.Next(1, 7);
            int die2 = random.Next(1, 7);
            int sumDie = die1 + die2; // adds sum of both die
            rollCounts[sumDie - 2]++; // Adjust index to match combination (2-12)
        }
    }

    public void PrintHistogram()
    {
        Console.WriteLine("DICE ROLLING SIMULATION RESULTS");
        Console.WriteLine("Each \"*\" represents 1% of the total number of rolls.");

        int totalRolls = rollCounts.Sum();
        Console.WriteLine($"Total number of rolls = {totalRolls}."); // totalRolls is an interpolated string in this case, eliminating the need for concatenation

        for (int i = 2; i <= 12; i++) // set i equal to 2 to print off correct format when displaying results
        {
            int percentage = (int)((double)rollCounts[i - 2] / totalRolls * 100); // (int) casts the mathmatical results to type int
            string asterisks = new string('*', percentage); // repeats the asterisk according to the number that is assigned to percentage 
            Console.WriteLine($"{i}: {asterisks}"); // takes the number of index it is on, prints it, then prints the number of asteriks based on percentage. also, automatically increments a new line
        }

        Console.WriteLine("\nThank you for using the dice throwing simulator. Goodbye!"); // prints off goodbye statement
    }
}