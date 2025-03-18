//Author : Diogo Rangel Dos Santos
using System;

class Program
{
    static void Main()
    {
        // Test default constructor (1/1)
        Fraction frac1 = new Fraction();
        Console.WriteLine($"Fraction: {frac1.GetFractionString()}, Decimal: {frac1.GetDecimalValue()}");

        // Test constructor with one parameter (5/1)
        Fraction frac2 = new Fraction(5);
        Console.WriteLine($"Fraction: {frac2.GetFractionString()}, Decimal: {frac2.GetDecimalValue()}");

        // Test constructor with two parameters (3/4)
        Fraction frac3 = new Fraction(3, 4);
        Console.WriteLine($"Fraction: {frac3.GetFractionString()}, Decimal: {frac3.GetDecimalValue()}");

        // Test constructor with another fraction (1/3)
        Fraction frac4 = new Fraction(1, 3);
        Console.WriteLine($"Fraction: {frac4.GetFractionString()}, Decimal: {frac4.GetDecimalValue()}");

        // Test setters and getters
        frac1.SetNumerator(7);
        frac1.SetDenominator(2);
        Console.WriteLine($"Updated Fraction: {frac1.GetFractionString()}, Decimal: {frac1.GetDecimalValue()}");
    }
}