using System;

class Program
{
    static void Main()
    {   
        Console.WriteLine("Hello World! This is the Exercise1 Project.");
        //Ask for the first name of user
        Console.Write("What is your first name? ");
        string firstname = Console.ReadLine();

        //Ask for the last name of user
        Console.Write("What is your last name? ");
        string lastname = Console.ReadLine();

         //Show the name at format requested
        Console.WriteLine($"Hello, your name is {lastname}, {firstname} {lastname}!");

        Console.WriteLine("Done");
        
    }
}