using System;
using System.Collections.Generic;

namespace boxing_unboxing
{
    class Program
    {
        static void Main(string[] args)
        {
            List<object> SuperList = new List<object>();
            SuperList.Add(7);
            SuperList.Add(28);
            SuperList.Add(-1);
            SuperList.Add(true);
            SuperList.Add("chair");

            int Sum = 0;
            for(int idx = 0; idx < SuperList.Count; idx++)
            {
                System.Console.WriteLine(SuperList[idx]);
                if(SuperList[idx] is int)
                {
                    Sum += (int)SuperList[idx];
                }
            }
            System.Console.WriteLine("The sum of all the integers in the list is: " + Sum);
        }
    }
}
