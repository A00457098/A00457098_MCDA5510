Assignment #1
-------------------------------------------------------------------

This project recursively read a series of data files in CSV format and enter them into a single file (Output.csv in the Output folder)

The program logs the total execution time which includes time to read the files and write the files to a file (Logs.log in the logs folder)
It also logs the skipped records occurences in a particular file
Lastly,  it also logs total number of skipped records nad valid records in the end.
Extra date column is also added in the output.csv file taken from the input files directory structure.

The assignment uses nuget libraries 'CsvHelper' for CSV reading and writing, and 'log4net' for logging

The solution consists of one project 'MergeCsvFiles' (.net Core Console Application)

The main method resides in MergeFiles.cs which is a starting point of the program

Other main files are:
DirectoryWalker.cs- Recursively traverse through the directories and get the files
CsvParser.cs- Parses the Csv file and returns the valid records. 
WriteOutput.cs- writes the files to Output.csv file. It also adds extra date column to the file.

