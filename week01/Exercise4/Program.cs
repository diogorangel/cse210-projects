using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise4 Project.");
        List<int> numbers = new List<int>();
        int number;

        Console.WriteLine("Enter a list of number type 0 when finished: ");
        do
        {   
            Console.Write("Enter a number: ");
            number = int.Parse(Console.ReadLine());
            if (number != 0)
            {
                numbers.Add(number);
            }
        } while (number != 0);

        // Calculate and display the sum
        int sum = numbers.Sum();
        Console.WriteLine($"The sum of the numbers is: {sum}");

        // Calculate and display the average
        double average = numbers.Average();
        Console.WriteLine($"The average of the numbers is: {average}");

        // Determine and display the largest number
        int maxNumber = numbers.Max();
        Console.WriteLine($"The maximum number is: {maxNumber}");

        // Extra challenge: find the smallest positive number
        int? smallestPositive = numbers.Where(n => n > 0).DefaultIfEmpty().Min();
        if (smallestPositive >0)
        {
            Console.WriteLine($"The smallest positive number is: {smallestPositive}");
        }
        // Extra challenge: sort the list and display it
        numbers.Sort();
        Console.WriteLine("The sorted list is: ");
        foreach(int num in numbers)
        {
            Console.WriteLine(num);
        }
    }   
}   