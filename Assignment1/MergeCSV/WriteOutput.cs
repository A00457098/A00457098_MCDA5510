using CsvHelper;
using CsvHelper.Configuration;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace MergeCsvFiles
{
    public class WriteOutput
    {
        public void WriteToOutputFile(List<HeaderInfo> records)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                PrepareHeaderForMatch = args => args.Header.Replace(" ", "")
            };

            //Eliminates duplicate header record inclusion
            config.HasHeaderRecord = !File.Exists(Path.GetFullPath("../../../../Output/Output.csv"));

            using var writter = new StreamWriter(Path.GetFullPath("../../../../Output/Output.csv"), true);
            using var csvWriter = new CsvWriter(writter, config);
            {
                csvWriter.WriteRecords(records);
            }
        }
    }
}
