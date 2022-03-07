using System;

namespace SerialisationApp;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Hello, world!");
        Trainee trainee = new Trainee() { FirstName = "Adam", LastName = "Kolaczynski" };
        Console.WriteLine(trainee);
        Console.WriteLine(trainee.FirstName + " " + trainee.LastName);
        Console.WriteLine(trainee.FullName);
        Console.WriteLine(trainee.FullName);
        Trainee trainee2 = new Trainee();
        Console.WriteLine(trainee2.FullName);

    }
}