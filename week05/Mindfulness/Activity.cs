//Author : Diogo Rangel Dos Santos
//Base Class Activity

using System;
using System.Threading;

public class Activity
{
    private string _name;
    private string _description;
    private int _duration;

    public Activity (string name, string description, int durationInSeconds)
    {
        _name = name;
        _description = description;
        _duration = durationInSeconds;
    }
    
     public void SetDuration()
    {
        Console.Write("Enter the duration of the activity in seconds: ");
        _duration = int.Parse(Console.ReadLine());
    }

    public int GetDuration() => _duration;
    
    public void DisplayStartingMessage()
    {
        Console.WriteLine($"Welcome to the {_name} activity.");
        Console.WriteLine($"You will love the {_description} activity.☼");
        Console.WriteLine($"This activity will last for {_duration} seconds.");
        SetDuration();
        Console.WriteLine("Get ready...");
        Console.WriteLine("Are you prepared?");
        Console.WriteLine("Then, Let's start!");
        ShowSpinner(3);
    }

     public void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!");
        ShowSpinner(2);
        Console.WriteLine($"You have completed {_duration} seconds of the {_name}.");
        ShowSpinner(3);
    }

    public void ShowSpinner(int seconds)
    {
       for (int i = 0; i < seconds; i++)
        {
            Console.Write(".");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }
     public void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
        Console.WriteLine();
    }
}