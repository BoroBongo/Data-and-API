using NUnit.Framework;
using System;
using ReadingCSVApp;

namespace UTestSerialising
{
    public class Tests
    {

        private static readonly string _path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CSVReader_WhenReadingCSVFile_ReturnTheCorrectNumberOfRows()
        {
            int length;
            string[][] csvRows = Program.csvReadFromFile($"{_path}/EmployeeRecords_Short.csv");
            Assert.That(length = csvRows.Length, Is.EqualTo(11));
        }
        
        [Test]
        public void CSVReader_WhenReadingCSVFile_ReturnTheCorrectNumberOfCollumns()
        {
            int length;
            string[][] csvRows = Program.csvReadFromFile($"{_path}/EmployeeRecords_Short.csv");
            Assert.That(length = csvRows[0].Length, Is.EqualTo(10));
        }
        
        [Test]
        public void CSVReader_WhenReadingCSVFile_ReturnTheCorrectCollumns_FirstRow()
        {
            string[][] csvRows = Program.csvReadFromFile($"{_path}/EmployeeRecords_Short.csv");
            Assert.That(csvRows[0], Is.EqualTo(new string[]{ "Emp ID", "Name Prefix", "First Name", "Middle Initial", "Last Name", "Gender", "E Mail", "Date of Birth", "Date of Joining", "Salary" }));
        }
        
        [Test]
        public void CSVReader_WhenReadingCSVFile_ReturnTheCorrectCollumns_LastRow()
        {
            string[][] csvRows = Program.csvReadFromFile($"{_path}/EmployeeRecords_Short.csv");
            Assert.That(csvRows[csvRows.Length-1], Is.EqualTo(new string[]{ "744723", "Hon.", "Bibi", "H", "Paddock", "F", "bibi.paddock@yahoo.co.in", "10/20/1991", "11/02/2016", "87148" }));
        }
    }
}

//check length of the _short file read