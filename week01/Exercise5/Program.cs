using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise5 Project.");
        DisplayWelcome();
        string userName = PromptUserName();
        int favoriteNumber = PromptUserNumber();
        int squaredNumber = SquaredNumber(favoriteNumber);
        DisplayResult(userName, squaredNumber);
    }
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the program!");
    }
    static string PromptUserName()
    {
        Console.Write("Please, What is your name? ");
        return Console.ReadLine();
    }
    static int PromptUserNumber()
    {
        Console.Write("Please, What is your favorite number? ");
        return int.Parse(Console.ReadLine());
    }
    static int SquaredNumber(int number)
    {
        return number * number;
    }
    static void DisplayResult(string name, int number)
    {
        Console.WriteLine($"Thank you, {name}. The square of your number is {number}.");
    }
}