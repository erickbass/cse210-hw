using System;

// Address class representing an event address
class Address
{
    private string street;
    private string city;
    private string state;
    private string country;

    public string Street
    {
        get { return street; }
        set { street = value; }
    }

    public string City
    {
        get { return city; }
        set { city = value; }
    }

    public string State
    {
        get { return state; }
        set { state = value; }
    }

    public string Country
    {
        get { return country; }
        set { country = value; }
    }

    public string GetFullAddress()
    {
        return street + ", " + city + ", " + state + ", " + country;
    }
}

// Base Event class
class Event
{
    private string eventTitle;
    private string description;
    private DateTime date;
    private TimeSpan time;
    private Address address;

    public Event(string title, string desc, DateTime dt, TimeSpan tm, Address addr)
    {
        eventTitle = title;
        description = desc;
        date = dt;
        time = tm;
        address = addr;
    }

    public virtual string GetStandardDetails()
    {
        return "Title: " + eventTitle + Environment.NewLine +
               "Description: " + description + Environment.NewLine +
               "Date: " + date.ToString("MMMM d, yyyy") + Environment.NewLine +
               "Time: " + time.ToString(@"hh\:mm") + Environment.NewLine +
               "Address: " + address.GetFullAddress();
    }

    public virtual string GetFullDetails()
    {
        return GetStandardDetails();
    }

    public virtual string GetShortDescription()
    {
        return "Type: Event" + Environment.NewLine +
               "Title: " + eventTitle + Environment.NewLine +
               "Date: " + date.ToString("MMMM d, yyyy");
    }
}

// Derived Lecture class
class Lecture : Event
{
    private string speaker;
    private int capacity;

    public Lecture(string title, string desc, DateTime dt, TimeSpan tm, Address addr, string spkr, int cap)
        : base(title, desc, dt, tm, addr)
    {
        speaker = spkr;
        capacity = cap;
    }

    public override string GetFullDetails()
    {
        return base.GetFullDetails() + Environment.NewLine +
               "Type: Lecture" + Environment.NewLine +
               "Speaker: " + speaker + Environment.NewLine +
               "Capacity: " + capacity;
    }
}

// Derived Reception class
class Reception : Event
{
    private string rsvpEmail;

    public Reception(string title, string desc, DateTime dt, TimeSpan tm, Address addr, string email)
        : base(title, desc, dt, tm, addr)
    {
        rsvpEmail = email;
    }

    public override string GetFullDetails()
    {
        return base.GetFullDetails() + Environment.NewLine +
               "Type: Reception" + Environment.NewLine +
               "RSVP Email: " + rsvpEmail;
    }
}

// Derived OutdoorGathering class
class OutdoorGathering : Event
{
    private string weatherForecast;

    public OutdoorGathering(string title, string desc, DateTime dt, TimeSpan tm, Address addr, string forecast)
        : base(title, desc, dt, tm, addr)
    {
        weatherForecast = forecast;
    }

    public override string GetFullDetails()
    {
        return base.GetFullDetails() + Environment.NewLine +
               "Type: Outdoor Gathering" + Environment.NewLine +
               "Weather Forecast: " + weatherForecast;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address
        {
            Street = "123 Main Street",
            City = "New York",
            State = "NY",
            Country = "USA"
        };

        DateTime date1 = new DateTime(2023, 7, 1);
        TimeSpan time1 = new TimeSpan(14, 0, 0);

        Lecture lecture = new Lecture("Lecture 1", "Introduction to Programming", date1, time1, address1, "John Smith", 100);

        Console.WriteLine("Lecture Marketing Messages:");
        Console.WriteLine("Standard Details:");
        Console.WriteLine(lecture.GetStandardDetails());

        Console.WriteLine("\nFull Details:");
        Console.WriteLine(lecture.GetFullDetails());

        Console.WriteLine("\nShort Description:");
        Console.WriteLine(lecture.GetShortDescription());

        Address address2 = new Address
        {
            Street = "456 Elm Street",
            City = "London",
            State = "London",
            Country = "UK"
        };

        DateTime date2 = new DateTime(2023, 7, 5);
        TimeSpan time2 = new TimeSpan(18, 30, 0);

        Reception reception = new Reception("Reception 1", "Networking Event", date2, time2, address2, "rsvp@example.com");

        Console.WriteLine("\nReception Marketing Messages:");
        Console.WriteLine("Standard Details:");
        Console.WriteLine(reception.GetStandardDetails());

        Console.WriteLine("\nFull Details:");
        Console.WriteLine(reception.GetFullDetails());

        Console.WriteLine("\nShort Description:");
        Console.WriteLine(reception.GetShortDescription());

        Address address3 = new Address
        {
            Street = "789 Oak Street",
            City = "Los Angeles",
            State = "CA",
            Country = "USA"
        };

        DateTime date3 = new DateTime(2023, 7, 10);
        TimeSpan time3 = new TimeSpan(12, 0, 0);

        OutdoorGathering outdoorGathering = new OutdoorGathering("Gathering 1", "Summer Picnic", date3, time3, address3, "Sunny");

        Console.WriteLine("\nOutdoor Gathering Marketing Messages:");
        Console.WriteLine("Standard Details:");
        Console.WriteLine(outdoorGathering.GetStandardDetails());

        Console.WriteLine("\nFull Details:");
        Console.WriteLine(outdoorGathering.GetFullDetails());

        Console.WriteLine("\nShort Description:");
        Console.WriteLine(outdoorGathering.GetShortDescription());

        Console.ReadLine();
    }
}
