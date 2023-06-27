using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Scripture scripture = new Scripture("John 3:16", "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.");
        MemorizationTool tool = new MemorizationTool(scripture);

        while (true)
        {
            Console.Clear();
            tool.DisplayScripture();

            Console.WriteLine("Press Enter to continue or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
                break;

            tool.HideRandomWord();
        }
    }
}

class Scripture
{
    public string Reference { get; }
    public string Text { get; }

    public Scripture(string reference, string text)
    {
        Reference = reference;
        Text = text;
    }
}

class MemorizationTool
{
    private Scripture scripture;
    private List<string> hiddenWords = new List<string>();
    private Random random = new Random();

    public MemorizationTool(Scripture scripture)
    {
        this.scripture = scripture;
    }

    public void DisplayScripture()
    {
        Console.WriteLine($"Reference: {scripture.Reference}");
        Console.WriteLine();

        string[] words = scripture.Text.Split(' ');

        for (int i = 0; i < words.Length; i++)
        {
            if (hiddenWords.Contains(words[i]))
                Console.Write("____ ");
            else
                Console.Write($"{words[i]} ");
        }

        Console.WriteLine();
    }

    public void HideRandomWord()
    {
        string[] words = scripture.Text.Split(' ');
        List<string> visibleWords = new List<string>();

        foreach (string word in words)
        {
            if (!hiddenWords.Contains(word))
                visibleWords.Add(word);
        }

        if (visibleWords.Count == 0)
            return;

        int index = random.Next(visibleWords.Count);
        hiddenWords.Add(visibleWords[index]);
    }
}
