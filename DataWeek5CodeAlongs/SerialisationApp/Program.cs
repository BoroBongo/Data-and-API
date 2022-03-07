using System;

namespace SerialisationApp;

public class Program
{
    private static ISerialise _serialiser;
    private static readonly string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
    public static void Main()
    {
        Trainee trainee = new Trainee() { FirstName = "Adam", LastName = "Kolaczynski", SpartaNo=1001 };
        Trainee trainee2 = new Trainee() { FirstName = "James", LastName = "Bond", SpartaNo=007 };
        Trainee trainee3 = new Trainee() { FirstName = "Test", LastName = "Test", SpartaNo=9999 };
        _serialiser = new SerialiserBinary();
        _serialiser.SerialiseToFile($"{path}/BinaryTrainee.bin", trainee);

        Trainee deserialised = _serialiser.DeserialiseFromFile<Trainee>($"{path}/BinaryTrainee.bin");
        Console.WriteLine(deserialised);

        _serialiser = new SerialiserXML();
        _serialiser.SerialiseToFile($"{path}/BinaryTrainee.XML", trainee);

        Trainee deserialised2 = _serialiser.DeserialiseFromFile<Trainee>($"{path}/BinaryTrainee.XML");
        Console.WriteLine(deserialised2);

        _serialiser = new SerialiserJSON();
        _serialiser.SerialiseToFile($"{path}/BinaryTrainee.JSON", trainee);

        Trainee deserialised3 = _serialiser.DeserialiseFromFile<Trainee>($"{path}/BinaryTrainee.JSON");
        Console.WriteLine(deserialised3);

        Course eng105 = new Course
        {
            Title="Engineering 105",
            Subject="C# Dev/SRE",
            StartDate = new DateTime(2022,2,7)
        };
        eng105.AddTrainee(trainee);
        eng105.AddTrainee(trainee2);
        eng105.AddTrainee(trainee3);
        eng105.AddTrainee(new Trainee
        {
            FirstName="Test2",
            LastName="2Test",
            SpartaNo=444
        });
        
        _serialiser.SerialiseToFile($"{path}/JsonCourse.JSON", eng105);
        Course deserialisedCourse = _serialiser.DeserialiseFromFile<Course>($"{path}/JsonCourse.JSON");
        _serialiser = new SerialiserXML();
        _serialiser.SerialiseToFile($"{path}/XMLCourse.XML", eng105);
        Course deserialisedCourse2 = _serialiser.DeserialiseFromFile<Course>($"{path}/XMLCourse.XML");
        Console.WriteLine(deserialisedCourse);
        Console.WriteLine(deserialisedCourse2);

    }
}
