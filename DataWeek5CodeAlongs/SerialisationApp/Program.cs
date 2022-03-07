using System;

namespace SerialisationApp;

public class Program
{
    private static readonly string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
    public static void Main()
    {
        Trainee trainee = new Trainee() { FirstName = "Adam", LastName = "Kolaczynski", SpartaNo=1001 };
        SerialiserBinary sB = new SerialiserBinary();
        sB.SerialiseToFile($"{path}/BinaryTrainee.bin", trainee);

        Trainee deserialised = sB.DeserialiseFromFile<Trainee>($"{path}/BinaryTrainee.bin");
        Console.WriteLine(deserialised);
    }
}
