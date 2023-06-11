using System;

namespace FullNameGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("What is your first name? ");
            string firstName = Console.ReadLine();

            Console.Write("What is your last name? ");
            string lastName = Console.ReadLine();

            string fullName = $"{lastName}, {firstName} {lastName}";

            Console.WriteLine($"Your name is {fullName}.");

            Console.ReadLine();
        }
    }
}
