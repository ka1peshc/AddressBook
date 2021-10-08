using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using CsvHelper;
using Newtonsoft.Json;
using System.Globalization;
using System.Linq;

namespace AddressBook
{
    class CsvToJson
    {
        private string CsvFile = @"D:/Bridgelabz lecture/Dot net/Day 9 C# AddressBook/AddressBook/Addresses.csv";
        private string JSONFile = @"D:/Bridgelabz lecture/Dot net/Day 9 C# AddressBook/AddressBook/AddressJson.json";
        public void ImplementCsvtoJson()
        {
            using (var reader = new StreamReader(CsvFile))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<AddressData>().ToList();
                Console.WriteLine("Read data successfully");
                foreach(AddressData addressData in records)
                {
                    Console.Write(addressData.City + "\t");
                }
                Console.WriteLine("\n******Reading from csv file complete******");

                //Writing in json
                JsonSerializer serializer = new JsonSerializer();
                
                using (StreamWriter sw = new StreamWriter(JSONFile))
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, records);
                }

            }
        }
    }
}
