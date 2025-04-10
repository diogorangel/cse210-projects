//Author : Diogo Rangel Dos Santos
//W07 Learning Activity: Final Foundation Project Exercise Tracking

using System;
using System.Collections.Generic;

namespace ExerciseTracking
{
    // Base Activity class
    public abstract class Activity
    {
        // Private member variables
        private DateTime date;
        private int durationInMinutes;

        // Constructor
        public Activity(DateTime date, int durationInMinutes)
        {
            this.date = date;
            this.durationInMinutes = durationInMinutes;
        }

        // Properties to access private members
        public DateTime Date { get { return date; } }
        public int DurationInMinutes { get { return durationInMinutes; } }

        // Abstract methods to be implemented by derived classes
        public abstract double GetDistance();
        public abstract double GetSpeed();
        public abstract double GetPace();

        // Method to generate summary (can be overridden)
        public virtual string GetSummary()
        {
            return $"{Date:dd MMM yyyy} {this.GetType().Name} ({DurationInMinutes} min) - Distance {GetDistance()} miles, Speed {GetSpeed()} mph, Pace: {GetPace()} min per mile";
        }
    }

    // Derived class for Running
    public class Running : Activity
    {
        private double distance; // distance in miles

        public Running(DateTime date, int durationInMinutes, double distance) : base(date, durationInMinutes)
        {
            this.distance = distance;
        }

        public override double GetDistance()
        {
            return distance;
        }

        public override double GetSpeed()
        {
            return (GetDistance() / DurationInMinutes) * 60; // speed in miles per hour
        }

        public override double GetPace()
        {
            return DurationInMinutes / GetDistance(); // pace in minutes per mile
        }
    }

    // Derived class for Cycling
    public class Cycling : Activity
    {
        private double speed; // speed in miles per hour

        public Cycling(DateTime date, int durationInMinutes, double speed) : base(date, durationInMinutes)
        {
            this.speed = speed;
        }

        public override double GetDistance()
        {
            return (speed * DurationInMinutes) / 60; // distance in miles
        }

        public override double GetSpeed()
        {
            return speed;
        }

        public override double GetPace()
        {
            return 60 / speed; // pace in minutes per mile
        }
    }

    // Derived class for Swimming
    public class Swimming : Activity
    {
        private int laps; // number of laps

        public Swimming(DateTime date, int durationInMinutes, int laps) : base(date, durationInMinutes)
        {
            this.laps = laps;
        }

        public override double GetDistance()
        {
            // 50 meters per lap, convert to miles (1 mile = 1609.34 meters)
            return (laps * 50) / 1609.34; 
        }

        public override double GetSpeed()
        {
            return (GetDistance() / DurationInMinutes) * 60; // speed in miles per hour
        }

        public override double GetPace()
        {
            return DurationInMinutes / GetDistance(); // pace in minutes per mile
        }
    }

    // Main program
    class Program
    {
        static void Main(string[] args)
        {
            // Create instances of each activity
            var runningActivity = new Running(new DateTime(2025, 04, 10), 30, 3.0);
            var cyclingActivity = new Cycling(new DateTime(2025, 04, 10), 30, 12.0); // 12 mph
            var swimmingActivity = new Swimming(new DateTime(2025, 04, 10), 30, 20); // 20 laps

            // Create a list of activities
            List<Activity> activities = new List<Activity>
            {
                runningActivity,
                cyclingActivity,
                swimmingActivity
            };

            // Iterate through the list and display summaries
            foreach (var activity in activities)
            {
                Console.WriteLine(activity.GetSummary());
            }
        }
    }
}
// Output:  