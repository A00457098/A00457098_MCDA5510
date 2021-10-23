using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;

namespace MergeCsvFiles
{
    class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                DirectoryWalker directoryWalker = new DirectoryWalker();

                var files = directoryWalker.Walk(Path.GetFullPath("../../../../../Sample Data"));
                if (files.Count != 0)
                {
                    CSVParser parser = new CSVParser();

                    foreach (var file in files)
                    {
                        var record = parser.Parse(file);

                        //Task.Run(() => WriteToOutputFile(record));
                        WriteToOutputFile(record);
                    }
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
        }

        private static void WriteToOutputFile(List<HeaderInfo> records)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                PrepareHeaderForMatch = args => args.Header.Replace(" ", "")
            };
            

            using var writter = new StreamWriter(Path.GetFullPath("../../../../Output/Output.csv"), true);
            using var csvWriter = new CsvWriter(writter, config);
            {
                csvWriter.WriteRecords(records);
            }
        }

    }
}
