//Author : Diogo Rangel Dos Santos
using System;

class Fraction
{
    private int numerator;
    private int denominator;

    // Default constructor (1/1)
    public Fraction()
    {
        numerator = 1;
        denominator = 1;
    }

    // Constructor with one parameter (X/1)
    public Fraction(int top)
    {
        numerator = top;
        denominator = 1;
    }

    // Constructor with two parameters (X/Y)
    public Fraction(int top, int bottom)
    {
        if (bottom == 0)
        {
            throw new ArgumentException("Denominator cannot be zero.");
        }
        numerator = top;
        denominator = bottom;
    }

    // Getters
    public int GetNumerator()
    {
        return numerator;
    }

    public int GetDenominator()
    {
        return denominator;
    }

    // Setters
    public void SetNumerator(int top)
    {
        numerator = top;
    }

    public void SetDenominator(int bottom)
    {
        if (bottom == 0)
        {
            throw new ArgumentException("Denominator cannot be zero.");
        }
        denominator = bottom;
    }

    // Returns the fraction as "X/Y"
    public string GetFractionString()
    {
        return $"{numerator}/{denominator}";
    }

    // Returns the decimal representation of the fraction
    public double GetDecimalValue()
    {
        return (double)numerator / denominator;
    }
}
