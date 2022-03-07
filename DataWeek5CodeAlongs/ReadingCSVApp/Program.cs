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
            string[] csvContents = File.ReadAllLines($"{path}/EmployeeRecords_Short.csv");
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
            //Writing .csv
            StreamWriter sw = new StreamWriter($"{path}/CSVText.csv");
            foreach (var row in csvRows)
            {
                foreach (string element in row)
                {
                    sw.Write(element + ",");
                }
                sw.Write("\n");
            }

            //Company Sparta = new Company(GetListEmployees(csvRows));
            _serialiser = new SerialiserJSON();
            Company Sparta = new Company(GetEmployeeList(csvRows));
            _serialiser.SerialiseToFile($"{path}/JsonCompany.JSON", Sparta);
        Company Sparta1 = new Company(new List<Employees>() { GetEmployeeList(csvRows)[3] });
            _serialiser.SerialiseToFile($"{path}/JsonCompany2.JSON", Sparta1);
        
        sw.Close();


    }

    private static List<Employees> GetEmployeeList(string[][] csvRows)
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