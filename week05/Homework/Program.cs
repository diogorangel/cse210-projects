// Author : Diogo Rangel Dos Santos
// Program.cs
using System;

class Program
{
    static void Main()
    {
       Assignment assignment = new Assignment("Samuel Bennett", "Multiplication");
        Console.WriteLine(assignment.GetSummary());

        MathAssignment mathAssignment = new MathAssignment("Roberto Rodriguez", "Fractions", "Section 7.3", "Problems 8-19");
        Console.WriteLine(mathAssignment.GetSummary());
        Console.WriteLine(mathAssignment.GetHomeworkList());

        WritingAssignment writingAssignment = new WritingAssignment("Mary Johnson", "American History", "The Civil War");
        Console.WriteLine(writingAssignment.GetWritingInformation());
    }
}
