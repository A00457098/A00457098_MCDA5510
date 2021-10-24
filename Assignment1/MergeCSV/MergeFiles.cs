using System;
using System.IO;
using System.Diagnostics;
using log4net;

namespace MergeCsvFiles
{
    /// <summary>
    /// This class contains Main.
    /// It creates objects of respective classses and calls for read and write
    /// </summary>
    internal class MergeFiles
    {
        private static int validRecordsCount = 0;
        private static Stopwatch watch = new Stopwatch();
        private static readonly ILog logger = Logger.Instance.GetLogger();

        /// <summary>
        /// Main
        /// </summary>
        /// <param name="args"></param>
        internal static void Main(string[] args)
        {
            try
            {
                //Start the stopwatch to start watching execution time
                watch.Start();

                Console.WriteLine("Traversing directories..");
                DirectoryWalker directoryWalker = new DirectoryWalker();

                var files = directoryWalker.Walk(Path.GetFullPath("../../../../../Sample Data"));
                if (files.Count != 0)
                {
                    CSVParser parser = new CSVParser();
                    WriteOutput output = new WriteOutput();
                    Console.WriteLine("Writing to Output csv file..");
                    foreach (var file in files)
                    {
                        //Skip files which are not CSV
                        if (!(Path.GetExtension(file) == ".csv"))
                        {
                            continue;
                        }
                        var record = parser.Parse(file);

                        if (record.Count != 0)
                        {
                            validRecordsCount += record.Count;
                            output.WriteToOutputFile(record);
                        }
                    }
                    //Log the total skipped records.
                    logger.Info($"Skipped Records: {CSVParser.skippedRecordCount}");
                    //Log the total valid records.
                    logger.Info($"Valid Records: {validRecordsCount}");
                }
            }

            catch (FileNotFoundException)
            {
                logger.Error("The file or directory cannot be found.");
            }
            catch (DirectoryNotFoundException)
            {
                logger.Error("The file or directory cannot be found.");
            }
            catch (DriveNotFoundException)
            {
                logger.Error("The drive specified in 'path' is invalid.");
            }
            catch (PathTooLongException)
            {
                logger.Error("'path' exceeds the maxium supported path length.");
            }
            catch (UnauthorizedAccessException)
            {
                logger.Error("You do not have permission to create this file.");
            }
            catch (IOException e) when ((e.HResult & 0x0000FFFF) == 32)
            {
                logger.Error("There is a sharing violation.");
            }
            catch (IOException e) when ((e.HResult & 0x0000FFFF) == 80)
            {
                logger.Error("The file already exists.");
            }
            catch (IOException e)
            {
                logger.Error($"An exception occurred:\nError code: " +
                                  $"{e.HResult & 0x0000FFFF}\nMessage: {e.Message}");
            }
            catch (Exception e)
            {
                logger.Error(e);
            }
            finally
            {
                watch.Stop();
                Console.WriteLine("Writing completed. Please check Output and logs files for detailed execution report");
                logger.Info($"Total Time of Execution: {Math.Round(watch.Elapsed.TotalSeconds/60, 2)}"); 
            }
        }

    }
}
