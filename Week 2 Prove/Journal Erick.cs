using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        Journal journal = new Journal();

        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Show the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");

            int option = ReadIntInput();

            switch (option)
            {
                case 1:
                    journal.WriteNewEntry();
                    break;
                case 2:
                    journal.ShowJournal();
                    break;
                case 3:
                    journal.SaveJournalToFile();
                    break;
                case 4:
                    journal.LoadJournalFromFile();
                    break;
                case 5:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }

            Console.WriteLine();
        }
    }

    static int ReadIntInput()
    {
        int input;
        while (!int.TryParse(Console.ReadLine(), out input))
        {
            Console.WriteLine("Invalid input. Please try again.");
        }
        return input;
    }
}

class JournalEntry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Date { get; set; }

    public JournalEntry(string prompt, string response, string date)
    {
        Prompt = prompt;
        Response = response;
        Date = date;
    }

    public override string ToString()
    {
        return $"[{Date}] {Prompt}: {Response}";
    }
}

class Journal
{
    private List<JournalEntry> entries = new List<JournalEntry>();
    private Random random = new Random();
    private string currentFile;

    public void WriteNewEntry()
    {
        string prompt = GetRandomPrompt();
        Console.WriteLine("Prompt: " + prompt);
        Console.WriteLine("Enter your response:");
        string response = Console.ReadLine();
        string date = DateTime.Now.ToString();

        JournalEntry entry = new JournalEntry(prompt, response, date);
        entries.Add(entry);
    }

    public void ShowJournal()
    {
        Console.WriteLine("Journal:");

        if (entries.Count == 0)
        {
            Console.WriteLine("No entries in the journal.");
        }
        else
        {
            foreach (var entry in entries)
            {
                Console.WriteLine(entry);
            }
        }
    }

    public void SaveJournalToFile()
    {
        Console.WriteLine("Enter the file name:");
        string fileName = Console.ReadLine();

        try
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach (var entry in entries)
                {
                    writer.WriteLine($"{entry.Prompt},{entry.Response},{entry.Date}");
                }
            }

            currentFile = fileName;
            Console.WriteLine("Journal saved successfully to the file.");
        }
        catch (IOException e)
        {
            Console.WriteLine("Error saving the journal to the file: " + e.Message);
        }
    }

    public void LoadJournalFromFile()
    {
        Console.WriteLine("Enter the file name:");
        string fileName = Console.ReadLine();

        try
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                entries.Clear();

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 3)
                    {
                        JournalEntry entry = new JournalEntry(parts[0], parts[1], parts[2]);
                        entries.Add(entry);
                    }
                }
            }

