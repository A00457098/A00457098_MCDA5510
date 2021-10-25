using CsvHelper;
using CsvHelper.Configuration;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace MergeCsvFiles
{
    /// <summary>
    /// This class Writes output to csv file
    /// </summary>
    public class WriteOutput
    {
        private string outputFilePath = Path.GetFullPath("../../../../Output/Output.csv");
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="records">Records list of type headerInfo</param>
        public void WriteToOutputFile(List<HeaderInfo> records, string file)
        {
            OutputHeaderInfo outputInfo = new OutputHeaderInfo();
            List<OutputHeaderInfo> outputRecords = new List<OutputHeaderInfo>();
            foreach(var record in records)
            {
                outputInfo.City = record.City;
                outputInfo.Country = record.Country;
                outputInfo.emailAddress = record.emailAddress;
                outputInfo.FirstName = record.FirstName;
                outputInfo.LastName = record.LastName;
                outputInfo.PhoneNumber = record.PhoneNumber;
                outputInfo.PostalCode = record.PostalCode;
                outputInfo.Province = record.Province;
                outputInfo.Street = record.Street;
                outputInfo.StreetNumber = record.StreetNumber;
                outputInfo.Date = GetDateColumnValue(file);    
            }
            outputRecords.Add(outputInfo);

            var config = new CsvConfiguration(CultureInfo.InvariantCulture);

            //Eliminates duplicate header record inclusion
            config.HasHeaderRecord = !File.Exists(outputFilePath);

            using var writter = new StreamWriter(outputFilePath, true);
            using var csvWriter = new CsvWriter(writter, config);
            {
                csvWriter.WriteRecords(outputRecords);
            }
        }

        private string GetDateColumnValue(string file)
        {
            var dirs = Directory.EnumerateDirectories(file);
            DirectoryInfo dirInfo = new DirectoryInfo(file);
            var day = dirInfo.Parent.Name;
            var month = dirInfo.Parent.Parent.Name;
            var year = dirInfo.Parent.Parent.Parent.Name;

            return $"{year}/{month}/{day}";
        }
    }
}
