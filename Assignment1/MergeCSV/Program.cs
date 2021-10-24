using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Diagnostics;

namespace MergeCsvFiles
{
    class Program
    {
        private static int validRecordsCount = 0;
        private static Stopwatch watch = new Stopwatch();

        public static void Main(string[] args)
        {
            try
            {
                watch.Start();
                
                DirectoryWalker directoryWalker = new DirectoryWalker();

                var files = directoryWalker.Walk(Path.GetFullPath("../../../../../Sample Data"));
                if (files.Count != 0)
                {
                    CSVParser parser = new CSVParser();

                    foreach (var file in files)
                    {
                        //Skip files which are not CSV
                        if (!(Path.GetExtension(file) == ".csv"))
                        {
                            continue;
                        }
                        var record = parser.Parse(file);

                        //Task.Run(() => WriteToOutputFile(record));
                        if (record.Count != 0)
                        {
                            validRecordsCount += record.Count;
                            WriteToOutputFile(record);
                        }
                    }
                    //Log the total skipped records.
                    Console.WriteLine($"Skipped Records: {CSVParser.skippedRecordCount}");
                    //Log the total valid records.
                    Console.WriteLine($"Skipped Records: {validRecordsCount}");
                }
            }

            catch (FileNotFoundException)
            {
                Console.WriteLine("The file or directory cannot be found.");
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("The file or directory cannot be found.");
            }
            catch (DriveNotFoundException)
            {
                Console.WriteLine("The drive specified in 'path' is invalid.");
            }
            catch (PathTooLongException)
            {
                Console.WriteLine("'path' exceeds the maxium supported path length.");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("You do not have permission to create this file.");
            }
            catch (IOException e) when ((e.HResult & 0x0000FFFF) == 32)
            {
                Console.WriteLine("There is a sharing violation.");
            }
            catch (IOException e) when ((e.HResult & 0x0000FFFF) == 80)
            {
                Console.WriteLine("The file already exists.");
            }
            catch (IOException e)
            {
                Console.WriteLine($"An exception occurred:\nError code: " +
                                  $"{e.HResult & 0x0000FFFF}\nMessage: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                watch.Stop();
                Console.WriteLine($"Time of Execution: {(watch.Elapsed.TotalSeconds)/60}");
                
            }
        }

        private static void WriteToOutputFile(List<HeaderInfo> records)
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
