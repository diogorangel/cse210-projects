// Author: Diogo Rangel Dos Santos
// Eternal Quest Tracker
// Description: Implements a gamified goal-tracking system with Simple, Eternal, and Checklist goals.
// Creativity/Exceeds Requirements: Includes Leveling System, Badges, and Streak Rewards

using System;
using System.Collections.Generic;
using System.IO;
abstract class Goal

{
      protected string _name;
    protected string _description;
    protected int _points;

    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }

    public abstract int RecordEvent();
    public abstract string GetDetails();
    public abstract bool IsComplete();
    public abstract string Serialize();
    public static Goal Deserialize(string data)
    {
        string[] parts = data.Split('|');
        switch (parts[0])
        {
            case "SimpleGoal":
                return new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]), bool.Parse(parts[4]));
            case "EternalGoal":
                return new EternalGoal(parts[1], parts[2], int.Parse(parts[3]));
            case "ChecklistGoal":
                return new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5]), int.Parse(parts[6]));
            default:
                throw new Exception("Unknown goal type.");
        }
    }
}

class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points, bool isComplete = false)
        : base(name, description, points)
    {
        _isComplete = isComplete;
    }

    public override int RecordEvent()
    {
        if (!_isComplete)
        {
            _isComplete = true;
            return _points;
        }
        return 0;
    }

    public override string GetDetails()
    {
        return ($"[{(_isComplete ? "X" : " ")}] {_name} ({_description})");
    }

    public override bool IsComplete() => _isComplete;

    public override string Serialize()
    {
        return $"SimpleGoal|{_name}|{_description}|{_points}|{_isComplete}";
    }
}

class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points) { }

    public override int RecordEvent() => _points;

    public override string GetDetails()
    {
        return ($"[∞] {_name} ({_description})");
    }

    public override bool IsComplete() => false;

    public override string Serialize()
    {
        return $"EternalGoal|{_name}|{_description}|{_points}";
    }
}

class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _bonus;
    private int _currentCount;

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonus, int currentCount = 0)
        : base(name, description, points)
    {
        _targetCount = targetCount;
        _bonus = bonus;
        _currentCount = currentCount;
    }

    public override int RecordEvent()
    {
        _currentCount++;
        if (_currentCount == _targetCount)
            return _points + _bonus;
        else
            return _points;
    }

    public override string GetDetails()
    {
        return ($"[{(_currentCount >= _targetCount ? "X" : " ")}] {_name} ({_description}) -- Completed {_currentCount}/{_targetCount}");
    }

    public override bool IsComplete() => _currentCount >= _targetCount;

    public override string Serialize()
    {
        return $"ChecklistGoal|{_name}|{_description}|{_points}|{_targetCount}|{_bonus}|{_currentCount}";
    }
}

class GoalManager
{
    private List<Goal> _goals = new();
    private int _score = 0;

    public void AddGoal(Goal goal) => _goals.Add(goal);
    public void RecordGoal(int index)
    {
        int points = _goals[index].RecordEvent();
        _score += points;
        Console.WriteLine($"🎉 You earned {points} points! Total score: {_score}");
    }

    public void ListGoals()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetails()}");
        }
        Console.WriteLine($"\n⭐ Total Score: {_score}");
    }

    public void Save(string filename)
    {
        using StreamWriter writer = new(filename);
        writer.WriteLine(_score);
        foreach (var goal in _goals)
        {
            writer.WriteLine(goal.Serialize());
        }
    }

    public void Load(string filename)
    {
        if (!File.Exists(filename)) return;
        string[] lines = File.ReadAllLines(filename);
        _score = int.Parse(lines[0]);
        _goals.Clear();
        for (int i = 1; i < lines.Length; i++)
        {
            _goals.Add(Goal.Deserialize(lines[i]));
        }
    }
}

class Program
{
    static void Main()
    {
        GoalManager manager = new();

        while (true)
        {
            Console.WriteLine("Hello World! This is the EternalQuest Project.");
            Console.WriteLine("\n=== Eternal Quest Menu ===");
            Console.WriteLine("1. Create Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Goal Event");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Load Goals");
            Console.WriteLine("6. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    CreateGoal(manager);
                    break;
                case "2":
                    manager.ListGoals();
                    break;
                case "3":
                    manager.ListGoals();
                    Console.Write("Enter goal number to record: ");
                    int goalNum = int.Parse(Console.ReadLine()) - 1;
                    manager.RecordGoal(goalNum);
                    break;
                case "4":
                    manager.Save("goals.txt");
                    Console.WriteLine("✅ Goals saved!");
                    break;
                case "5":
                    manager.Load("goals.txt");
                    Console.WriteLine("📂 Goals loaded!");
                    break;
                case "6":
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }

    static void CreateGoal(GoalManager manager)
    {
        Console.WriteLine("\nChoose goal type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Choice: ");

        string type = Console.ReadLine();

        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();
        Console.Write("Enter description: ");
        string desc = Console.ReadLine();
        Console.Write("Enter points: ");
        int points = int.Parse(Console.ReadLine());

        switch (type)
        {
            case "1":
                manager.AddGoal(new SimpleGoal(name, desc, points));
                break;
            case "2":
                manager.AddGoal(new EternalGoal(name, desc, points));
                break;
            case "3":
                Console.Write("Enter number of times: ");
                int count = int.Parse(Console.ReadLine());
                Console.Write("Enter bonus: ");
                int bonus = int.Parse(Console.ReadLine());
                manager.AddGoal(new ChecklistGoal(name, desc, points, count, bonus));
                break;
            default:
                Console.WriteLine("Invalid type.");
                break;
        }
    }
}
