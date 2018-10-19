using System;
using System.Collections.Generic;

namespace collections_practice
{
    class Program
    {
        static void Main(string[] args)
        {
            // // THREE BASIC ARRAYS
            // // Create an array to hold integer values 0 through 9
            int[] intArr = new int[10];
            for(int i = 0; i < intArr.Length; i++)
            {
                intArr[i] = i;
            }

            foreach(int item in intArr)
            {
                System.Console.WriteLine(item);
            }

            // // // Create an array of the names "Tim", "Martin", "Nikki", & "Sara"
            string[] nameArr = {"Tim", "Martin", "Nikki", "Sara"};
            
            foreach(string strItem in nameArr)
            {
                System.Console.WriteLine(strItem);
            }        

            // // Create an array of length 10 that alternates between true and false values, starting with true
            bool[] boolArr = new bool[10];
            for (int i = 0; i < boolArr.Length; i++)
            {
                if (i % 2 == 0)
                {
                    boolArr[i] = true;
                }
                else
                {
                    boolArr[i] = false;
                }
            }
            foreach(bool boolItem in boolArr)
                {
                    System.Console.WriteLine(boolItem);
                }

            // LIST OF FLAVORS
            // Create a list of Ice Cream flavors that holds at least 5 different flavors
            List<string> iceCream = new List<string>();
            iceCream.Add("Strawberry");
            iceCream.Add("Chocolate");
            iceCream.Add("Vanilla");
            iceCream.Add("Blueberry");
            iceCream.Add("Cheese");

            foreach(string iceItem in iceCream)
            {
                System.Console.WriteLine(iceItem);
            }

            // Output the length of this list after building it
            System.Console.WriteLine("List length is: " + iceCream.Count);     


            // Output the third flavor in the list, then remove this value.
            System.Console.WriteLine("The Third flavor in list is: {0}", iceCream[2]);
            iceCream.RemoveAt(2);

            // Output the new length of the list (Note it should just be one less~)
            System.Console.WriteLine("List length is: " + iceCream.Count);
        

            // USER INFO DICTIONARY
            // Create a Dictionary that will store both string keys as well as string values  
            Dictionary<string,string> profile = new Dictionary<string,string>();

            // For each name in the array of names you made previously, add it as a new key in this dictionary with value null
            for(int idx = 0; idx < nameArr.Length; idx++)
            {
                profile.Add(nameArr[idx], null);
            }

            foreach(KeyValuePair<string,string> entry in profile)
            {
                System.Console.WriteLine(entry.Key + " - " + entry.Value);
            }
            
            // For each name key, select a random flavor from the flavor list above and store it as the value
            for(int idx = 0; idx < nameArr.Length; idx++)
            {
                int iceCreamIdx = new Random().Next(iceCream.Count);
                profile[nameArr[idx]] = iceCream[iceCreamIdx];
            }

            // Loop through the Dictionary and print out each user's name and their associated ice cream flavor.
            foreach(KeyValuePair<string,string> entry in profile)
            {
                System.Console.WriteLine(entry.Key + " - " + entry.Value);
            }
        }
    }
}
