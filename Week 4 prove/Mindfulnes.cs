using System;
using System.Threading;

namespace MindfulnessApp
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Mindfulness App");
                Console.WriteLine("1. Breathing Activity");
                Console.WriteLine("2. Reflection Activity");
                Console.WriteLine("3. Listing Activity");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();
                Console.Clear();

                if (choice == "1")
                {
                    BreathingActivity breathingActivity = new BreathingActivity();
                    breathingActivity.Start();
                }
                else if (choice == "2")
                {
                    ReflectionActivity reflectionActivity = new ReflectionActivity();
                    reflectionActivity.Start();
                }
                else if (choice == "3")
                {
                    ListingActivity listingActivity = new ListingActivity();
                    listingActivity.Start();
                }
                else if (choice == "4")
                {
                    break;
                }

                Console.Clear();
            }
        }
    }

    abstract class MindfulnessActivity
    {
        protected int duration;

        protected void DisplayStartingMessage(string activityName, string description)
        {
            Console.WriteLine(activityName);
            Console.WriteLine(description);
            Console.Write("Enter the duration (in seconds): ");
            duration = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Prepare to begin...");
            Thread.Sleep(3000);
        }

        protected void DisplayFinishingMessage(string activityName)
        {
            Console.WriteLine("Good job! You have completed the {0}.", activityName);
            Console.WriteLine("Duration: {0} seconds", duration);
            Thread.Sleep(3000);
        }
    }

    class BreathingActivity : MindfulnessActivity
    {
        public void Start()
        {
            DisplayStartingMessage("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.");

            Console.Clear();
            Console.WriteLine("Breathing in...");
            Thread.Sleep(2000);

            for (int i = 0; i < duration; i += 2)
            {
                Console.Clear();
                Console.WriteLine("Breathing in...");
                Thread.Sleep(1000);

                Console.Clear();
                Console.WriteLine("Breathe out...");
                Thread.Sleep(1000);
            }

            DisplayFinishingMessage("Breathing Activity");
        }
    }

    class ReflectionActivity : MindfulnessActivity
    {
        private string[] prompts = {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        private string[] questions = {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        private Random random = new Random();

        public void Start()
        {
            DisplayStarting
Message("Reflection Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");

            Console.Clear();
            string prompt = GetRandomPrompt();

            Console.WriteLine(prompt);
            Thread.Sleep(2000);

            foreach (string question in questions)
            {
                Console.Clear();
                Console.WriteLine(prompt);
                Console.WriteLine();

                Console.WriteLine("Question:");
                Console.WriteLine(question);
                Thread.Sleep(2000);

                Console.WriteLine("Spinner...");
                Thread.Sleep(2000);
            }

            DisplayFinishingMessage("Reflection Activity");
        }

        private string GetRandomPrompt()
        {
            int index = random.Next(prompts.Length);
            return prompts[index];
        }
    }

    class ListingActivity : MindfulnessActivity
    {
        private string[] prompts = {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        private Random random = new Random();

        public void Start()
        {
            DisplayStartingMessage("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");

            Console.Clear();
            string prompt = GetRandomPrompt();

            Console.WriteLine(prompt);
            Thread.Sleep(2000);

            Console.WriteLine("Get ready to start listing...");
            Thread.Sleep(3000);

            Console.Clear();
            Console.WriteLine("Start listing...");

            int itemCount = 0;
            DateTime endTime = DateTime.Now.AddSeconds(duration);

            while (DateTime.Now < endTime)
            {
                string item = Console.ReadLine();
                itemCount++;
            }

            Console.Clear();
            Console.WriteLine("You listed {0} items.", itemCount);
            Thread.Sleep(3000);

            DisplayFinishingMessage("Listing Activity");
        }

        private string GetRandomPrompt()
        {
            int index = random.Next(prompts.Length);
            return prompts[index];
        }
    }
}
