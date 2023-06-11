using System;

namespace NumberGuessingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int magicNumber = 6;
            int guess;

            do
            {
                Console.Write("What is the magic number? ");
                magicNumber = Convert.ToInt32(Console.ReadLine());

                Console.Write("What is your guess? ");
                guess = Convert.ToInt32(Console.ReadLine());

                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher\n");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower\n");
                }
                else
                {
                    Console.WriteLine("You guessed it!\n");
                }
            }
            while (guess != magicNumber);

            Console.ReadLine();
        }
    }
}
