using System;
using System.Collections.Generic;

namespace puzzles
{
    public class Program
    {
        // Random Array
        // Create a function called RandomArray() that returns an integer array
        // Place 10 random integer values between 5-25 into the array
        // Print the min and max values of the array
        // Print the sum of all the values
        public static void RandomArray()
        {
            int[] randArr = new int[10];
            Random rand = new Random();
            for(int idx = 0; idx < 10; idx++)
            {
                randArr[idx] = rand.Next(5,25);
            }
            int sum = 0;
            int min = randArr[0];
            int max = randArr[0];
            for(int idx = 1; idx < randArr.Length; idx++)
            {
                sum += randArr[idx];
                if(randArr[idx] > max)
                {
                    max = randArr[idx];
                }
                if(randArr[idx] < min)
                {
                    max = randArr[idx];
                }
            }
            int avg = sum/randArr.Length;
            System.Console.WriteLine($"Max: {max}, Min: {min}, Average {avg}");
        }

        // Coin Flip
        // Create a function called TossCoin() that returns a string
        // Have the function print "Tossing a Coin!"
        // Randomize a coin toss with a result signaling either side of the coin 
        // Have the function print either "Heads" or "Tails"
        // Finally, return the result
        public static string TossCoin()
        {
            System.Console.WriteLine("Tossing a Coin!");
            Random rand = new Random();
            int coinToss = rand.Next(2);
            if(coinToss == 0)
            {
                System.Console.WriteLine("Heads");
                return("Heads");
            }
            else
            {
                System.Console.WriteLine("Tails");
                return("tails");
            }
        }

        // Create another function called TossMultipleCoins(int num) that returns a Double
        // Have the function call the tossCoin function multiple times based on num value
        // Have the function return a Double that reflects the ratio of head toss to total toss
        public static Double TossMultipleCoins(int num)
        {   
            int headCount = 0;
            int tailCount = 0;
            for(int i = 0; i < num; i++)
            {
                string toss = TossCoin();
                if(toss == "Heads")
                {
                    headCount++;
                }            
                else
                {
                    tailCount++;
                }            
            }
            System.Console.WriteLine($"Tail Count: {tailCount} Head Count: {headCount}");
            double tossRatio = (double)headCount/(double)num;
            System.Console.WriteLine($"Ratio of head toss to total toss: {tossRatio}");
            return tossRatio;
        }

        // Names
        // Build a function Names that returns an array of strings
        // Create an array with the values: Dragon, Robot, Unicorn, Mist, Seahorse
        // Shuffle the array and print the values in the new order
        // Return an array that only includes names longer than 5 characters
        public static string[] Names(string[] arr)
        {
            Random rand = new Random();
            for(int idx = 0; idx < arr.Length; idx++)
            {
                int randomIdx = rand.Next(0, arr.Length-1);
                string temp = arr[idx];
                arr[idx] = arr[randomIdx];
                arr[randomIdx] = temp;
            }

            for(int i = 0; i < arr.Length; i++)
            {
                if(arr[i].Length > 5)
                {
                    System.Console.WriteLine(arr[i]);
                }
            }
            return(arr);
        }

        static void Main(string[] args)
        {

            // Random Array
            RandomArray();

            // Coin Flip
            TossCoin();

            // Create another function called TossMultipleCoins(int num) that returns a Double
            TossMultipleCoins(5);

            // Names
            string[] namesArray = {"Dragon", "Robot", "Unicorn", "Mist","Seahorse"};
            Names(namesArray);
        }
    }
}