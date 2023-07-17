using System;
using System.Collections.Generic;

// Base Activity class
abstract class Activity
{
    private DateTime date;
    private int lengthInMinutes;

    public DateTime Date
    {
        get { return date; }
        set { date = value; }
    }

    public int LengthInMinutes
    {
        get { return lengthInMinutes; }
        set { lengthInMinutes = value; }
    }

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public string GetSummary()
    {
        string activityType = GetType().Name;
        double distance = GetDistance();
        double speed = GetSpeed();
        double pace = GetPace();

        string unit = GetUnit();

        string summary = date.ToString("dd MMM yyyy") + " " + activityType + " (" + lengthInMinutes + " min): ";
        summary += "Distance: " + distance.ToString("F1") + " " + unit + ", ";
        summary += "Speed: " + speed.ToString("F1") + " " + GetSpeedUnit() + ", ";
        summary += "Pace: " + pace.ToString("F1") + " min per " + unit;

        return summary;
    }

    protected abstract string GetUnit();
    protected abstract string GetSpeedUnit();
}

// Derived Running class
class Running : Activity
{
    private double distance;

    public double Distance
    {
        get { return distance; }
        set { distance = value; }
    }

    public override double GetDistance()
    {
        return distance;
    }

    public override double GetSpeed()
    {
        return (distance / LengthInMinutes) * 60;
    }

    public override double GetPace()
    {
        return LengthInMinutes / distance;
    }

    protected override string GetUnit()
    {
        return "miles";
    }

    protected override string GetSpeedUnit()
    {
        return "mph";
    }
}

// Derived Cycling class
class Cycling : Activity
{
    private double speed;

    public double Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    public override double GetDistance()
    {
        return (speed * LengthInMinutes) / 60;
    }

    public override double GetSpeed()
    {
        return speed;
    }

    public override double GetPace()
    {
        return 60 / speed;
    }

    protected override string GetUnit()
    {
        return "miles";
    }

    protected override string GetSpeedUnit()
    {
        return "mph";
    }
}

// Derived Swimming class
class Swimming : Activity
{
    private int laps;

    public int Laps
    {
        get { return laps; }
        set { laps = value; }
    }

    public override double GetDistance()
    {
        return (laps * 50) / 1000;
    }

    public override double GetSpeed()
    {
        double distance = GetDistance();
        return (distance / LengthInMinutes) * 60;
    }

    public override double GetPace()
    {
        double distance = GetDistance();
        return LengthInMinutes / distance;
    }

    protected override string GetUnit()
    {
        return "kilometers";
    }

    protected override string GetSpeedUnit()
    {
        return "kph";
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();

        Running running = new Running
        {
            Date = new DateTime(2022, 11, 3),
            LengthInMinutes = 30,
            Distance = 3.0
        };
        activities.Add(running);

        Cycling cycling = new Cycling
        {
            Date = new DateTime(2022, 11, 3),
            LengthInMinutes = 30,
            Speed = 6.0
        };
        activities.Add(cycling);

        Swimming swimming = new Swimming
        {
            Date = new DateTime(2022, 11, 3),
            LengthInMinutes = 30,
            Laps = 40
        };
        activities.Add(swimming);

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }

        Console.ReadLine();
    }
}
