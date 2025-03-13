using System;
using System.Collections.Generic;

public class Resume
{
    // Member variables
    public string _name;
    public List<Job> _jobs = new List<Job>(); // List of job objects

    // Method to display resume details
    public void Display()
    {
        Console.WriteLine($"Resume of {_name}");
        Console.WriteLine("Work Experience:");
        foreach (Job job in _jobs)
        {
            job.Display(); // Call Job's Display method
        }
    }
}