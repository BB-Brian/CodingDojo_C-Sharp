using System;

namespace fundamentals_i
{
    class Program
    {
        // //print all values from 1-255
        static void printAllVals()
        {
            for(int i = 1; i<=255; i++)
            {
                System.Console.WriteLine(i);
            }
        }

        // // Create a new loop that prints all values from 1-100 that are divisible by 3 or 5, but not both
        static void printDivisibleThreeOrFive()
        {
            for(int i = 1; i <= 100; i++)
            {
                if((i % 3 == 0) && (i % 5 != 0) || (i % 5 == 0) && (i % 3 != 0))
                {
                    System.Console.WriteLine(i);
                }
            }
        }

        // // Modify the previous loop to print "Fizz" for multiples of 3, "Buzz" for multiples of 5, and "FizzBuzz" for numbers that are multiples of both 3 and 5
        static void FizzBuzz()
        {
            for(int i = 0; i < 100; i++)
            {
                if((i % 3 == 0) && (i % 5 != 0))
                {
                    System.Console.WriteLine("Fizz");
                }
                if((i % 5 == 0) && (i % 3 != 0))
                {
                    System.Console.WriteLine("Buzz");
                }
                if((i % 3 == 0) && (i % 5 == 0))
                {
                    System.Console.WriteLine("FizzBuzz");
                }
            }
        }


        static void Main(string[] args)
        {
            printAllVals();
            printDivisibleThreeOrFive();
            FizzBuzz();
            // Console.WriteLine("Hello World!");
        }
    }
}
