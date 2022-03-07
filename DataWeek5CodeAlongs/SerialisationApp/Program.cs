﻿using System;

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

        _serialiser = new SerialiserXML();
        _serialiser.SerialiseToFile($"{path}/BinaryTrainee.XML", trainee);

        Trainee deserialised2 = _serialiser.DeserialiseFromFile<Trainee>($"{path}/BinaryTrainee.XML");
        Console.WriteLine(deserialised2);

        _serialiser = new SerialiserJSON();
        _serialiser.SerialiseToFile($"{path}/BinaryTrainee.JSON", trainee);

        Trainee deserialised3 = _serialiser.DeserialiseFromFile<Trainee>($"{path}/BinaryTrainee.JSON");
        Console.WriteLine(deserialised3);
    }
}
