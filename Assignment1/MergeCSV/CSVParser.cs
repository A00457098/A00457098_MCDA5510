using CsvHelper;
using CsvHelper.Configuration;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace MergeCsvFiles
{

    public class CSVParser
    {
        private static int skippedRecordCount = 0;
        /// <summary>
        /// Parses the CSV File
        /// </summary>
        /// <param name="fileName"></param>
        public List<HeaderInfo> Parse(string fileName)
        {

            
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                PrepareHeaderForMatch = args => args.Header.Replace(" ", ""),
                MissingFieldFound = null,
                HeaderValidated = null
            };

            using (var reader = new StreamReader(fileName))
            using (var csv = new CsvReader(reader, config))
            {
                var headerLength = csv.Context.Reader.HeaderRecord?.Length;
                config.ShouldSkipRecord = record => record.Record.Length != headerLength;
               
                return csv.GetRecords<HeaderInfo>().ToList();
            }

        }
    }
}
