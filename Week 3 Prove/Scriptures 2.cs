using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create a list of scriptures
        List<Scripture> scriptures = new List<Scripture>();

        // Add your desired scriptures to the list
        scriptures.Add(new Scripture("John 3:16", "For God so loved the world, that he gave his only Son..."));
        scriptures.Add(new Scripture("Proverbs 3:5-6", "Trust in the LORD with all your heart..."));

        // Select a random scripture from the list
        Random random = new Random();
        Scripture currentScripture = scriptures[random.Next(0, scriptures.Count)];

        // Display the complete scripture
        Console.WriteLine($"{currentScripture.Reference}: {currentScripture.Text}");

        // Prompt the user to press enter or type quit
        Console.WriteLine("Press enter to continue or type 'quit' to exit.");
        string input = Console.ReadLine();

        // Continue hiding words until all words are hidden or the user types quit
        while (input != "quit" && !currentScripture.AllWordsHidden())
        {
            Console.Clear();
            currentScripture.HideRandomWord();
            Console.WriteLine($"{currentScripture.Reference}: {currentScripture.GetHiddenText()}");

            Console.WriteLine("Press enter to continue or type 'quit' to exit.");
            input = Console.ReadLine();
        }
    }
}

class Scripture
{
    public string Reference { get; }
    private List<string> words;
    private List<bool> hiddenFlags;

    public Scripture(string reference, string text)
    {
        Reference = reference;
        words = new List<string>(text.Split(' '));
        hiddenFlags = new List<bool>(new bool[words.Count]);
    }

    public bool AllWordsHidden()
    {
        foreach (bool flag in hiddenFlags)
        {
            if (!flag)
                return false;
        }
        return true;
    }

    public void HideRandomWord()
    {
        Random random = new Random();
        int index = random.Next(0, words.Count);

        if (!hiddenFlags[index])
            hiddenFlags[index] = true;
    }

    public string GetHiddenText()
    {
        string hiddenText = "";
        for (int i = 0; i < words.Count; i++)
        {
            if (hiddenFlags[i])
                hiddenText += "***** ";
            else
                hiddenText += words[i] + " ";
        }
        return hiddenText.Trim();
    }
}
