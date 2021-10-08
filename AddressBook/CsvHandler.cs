using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Globalization;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;

namespace AddressBook
{
    class CsvHandler
    {
        public const string ADDRESS = @"D:/Bridgelabz lecture/Dot net/Day 9 C# AddressBook/AddressBook/Addresses.csv";
        public const string EXPORT = @"D:/Bridgelabz lecture/Dot net/Day 9 C# AddressBook/AddressBook/Export.csv";
        public void ImplementCSVDataHandling()
        {
            ReadCsv();
            WriteCsv();
        }
        public void WriteCsv()
        {
            var records = new List<AddressData> { 
                new AddressData{ Firstname="Kalpesh", Lastname="Chindarkar", Address="Sewri",
                    City="Mumbai", State="Maharashtra", Email="kalpesh@gmail.com",
                    zipNo="400015", Phonenumber="9920036999" },
                new AddressData
                {
                    Firstname="Luffy", Lastname="Monkey", Address="Grey Terminal",
                    City="GoaKingdom", State="GoaKingdom", Email="luffyDmonkey@gmail.com",
                    zipNo="100015", Phonenumber="2220036999"
                }
            };
            using (var writer = new StreamWriter(EXPORT))
            using (var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csvWriter.WriteRecord(records);
            }
        }
        public void ReadCsv()
        {
            using (var reader = new StreamReader(ADDRESS))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<AddressData>().ToList();
                Console.WriteLine("Read data Successfully from Addresses.csv");
                foreach (AddressData c in records)
                {
                    Console.Write(c.Firstname+"\t"+c.Lastname+"\t"+c.City + "\n");
                }
                Console.WriteLine("*********Reading completed*********");
            }
        }
    }
}
