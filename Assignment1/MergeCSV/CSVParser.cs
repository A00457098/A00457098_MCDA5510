using CsvHelper;
using CsvHelper.Configuration;
using log4net;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace MergeCsvFiles
{
    /// <summary>
    /// This class Parses the CSV files and filters out the valid records to write to the output file
    /// It also keeps tracksof skipped bad records
    /// </summary>
    public class CSVParser
    {
        public static int skippedRecordCount = 0;
        private static readonly ILog logger = Logger.Instance.GetLogger();

        /// <summary>
        /// Parses the CSV files and filters out the valid records
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public List<HeaderInfo> Parse(string fileName)
        {
            var goodRecords = new List<HeaderInfo>();
            try
            {
                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    PrepareHeaderForMatch = args => args.Header.Replace(" ", ""),

                    MissingFieldFound = x =>
                    {
                        logger.Info($"Skipped record as Missing field found at {x.Index} in {fileName} ");
                        skippedRecordCount++;
                    },
                    BadDataFound = context =>
                    {
                        logger.Info($"Skipped record as BadData found  {context.RawRecord} in {fileName} ");
                        skippedRecordCount++;
                    },
                };

                using (var reader = new StreamReader(fileName))
                using (var csv = new CsvReader(reader, config))
                {
                    var records = csv.Context.Reader.GetRecords<HeaderInfo>().ToArray();
                    for(int i = 0; i< records.Count(); i++)
                    {
                        //Checks if there are any fields with blank values
                        if (records[i].GetType().GetProperties().Any(x => string.IsNullOrWhiteSpace((string)x.GetValue(records[i]))))
                        {
                            logger.Info($"Skipped record as blank field found at field {i} in file: {fileName}");
                            skippedRecordCount++;
                        }
                        //Add valid records to goodrecords list which can be returned
                        else
                            goodRecords.Add(records[i]);
                    }

                    return goodRecords;
                }
            }

            catch (Exception e)
            {
                logger.Error(e);
                return goodRecords;
            }
        }
    }
}
