using System;
using SerialisationApp;

namespace ReadingCSVApp;

public class Program
{
    private static ISerialise _serialiser;
    private static List<Employees> _employees;
    //EmployeeRecords_Short.xlsx
    private static readonly string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
    public static void Main()
    {
        string[][] csvRows = csvReadFromFile($"{path}/EmployeeRecords_Short.csv");
        //Writing .csv
        StreamWriter sw = WriteToAFile(csvRows, $"{path}/CSVText.csv");

        //Company Sparta = new Company(GetListEmployees(csvRows));

        List<Employees> employees = GetEmployeeList(csvRows);

        _serialiser = new SerialiserJSON();
        Company Sparta = new Company(employees);
        _serialiser.SerialiseToFile($"{path}/JsonCompany.JSON", Sparta);
        Company Sparta1 = new Company(new List<Employees>() { GetEmployeeList(csvRows)[3] });
        _serialiser.SerialiseToFile($"{path}/JsonCompany2.JSON", Sparta1);

        //TO XML
        _serialiser = new SerialiserXML();
        try
        {
            _serialiser.SerialiseToFile($"{path}/JsonCompany.XML", Sparta);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }


        sw.Close();


    }

    public static string[][] csvReadFromFile(string path)
    {
        string[] csvContents = File.ReadAllLines(path);
        string[][] csvRows = new string[csvContents.Length][];
        for (int i = 0; i < csvRows.Length; i++)
        {
            csvRows[i] = new string[9];
        }
        foreach (var csv in csvContents.Select((value, index) => new { value, index }))
        {
            csvRows[csv.index] = csv.value.Split(",");
            //Console.WriteLine(csv.value);
        }

        return csvRows;
    }
    public static StreamWriter WriteToAFile(string[][] csvRows, string path)
    {
        StreamWriter sw = new StreamWriter(path);
        foreach (var row in csvRows)
        {
            foreach (string element in row)
            {
                sw.Write(element + ",");
            }
            sw.Write("\n");
        }

        return sw;
    }

    public static List<Employees> GetEmployeeList(string[][] csvRows)
    {
        List<Employees> employees = new List<Employees>();
        foreach (var element in csvRows.Select((value, index) => new { value, index }))
        {
            if (element.index != 0)
            {
                employees.Add(new Employees(element.value));
            }
        }
        return employees;
    }
}