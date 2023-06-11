using System;

namespace SimpleFunctions
{
    class Program
    {
        static void Main(string[] args)
        {
            DisplayWelcome();

            string name = PromptUserName();
            int number = PromptUserNumber();

            int squaredNumber = SquareNumber(number);

            DisplayResult(name, squaredNumber);

            Console.ReadLine();
        }

        static void DisplayWelcome()
        {
            Console.WriteLine("Welcome to the program!");
        }

        static string PromptUserName()
        {
            Console.Write("Please enter your name: ");
            string name = Console.ReadLine();
            return name;
        }

        static int PromptUserNumber()
        {
            Console.Write("Please enter your favorite number: ");
            int number = Convert.ToInt32(Console.ReadLine());
            return number;
        }

        static int SquareNumber(int number)
        {
            int squaredNumber = number * number;
            return squaredNumber;
        }

        static void DisplayResult(string name, int squaredNumber)
        {
            Console.WriteLine($"{name}, the square of your number is {squaredNumber}");
        }
    }
}
