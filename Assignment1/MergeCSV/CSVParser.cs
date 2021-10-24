using CsvHelper;
using CsvHelper.Configuration;
using log4net;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;

namespace MergeCsvFiles
{
    /// <summary>
    /// This class Parses the CSV files and filters out the valid records to write to the output file
    /// It also keeps tracksof skipped bad records
    /// </summary>
    public class CSVParser
    {
        public static int skippedRecordCount = 0;
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Parses the CSV files and filters out the valid records
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public List<HeaderInfo> Parse(string fileName)
        {

            try
            {
                var goodRecords = new List<HeaderInfo>();

                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    PrepareHeaderForMatch = args => args.Header.Replace(" ", ""),

                    MissingFieldFound = x =>
                    {
                        skippedRecordCount++;
                    },
                    BadDataFound = context =>
                    {
                        skippedRecordCount++;
                    },
                };

                using (var reader = new StreamReader(fileName))
                using (var csv = new CsvReader(reader, config))
                {
                    var records = csv.Context.Reader.GetRecords<HeaderInfo>();
                    foreach (var rec in records)
                    {
                        //Checks if there are any fields with blank values
                        if (rec.GetType().GetProperties().Any(x => string.IsNullOrWhiteSpace((string)x.GetValue(rec))))
                        {
                            skippedRecordCount++;
                        }
                        else
                            goodRecords.Add(rec);
                    }

                    return goodRecords;
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<HeaderInfo>();
            }
        }
    }
}
