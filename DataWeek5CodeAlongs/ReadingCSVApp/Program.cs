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
            StreamWriter sw = new StreamWriter($"{path}/CSVText.txt");
        _serialiser = new SerialiserJSON();
        try
        {
            string[] csvContents = File.ReadAllLines($"{path}/EmployeeRecords_Short.csv");
            string[][] csvRows = new string[csvContents.Length][];
            for(int i = 0; i < csvRows.Length; i++)
            {
                csvRows[i] = new string[9];
            }
            foreach(var csv in csvContents.Select((value, index) => new { value, index }))
            {
                csvRows[csv.index] = csv.value.Split(",");
                //Console.WriteLine(csv.value);
            }
            foreach(var row in csvRows)
            {
                foreach(string element in row)
                {
                    sw.Write(element+" ");
                }
                sw.Write("\n");
            }

            foreach(var element in csvRows)
            {
                _employees.Add(new Employees(element));
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            sw.Close();
        }
    }
}