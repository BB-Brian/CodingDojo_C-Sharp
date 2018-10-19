using System;

namespace human
{
    class Program
    {
        static void Main(string[] args)
        {
            Human X = new Human("X");
            // System.Console.WriteLine(X.name);
            Human Y = new Human("Y");

            X.Attack(Y);
            X.Attack(Y);
            System.Console.WriteLine(Y.health);

            Y.Attack(X);
            System.Console.WriteLine(X.health);
        }
    }
}
