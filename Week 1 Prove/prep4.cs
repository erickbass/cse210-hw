using System;
using System.Collections.Generic;
using System.Linq;

namespace NumberStatistics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();

            Console.WriteLine("Enter a list of numbers, type 0 when finished.");

            int number;
            do
            {
                Console.Write("Enter number: ");
                number = Convert.ToInt32(Console.ReadLine());
                if (number != 0)
                {
                    numbers.Add(number);
                }
            }
            while (number != 0);

            int sum = numbers.Sum();
            double average = numbers.Average();
            int max = numbers.Max();

            Console.WriteLine("The sum is: " + sum);
            Console.WriteLine("The average is: " + average);
            Console.WriteLine("The largest number is: " + max);

            Console.ReadLine();
        }
    }
}
