using System;

namespace SerialisationApp;

public class Program
{
    private static ISerialise _serialiser;
    private static readonly string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
    public static void Main()
    {
        Trainee trainee = new Trainee() { FirstName = "Adam", LastName = "Kolaczynski", SpartaNo=1001 };
        _serialiser = new SerialiserBinary();
        _serialiser.SerialiseToFile($"{path}/BinaryTrainee.bin", trainee);

        Trainee deserialised = _serialiser.DeserialiseFromFile<Trainee>($"{path}/BinaryTrainee.bin");
        Console.WriteLine(deserialised);
    }
}
