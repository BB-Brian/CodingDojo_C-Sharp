using System;
using System.Collections.Generic;

namespace basic13
{
    class Program
    {
        // Print 1-255
        // Print all the numbers from 1 to 255.
        public static void PrintNums()
        {
            System.Console.WriteLine("\nResult for PrintNums function:");
            for(int i = 0; i <= 255; i++)
            {
                System.Console.WriteLine(i);
            }

        }

        // Print odd numbers between 1-255
        // Print all the odd numbers from 1 to 255.
        public static void PrintOdds()
        {
            System.Console.WriteLine("\nResult for WriteLine function:");
            for(int i = 0; i <= 255; i++)
            {
                if(i % 2 != 0)
                {
                    System.Console.WriteLine(i);
                }
            }
        }

        // Print Sum
        // Print the numbers from 0 to 255, but this time, also print the sum of the numbers that have been printed so far. For example, your output should be something like this:
        // New number: 0 Sum: 0
        // New number: 1 Sum: 1
        // New Number: 2 Sum: 3
        // New number: 3 Sum: 6
        // New Number: 255 Sum: ___.
        // Do NOT use an array to do this exercise.
        public static void PrintSum()
        {
            System.Console.WriteLine("\nResult for PrintSum function:");
            int Sum = 0;
            for(int i = 0; i <= 255; i++)
            {
                Sum += i;
                System.Console.WriteLine("New number: {0} Sum {1}",i,Sum);
            }
        }
        
        // Iterating through an Array
        // Given an array X, say [1,3,5,7,9,13], write a function that would iterate through each member of the array and print each value on the screen. Being able to loop through each member of the array is extremely important.

        public static void IterateArray(int[] arr)
        { 
            System.Console.WriteLine("\nResult for IterateArray function:");
            for(int idx = 0; idx < arr.Length; idx++)
            {
                System.Console.WriteLine(arr[idx]);
            }
        }

        // Find Max
        // Write a function that takes any array and prints the maximum value in the array. Your program should also work with a given array that has all negative numbers (e.g. [-3, -5, -7]), or even a mix of positive numbers, negative numbers and zero.
        public static void FindMax(int[] arr)
        {
            System.Console.WriteLine("\nResult for FindMax function:");
            int maxNum = arr[0];
            for(int idx = 0; idx < arr.Length; idx++)
            {
                if(arr[idx] > maxNum)
                {
                    maxNum = arr[idx];
                }
            }
            System.Console.WriteLine("Max num in array is: " + maxNum);
        }

        //Get Average
        // Write a function that takes an array and prints the AVERAGE of the values in the array. For example, for an array [2, 10, 3], your program should print an average of 5. Again, make sure you come up with a simple base case and write instructions to solve that base case first, then test your instructions for other complicated cases. You can use a count function with this assignment.
        public static void GetAvg(int[] arr)
        {
            System.Console.WriteLine("\nResult for GetAvg function:");
            int Sum = 0;
            // foreach(int item in arr)
            // {
            //     Sum += item;
            // }
            for(int idx = 0; idx < arr.Length; idx++)
                {
                    Sum += arr[idx];
                }
            System.Console.WriteLine("The average of the integers in the array is: " + Sum/arr.Length);        
        }  

        //Array with Odd Numbers
        // Write a function that creates an array 'y' that contains all the odd numbers between 1 to 255. When the program is done, 'y' should have the value of [1, 3, 5, 7, ... 255].
        public static void OddNums()
        {
            System.Console.WriteLine("\nResult for OddNums function:");
            int idx = 0;
            int[] y = new int[256/2]; 
            for(int i = 1; i < 256; i++)
            {
                if(i % 2 != 0)
                {
                    y[idx] = i;
                    System.Console.WriteLine(y[idx]);
                    idx++;
                }
            }
            
        }

        // Greater than Y
        // Write a function that takes an array and returns the number of values in that array whose value is greater than a given value y. For example, if array = [1, 3, 5, 7] and y = 3. After your program is run it will return 2 (since there are two values in the array that are greater than 3).
        public static void GreaterThanY(int[] arr, int y)
        {
            System.Console.WriteLine("\nResult for GreaterThanY function:");
            int count = 0;
            for(int idx = 0; idx < arr.Length; idx++)
            {
                if(arr[idx] > y)
                {
                    count++;
                }
            }
            System.Console.WriteLine("The number of values greater than y is: " + count);
        }

        // Square the Values
        // Given any array x, say [1, 5, 10, -2], create a function that multiplies each value in the array by itself. When the program is done, the array x should have values that have been squared, say [1, 25, 100, 4].
        public static void SquaredArray(int[] arr)
        {
            System.Console.WriteLine("\nResult for SquaredArray function:");
            for(int idx = 0; idx < arr.Length; idx++)
            {
                arr[idx] *= arr[idx];
                System.Console.WriteLine(arr[idx]);
            }
        }

        //Eliminate Negative Numbers
        // Given any array x, say [1, 5, 10, -2], create a function that replaces any negative number with the value of 0. When the program is done, x should have no negative values, say [1, 5, 10, 0].
        public static void NoNegatives(int[] arr)
        {
            System.Console.WriteLine("\nResult for NoNegatives function:");
            for(int idx = 0; idx < arr.Length; idx++)
            {
                if(arr[idx] < 0)
                {
                    arr[idx] = 0;
                }
            System.Console.WriteLine(arr[idx]);
            }
        }

        //Min, Max, and Average
        // Given any array x, say [1, 5, 10, -2], create a function that prints the maximum number in the array, the minimum value in the array, and the average of the values in the array.
        public static void MaxMinAvg(int[] arr)
        {
            System.Console.WriteLine("\nResult for MaxMinAvg function:");
            int Min = 0;
            int Max = 0;
            int Sum = 0;
            int Avg = 0;
            for(int idx = 0; idx < arr.Length; idx++)
            {
                if(arr[idx] > Max)
                {
                    Max = arr[idx];
                }
                if(arr[idx] < Min)
                {
                    Min = arr[idx];
                }
                Sum += arr[idx];
                Avg = Sum/arr.Length;
            }
            System.Console.WriteLine("The max value is: " + Max);
            System.Console.WriteLine("The min value is: " + Min);
            System.Console.WriteLine("The avg value is: " + Avg);
        }

        // Shifting the values in an array
        // Given any array x, say [1, 5, 10, 7, -2], create a function that shifts each number by one to the front and adds '0' to the end. For example, when the program is done,  if the array [1, 5, 10, 7, -2] is passed to the function, it should become [5, 10, 7, -2, 0].
        public static void ShiftLeft(int[] arr)
        {
            System.Console.WriteLine("\nResult for ShiftLeft function:");
            for(int idx = 0; idx < arr.Length; idx++)
            {
                if(idx != arr.Length-1)
                {
                    arr[idx] = arr[idx+1];
                }
                else
                {
                    arr[idx] = 0;
                }
            }
            foreach(int item in arr)
            {
                System.Console.WriteLine(item);
            }
        }

        // Number to String
        // Write a function that takes an array of numbers and replaces any negative number with the string 'Dojo'. For example, if array x is initially [-1, -3, 2] your function should return an array with values ['Dojo', 'Dojo', 2].
        public static List<object> NumToString(int[] arr)
        {
            System.Console.WriteLine("\nResult for NumToString function:");
            List<object> NumStringList = new List<object>();
            for(var idx = 0; idx < arr.Length; idx++)
            {
                if(arr[idx] < 0)
                {
                    NumStringList.Add("Dojo");
                }
                else
                {
                    NumStringList.Add(arr[idx]);
                }
                System.Console.WriteLine(NumStringList[idx]);
            }
            return NumStringList;
        }

        static void Main(string[] args)
        {            
            // Print 1-255
            PrintNums();

            // Print odd numbers between 1-255
            PrintOdds();

            // Print Sum
            PrintSum();

            // Iterating through an Array
            int[] IterateThroughArr = {1,3,5,7,9,13};
            IterateArray(IterateThroughArr);

            // Find Max
            int[] FindMaxArr = {3,5,7};
            int[] FindMaxNegArr = {-3,-5,-7};
            int[] FindMaxMixedArr = {0,-5,7};
            FindMax(FindMaxArr);
            
            // Get Average
            int[] AvgArr = {2, 10, 3};
            GetAvg(AvgArr);

            // Array with Odd Numbers
            OddNums();

            // Greater than Y
            int[] GreaterYArr = {1,3,5,7};
            int y = 3;
            GreaterThanY(GreaterYArr, y);

            // Square the Values
            int[] SquaredArr = {1,5,10,-2};
            SquaredArray(SquaredArr);

            // Eliminate Negative Numbers
            int[] NoNegArr = {1,5,10,-2};
            NoNegatives(NoNegArr);

            // Min, Max, and Average
            int[] MaxMinAvgArr = {1,5,10,-2};
            MaxMinAvg(MaxMinAvgArr);

            // Shifting the values in an array
            int[] ShiftArr = {1,5,10,7,-2};
            ShiftLeft(ShiftArr);

            // Number to String
            int[] NumStringArr = {-1,-3,2};
            NumToString(NumStringArr);
           
        }
    }
}
