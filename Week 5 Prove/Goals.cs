using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create a list to store the goals
        List<Goal> goals = new List<Goal>();

        // Variable to track the user's score
        int score = 0;

        bool exitProgram = false;
        while (!exitProgram)
        {
            Console.WriteLine("Eternal Quest - Goal Tracker");
            Console.WriteLine("1. Create a new goal");
            Console.WriteLine("2. Record an event");
            Console.WriteLine("3. Show list of goals");
            Console.WriteLine("4. Show user's score");
            Console.WriteLine("5. Save goals and score");
            Console.WriteLine("6. Load goals and score");
            Console.WriteLine("7. Exit program");

            Console.Write("Enter your choice: ");
            string input = Console.ReadLine();
            Console.WriteLine();

            switch (input)
            {
                case "1":
                    CreateGoal(goals);
                    break;
                case "2":
                    RecordEvent(goals, ref score);
                    break;
                case "3":
                    ShowGoals(goals);
                    break;
                case "4":
                    ShowScore(score);
                    break;
                case "5":
                    SaveGoalsAndScore(goals, score);
                    break;
                case "6":
                    LoadGoalsAndScore(ref goals, ref score);
                    break;
                case "7":
                    exitProgram = true;
                    Console.WriteLine("Exiting program...");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine();
        }
    }

    static void CreateGoal(List<Goal> goals)
    {
        Console.WriteLine("Create a New Goal");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");

        Console.Write("Enter the type of goal: ");
        string typeInput = Console.ReadLine();

        Console.Write("Enter the description of the goal: ");
        string description = Console.ReadLine();

        switch (typeInput)
        {
            case "1":
                goals.Add(new SimpleGoal(description));
                Console.WriteLine("Simple goal created successfully.");
                break;
            case "2":
                goals.Add(new EternalGoal(description));
                Console.WriteLine("Eternal goal created successfully.");
                break;
            case "3":
                Console.Write("Enter the number of times the goal must be accomplished: ");
                int targetCount = int.Parse(Console.ReadLine());
                goals.Add(new ChecklistGoal(description, targetCount));
                Console.WriteLine("Checklist goal created successfully.");
                break;
            default:
                Console.WriteLine("Invalid goal type. Please try again.");
                break;
        }
    }

    static void RecordEvent(List<Goal> goals, ref int score)
    {
        Console.WriteLine("Record an Event");

        if (goals.Count == 0)
        {
            Console.WriteLine("No goals available. Create a goal first.");
            return;
        }

        Console.WriteLine("Select a goal to record an event:");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].Description}");
        }

        Console.Write("Enter the goal number: ");
        int goalIndex = int.Parse(Console.ReadLine()) - 1;

        if (goalIndex < 0 || goalIndex >= goals.Count)
        {
            Console.WriteLine("Invalid goal number. Please try again.");
            return;
        }

        Goal selectedGoal = goals[goalIndex];
        score += selectedGoal.RecordEvent();

        Console.WriteLine("Event recorded successfully.");
    }

    static void ShowGoals(List<Goal> goals)
    {
        Console.WriteLine("List of Goals:");

        if (goals.Count == 0)
        {
            Console.WriteLine("No goals available. Create a goal first.");
            return;
        }

        for (int i = 0; i < goals.Count; i++)
        {
            Goal goal = goals[i];
            string completionStatus = goal.IsComplete ? "[X]" : "[ ]";
            string goalStatus = goal is ChecklistGoal ? $"Completed {goal.CompletionCount}/{((ChecklistGoal)goal).TargetCount} times" : "";
            Console.WriteLine($"{completionStatus} {goal.Description} {goalStatus}");
        }
    }

    static void ShowScore(int score)
    {
        Console.WriteLine($"User's Score: {score}");
    }

    static void SaveGoalsAndScore(List<Goal> goals, int score)
    {
        // Code to save goals and score to a file or database
        Console.WriteLine("Goals and score saved successfully.");
    }

    static void LoadGoalsAndScore(ref List<Goal> goals, ref int score)
    {
        // Code to load goals and score from a file or database
        Console.WriteLine("Goals and score loaded successfully.");
    }
}

abstract class Goal
{
    public string Description { get; }
    public bool IsComplete { get; protected set; }

    public Goal(string description)
    {
        Description = description;
        IsComplete = false;
    }

    public abstract int RecordEvent();
}

class SimpleGoal : Goal
{
    private int value;

    public SimpleGoal(string description) : base(description)
    {
        value = 100; // Points earned for completing a simple goal
    }

    public override int RecordEvent()
    {
        IsComplete = true;
        return value;
    }
}

class EternalGoal : Goal
{
    private int value;

    public EternalGoal(string description) : base(description)
    {
        value = 100; // Points earned for recording an event for an eternal goal
    }

    public override int RecordEvent()
    {
        return value;
    }
}

class ChecklistGoal : Goal
{
    private int value;
    private int completionCount;
    private int targetCount;

    public int CompletionCount => completionCount;
    public int TargetCount => targetCount;

    public ChecklistGoal(string description, int targetCount) : base(description)
    {
        value = 50; // Points earned for recording an event for a checklist goal
        this.targetCount = targetCount;
    }

    public override int RecordEvent()
    {
        completionCount++;
        if (completionCount == targetCount)
        {
            IsComplete = true;
            return value + 500; // Bonus points earned for completing a checklist goal
        }

        return value;
    }
}

   
