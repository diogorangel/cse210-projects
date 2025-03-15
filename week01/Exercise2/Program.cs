using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise2 Project.");
        //Request the grade user percentage
        Console.WriteLine("Please enter with your grade percentage: ");
        int percentage = int.Parse(Console.ReadLine());

        //Check the grade percentage and return the letter grade
        string letter ="";
        string sign = "";

        // Determines the letter corresponding to the note
        if(percentage >= 90)
        {
            letter = "A";
        }
        else if (percentage >= 80){
            letter = "B";
        }
        else if (percentage >= 70){
            letter = "C";
        }
         else if (percentage >= 60){
            letter = "D";
        }
        else{
            letter = "F";
        }
        // Determines the sign (+ or -) for the note
        int lastDigit = percentage % 10;
        if (lastDigit >= 7){
            sign = "+";
        }
        else if (lastDigit <= 3){
            sign = "-";
        }
        else{
            sign = "";
        }
        // Special cases where there is no A+ or any modification in F
        if(letter == "A" && sign == "+")
        {   
            sign = "";
        }
        else if(letter == "F")
        {
            sign = "";
        }
        // Display the final grade
        Console.WriteLine("Your grade is: " + letter + sign);
        if (percentage >= 70)
         {
            Console.WriteLine("Congratulations! You passed the course.");
        }
        else{
            Console.WriteLine("Keep working hard! You'll do better next time");
        }
    }        
}