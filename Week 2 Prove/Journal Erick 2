using System;
using System.Collections.Generic;
using System.IO;

class JournalEntry
{
    public DateTime Date { get; set; }
    public string Prompt { get; set; }
    public string Response { get; set; }

    public JournalEntry(DateTime date, string prompt, string response)
    {
        Date = date;
        Prompt = prompt;
        Response = response;
    }

    public override string ToString()
    {
        return $"Date: {Date.ToString("yyyy-MM-dd")}\nPrompt: {Prompt}\nResponse: {Response}\n";
    }
}

class Journal
{
    private List<JournalEntry> entries;

    public Journal()
    {
        entries = new List<JournalEntry>();
    }

    public void AddEntry(JournalEntry entry)
    {
        entries.Add(entry);
    }

    public void DisplayEntries()
    {
        Console.WriteLine("Journal Entries:");
        foreach (var entry in entries)
        {
            Console.WriteLine(entry);
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var entry in entries)
            {
                writer.WriteLine(entry.Date.ToString("yyyy-MM-dd"));
                writer.WriteLine(entry.Prompt);
                writer.WriteLine(entry.Response);
            }
        }
        Console.WriteLine("Journal saved to file.");
    }

    public void LoadFromFile(string filename)
    {
        entries.Clear();
        try
        {
            using (StreamReader reader = new StreamReader(filename))
            {
                while (!reader.EndOfStream)
                {
                    string dateStr = reader.ReadLine();
                    string prompt = reader.ReadLine();
                    string response = reader.ReadLine();
                    DateTime date = DateTime.Parse(dateStr);
                    JournalEntry entry = new JournalEntry(date, prompt, response);
                    entries.Add(entry);
                }
            }
            Console.WriteLine("Journal loaded from file.");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("Journal App");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    WriteNewEntry(journal);
                    break;
                case "2":
                    journal.DisplayEntries();
                    break;
                case "3":
                    SaveJournalToFile(journal);
                    break;
                case "4":
                    LoadJournalFromFile(journal);
                    break;
                case "5":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine();
        }
    }

    static void WriteNewEntry(Journal journal)
    {
        Random random = new Random();
        string[] prompts = {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };
        string prompt = prompts[random.Next(prompts.Length)];

        Console.WriteLine($"Prompt
        Console.WriteLine($"Prompt: {prompt}");
        Console.Write("Enter your response: ");
        string response = Console.ReadLine();
        DateTime currentDate = DateTime.Now;

        JournalEntry entry = new JournalEntry(currentDate, prompt, response);
        journal.AddEntry(entry);

        Console.WriteLine("Entry added to the journal.");
    }

    static void SaveJournalToFile(Journal journal)
    {
        Console.Write("Enter the filename to save the journal: ");
        string filename = Console.ReadLine();
        journal.SaveToFile(filename);
    }

    static void LoadJournalFromFile(Journal journal)
    {
        Console.Write("Enter the filename to load the journal: ");
        string filename = Console.ReadLine();
        journal.LoadFromFile(filename);
    }
}
