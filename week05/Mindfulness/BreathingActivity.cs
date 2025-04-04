//Author : Diogo Rangel Dos Santos
// Breathing Activity

using System;

public class BreathingActivity : Activity
{
    public BreathingActivity() 
        : base("Breathing Activity", 
               "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.",60)
    {
    }

    public void Run()
    {
        DisplayStartingMessage();
        int duration = GetDuration();
        for (int i = 0; i < duration; i += 6)
        {
            Console.Write("Breathe in... ");
            ShowCountdown(3);
            Console.Write("Now breathe out... ");
            ShowCountdown(3);
            Console.WriteLine();
        }
        DisplayEndingMessage();
    }
}